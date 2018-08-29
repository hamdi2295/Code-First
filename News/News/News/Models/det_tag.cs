using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class det_tag
    {
        [Key]
        public int id { get; set; }
        public string det_tag_name { get; set; }
        public int tagid { get; set; }

        public virtual tag tags { get; set; }

    }
}
