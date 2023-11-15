/*Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * Fecha de inicio de proyecto 26 de Septiembre del 2022
 * "FrmCustomer" este formulario da al usuario la opcion de agregar mas clientes
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
    public partial class FrmCustomer : Form
    {
        CustomerBLL bll = new CustomerBLL();
        public CustomerDetailDTO detail = new CustomerDetailDTO();
        public bool isUpdate = false;

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, escriba el nombre del cliente");
            }
            else
            {
                if (!isUpdate)//Gusrdar
                {
                    CustomerDetailDTO customer = new CustomerDetailDTO();
                    customer.CustomerName = txtCustomerName.Text.ToUpper();
                    if (bll.Insert(customer))
                    {
                        MessageBox.Show("El cliente ha sido agregado");
                        txtCustomerName.Clear();

                    }
                }
                else if (txtCustomerName.Text == detail.CustomerName)
                {
                    MessageBox.Show("No se ha detectado algun cambio");
                    this.Close();
                }
                else //Modificar
                {
                    detail.CustomerName = txtCustomerName.Text;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("El nombre del cliente ha sido actualizado");
                        this.Close();
                    }
                }
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate == true)
                txtCustomerName.Text = detail.CustomerName;
        }
    }
}
