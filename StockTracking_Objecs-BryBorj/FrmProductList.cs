/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * "FrmProductList" esta parte del programa funciona para mostrar
 * una tabla del listado de productos
*/
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
    public partial class FrmProductList : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        ProductDetailDTO detail = new ProductDetailDTO();
        ProductDAO dao = new ProductDAO();
        SalesDTO salesDTO = new SalesDTO();
        SalesBLL salesBLL = new SalesBLL();

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmProduct product = new FrmProduct();//Nuevo objeto
            this.Hide();//ocultar formulario
            product.ShowDialog();//mostrar nuevo formulario
            this.Visible = true;//mostrar formulario
            product.dto = dto;//Cargar cambios
            dto = bll.Select();//Cargar capa de negocios a objeto de transferencia de datos
            dataGridView1.DataSource = dto.Products;//cargar tabla
            ClearFilter();//limpiar filtros
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            salesDTO = salesBLL.Select();
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Producto";
            dataGridView1.Columns[1].HeaderText = "Categoría";
            dataGridView1.Columns[2].HeaderText = "Existencia";
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            if (txtProductName.Text.Trim() != null)
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rdbPriceEqual.Checked)
                    list = list.Where(x => x.Price == Convert.ToSingle(txtPrice.Text)).ToList();
                if (rdbPriceMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToSingle(txtPrice.Text)).ToList();
                if (rdbPriceLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToSingle(txtPrice.Text)).ToList();
            }
            if (txtStockAmount.Text.Trim() != "")
            {
                if (rdbAmountEqual.Checked)
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(txtStockAmount.Text)).ToList();
                if (rdbAmountMore.Checked)
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(txtStockAmount.Text)).ToList();
                if (rdbAmountLess.Checked)
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(txtStockAmount.Text)).ToList();
            }
            dataGridView1.DataSource = list;
        }
        private void ClearFilter()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStockAmount.Clear();
            cmbCategory.SelectedIndex = -1;
            rdbPriceEqual.Checked = false;
            rdbPriceMore.Checked = false;
            rdbPriceLess.Checked = false;
            rdbAmountEqual.Checked = false;
            rdbAmountMore.Checked = false;
            rdbAmountLess.Checked = false;
            dataGridView1.DataSource = dto.Products;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new ProductDetailDTO();
            detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Por favor, seleccione un producto de la lista");
            else
            {
                FrmProduct frm = new FrmProduct();
                frm.isUpdate = true;
                frm.detail = detail;
                frm.dto = dto;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                
                bll = new ProductBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Products;
                ClearFilter();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Por favor, seleccione un producto de la lista");
            else
            {
                var list = salesDTO.Sales;
                list = list.Where(x => x.ProductID == detail.ProductID).ToList();
                if (list.Count != 0)
                    MessageBox.Show("Hay ventas que tienen referencia a este producto \n Eliminelas primero", "Alerta",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    DialogResult dialog = MessageBox.Show("Esta a punto de borrar este producto \n ¿Desea continuar", "Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.Yes)
                    {
                        if (bll.Delete(detail))
                        {
                            MessageBox.Show("El producto ha sido eliminado");
                            bll = new ProductBLL();
                            dto = bll.Select();
                            dto.Products = dao.Select();
                            dataGridView1.DataSource = dto.Products;
                            ClearFilter();
                        }
                    }
                }
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
