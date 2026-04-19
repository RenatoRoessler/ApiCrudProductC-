using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Model;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(1000, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
    public string Nome { get; set; }

    [Range(0.1, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
    public int Estoque { get; set; }
}