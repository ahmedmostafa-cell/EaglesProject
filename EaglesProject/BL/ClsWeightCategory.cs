using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface WeightCategoryService
    {
        List<TbWeightCategory> getAll();
        bool Add(TbWeightCategory client);
        bool Edit(TbWeightCategory client);
        bool Delete(TbWeightCategory client);


    }
    public class ClsWeightCategory : WeightCategoryService
    {
        EaglesDatabaseContext ctx;
        public ClsWeightCategory(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbWeightCategory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbWeightCategory> lstWeightCategory = ctx.TbWeightCategories.ToList();

            return lstWeightCategory;
        }

        public bool Add(TbWeightCategory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.WeightCategoryId = Guid.NewGuid();
                ctx.TbWeightCategories.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbWeightCategory item)
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

        public bool Delete(TbWeightCategory item)
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
