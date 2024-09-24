﻿using HostGallery.Domain.Exceptions;

namespace HostGallery.Infrastructure.Identity.Exceptions
{
    public class EmailNaoConfirmadoException : BaseException
    {
        public EmailNaoConfirmadoException() : base("Confirme seu e-mail para realizar o login.") { } 
    }
}
