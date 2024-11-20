namespace HostGallery.Application.Dtos.Common;

public class EntidadeBaseDTO
{
    public int Id { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public string? IpCriacao { get; set; }
    public string? IpAtualizacao { get; set; }
}
