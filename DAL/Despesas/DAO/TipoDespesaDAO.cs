using ContexBinds.EntityCore;
using DAL.DAOBase;
using DAL.Despesas.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Despesas;

namespace DAL.Despesas.DAO
{
    public class TipoDespesaDAO : DataAccess, ITipoDespesaDAO
    {
        private ContextBind contexto;

        public TipoDespesaDAO(ContextBind _context) : base(_context)
        {
            this.contexto = _context;
        }

        public DbSet<TipoDespesa> GetAll()
        {
            return this.contexto.TipoDespesa;
        }


    }
}
