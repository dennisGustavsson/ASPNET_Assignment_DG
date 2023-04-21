﻿using System.ComponentModel.DataAnnotations;

namespace EcomWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must enter an email.")]
        public string Email { get; set; } = null!;


        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You must enter a password.")]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;
    }
}
