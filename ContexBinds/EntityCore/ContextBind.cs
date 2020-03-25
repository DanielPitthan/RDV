using Microsoft.EntityFrameworkCore;
using Models.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContexBinds.EntityCore
{
    public class ContextBind : DbContext
    {
        DbSet<Login> Login { get; set; }

        public ContextBind(DbContextOptions<ContextBind> options) : base(options) { }
    }
}
