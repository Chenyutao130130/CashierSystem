using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 销售表
    /// </summary>
   public  class ProfitsInfo:BaseModel
    { 

        /// <summary>
        /// 订单编号OrderId
        /// </summary>
        public string  OrderId { get; set; }
      
        /// <summary>
        /// 总利润Profit
        /// </summary>
        public  decimal Profit{ get; set; }
        /// <summary>
        /// 总折扣DisCount
        /// </summary>
        public  decimal DisCount { get; set; }
        /// <summary>
        /// 总收账 PayPrices
        /// </summary>
        public decimal PayPrices { get; set; }

        /// <summary>
        /// 是否支付完成 CreateTime
        /// </summary>
        public  bool IsPay { get; set; }
        /// <summary>
        /// 创建时间 IsPay
        /// </summary>
        public  DateTime CreateTime { get; set; }           
      

        public OrderInfo OrderInfo { get; set; }

        public  ProfitsInfo()
        {
            OrderInfo = null;
        }

        public override string GetModelName()
        {
            return "ProfitsInfo";
        }
        /// <summary>
        /// 获取表格值名称 编号  订单号 总利润 折扣 价格 订单时间 是否支付 备注 是否删除
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "OrderId",  "Profit","DisCount", "PayPrices","CreateTime",
             "IsPay",  "Remark", "DelFlag" }; ;
        }

        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        { 
            return new List<string> { "ID编号", "订单编号",  "利润", "折扣", "收款","订单时间", "是否支付", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置 ID编号 是否删除 隐藏
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {

            return new List<int>() { 0, 8};
        }

        //返回字段
        public override string GetSql()
        {
            return "([OrderId],[Profit],[DisCount],[PayPrices],[CreateTime],[IsPay],[Remark],[DelFlag]) ";
        }

        //增加
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.OrderId + "','"
                  + this.Profit + "','"
                  + this.DisCount + "','"
                  + this.PayPrices + "','"
                  + this.CreateTime + "',"
                  + this.IsPay + ",'"
                  + this.Remark + "',"
                  + this.DelFlag + ")";

            return sql;
        }
        /// <summary>
        /// 修改是否支付和备注 字段
        /// </summary>
        /// <returns></returns>
        public override string GetEditSql()
        {
            string sql = " Set [Remark]='" + this.Remark + "',"+ "[IsPay] = " + this.IsPay + "  Where [ID]=" + this.Id;

            return sql;
        }

        //返回订单List
        public override List<BaseModel> GetList(DataTable dataTable)
        {
            DataRow dr = null;           
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProfitsInfo profitsInfo = new ProfitsInfo();
                dr = dataTable.Rows[i];
                profitsInfo.Id         = Convert.ToInt32(dr["ID"]);            //ID编号
                profitsInfo.OrderId    = Convert.ToString(dr["OrderId"]);      //订单编号
                profitsInfo.Profit     = Convert.ToDecimal(dr["Profit"]);      //利润
                profitsInfo.PayPrices  = Convert.ToDecimal(dr["PayPrices"]);   //收款
                profitsInfo.DisCount   = Convert.ToDecimal(dr["DisCount"]);    //折扣
                profitsInfo.IsPay      = Convert.ToBoolean(dr["IsPay"]);       //是否支付
                profitsInfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]); //备注
                profitsInfo.Remark     = Convert.ToString(dr["Remark"]);       //是否删除             
                Entitys.Add(profitsInfo);
            }
            return Entitys;
        }

    }
}
