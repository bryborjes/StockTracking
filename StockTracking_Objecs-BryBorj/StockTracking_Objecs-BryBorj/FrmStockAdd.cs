/*
 *Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * "FrmStockAdd" esta parte del programa sirve para agregar la cantidad de existencias
 * de algun producto ya registrado.
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

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmStockAdd : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        ProductDetailDTO product = new ProductDetailDTO();
        bool comboFull = false;

        public FrmStockAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStockAdd_Load(object sender, EventArgs e)
        {

            dto = bll.Select();//Cargar capa logica a capa de transferencia
            dataGridView1.DataSource = dto.Products;//Insertar tabla
            //Cargar categorias de tabla en comboBox
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            //Propiedades de columnas de tabla
            dataGridView1.Columns[0].HeaderText = "Producto";
            dataGridView1.Columns[1].HeaderText = "Categoría";
            dataGridView1.Columns[2].HeaderText = "Existencia";
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            if (dto.Categories.Count > 0)
                comboFull = true;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull == true)
            {
                List<ProductDetailDTO> list = dto.Products;//Cargarlsitado de productos a lista de detalle
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();//buscar segun elemento seleccionado
                dataGridView1.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStockAmount.Clear();
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Segun elemento selecionado ingresar a cajas de texto los dato del mismo
            //
            product.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = product.ProductName;
            //
            product.Price = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = product.Price.ToString();
            //
            product.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            //txtStockAmount.Text = product.StockAmount.ToString();
            //
            product.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Por favor, seleccione un producto de la tabla");
            else if (txtStockAmount.Text.Trim()=="")
            {
                MessageBox.Show("Por favor, escriba la cantidad para la existencia");
            }
            else
            {
                //Agregar estock
                int sumStock = product.StockAmount;
                sumStock += Convert.ToInt32(txtStockAmount.Text);
                product.StockAmount = sumStock;
                //Preguntar si se puede llevar a cabo la ctualización
                if (bll.Update(product))
                {
                    MessageBox.Show("La existencia ha sido actializada");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Products;
                    txtStockAmount.Clear();
                    txtStockAmount.Focus();
                }
            }
        }
    }
}
