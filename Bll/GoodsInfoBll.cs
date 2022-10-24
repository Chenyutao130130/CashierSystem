﻿using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Bll
{
   public  class GoodsInfoBll:BaseBll<GoodsInfo>
    {
        GoodsInfoDal dal = new GoodsInfoDal();
        public  GoodsInfoBll()
        {
            this.CurrentDal = new GoodsInfoDal();
        }

        public DataTable GetDataTablebyPammer( SearchModel searchModel )
        {
            //根据搜索条件返回DataTable
            return dal.GetDataTablebyPammer(searchModel);
        }
        /// <summary>
        /// 获取符合条件的行数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public int  GetDataTableCountByPammer(SearchModel searchModel)
        {
            searchModel.StartIndex = 0;
            searchModel.PageCount = int.MaxValue;
            return dal.GetDataTablebyPammer(searchModel).Rows.Count;
        }


        public bool EditGoodsInfoCount(int  id, double  salescount, double  surplusCount)
        {
            return dal.EditGoodsInfoCount(id, salescount, surplusCount);
        }

    }
}
