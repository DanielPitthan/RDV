using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContexBinds.EntityCore
{
    public class ContextBind : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<UserClaims> UserClaims { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaRegra> EmpresaRegra { get; set; }
        public ContextBind(DbContextOptions<ContextBind> options) : base(options)
        { 
           
        }
    }
}
