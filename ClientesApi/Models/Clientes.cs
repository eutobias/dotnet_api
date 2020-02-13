using System;
using System.ComponentModel.DataAnnotations;
using ClientesApi.Validation;

namespace ClientesApi.Models
{
  public class Clientes
  {
    public int Id { get; set; }

    [Required]
    [MaxLengthAttribute(30)]
    public string Nome { get; set; }

    
    [Required]
    [ValidCpf]
    public string Cpf { get; set; }

    
    [Required]
    public string Idade { get; set; }

  }
}