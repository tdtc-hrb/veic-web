using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class Parameter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Lang_id { get; set; }
        public int Mtbf { get; set; }
        public double Voltage { get; set; }
        public double Electricity { get; set; }
        public string Ipxx { get; set; }
        public string Temperature { get; set; }
    }
}
