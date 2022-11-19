using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TurkeyTwoService
    {
        List<TbTurkeyTwo> getAll();
        bool Add(TbTurkeyTwo client);
        bool Edit(TbTurkeyTwo client);
        bool Delete(TbTurkeyTwo client);


    }
    public class ClsTurkeyTwo : TurkeyTwoService
    {
        EaglesDatabaseContext ctx;
        public ClsTurkeyTwo(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbTurkeyTwo> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTurkeyTwo> lstTurkeyTwo = ctx.TbTurkeyTwos.ToList();

            return lstTurkeyTwo;
        }

        public bool Add(TbTurkeyTwo item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TurkeyTwoId = Guid.NewGuid();
                ctx.TbTurkeyTwos.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTurkeyTwo item)
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

        public bool Delete(TbTurkeyTwo item)
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
