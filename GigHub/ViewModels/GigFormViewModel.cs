﻿using GigHub.Models;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        
        public string Date { get; set; }

        [Required]
        
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public DateTime GetDateTime ()
        { 
          
             return DateTime.Parse(String.Format("{0} {1}", Date, Time));
            
        }


    }
}
