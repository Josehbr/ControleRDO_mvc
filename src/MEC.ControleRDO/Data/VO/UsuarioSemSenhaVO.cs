﻿using MEC.ControleRDO.Enum;
using System.ComponentModel.DataAnnotations;

namespace MEC.ControleRDO.Data.VO
{
    public class UsuarioSemSenhaVO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email fornecido não é válido")]
        public string Email { get; set; }

        [PerfilEnumValidation(ErrorMessage = "O perfil selecionado não é válido.")]
        public PerfilEnum Perfil { get; set; }
    }
}
