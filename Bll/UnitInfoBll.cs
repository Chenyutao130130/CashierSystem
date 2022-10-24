using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    //商品单位表
   public  class UnitInfoBll:BaseBll<UnitInfo>
    {
        public  UnitInfoBll()
        {
            this.CurrentDal = new UnitInfoDal();   //CurrentDal绑定到UnitInfoDal
        }
    }
}
