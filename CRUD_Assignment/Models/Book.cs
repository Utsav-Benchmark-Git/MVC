//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Book
    {
        public int BookID { get; set; }

        [Required(ErrorMessage ="ISBN Can't be empty")]
        public Nullable<int> ISBN { get; set; }

        [Required(ErrorMessage = "Name Can't be empty")]
        public string BookName { get; set; }

        public Nullable<int> AuthorID { get; set; }

        [Required(ErrorMessage = "Publication Can't be empty")]
        public string Publication { get; set; }

        [Required(ErrorMessage = "Price Can't be empty")]
        public Nullable<decimal> Price { get; set; }

        public string Image { get; set; }
    
        public virtual Author Author { get; set; }
    }
}
