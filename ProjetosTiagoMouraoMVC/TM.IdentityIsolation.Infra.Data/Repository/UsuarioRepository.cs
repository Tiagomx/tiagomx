﻿using System;
using System.Collections.Generic;
using System.Linq;
using TM.IdentityIsolation.Domain.Entities;
using TM.IdentityIsolation.Domain.Interface.Repository;
using TM.IdentityIsolation.Infra.Data.Context;

namespace TM.IdentityIsolation.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IdentityIsolationContext _db;

        public UsuarioRepository()
        {
            _db = new IdentityIsolationContext();
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.ToList();
        }
        public void DesativarLock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
