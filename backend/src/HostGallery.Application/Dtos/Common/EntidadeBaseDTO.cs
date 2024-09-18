﻿namespace HostGallery.Application.Dtos.Common;

public class EntidadeBaseDTO
{
    public int Id { get; set; }
    public DateTimeOffset? DataCriacao { get; set; }
    public DateTimeOffset? DataAtualizacao { get; set; }
    public string? IpCriacao { get; set; }
    public string? IpAtualizacao { get; set; }
}
