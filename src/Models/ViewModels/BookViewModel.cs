using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Models
{
    public class BookViewModel : BookDataModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }

        public BookViewModel()
        {
            Books = new List<BookViewModel>();
        }

        public BookViewModel List(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<BookViewModel> List()
        {
            return Books;
        }

        public void Load(List<BookViewModel> books)
        {
            Books = books;
        }
    }
}
