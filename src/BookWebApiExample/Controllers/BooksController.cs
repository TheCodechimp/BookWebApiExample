using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccessRepository;
using DataAccessRepository.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Models;

namespace BookWebApiExample.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private BookRepository bookRepository;
        public BooksController()
        {
            bookRepository = new BookRepository(new DataAccessContext());
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> Get()
        {
            var model = new BookViewModel();
            var books = await bookRepository.FindAll();
            model.Load(books.Select(r => new BookViewModel() {Id = r.Id, Edition = r.Edition, ISBN = r.ISBN, Title = r.Title}).ToList());
            return model.List();
        }
        
        [HttpGet("{id}")]
        public BookViewModel Get(int id)
        {
            var model = new BookViewModel();
            var r = bookRepository.Find(id);

            //It would be good to return an http status message here, but null should be okay for now.
            if (null == r)
                return null;
       
                model.Load(new List<BookViewModel>() { new BookViewModel() { Id = r.Id, Edition = r.Edition, ISBN = r.ISBN, Title = r.Title } });
            return model.List(id);
        }
        
        [HttpPost]
        public BookViewModel Post([FromBody]BookViewModel book)
        {   
            var model = new BookViewModel();                     
            bookRepository.Add(new BookDataModel() { Id = book.Id, Edition = book.Edition, ISBN = book.ISBN, Title = book.Title} );
            bookRepository.Save();
            var r = bookRepository.FindLast();
            model.Load(new List<BookViewModel>() { new BookViewModel() { Id = r.Id, Edition = r.Edition, ISBN = r.ISBN, Title = r.Title } });
            return model.List().FirstOrDefault();
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
