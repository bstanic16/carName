using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRenting.Models;

namespace CarRenting.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}