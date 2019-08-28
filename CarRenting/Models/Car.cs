using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRenting.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
        [Display(Name="Genre")]
        [Required]
        public byte GenreId { get; set; }
        [Display(Name="Date released")]
        public DateTime DateReleased { get; set; }
        [Display(Name="Available cars")]
        [Range(1,20)]
        public byte Available { get; set; }
        public byte NumberAvailable { get; set; }


    }
}