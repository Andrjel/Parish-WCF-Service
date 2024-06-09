using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Parish.Domain
{
    [Table("Parish")]
    public class ParishModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
}
