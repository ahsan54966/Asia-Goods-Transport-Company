using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; 
using System.Web;

namespace Fyp_First_Increment.ViewModel.Admin.builty
{
    public class BuiltyViewModel
    {
        public Builty builty;
        public IEnumerable<Users> Drivers { get; set; }

        
 
                public BuiltyViewModel(Models.Builty builty)
                {
                    // TODO: Complete member initialization
                    this.builty = builty;
                }
        
        public BuiltyViewModel()
                {

                    // TODO: Complete member initialization
                }
         

    }

    
}