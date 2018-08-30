using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    /*Function detail_tag akan di generate menjadi table database saat terjadi proses migration */
    public class det_tag
    {
        /* attribut yang akan ter generate saat pembuatan table det_tag */
        [Key]
        public int id { get; set; }
        public string det_tag_name { get; set; }
        public int tagid { get; set; }

        public virtual tag tags { get; set; }
        public virtual List<news_report> news_report { get; set; }

    }
}
