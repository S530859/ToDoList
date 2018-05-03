using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testing.Models
{
    public class PersonModel
    {
        [Required]
        public String Title { get; set; }
        [Required]
        public int id { get; set; }
        [Required]
        public String Description { get; set; }
    }
}