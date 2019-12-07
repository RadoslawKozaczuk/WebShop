using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Page
    {
        public int Id { get; set; } // this is going to be automatically recognized as the primary key
        [Required] // to make the column not nullable in the db
        //[Display(Name = "Fruit")] // it will be displayed in the view if we have a @Html.DsiplayNameFor method used
        [MinLength(2, ErrorMessage = "Minimum length is 2")] // custom error message
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Minimum length is 4")] // it is possible to add more than one attributes in one line
        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
