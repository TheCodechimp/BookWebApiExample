using System.ComponentModel.DataAnnotations;
using Models.Shared;

namespace Models
{
    public class BookDataModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }        
    }
}
