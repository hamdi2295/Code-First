using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    /*
   Function det_cat digunakan untuk men generate nama table ketia terjadi migration dari code menuju database
   */
    public class det_cat
    {
        /*atribut yang akan mengisi field pada table det_cat */
        [Key]
        public int id { get; set; }
        public string det_name { get; set; }
        public int categoryid { get; set; }
        public virtual category categoryy { get; set; }
        public virtual List<news_report> news_report { get; set; }

    }
}
