﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class news_report
    {
        [Key]
        public int id { get; set; }
        public int det_cat_id { get; set; }
        public DateTime news_date { get; set; }
        public string news_title { get; set; }
        public string news_lead { get; set; }
        public string news_body { get; set; }
        public string news_image { get; set; }
        public int publisher_id { get; set; }
        public string editor_id { get; set; }
        public string viewer { get; set; }
        public int det_tag_id { get; set; }
        public int salary { get; set; }
    }
}