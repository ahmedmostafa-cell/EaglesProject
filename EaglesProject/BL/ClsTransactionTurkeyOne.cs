﻿using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TransactionTurkeyOneService
    {
        List<TbTransactionTurkeyOne> getAll();
        bool Add(TbTransactionTurkeyOne client);
        bool Edit(TbTransactionTurkeyOne client);
        bool Delete(TbTransactionTurkeyOne client);


    }
    public class ClsTransactionTurkeyOne : TransactionTurkeyOneService
    {
        EaglesDatabaseContext ctx;
        public ClsTransactionTurkeyOne(EaglesDatabaseContext context)
        {
            ctx = context;
        }

        public List<TbTransactionTurkeyOne> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTransactionTurkeyOne> lstTransactionTurkeyOne = ctx.TbTransactionTurkeyOnes.ToList();

            return lstTransactionTurkeyOne;
        }

        public bool Add(TbTransactionTurkeyOne item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.TransactionTurkeyOneId = Guid.NewGuid();
                ctx.TbTransactionTurkeyOnes.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTransactionTurkeyOne item)
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

        public bool Delete(TbTransactionTurkeyOne item)
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