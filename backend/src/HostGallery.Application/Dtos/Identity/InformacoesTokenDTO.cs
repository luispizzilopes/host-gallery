﻿namespace HostGallery.Application.Identity.Dtos;

public class InformacoesTokenDTO
{
    public string Token { get; set; } = null!; 
    public DateTime DataExpiracao { get; set; }
}
