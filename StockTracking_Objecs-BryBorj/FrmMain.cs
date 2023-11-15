/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 *"FrmMain" este es la parte del programa que muestra
 *el menu al usuario para eligir entre todas las opciones
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }
        //Menu de inicio
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomerList customer = new FrmCustomerList();
            this.Hide();
            customer.ShowDialog();
            this.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProductList product = new FrmProductList();
            this.Hide();
            product.ShowDialog();
            this.Visible = true;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            FrmSalesList sales = new FrmSalesList();
            this.Hide();
            sales.ShowDialog();
            this.Visible = true;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FrmStockAdd stock = new FrmStockAdd();
            this.Hide();
            stock.ShowDialog();
            this.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FrmCategoryList category = new FrmCategoryList();
            this.Hide();
            category.ShowDialog();
            this.Visible = true;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            FrmDeletedRecords deleted = new FrmDeletedRecords();
            this.Hide();
            deleted.ShowDialog();
            this.Visible = true;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FrmUser user = new FrmUser();
            this.Hide();
            user.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnSingOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
