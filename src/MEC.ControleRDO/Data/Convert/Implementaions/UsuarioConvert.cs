using MEC.ControleRDO.Data.Convert.Contract;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Models;
using Microsoft.Win32.SafeHandles;

namespace MEC.ControleRDO.Data.Convert.Implementaions
{
    public class UsuarioConvert : IParser<UsuarioVO, UsuarioModel>, IParser<UsuarioModel, UsuarioVO>
    {
        public UsuarioModel Parser(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new UsuarioModel
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Login = origin.Login,
                Email = origin.Email,
                Perfil = origin.Perfil,
                Senha = origin.Senha
            };
        }

        public UsuarioVO Parser(UsuarioModel origin)
        {
            if (origin == null) return null;
            return new UsuarioVO
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Login = origin.Login,
                Email = origin.Email,
                Perfil = origin.Perfil,
                Senha = origin.Senha
            };
        }

        public List<UsuarioModel> Parser(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }

        public List<UsuarioVO> Parser(List<UsuarioModel> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parser(item)).ToList();
        }
    }
}
