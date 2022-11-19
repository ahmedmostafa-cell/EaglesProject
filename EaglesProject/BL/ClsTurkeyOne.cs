using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TurkeyOneService
    {
        List<TbTurkeyOne> getAll();
        bool Add(TbTurkeyOne client);
        bool Edit(TbTurkeyOne client);
        bool Delete(TbTurkeyOne client);


    }
    public class ClsTurkeyOne : TurkeyOneService
    {
        EaglesDatabaseContext ctx;
        public ClsTurkeyOne(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbTurkeyOne> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTurkeyOne> lstTurkeyOne = ctx.TbTurkeyOnes.ToList();

            return lstTurkeyOne;
        }

        public bool Add(TbTurkeyOne item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TurkeyOneId = Guid.NewGuid();
                ctx.TbTurkeyOnes.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTurkeyOne item)
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

        public bool Delete(TbTurkeyOne item)
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
