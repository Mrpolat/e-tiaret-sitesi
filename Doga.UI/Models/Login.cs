﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Doga.UI.Models
{
    public class Login
    {
        
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }
        
        [DisplayName("Beni Hatırla")]
        
        public bool RememberMe { get; set; }
        
    }
}