using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRenting.Models;
using System.ComponentModel.DataAnnotations;

namespace CarRenting.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Genre")]
        [Required]
        public byte? GenreId { get; set; }
        [Display(Name="Release Date")]
        [Required]
        public DateTime? DateReleased { get; set; }
        [Display(Name="Number in garage")]
        [Required]
        public byte? Available { get; set; }
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Car" : "New Car";
                    
            }
        }
        public CarFormViewModel()
        {
            Id = 0;
        }
        public CarFormViewModel(Car car)
        {
            Id = car.Id;
            Name = car.Name;
            DateReleased = car.DateReleased;
            Available = car.Available;
            GenreId = car.GenreId;
        }
    }
}