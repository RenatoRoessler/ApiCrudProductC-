using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Model;

public class Login
{
    [Required]
    public string Usuario { get; set; }

    [Required]
    public string Senha { get; set; }
}