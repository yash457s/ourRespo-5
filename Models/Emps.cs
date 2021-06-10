using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{[Table("Emps")]
    public class Emps
    {
        [Key]
        public int EId { get; set; }
        public string EName { get; set; }
        public string EDesignation { get; set; }
        public DateTime EDoj { get; set; }
    }
}