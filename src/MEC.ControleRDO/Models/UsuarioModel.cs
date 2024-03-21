using MEC.ControleRDO.Enum;
using MEC.ControleRDO.Models.Base;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;

namespace MEC.ControleRDO.Models
{
    [Table("Usuario")]
    public class UsuarioModel : BaseModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha; 
        }
    }
}
