﻿using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class EnderecoViewModel
{
    public int Id { get; set; }

    public int AlunoId { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 50 caracteres.")]
    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    [Display(Name = "Endereço")]
    public string NomeEndereco
    {
        get
        {
            string endereco = string.Empty + Logradouro;
            if (Numero >= 0)
            {
                endereco += $", N°{Numero}";
            }
            return endereco;
        }
    }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 50 caracteres.")]
    public string? Complemento { get; set; }

    [StringLength(50, ErrorMessage = "Não pode ter mais do que 10 caracteres.")]
    public string? CEP { get; set; }
}
