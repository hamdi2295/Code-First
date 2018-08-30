using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    /*
    Function tag digunakan untuk men generate nama table ketia terjadi migration dari code menuju database
    */
    public class tag
    {
        /*atribut yang akan mengisi field pada table tag */
        [Key]
        public int id { get; set; }
        public string tag_name { get; set; }
        public virtual List<det_tag> det_tag { get; set; }
    }
}
