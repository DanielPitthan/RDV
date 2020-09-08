using ContexBinds.EntityCore;
using DAL.DAOBase;
using DAL.Despesas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Despesas;

namespace DAL.Despesas.DAO
{
    public class DespesaHeaderDAO : DataAccess, IDespesaHeaderDAO
    {
        private readonly ContextBind contexto;

        public DespesaHeaderDAO(ContextBind _context) : base(_context)
        {
            this.contexto = _context;
        }

        public DbSet<DespesaHeader> GetAll()
        {
            return this.contexto.DespesaHeader;
        }
    }
}
