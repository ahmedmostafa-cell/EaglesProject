using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TransactionLogisticCompanyService
    {
        List<TransactionLogisticCompany> getAll();
        bool Add(TransactionLogisticCompany client);
        bool Edit(TransactionLogisticCompany client);
        bool Delete(TransactionLogisticCompany client);


    }
    public class ClsTransactionLogisticCompany : TransactionLogisticCompanyService
    {
        EaglesDatabaseContext ctx;
        public ClsTransactionLogisticCompany(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TransactionLogisticCompany> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TransactionLogisticCompany> lstTransactionLogisticCompany = ctx.TransactionLogisticCompanies.ToList();

            return lstTransactionLogisticCompany;
        }

        public bool Add(TransactionLogisticCompany item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TransactionLogisticCompanyId = Guid.NewGuid();
                item.CreatedDate = DateTime.Now;
                item.CurrentState = 1;
                ctx.TransactionLogisticCompanies.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TransactionLogisticCompany item)
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

        public bool Delete(TransactionLogisticCompany item)
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
