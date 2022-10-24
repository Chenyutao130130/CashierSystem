﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    /// <summary>
    /// 供货信息类
    /// </summary>
    public class WholeSalerInfo : BaseModel
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public string SupName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>

        public string AddressInfo { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>

        public string Management { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelePhone { get; set; }


        public WholeSalerInfo()
        {


        }

        /// <summary>
        /// 获取表格名称
        /// </summary>
        /// <returns></returns>
        public override string GetModelName()
        {
            return "WholeSalerInfo";
        }
        

        //组织字段
        public override string GetSql()
        {
            return "([SupName],[Management],[TelePhone],[AddressInfo],[Remark],[DelFlag]) ";
        }

        //组织记录
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.SupName + "','" +
                this.Management + "','" +
                this.TelePhone + "','" +
                this.AddressInfo + "','" +
                this.Remark + "'," +
                this.DelFlag + ")";

            return sql;
        }
        public override string GetEditSql()
        {
            string sql = " Set[SupName]='" + this.SupName +                
                 "', [Management]='" + this.Management +
                 "', [TelePhone]='" + this.TelePhone +
                  "', [AddressInfo]='" + this.AddressInfo +
                 "', [Remark]='" + this.Remark +
                 "'  Where [ID]=" + this.Id;

            return sql;
        }

        //记录集合
        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;            
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                WholeSalerInfo wholeSalerInfo = new WholeSalerInfo();
                dr = dataTable.Rows[i];
                wholeSalerInfo.Id = Convert.ToInt32(dr["ID"]);
                wholeSalerInfo.SupName = Convert.ToString(dr["SupName"]);
                wholeSalerInfo.AddressInfo = Convert.ToString(dr["AddressInfo"]);
                wholeSalerInfo.Management = Convert.ToString(dr["Management"]);
                wholeSalerInfo.TelePhone = Convert.ToString(dr["TelePhone"]);
                wholeSalerInfo.Remark = Convert.ToString(dr["Remark"]);

                Entitys.Add(wholeSalerInfo);
            }

            return Entitys;
        }

        /// <summary>
        /// 获取表格值名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "SupName", "Management",  "TelePhone", "AddressInfo", "Remark", "DelFlag" }; ;
        }
        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "供货商店名", "负责人", "联系电话", "供货商地址", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {
            return new List<int>() { 0, 6 };
        }

    }
}