/* 
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 *"FrmSalesList" esta parte del programa muesrea un listado en tabla de
 *las ventas que se hayan hecho con el formulario "FrmSales"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockTracking_Objecs_BryBorj.BLL; 
using StockTracking_Objecs_BryBorj.DAL.DTO;
using StockTracking_Objecs_BryBorj.DAL.DAO;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmSalesList : Form
    {
        CategoryDAO categorydao = new CategoryDAO();
        CustomerDAO customerdao = new CustomerDAO();
        ProductDAO productdao = new ProductDAO();
        SalesDAO dao = new SalesDAO();
        SalesDetailDTO detail = new SalesDetailDTO();
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();

        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales sales = new FrmSales();
            sales.dto = dto;
            //Carga de datagrid
            this.Hide();
            sales.ShowDialog(); //Mostrar el formulario de Agegar venta
            this.Visible = true;
            sales.dto = dto;
            dto = bll.Select();
            dto.Sales = dao.Select();
            dataGridView1.DataSource = dto.Sales;
            ClearFilter();
        }

        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            //Carga del evento select de la capa de negocios a la capa de transferencia
            dto = bll.Select();
            dto.Categories = categorydao.Select();
            dto.Customers = customerdao.Select();
            dto.Products = productdao.Select();
            dto.Sales = dao.Select();
            //Cargar categorias en el combobox
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Sales;//Cargar tabla de ventas en el visor de datos
            //Cambio de encabezados de columnas y visibilidad
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Nombre de producto";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].HeaderText = "Cliente";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].HeaderText = "Categoría";
            dataGridView1.Columns[7].HeaderText = "Cantidad vendida";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Cantidad en almacen";
            dataGridView1.Columns[10].HeaderText = "Fecha de la venta";
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (txtCustomerName.Text.Trim() != null)
                list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            if (txtProductName.Text.Trim() != null)
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rdbPriceEqual.Checked)
                    list = list.Where(x => x.SalesPrice == Convert.ToSingle(txtPrice.Text)).ToList();
                if (rdbPriceMore.Checked)
                    list = list.Where(x => x.SalesPrice > Convert.ToSingle(txtPrice.Text)).ToList();
                if (rdbPriceLess.Checked)
                    list = list.Where(x => x.SalesPrice < Convert.ToSingle(txtPrice.Text)).ToList();
            }
            if (txtSalesAmount.Text.Trim() != null)
            {
                if (rdbAmountEqual.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                if (rdbAmountMore.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                if (rdbAmountLess.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
            }
            if (chkDate.Checked == true)
            {
                list = list.Where(x => x.SalesDate.Date.Day >= Convert.ToDateTime(dtpBegin.Value).Day && x.SalesDate.Date.Day <= Convert.ToDateTime(dtpEnd.Value).Day).ToList();
            }
            dataGridView1.DataSource = list;
            txtCustomerName.Focus();
        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            list = list.Where(x => x.SalesDate.Date > Convert.ToDateTime(dtpBegin.Value) && x.SalesDate < Convert.ToDateTime(dtpEnd.Value)).ToList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }

        private void ClearFilter()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            txtCustomerName.Clear();
            cmbCategory.SelectedIndex = -1;
            rdbPriceEqual.Checked = false;
            rdbPriceMore.Checked = false;
            rdbPriceLess.Checked = false;
            rdbAmountEqual.Checked = false;
            rdbAmountMore.Checked = false;
            rdbAmountLess.Checked = false;
            chkDate.Checked = false;
            dataGridView1.DataSource = dto.Sales;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //
            detail = new SalesDetailDTO();
            detail.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            //
            detail.SalesPrice = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            //
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Por favor, seleccione una venta de la lista");
            else
            {
                FrmSales frm = new FrmSales();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;

                bll = new SalesBLL();
                dto = bll.Select();
                dto.Sales = dao.Select();
                dataGridView1.DataSource = dto.Sales;
                ClearFilter();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Por favor, seleccine una venta de la lista");
            else
            {
                DialogResult result = MessageBox.Show("El registro sera eliminado\n ¿Esta seguro de realizar esta accion?", "!Precaución¡", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("La venta ha sido eliminada");
                        bll = new SalesBLL();
                        dto = bll.Select();
                        dto.Sales = dao.Select();
                        dataGridView1.DataSource = dto.Sales;
                        ClearFilter();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
