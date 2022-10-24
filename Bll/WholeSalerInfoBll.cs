using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll
{
    public class WholeSalerInfoBll : BaseBll<WholeSalerInfo>
    {

        //构造函数
        public WholeSalerInfoBll()
        {
            this.CurrentDal = new WholeSalerInfoDal();
        }
    }
}
