using ContexBinds.EntityCore;
using DAL.Cadastros.CentroCustos.Interfaces;
using DAL.DAOBase;
using Microsoft.EntityFrameworkCore;
using Models.Cadastros;

namespace DAL.Cadastros.CentroCustos.DAO
{
    public class CentroCustoDAO : DataAccess, ICentroCustoDAO
    {
        private readonly ContextBind contexto;

        public CentroCustoDAO(ContextBind _context) : base(_context)
        {
            this.contexto = _context;
        }

        public DbSet<CentroCusto> GetAll()
        {
            return this.contexto.CentroCusto;
        }
    }
}
