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
        public int det_tag_id { get; set; }
        public string tag_name { get; set; }
    }
}
