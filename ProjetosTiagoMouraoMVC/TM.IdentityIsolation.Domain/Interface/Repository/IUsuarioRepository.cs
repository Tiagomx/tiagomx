using System;
using System.Collections.Generic;
using TM.IdentityIsolation.Domain.Entities;

namespace TM.IdentityIsolation.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
