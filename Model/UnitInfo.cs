using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{
    //商品单位
    public class UnitInfo : BaseModel
    {
        /// <summary>
        /// 单位 瓶/个/箱
        /// </summary>
        public string UnitName { get; set; }


        public UnitInfo()
        {


        }

        //商品单位表格名称
        public override string GetModelName()
        {
            return "UnitInfo";
        }

        /// <summary>
        /// 获取表格记录字段名称 
        /// </summary>
        /// <returns></returns>
        public override List<string> GetTableName()
        {
            //DgvName
            return new List<string> { "ID", "UnitName",  "Remark", "DelFlag" }; ;
        }
        /// <summary>
        /// 获取标题中文名称
        /// </summary>
        /// <returns></returns>
        public override List<string> GetHanderTxt()
        {
            return new List<string> { "ID编号", "名称", "备注", "是否删除" };
        }
        /// <summary>
        /// 获取隐藏数据位置
        /// </summary>
        /// <returns></returns>
        public override List<int> GetHideIndex()
        {

            return new List<int>() { 0, 3 };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string GetSql()
        {
            return "([UnitName],[Remark],[DelFlag]) ";
        }

        /// <summary>
        /// 增加 
        /// </summary>
        /// <returns></returns>
        public override string GetAddSql()
        {
            string sql = " Values ('" + this.UnitName + "','" + this.Remark + "'," + this.DelFlag + ")";

            return sql;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public override string GetEditSql()
        {
            string sql = " Set[UnitName]='" + this.UnitName + "', [Remark]='" + this.Remark + "'  Where [ID]=" + this.Id;
            return sql;
        }

        /// <summary>
        /// 表格转记录对象列表
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public override List<BaseModel> GetList(DataTable dataTable)
        {

            DataRow dr = null;            
            List<BaseModel> Entitys = new List<BaseModel>();
            for (int i = 0; i < dataTable.Rows.Count; i++)             //n条记录
            {
                UnitInfo unitInfo = new UnitInfo();                    //1条记录, 1个UnitInfo实例对象
                dr = dataTable.Rows[i];
                unitInfo.Id = Convert.ToInt32(dr["ID"]);               //ID编号
                unitInfo.UnitName = Convert.ToString(dr["UnitName"]);  //名称
                unitInfo.Remark = Convert.ToString(dr["Remark"]);      //备注
                Entitys.Add(unitInfo);                                 //添加对象
            }

            return Entitys;
        }

    }
}
