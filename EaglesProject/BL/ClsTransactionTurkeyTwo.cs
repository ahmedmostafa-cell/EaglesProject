using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TransactionTurkeyTwoService
    {
        List<TbTransactionTurkeyTwo> getAll();
        bool Add(TbTransactionTurkeyTwo client);
        bool Edit(TbTransactionTurkeyTwo client);
        bool Delete(TbTransactionTurkeyTwo client);


    }
    public class ClsTransactionTurkeyTwo : TransactionTurkeyTwoService
    {
        EaglesDatabaseContext ctx;
        public ClsTransactionTurkeyTwo(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbTransactionTurkeyTwo> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTransactionTurkeyTwo> lstTransactionTurkeyTwo = ctx.TbTransactionTurkeyTwos.ToList();

            return lstTransactionTurkeyTwo;
        }

        public bool Add(TbTransactionTurkeyTwo item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TransactionTurkeyTwoId = Guid.NewGuid();
                item.CreatedDate = DateTime.Now;
                item.CurrentState = 1;
                ctx.TbTransactionTurkeyTwos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTransactionTurkeyTwo item)
        {
            try
            {
                if (item.CurrentState != 0)
                {
                    item.CurrentState = 1;
                }
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
              
                item.UpdatedDate = DateTime.Now;
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbTransactionTurkeyTwo item)
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
