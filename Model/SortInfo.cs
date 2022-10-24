using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    public class SortInfo : BaseModel
    {
       
        //属性-商品种类
        public string SortName { get; set; }

   

        public  SortInfo(){
           
        }

        public override string GetModelName()
        {
            return "SortInfo";
        }

       
        //获取组织商品单位表格字段
        public override string GetSql()
        {
            return "([SortName],[Remark],[DelFlag]) ";
        }

        //组织记录
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.SortName + "','"  + this.Remark + "'," + this.DelFlag + ")";

            return sql;
        }

        //修改记录sql
        public override string GetEditSql()
        {
            string sql = " Set [SortName]='" + this.SortName + "',[Remark]='" + this.Remark + "'" + "  Where [ID]=" + this.Id;

            return sql;
        }


        //dataTable-->List
        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;           
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                SortInfo sortInfo = new SortInfo();
                dr = dataTable.Rows[i];
                sortInfo.Id = Convert.ToInt32(dr["ID"]);
                sortInfo.SortName = Convert.ToString(dr["SortName"]);
                sortInfo.Remark = Convert.ToString(dr["Remark"]);
             
                Entitys.Add(sortInfo);
            }

            return Entitys;
        }

        /// <summary>
        /// 获取表格值名称
        /// </summary>
        /// <returns> string list </returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "SortName",  "Remark", "DelFlag" }; ;
        }
        /// <summary>
        /// 获取标题名称
        /// </summary>
        /// <returns> string list </returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "类别", "备注", "是否删除" };
        }

        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns>string list </returns>
        public override List<int> GetHideIndex()
        {
            return new List<int>() { 0, 3 };   //"ID" "DelFlag" 列隐藏
        }

    }
}
