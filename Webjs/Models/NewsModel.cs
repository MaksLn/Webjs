using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Webjs.Models
{
    public class NewsModel
    {
        [Required]
        public int id { get; set; }

        [Key]
        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public string Header { get; set; }
       
        public string Text { get; set; }

        [Required]
        public DateTime TimeOf { get; set; }

       
    }
}
