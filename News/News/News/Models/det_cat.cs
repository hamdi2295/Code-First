using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class det_cat
    {
        [Key]
        public int id { get; set; }
        public string det_name { get; set; }
        public int categoryid { get; set; }
        public virtual category categoryy { get; set; }

    }
}
