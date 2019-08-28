﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRenting.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Car Car { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}