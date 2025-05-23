﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Doga.UI.Models
{
    public class ShippingDetails
    {
        

        public string Username { get; set; }
        [Required(ErrorMessage ="Lütfen adres tanımını giriniz")]
        
        public string AdressBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen bir adres giriniz")]
        public string Adres1 { get; set; }
        [Required(ErrorMessage = "Lütfen şehir giriniz")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen semt giriniz")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle giriniz")]
        public string Mahalle { get; set; }
        
        public string PostaKodu { get; set; }

    }
}