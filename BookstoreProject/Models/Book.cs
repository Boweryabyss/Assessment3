using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookstoreProject.Models
{
    /// <summary>
    /// The Book model
    /// Contains get and set methods for each member variable
    /// </summary>
    
    public class Book
    {
        public int ID { get; set; }
        [StringLength(154)]
        [Required]
        public string Title { get; set; }
        [StringLength(154)]
        [Required]
        public string Genre { get; set; }
        [StringLength(154)]
        [Required]
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }
    }

    /// <summary>
    /// The BookDBContext class
    /// Inherits from DbContext and contains a DbSet with a generic type of Book
    /// </summary>
    public class BookDBContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
    }
}