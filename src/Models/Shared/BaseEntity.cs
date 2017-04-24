using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Shared
{
    public class BaseEntity
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
}
