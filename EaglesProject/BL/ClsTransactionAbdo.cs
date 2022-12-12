using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TransactionAbdoService
    {
        List<TbTransactionAbdo> getAll();
        bool Add(TbTransactionAbdo client);
        bool Edit(TbTransactionAbdo client);
        bool Delete(TbTransactionAbdo client);


    }
    public class ClsTransactionAbdo : TransactionAbdoService
    {
        EaglesDatabaseContext ctx;
        public ClsTransactionAbdo(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbTransactionAbdo> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTransactionAbdo> lstTransactionAbdos = ctx.TbTransactionAbdos.ToList();

            return lstTransactionAbdos;
        }

        public bool Add(TbTransactionAbdo item)
        {
            try
            {
              
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TransactionAbdoId = Guid.NewGuid();
                item.CreatedDate = DateTime.Now;
                item.CurrentState = 1;
                ctx.TbTransactionAbdos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTransactionAbdo item)
        {
            try
            {
                if (item.CurrentState != 0)
                {
                    item.CurrentState = 1;
                }
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbTransactionAbdo item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
