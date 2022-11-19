using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface LogisticCompanyService
    {
        List<TbLogisticCompany> getAll();
        bool Add(TbLogisticCompany client);
        bool Edit(TbLogisticCompany client);
        bool Delete(TbLogisticCompany client);


    }

    public class ClsLogisticCompany : LogisticCompanyService
    {
        EaglesDatabaseContext ctx;
        public ClsLogisticCompany(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbLogisticCompany> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLogisticCompany> lstLogisticCompanies = ctx.TbLogisticCompanies.ToList();

            return lstLogisticCompanies;
        }

        public bool Add(TbLogisticCompany item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LogisticCompanyId = Guid.NewGuid();
                ctx.TbLogisticCompanies.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLogisticCompany item)
        {
            try
            {
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

        public bool Delete(TbLogisticCompany item)
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
