using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal
{

    /*
    class T Class<T>
    {
        public void test(T param)
        { }
    } 

    */


    //泛型类 当要实例化这个类型的时候，必须告诉这个类型T代表哪个类型，之后，所有这个类里面被标识了T的地方，都是指你开始实例化指明的类型 这个类型必须是BaseModel
    public class BaseDal<T> where T : BaseModel, new()
    {
        
        //插入T指定的记录
        public bool Add(T entity)
        {
            //表名字
            string modelName = entity.GetModelName();  //记录表格名称
           
            string sqls = entity.GetSql();         //记录字段
            string pamerSql = entity.GetAddSql();  //记录值
            string sql = "Insert into " + "[" + modelName + "]" + sqls + pamerSql;
            try
            {
                return SqlHelper.ExecuteNonQuery(sql);  //执行记录插入
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //插入记录,并返回类型
        public int  GetIdByAdd(T entity)
        {
            //表名字
            int id = 0;
            string modelName = entity.GetModelName();           
            string sqls = entity.GetSql();
            string pamerSql = entity.GetAddSql();
            string sql = "Insert into " + "[" + modelName + "]" + sqls + pamerSql;
            try
            {
                id = SqlHelper.ExecuteQueryId(sql);
            }
            catch (Exception ex)
            {
                return 0;
            }
            return id;
        }

        //更新记录
        public bool Edit(T entity)
        {
            string modelName = entity.GetModelName();           
            string pamerSql = entity.GetEditSql();
            string sql = "Update [" + modelName + "]" + pamerSql;
            try
            {
              return SqlHelper.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //获取一条T类型的记录
        public T GetEntityById(int id)
        {
            T entity = new T();
            try
            {
                string sql = "Select * from [" + entity.GetModelName() + "] where [ID]=" + id;
                var dataTable = SqlHelper.GetDataTable(sql);
                var listEntity = entity.GetList(dataTable);
                if (listEntity.Count == 1)
                {
                    return (T)listEntity[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public List<T> GetList()
        {
            List<T> list = new List<T>();
            T entity = new T();
            try
            {
                string sql = "Select * from [" + entity.GetModelName() + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);
                var listEntity = entity.GetList(dataTable);  //!!!

                if (listEntity.Count > 0)
                {
                    listEntity = listEntity.ToList();        //!!
                    foreach (var item in listEntity)
                    {
                        list.Add((T)item);  //
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public DataTable GetDataTable()
        {
            T entity = new T();
           
            try
            {
                //DelFlag 不是False
                string sql = "Select * from [" + entity.GetModelName() + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);

                /*
                List<string> ListColunmName = entity.GetHanderTxt();
                for(int i = 0; i < dataTable.Columns.Count; i++)
                {
                    ListColunmName[i] = dataTable.Columns[i].ColumnName;
                }
                */
                return dataTable;
            }
            catch(Exception ex)
            {
                var e = ex.Message; ;
                return null;
            }
        }
        public DataTable GetDataTable(SearchModel searchModel)
        {
            T entity = new T();
            string sqls = entity.GetSql();
            try
            {
                string sql = @"Select * from [" + searchModel.ModelName + "] Where [DelFlag]=False";
                var dataTable = SqlHelper.GetDataTable(sql);
                return dataTable;
            }
            catch
            {
                return null;
            }
        }

        public int GetCount()
        {
           
            return GetList().Count;
        }

        //没有真正从数据库删除
        public virtual bool Delete(int id)
        {
            T entity = new T();
            try
            {
                string sql = "Update  [" + entity.GetModelName() + "] Set [DelFlag]= "+true+" Where [ID]=" + id + "";
               return  SqlHelper.ExecuteNonQuery(sql);
               
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                string sql = "Update  [" + entity.GetModelName() + "] Set [DelFlag]=" + true + "  Where [ID]=" + entity.Id + "";
                return  SqlHelper.ExecuteNonQuery(sql);
               
            }
            catch
            {
                return false;
            }
        }

    }
}
