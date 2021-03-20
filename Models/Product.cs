using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace veic_web.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int Param_id { get; set; }
        public int Lang_id { get; set; }

        public int Img_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
