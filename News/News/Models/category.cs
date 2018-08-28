using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class category
    {
        [Key]
        public int id { get; set; }
        public int det_cat_id { get; set; }
        public string cat_name { get; set; }
    }
}
