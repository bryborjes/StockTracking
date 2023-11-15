/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * Fecha de inicio de proyecto 26 de Septiembre del 2022
 * "FrmDeletedRecords" esta parte del programa muestra
 * los elementos borrados y/o eliminados y da la posibilidad de recuperarlos
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using StockTracking_Objecs_BryBorj.BLL;
using StockTracking_Objecs_BryBorj.DAL.DTO;
using System.Windows.Forms;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmDeletedRecords : Form
    {
        SalesDTO dto = new SalesDTO();
        ProductDTO product = new ProductDTO();
        CustomerDTO customer = new CustomerDTO();
        CategoryDTO category = new CategoryDTO();

        SalesDetailDTO salesDTO = new SalesDetailDTO();
        ProductDetailDTO productDTO = new ProductDetailDTO();
        CustomerDetailDTO customerDTO = new CustomerDetailDTO();
        CategoryDetailDTO categoryDTO = new CategoryDetailDTO();

        SalesBLL bll = new SalesBLL();
        ProductBLL productBLL = new ProductBLL();
        CustomerBLL customerBLL = new CustomerBLL();
        CategoryBLL categoryBLL = new CategoryBLL();

        public FrmDeletedRecords()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeletedRecords_Load(object sender, EventArgs e)
        {
            dto = bll.Select(true);
            dataGridView1.DataSource = dto.Sales;
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
            cmbDeletedItems.SelectedIndex = 3;
        }

        private void cmbDeletedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeletedItems.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dto.Categories;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre de la categoría";
            }
            else if (cmbDeletedItems.SelectedIndex == 1)
            {
                dataGridView1.DataSource = dto.Customers;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
            }
            else if (cmbDeletedItems.SelectedIndex == 2)
            {
                dataGridView1.DataSource = dto.Products;
                dataGridView1.Columns[0].HeaderText = "Producto";
                dataGridView1.Columns[1].HeaderText = "Categoría";
                dataGridView1.Columns[2].HeaderText = "Existencia";
                dataGridView1.Columns[3].HeaderText = "Precio";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            else if (cmbDeletedItems.SelectedIndex == 3)
            {
                dataGridView1.DataSource = dto.Sales;
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
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeletedItems.SelectedIndex == 0)
            {
                categoryDTO = new CategoryDetailDTO();
                categoryDTO.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                categoryDTO.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedItems.SelectedIndex == 1)
            {
                customerDTO = new CustomerDetailDTO();
                customerDTO.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                customerDTO.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeletedItems.SelectedIndex == 2)
            {
                productDTO = new ProductDetailDTO();
                productDTO.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                productDTO.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                productDTO.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                productDTO.Price = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                productDTO.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);

            }
            else if (cmbDeletedItems.SelectedIndex == 3)
            {
                salesDTO = new SalesDetailDTO();
                salesDTO.SalesID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                salesDTO.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                salesDTO.ProductName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                salesDTO.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                salesDTO.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                salesDTO.SalesAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
                salesDTO.SalesPrice = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                salesDTO.isCategoryDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
                salesDTO.isProductDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
                salesDTO.isCustomerDeleted = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnRecovery_Click(object sender, EventArgs e)
        {
            if (cmbDeletedItems.SelectedIndex == 0)
            {
                if (categoryBLL.GetBack(categoryDTO))
                {
                    MessageBox.Show("La caegoría ha sido recumerada");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Categories;
                }
            }
            else if (cmbDeletedItems.SelectedIndex == 1)
            {
                if (customerBLL.GetBack(customerDTO))
                {
                    MessageBox.Show("El cliente ha sido recuperado");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Customers;
                }
            }
            else if (cmbDeletedItems.SelectedIndex == 2)
            {
                if (productDTO.isCategoryDeleted)
                    MessageBox.Show("La categoria asociada al proucto \n se encuentra eliminada");
                else if (productBLL.GetBack(productDTO))
                {
                    MessageBox.Show("El producto ha sido recuperado");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Products;
                }
            }
            else if (cmbDeletedItems.SelectedIndex == 3)
            {
                if (salesDTO.isCustomerDeleted)
                    MessageBox.Show("El cliente asociado a la venta \n se encuentra eliminado");
                else if (salesDTO.isProductDeleted)
                    MessageBox.Show("El producto asociado a la venta \n se encuentra eliminado");
                else if (bll.GetBack(salesDTO))
                {
                    MessageBox.Show("La venta ha sido recuperada");
                    dto = bll.Select(true);
                    dataGridView1.DataSource = dto.Sales;
                }
            }
        }
    }
}