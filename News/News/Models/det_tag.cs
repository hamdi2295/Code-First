﻿using System;
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
        public int news_report_id { get; set; }
    }
}
