﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{
    public class NoReceiveMoneyDal : BaseDal<NoReceiveMoney>
    {

        /// <summary>
        /// /筛选符合条件的数据
        /// </summary>
        /// <param name="startIndex">筛选ID起点</param>
        /// <param name="count">数据量</param>
        /// <param name="idAsc">是否顺序排列</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">终止时间</param>
        /// <param name="dic">条件字典</param>
        /// <returns></returns>
        public DataTable GetDataTablebyPammer(SearchModel searchModel)
        {
            var startTime = searchModel.StartTime;
            var endTime = searchModel.EndTime;
            var dic = searchModel.dic;
            var startIndex = searchModel.StartIndex;
            DateTime dateTime = DateTime.Now;
            string timeStart = (dateTime - new TimeSpan(7, 0, 0, 0, 0)).ToString("yyyy-MM-dd 00:00:00");
            string timeEnd = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            //操作员选择时间端
            if (!startTime.Equals(new DateTime()))
            {
                timeStart = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (!endTime.Equals(new DateTime()))
            {
                timeEnd = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            try
            {
                bool getDel = false;
                if (dic.TryGetValue("NoReceiveMoney_SelectValue", out string data))
                {
                    var isDel = int.Parse(data);
                    if (isDel > 0)
                    {
                        getDel = true;
                    }
                }

                string sql = @"Select top  " + searchModel.PageCount+
                     "  * " +
                   "from [NoReceiveMoney] Where [DelFlag]=  " + getDel +
                   "  And [CreateTime]>=#" + timeStart + "# And [CreateTime] <=#" + timeEnd + "#"
                     + " And  [ID]  >= "  + startIndex;

                string customerName = "";
                if (dic.TryGetValue("NoReceiveMoney_Name", out customerName))
                {
                    sql += @" and " + "[CustomerName]" + " like '%" + customerName + "%'";

                }
               
                sql += "   Order by [id]  asc"; 
                var dataTable = SqlHelper.GetDataTable(sql);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {

                    DataRow dr_first = dataTable.AsEnumerable().First<DataRow>();//获取最后一行
                    var fitstid = Convert.ToInt32(dr_first[0].ToString());//最后一行 ID
                    DataRow dr_last = dataTable.AsEnumerable().Last<DataRow>();//获取最后一行
                    var lastid = Convert.ToInt32(dr_last[0].ToString());//最后一行 ID
                                                                        //表示只有一个-1 ,即本次查询为第一页
                    if (searchModel.PageStartIndex.Count == 1)
                    {
                        searchModel.PageStartIndex.Add(fitstid);//
                    }
                    //如果该集合中不存在
                    if (!searchModel.PageStartIndex.Contains(lastid + 1))
                    {
                        searchModel.PageStartIndex.Add(lastid + 1);//下一页  
                    }
                   
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                var e = ex.Message; ;
                return null;
            }
        }


      

    }

    
}
