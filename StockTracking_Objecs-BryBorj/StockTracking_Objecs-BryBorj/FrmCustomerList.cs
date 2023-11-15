/*Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * Fecha de inicio de proyecto 26 de Septiembre del 2022
 * "FrmCustomer" este formulario muestra un listado de 
 * los clientes agregados en "FrmCustomer".
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
    public partial class FrmCustomerList : Form
    {
        CustomerDTO dto = new CustomerDTO();
        CustomerBLL bll = new CustomerBLL();
        CustomerDetailDTO detail = new CustomerDetailDTO();
        List<SalesDetailDTO> list = new List<SalesDetailDTO>();
        
        SalesBLL salesBLL = new SalesBLL();
        SalesDTO salesDTO = new SalesDTO();


        public FrmCustomerList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomer customer = new FrmCustomer();//Objeto nuevo
            this.Hide();//Ocultar formulario de clientes
            customer.ShowDialog();//Mostrar formulario de agrgar
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customer;

        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customer;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre del cliente";
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customer;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text.ToUpper())).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CustomerDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Por favor, Seleccione una categoria de la lista");
            else
            {
                FrmCustomer frm = new FrmCustomer();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new CustomerBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Customer;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Por favor, seleccione un cliente del listado");
            else
            {
                salesDTO = salesBLL.Select();
                list = salesDTO.Sales;
                list = list.Where(x => x.CategoryID == detail.ID).ToList();
                if (list.Count > 0)
                    MessageBox.Show("Hay ventas asociadas a este cliente \n eliminelas primero");
                else if (list.Count == 0)
                {
                    DialogResult result = MessageBox.Show("El cliente seleccionado sera eliminado \n ¿Deseas continuar?", "!Precaución¡", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (bll.Delete(detail))
                        {
                            MessageBox.Show("El cliente ha sido eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bll = new CustomerBLL();
                            dto = bll.Select();
                            dataGridView1.DataSource = dto.Customer;

                        }
                    }
                }
            }
        }
    }
}