﻿using System.ComponentModel.DataAnnotations;

namespace HostGallery.Application.Identity.Dtos
{
    public class LoginDTO
    {
        //[EmailAddress]
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;
    }
}
