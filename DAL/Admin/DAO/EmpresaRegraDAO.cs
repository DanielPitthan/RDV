using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContexBinds.EntityCore;
using ContextBinds;
using DAL.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Admin;

namespace DAL.Admin.DAO
{
    public class EmpresaRegraDAO : IEmpresaRegraDAO
    {
        private ContextBind _contexto;

        public EmpresaRegraDAO(ContextBind contexto)
        {
            this._contexto = contexto;
        }

        public async Task<bool> Delete(EmpresaRegra regra)
        {
            try
            {
                this._contexto.EmpresaRegra.Remove(regra);
                var result = await this._contexto.SaveChangesAsync();
                return result>0;

            }
            catch (DbUpdateException e)
            {
                return false;
            }

        }

        /// <summary>
        /// Obtem as regras da empresa do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IList<EmpresaRegra>> GetByUsuarioIdAsync(int id)
        {
            int empresaId = (from u in this._contexto.Usuario
                             where u.Id == id
                             select u.Empresa.Id)
                            .FirstOrDefault();


            IList<EmpresaRegra> empresaRegras = await this._contexto
                                .EmpresaRegra
                                .Where(e => e.EmpresaId == empresaId)
                                .ToListAsync();
            return empresaRegras;
        }

        /// <summary>
        /// Obtem as regras da empresa do usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IList<EmpresaRegra>> GetByEmpresaIdAsync(int id)
        {
            int empresaId = (from u in this._contexto.Empresa
                             where u.Id == id
                             select u.Id).FirstOrDefault();


            IList<EmpresaRegra> empresaRegras = await this._contexto
                                .EmpresaRegra
                                .Where(e => e.EmpresaId == empresaId)
                                .ToListAsync();
            return empresaRegras;

        }

        public async Task<bool> Save(EmpresaRegra regra)
        {
            try
            {
                this._contexto.EmpresaRegra.Add(regra);
                await this._contexto.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }


        }

        public async Task<bool> Update(EmpresaRegra regra)
        {
            try
            {
                _contexto.Entry(regra).State = EntityState.Modified;
                _contexto.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }

        }
    }
}
