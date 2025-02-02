﻿using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModel.Accounts
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string? Password { get; set; }
    }
}
