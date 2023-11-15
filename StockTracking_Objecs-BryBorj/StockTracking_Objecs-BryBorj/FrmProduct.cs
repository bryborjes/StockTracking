/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 *"FrmProduct" esta parte del programa funciona para agregar productos
 *con su precio y categoría
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockTracking_Objecs_BryBorj.DAL;
using StockTracking_Objecs_BryBorj.BLL;
using StockTracking_Objecs_BryBorj.DAL.DTO;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmProduct : Form
    {
        ProductBLL bll = new ProductBLL();
        public ProductDTO dto = new ProductDTO();
        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate = false;

        public FrmProduct()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate == true)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                cmbCategory.SelectedValue = detail.CategoryID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Por favor, escriba el nombre del producto");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Por favor, seleccione una categoría para el producto");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Por favor, indique el precio del producto");
            else
            {
                if (!isUpdate) //Añadir
                {
                    ProductDetailDTO product = new ProductDetailDTO();
                    product.ProductName = txtProductName.Text.ToUpper();
                    product.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                    product.Price = Convert.ToSingle(txtPrice.Text);
                    if (bll.Insert(product))
                    {
                        MessageBox.Show("El producto, ha sido agregado");
                        txtPrice.Clear();
                        txtProductName.Clear();
                        cmbCategory.SelectedValue = -1;
                    }
                }
                else //Modificar
                {
                    if (detail.ProductName == txtProductName.Text.Trim().ToUpper() &&
                        detail.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToSingle(txtPrice.Text.Trim()))
                    {
                        MessageBox.Show("No se han detectado cambios");
                    }
                    else
                    {
                        detail.ProductName = txtProductName.Text.Trim().ToUpper();
                        detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToSingle(txtPrice.Text);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("El producto ha sido actializado");
                            this.Close();
                        }
                    }
                }
            }
        }
        
    }
}
