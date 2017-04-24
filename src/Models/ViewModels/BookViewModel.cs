using System.Collections.Generic;
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

        public void Stuff(List<BookViewModel> books)
        {
            Books = books;
        }
    }
}
