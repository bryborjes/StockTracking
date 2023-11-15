/* 
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * "FrmSales" este formulario hace la funcion de registrar 
 * nuevas ventas y registrarlas en una base de datos*/
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
    public partial class FrmSales : Form
    {
        public SalesDTO dto = new SalesDTO();
        SalesBLL bll = new SalesBLL();
        bool comboFull = false, comboCustomers = false;//Declarar variables
        //Actualización
        public SalesDetailDTO detail = new SalesDetailDTO();
        public bool isUpdate = false;

        public FrmSales()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            //Insercion de menu a ComboBox
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;


            if (!isUpdate) // Agregar venta
            {
                //Tabla de productos
                gridProduct.DataSource = dto.Products;
                gridProduct.Columns[0].HeaderText = "Producto";
                gridProduct.Columns[1].HeaderText = "Categoría";
                gridProduct.Columns[2].HeaderText = "Existencia";
                gridProduct.Columns[3].HeaderText = "Precio";
                gridProduct.Columns[4].Visible = false;
                gridProduct.Columns[5].Visible = false;

                //Tabla de clientes
                gridCustomers.DataSource = dto.Customers;
                gridCustomers.Columns[0].Visible = false;
                gridCustomers.Columns[1].HeaderText = "Nombre del cliente";
                //comparar cantidad de informacion
                if (dto.Categories.Count > 0)
                    comboFull = true;
                if (dto.Customers.Count > 0)
                    comboCustomers = true;
            }
            else //Actualizar
            {
                panel1.Hide();
                txtCustomerName.Text = detail.CustomerName;
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.SalesPrice.ToString();
                txtSalesAmount.Text = detail.SalesAmount.ToString();
                ProductDetailDTO product = dto.Products.First(x => x.ProductID == detail.ProductID);
                detail.StockAmount = product.StockAmount;
                txtStockAmount.Text = detail.StockAmount.ToString();
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFull == true)
            {
                //Generar nueva lista dependiendo la categoria seleccionada
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProduct.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStockAmount.Clear();
                }
            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboCustomers == true)
            {
                //Generar lista conforme a lo que se escribe
                List<CustomerDetailDTO> list = dto.Customers;
                list = list.Where(x => x.CustomerName.Contains(txtCustomerSearch.Text.ToUpper())).ToList();
                gridCustomers.DataSource = list;
            }
        }

        private void gridProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Nombre del producto
            detail.ProductName = gridProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            //Precio del producto
            detail.SalesPrice = Convert.ToSingle(gridProduct.Rows[e.RowIndex].Cells[3].Value);
            //Cantidad de stock
            detail.StockAmount = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[2].Value);
            //IDs
            detail.ProductID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProduct.Rows[e.RowIndex].Cells[5].Value);
            //Asignacion
            txtProductName.Text = detail.ProductName; txtPrice.Text = detail.SalesPrice.ToString();
            txtStockAmount.Text = detail.StockAmount.ToString();

        }

        private void gridCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Nombre del cliente
            detail.CustomerName = gridCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            //ID de linea
            detail.CustomerID = Convert.ToInt32(gridCustomers.Rows[e.RowIndex].Cells[0].Value);
            //Asignacion
            txtCustomerName.Text = detail.CustomerName;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)//Verificar si ah seleccionado un producto
                MessageBox.Show("Por favor, seleccione un producto de la tabla");

            else if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Por favor, seleccione un producto de la tabla");

            else//Agregar venta
            {
                if (!isUpdate) //Añadir si el falso
                {
                    if (detail.CustomerID == 0)//Ha seleccionado un cliente
                        MessageBox.Show("Por favor, seleccione un cliente de la tabla");
                    else if (detail.StockAmount < Convert.ToInt32(txtSalesAmount.Text))//Verificar si la existencia es suficiente
                        MessageBox.Show("No hay suficientes productos en existencia");

                    else
                    {
                        detail.SalesAmount = Convert.ToInt32(txtSalesAmount.Text);//Instanciar el stock vendido
                        detail.SalesDate = DateTime.Today; //Inserar fecha de la venta
                        if (bll.Insert(detail))//Ver si se puede llevar a cabo la venta 
                        {
                            MessageBox.Show("Se ha agregado la venta");//Mostrar mensaje de confirmacion al usuario
                            bll = new SalesBLL();//Nueva capa de negocios y/o lógica
                            dto = bll.Select();//Agregar la nueva capa lógica a la capa de tranferencia de datos
                            gridProduct.DataSource = dto.Products;//Cargar tabla en el control DataGridView
                            dto.Customers = dto.Customers;
                            comboCustomers = false;
                            comboFull = false;
                            cmbCategory.DataSource = dto.Categories;
                            txtSalesAmount.Clear();
                            if (dto.Categories.Count > 0)
                                comboFull = true;
                        }
                    }
                }
                else //Modificar so es verdadero
                {
                    if (detail.SalesAmount == Convert.ToInt32(txtSalesAmount.Text))
                        MessageBox.Show("No se han detectado cambios");
                    else
                    {
                        int temp = detail.StockAmount + detail.SalesAmount;
                        if (temp < Convert.ToInt32(txtSalesAmount.Text))
                            MessageBox.Show("No hay suficientes productos");
                        else
                        {
                            detail.SalesAmount = Convert.ToInt32(txtSalesAmount.Text);
                            detail.StockAmount = temp - detail.SalesAmount;
                            if (bll.Update(detail))
                            {
                                MessageBox.Show("La venta ha sido actualizada");
                                this.Close();
                            }
                        }
                    }
                }
            }
            txtCustomerName.Focus();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}