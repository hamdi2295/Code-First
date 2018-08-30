using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    /*
    Function news_user digunakan untuk men generate nama table ketia terjadi migration dari code menuju database
    */
    public class news_user
    {
        /*atribut yang akan mengisi field pada table news_user */
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public int pocket { get; set; }
        public string role { get; set; }
        public virtual List<news_report> news_report { get; set; }
        
    }
}
