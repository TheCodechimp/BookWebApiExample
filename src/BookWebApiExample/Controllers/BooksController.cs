using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessRepository;
using DataAccessRepository.DataModels;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<BookViewModel> Get()
        {
            var model = new BookViewModel();            
            model.Stuff(bookRepository.FindAll().Select(r => r as BookViewModel).ToList());
            return model.List();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BookViewModel Get(int id)
        {
            var model = new BookViewModel();
            var r = bookRepository.Find(id);
            model.Stuff(new List<BookViewModel>() { r as BookViewModel });
            //model.Stuff(new List<BookViewModel>() { new BookViewModel() { Id = r.Id, Edition = r.Edition, ISBN = r.ISBN, Title = r.Title }});
            return model.List(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BookViewModel book)
        {            
            bookRepository.Add(book);
            bookRepository.Save();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
