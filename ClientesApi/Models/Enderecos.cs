using System;
using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Models
{
  public class Enderecos
  {
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Longradouro { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Bairro { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Cidade { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Estado { get; set; }

  }
}