﻿using HostGallery.Domain.Common;

namespace HostGallery.Domain.Entities;

public class Evento : EntidadeBase
{
    public string Nome { get; set; } = null!; 
    public Guid CodigoConvite { get; set; }
    public DateTimeOffset? DataInicio { get; set; }
    public DateTimeOffset? DataFim { get; set; }

    //Propriedades de relacionamento e navegação
    public string UsuarioId { get; set; } = null!;
    public ICollection<Categoria>? Categorias { get; set; }
    public ICollection<string>? Usuarios { get; set; }
}