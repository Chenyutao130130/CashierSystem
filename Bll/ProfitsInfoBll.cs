﻿using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class ProfitsInfoBll:BaseBll<ProfitsInfo>
    {
        ProfitsInfoDal dal = new ProfitsInfoDal();

       public   ProfitsInfoBll()
        {
            this.CurrentDal = new  ProfitsInfoDal();
        }
       

        public DataTable GetDataTablebyPammer( SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            return dal.GetDataTablebyPammer(searchModel);
        }
        public int GetDataTableCountByPammer(SearchModel searchModel)
        {
            searchModel.ModelName = "ProfitsInfo";
            searchModel.PageCount = int.MaxValue;
            var table = dal.GetDataTablebyPammer(searchModel);
            if (table==null||table.Rows.Count==0)
            {
                return 0;
            }
            return table.Rows.Count;


        }

        public List<ProfitsInfo> GetListByDataTable(DataTable dataTable)
        {
            return dal.GetListByDataTable(dataTable);
        }

        public ProfitsInfo GetProfitsInfoByOrderId(string  orderId)
        {
            return new ProfitsInfoDal().GetProfitsInfoByOrderId(orderId);
        }

    }
}
