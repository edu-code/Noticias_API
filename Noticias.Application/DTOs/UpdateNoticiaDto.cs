﻿using System.ComponentModel.DataAnnotations;

namespace Noticias.Application.DTOs;

public class UpdateNoticiaDto
{
    [Required(ErrorMessage = "O id não pode ser vazio")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O titulo não pode ser vazio")]
    [MaxLength(80, ErrorMessage = "O titulo deve ter no máximo 80 caracteres")]
    [MinLength(3, ErrorMessage = "o titulo deve ter no mínimo 3 caracteres")]
    public string Titulo { get; set; } = null!;
    
    [Required(ErrorMessage = "O texto não pode ser vazio")]
    [MaxLength(3000, ErrorMessage = "O texto deve ter no máximo 3000 caracteres")]
    [MinLength(3, ErrorMessage = "o titulo deve ter no mínimo 3 caracteres")]
    public string Texto { get; set; } = null!;
}