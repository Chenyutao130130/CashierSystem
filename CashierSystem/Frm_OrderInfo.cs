﻿using Model;
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
    public partial class Frm_OrderInfo : Form
    {
        Frm_OrderInfo()
        {
            InitializeComponent();
        }

        public static int orderIndex = int.MaxValue;
        public GoodsInfo theGoodInfo = null;
        public double  mixCount = 0;//最小值
        public double maxCount = double.MaxValue / 1000000000.0;
      
        private static Frm_OrderInfo _form;
        public static Frm_OrderInfo Create( int id )
        {
            orderIndex = int.MaxValue;
            if (_form == null)
            {
                _form = new Frm_OrderInfo();

                orderIndex = id;
            }
            else
            {
                orderIndex = id;

            }
            return _form;
        }
        
         public void  InIt()
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f
            try
            {
                var orderInfo = f1.OrdersInfo[orderIndex];
                theGoodInfo = DataManager.GoodsInfoBLL.GetEntityById(orderInfo.GoodsId);
                maxCount = theGoodInfo.SurplusCount;
                txtOrder_GoodsName.Text = orderInfo.GoodsName;           //商品名称
                txtOrder_Count.Text = orderInfo.Count.ToString();        //数量
                txtOrder_DisCount.Text = orderInfo.DisCount.ToString();  //折扣
                double dfd = (double)orderInfo.PayPrice;                 
                txtOrder_Price.Text = orderInfo.PayPrice.ToString();     //价格
                txtOrder_Remark.Text = orderInfo.Remark;                 //备注
                this.lblTips.Visible = false;
            }
            catch
            {

                MessageBox.Show("发生未知错误!!!");
                this.Close();
            }
        }
        private void btnOrderEnter_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f
            try
            {
                var orderInfo = f1.OrdersInfo[orderIndex];
                theGoodInfo = DataManager.GoodsInfoBLL.GetEntityById(orderInfo.GoodsId);
                double count, disCount;
                count = double.Parse(txtOrder_Count.Text.Trim());
                disCount = double.Parse(txtOrder_DisCount.Text.Trim());
                orderInfo.Count = count;  //修改数量
                orderInfo.DisCount = (decimal)disCount; //修改折扣
                orderInfo.PayPrice = theGoodInfo.PayPrice * (decimal)count - (decimal)disCount;
                orderInfo.Profit = (orderInfo.PayPrice) - (theGoodInfo.PurPrice * (decimal)count); //利润;
                orderInfo.Remark = this.txtOrder_Remark.Text.ToString();  //修改备注
                f1.OrdersInfo[orderIndex] = orderInfo;
                this.Close();
            }
            catch
            {

                MessageBox.Show("发生未知错误!!!");
                this.Close();
            }
        }

       
        private void Frm_OrderInfo_Load(object sender, EventArgs e)
        {
            InIt();
        }

        private void txtOrder_Count_MouseUp(object sender, MouseEventArgs e)
        {
            this.lblTips.Visible = false;
            double count;
            var isTrue = double.TryParse(this.txtOrder_Count.Text.Trim(), out count);
            if (isTrue)
            {
                ChangeData();
            }
            else
            {
                this.lblTips.Visible = true;
                lblTips.Text = "商品数量请填写数字!!!";
                this.txtOrder_Count.Focus();
            }
        }
        private void txtOrder_DisCount_MouseUp(object sender, MouseEventArgs e)
        {
            this.lblTips.Visible = false;
            double disCount;
            var isTrue = double.TryParse(this.txtOrder_DisCount.Text.Trim(), out disCount);
            if (isTrue)
            {
                ChangeData();
            }
            else
            {
                this.lblTips.Visible = true;
                lblTips.Text = "折扣请填写数字!!!";
                this.txtOrder_DisCount.Focus();
            }
        }



        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            lblTips.Text = "";
            lblTips.Visible = false;
            this.Close();
        }

       

        private void lblReduceCount_Click(object sender, EventArgs e)
        {
            this.lblTips.Visible = false;
            double count;
            var isTrue=  double.TryParse(this.txtOrder_Count.Text.Trim(), out count);
            if (isTrue)
            {
                if (count>(mixCount+1))
                {
                    this.txtOrder_Count.Text = (count - 1).ToString();
                    ChangeData();
                }
            }
            else
            {
                this.lblTips.Visible = true;
                lblTips.Text = "商品数量请填写数字!!!";
                this.txtOrder_Count.Focus();
            }
            
        }
        public void ChangeData()
        {
            this.lblTips.Visible = false;
            //数量
            double count;
            double disCount;
            var isCountTrue = double.TryParse(this.txtOrder_Count.Text.Trim(), out count);
            var isDisCount = double.TryParse(this.txtOrder_DisCount.Text.Trim(), out disCount);
            if (isCountTrue && isDisCount)
            {
                //售价
                var parice = (theGoodInfo.PayPrice * (decimal)count) - (decimal)disCount;
                this.txtOrder_Price.Text = parice.ToString();
            }
            else
            {
                this.lblTips.Visible = true;
                lblTips.Text = "商品数量和折扣请填写数字!!";
            }
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            this.lblTips.Visible = false;
            double count;
            var isTrue = double.TryParse(this.txtOrder_Count.Text.Trim(), out count);
            if (isTrue)
            {
                if ((count+1) <=maxCount)
                {
                    this.txtOrder_Count.Text = (count +1).ToString();
                    ChangeData();
                }
            }
            else
            {
                this.lblTips.Visible = true;
                lblTips.Text = "商品数量请填写数字,!!";
            }
           
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            Huang_System f1 = (Huang_System)this.Owner;//将本窗体的拥有者强制设为Form1类的实例f
            try
            {
                f1.OrdersInfo.RemoveAt(orderIndex);
                this.Close();
            }
            catch
            {
                MessageBox.Show("出错了,请重试");
            }
          }
    }
}
