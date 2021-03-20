using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class Navigation
    {
        [Key]
        public int Id { get; set; }
        public int Lang_id { get; set; }
        public string Name { get; set; }
        public int Order1 { get; set; }
        public int Parent_id { get; set; }
        public string LinkAddr { get; set; }
    }
}
