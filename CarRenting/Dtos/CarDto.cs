using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRenting.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string  Name { get; set; }
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateReleased { get; set; }
        [Range(1,20)]
        public byte Available { get; set; }
    }
}