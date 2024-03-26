using MEC.ControleRDO.Data.Convert.Implementaions;
using MEC.ControleRDO.Data.VO;
using MEC.ControleRDO.Enum;
using MEC.ControleRDO.Models;
using MEC.ControleRDO.Repository.Generic;

namespace MEC.ControleRDO.Business.Implementations
{

    public class UsuarioImplementation : IUsuarioBusiness
        {
            private readonly IRepository<UsuarioModel> _repository;
            private readonly UsuarioConvert _convert;

            public UsuarioImplementation(IRepository<UsuarioModel> repository)
            {
                _repository = repository;
                _convert = new UsuarioConvert();
            }

        public UsuarioVO GetByLogin(string login)
        {
            var usuarioModel = _repository.FindAll().SingleOrDefault(p => p.Login.ToUpper() == login.ToUpper());
            return usuarioModel != null ? ConvertToVO(usuarioModel) : null;
        }

        

        public UsuarioVO Create(UsuarioVO usuario)
            {
                usuario.SetSenhaHash();
                var usuariolEntity = _convert.Parser(usuario);
                usuariolEntity = _repository.Create(usuariolEntity);
                return _convert.Parser(usuariolEntity);
            }

            public void Delete(long Id)
            {
                _repository.Delete(Id);
            }

            public List<UsuarioVO> FindAll()
            {
                return _convert.Parser(_repository.FindAll());
            }

            public UsuarioVO FindById(long Id)
            {
                return _convert.Parser(_repository.FindById(Id));
            }

            public UsuarioVO Update(UsuarioVO usuario)
            {
                var usuariolEntity = _convert.Parser(usuario);
                usuariolEntity = _repository.Update(usuariolEntity);
                return _convert.Parser(usuariolEntity);
            }

        private UsuarioVO ConvertToVO(UsuarioModel usuarioModel)
        {
            return new UsuarioVO
            {
                Id = usuarioModel.Id,
                Nome = usuarioModel.Nome,
                Login = usuarioModel.Login,
                Email = usuarioModel.Email,
                Perfil = usuarioModel.Perfil,
                Senha = usuarioModel.Senha

            };
        }
    }
}

