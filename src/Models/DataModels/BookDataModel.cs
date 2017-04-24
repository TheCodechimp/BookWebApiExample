using System.ComponentModel.DataAnnotations;
using Models.Shared;

namespace Models
{
    public class BookDataModel : BaseEntity
    {
        [Key]
        [Required]
        //This should actually be scripted with an identity seed. Normally I would just do that, but in this case it slipped my mind.
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Edition { get; set; }        
    }
}
