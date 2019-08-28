using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRenting.Models;

namespace CarRenting.ViewModels
{
    public class RandomCarViewModel
    {
        public Car Car { get; set; }
        public List<Customer> Customers { get; set; }
    }
}