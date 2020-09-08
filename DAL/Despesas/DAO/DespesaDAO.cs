using ContexBinds.EntityCore;
using DAL.DAOBase;
using DAL.Despesas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Despesas;

namespace DAL.Despesas.DAO
{
    public class DespesaDAO : DataAccess, IDespesaDAO
    {
        private readonly ContextBind contexto;

        public DespesaDAO(ContextBind _context) : base(_context)
        {
            this.contexto = _context;
        }

        public DbSet<Despesa> GetAll()
        {
            return this.contexto.Despesa;
        }
    }
}
