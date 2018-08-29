using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class tag
    {
        [Key]
        public int id { get; set; }
        public string tag_name { get; set; }
        public virtual List<det_tag> det_tag { get; set; }
        public virtual List<news_report> news_report { get; set; }
    }
}
