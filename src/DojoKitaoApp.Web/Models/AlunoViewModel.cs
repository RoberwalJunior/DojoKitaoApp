﻿using System.ComponentModel.DataAnnotations;

namespace DojoKitaoApp.Web.Models;

public class AlunoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do Aluno é obrigatório")]
    [StringLength(100, ErrorMessage = "Não pode ter mais do que 100 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Sobrenome do Aluno é obrigatório")]
    [StringLength(150, ErrorMessage = "Não pode ter mais do que 150 caracteres.")]
    public string? Sobrenome { get; set; }

    [Display(Name = "Nome Completo")]
    public string NomeCompleto => $"{Nome} {Sobrenome}";

    [Required(ErrorMessage = "{0} é obrigatório")]
    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }

    [Required]
    public int EnderecoId { get; set; }
    public EnderecoViewModel? Endereco { get; set; }
}
