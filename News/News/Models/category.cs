using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    /*
    Function category digunakan untuk men generate nama table ketia terjadi migration dari code menuju database
    */
    public class category
    {
        /*atribut yang akan mengisi field pada table category */
        [Key]
        public int id { get; set; }
        public string cat_name { get; set; }
        public virtual List<det_cat> det_cat { get; set; }    }
}
