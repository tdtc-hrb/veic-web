using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        public int Lang_id { get; set; }
        public int Img_id { get; set; }
        public int Flag { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
