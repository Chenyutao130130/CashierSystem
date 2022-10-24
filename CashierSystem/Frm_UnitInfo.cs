using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CashierSystem
{
    //商品单位增加界面
    public partial class Frm_UnitInfo : Form
    {
         Frm_UnitInfo()
        {
            InitializeComponent();
        }
        public string _ModelName= "UnitInfo";  //模块名称
        public int entityId=int.MaxValue;      //最大啊值
        public static List<string> _Tags;
        
        //表名, lab1 ,lab2 ,lab3
        private static Frm_UnitInfo _form;
        public static Frm_UnitInfo Create(List<string> tags=null)
        {
            _Tags = null;
            if (_form == null)
            {
                _form = new Frm_UnitInfo();
                _Tags = tags;
            }
            else
            {
                Frm_UnitInfo._Tags = tags;
            }
            return _form;
        }

        //窗体加载初始化
        public  void   InIt()
        {
            this.Tag = false;
            entityId =int.MaxValue;
            txtFirst.Text = "";         //控件-商品单位输入框 
            txtRmark.Text = "";         //控件-商品单位备注输入框 

            if (_Tags!=null)
            {
                //添加数据 添加
                if (_Tags.Count==0)
                {
                              
                    this.Text = "添加";       //窗体标题:"添加"
                }
               
                //修改 3 修改 编辑
                else if (_Tags.Count == 3)
                {
                    this.Text = "修改";       //窗体标题:"修改"         
                    entityId = Convert.ToInt32(_Tags[0]);
                    
                    txtFirst.Text = _Tags[1]; //显示修改前的商品单位名称
                    txtRmark.Text = _Tags[2]; //显示修改前的商品单位备注
                }               
                else
                {
                    MessageBox.Show("发生意外情况,请稍后重试!");
                }
                txtFirst.Focus();//光标定位
            }

        }


        //窗体加载事件
        private void Frm_UnitInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }


        //对象的1个按钮单击事件
        private void btnEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;  //将本窗体的拥有者强制设为Form1类的实例f

            if (txtFirst.Text=="")
            {
                lbltips.Text = "请检查数据,数据不能为空";
                lbltips.ForeColor = Color.Red;
                return;
            }            
            //添加时候 默认 id 为maxValue
            if (entityId==int.MaxValue)
            {
                //添加
               
                    UnitInfo unitInfo = new UnitInfo();
                    unitInfo.UnitName = txtFirst.Text.Trim();
                    unitInfo.Remark = txtRmark.Text.Trim().Replace(';','.');//替换';'
                //后期 英文";"有作用
                   var isSuccess=  DataManager.UnitInfoBLL.Add(unitInfo);   //增加到数据库里面  没有查重bug
                    if (!isSuccess)
                    {
                        MessageBox.Show("操作失败!");
                    }
                    this.Tag = true;
                this.lbltips.Visible = false;
                this.lbltips.Text = "";
                this.Close();
                

            }
            else
            {
                    //创建1条商品单位记录
                    UnitInfo unitInfo = new UnitInfo();
                    unitInfo.UnitName = txtFirst.Text.Trim();  
                    unitInfo.Remark = txtRmark.Text.Trim();
                    unitInfo.Id = entityId;

                    var isSuccess = DataManager.UnitInfoBLL.Edit(unitInfo);  //替换原来的
                    if (!isSuccess)
                    {
                        MessageBox.Show("操作失败!");
                    }
                    this.Close();
                

            }
            //属性界面
            f1.GetDgv(f1.SelectIndex);  //更新修改后的UI

        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.lbltips.Visible = false;
            this.lbltips.Text = "";  //错误提示
            this.Close();

        }

        private void Frm_UnitInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Tags = new List<string>();
        }
    }
}
