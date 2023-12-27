using Microsoft.AspNetCore.Hosting;
using project.business.Exceptions;
using project.business.Exceptions.BookException;
using project.business.Extentions;
using project.business.Services.Interfaces;
using project.core.Models;
using project.core.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IBookTagsRepository _bookTagsRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IBookImagesRepository _bookImagesRepository;

        public BookService(IBookRepository bookRepository
                          ,IGenreRepository genreRepository
                           ,IAuthorRepository authorRepository
                            ,ITagRepository tagRepository
                            ,IBookTagsRepository bookTagsRepository
                             ,IWebHostEnvironment env
                             ,IBookImagesRepository bookImagesRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _tagRepository = tagRepository;
            _bookTagsRepository = bookTagsRepository;
            _env = env;
            _bookImagesRepository = bookImagesRepository;
        }
        public async Task CreateAsync(Book book)
        {
            if(!_genreRepository.Table.Any(x=> x.Id == book.GenreId))
            {
                throw new NotFoundException("GenreId", "Genre not found!");
            }
            if(!_authorRepository.Table.Any(x => x.Id == book.AuthorId))
            {
                throw new NotFoundException("AuthorId", "Author not found!");
            }

            bool check = false;
            if(book.TagIds!=null)
            {
                foreach(var tagId in book.TagIds)
                {
                    if (!_tagRepository.Table.Any(x => x.Id == tagId)){
                        check = true;
                        break;
                    }
                }
               
            }
            if(check)
            {
                throw new NotFoundException("TagId", "tag not found");
            }
            else
            {
                if (book.TagIds != null)
                {
                    foreach(var tagId in book.TagIds)
                    {
                        BookTag bookTag = new BookTag()
                        {
                            Book = book,
                            TagId = tagId,
                        };
                        await _bookTagsRepository.CreateAsync(bookTag);
                    }
                }
            }
            if(book.BookPosterImageFile!=null)
            {
                if(book.BookPosterImageFile.ContentType!="image/jpeg" && book.BookPosterImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentTypeExceptions("BookPosterImageFile", "file must be .jpeg or .png");
                }
                if (book.BookPosterImageFile.Length > 2097152)
                {
                    throw new InvalidImageSizeException("BookPosterImageFile", "File size must be lower than 2mb!");
                }
                BookImage bookImage = new BookImage()
                {
                    Book = book,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/Books", book.BookPosterImageFile),
                    IsPoster=true
                    
                };
                await _bookImagesRepository.CreateAsync(bookImage);
            }
            if (book.BookHoverImageFile != null)
            {
                if (book.BookHoverImageFile.ContentType != "image/jpeg" && book.BookHoverImageFile.ContentType != "image/png")
                {
                    throw new InvalidContentTypeExceptions("BookHoverImageFile", "file must be .jpeg or .png");
                }
                if (book.BookHoverImageFile.Length > 2097152)
                {
                    throw new InvalidImageSizeException("BookHoverImageFile", "File size must be lower than 2mb!");
                }
                BookImage bookImage = new BookImage()
                {
                    Book = book,
                    ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/Books", book.BookHoverImageFile),
                    IsPoster = false

                };
                await _bookImagesRepository.CreateAsync(bookImage);

            }
            if(book.ImageFiles != null)
            {
                foreach (var imagefile in book.ImageFiles)
                {
                    if (imagefile.ContentType != "image/jpeg" && imagefile.ContentType != "image/png")
                    {
                        throw new InvalidContentTypeExceptions("ImageFiles", "file must be .jpeg or .png");
                    }
                    if (imagefile.Length > 2097152)
                    {
                        throw new InvalidImageSizeException("imagefile", "File size must be lower than 2mb!");
                    }
                    BookImage bookImage = new BookImage()
                    {
                        Book = book,
                        ImageUrl = Helper.SaveFile(_env.WebRootPath, "uploads/Books", book.BookHoverImageFile),
                        IsPoster = false

                    };
                    await _bookImagesRepository.CreateAsync(bookImage);


                }
            }
            await _bookRepository.CreateAsync(book);
            await _bookRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            _bookRepository.Delete(entity);
            await _bookRepository.CommitAsync();
        }

        public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? expression = null)
        {
            return await _bookRepository.GetAllAsync(expression,"BookImages","Author","Genre");
        }

        public Task<Book> GetByIdAsync(int id)
        {
            var entity=_bookRepository.GetByIdAsync(x=>x.Id==id && x.IsDeleted==false);
            if(entity == null)
            {
                throw new NullReferenceException();
            }
            return entity;
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
