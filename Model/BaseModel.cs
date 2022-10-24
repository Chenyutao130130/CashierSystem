using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Model
{ 
    //抽象类
  public   class BaseModel 
    {
        //所有表格通用字段
        public  int Id { get; set; }        //id编号
        public  bool DelFlag { get; set; }      
        public string Remark { get; set; }  //备注

        //构造函数
        public   BaseModel()
        {
             Remark = " ";
             DelFlag = false;
           
        }

        //获取记录字段
        public virtual string GetSql() //虚方法
        {
            return "";
        }

        //获取增加记录SQL
        public virtual string GetAddSql()
        {
            return "Values()";
        }

        //获取修改记录SQL
        public virtual string GetEditSql()
        {
            return "Set[] where ID=1 ";
        }

        //获取记录list
        public virtual List<BaseModel> GetList(DataTable dataTable)
        {
            return null;
        }

        //记录字段list
        public virtual List<string> GetTableName()
        {
            return new List<string>();
        }

        /// <summary>
        /// 获取标题名称 记录字段中文名称
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetHanderTxt()
        {

            return new List<string>();
        }
        /// <summary>
        /// 获取隐藏数据位置  记录隐藏字段 list
        /// </summary> 
        /// <returns></returns>
        public virtual List<int > GetHideIndex()
        {

            return null ;
        }

        /// <summary>
        /// 获取表名称 记录表格名称
        /// </summary>
        /// <returns></returns>
        public virtual string GetModelName()
        {
            return " ";
        }


    }
}
