/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * "FrmCategory" este formulario cumple la funcion de permitir al
 * usuario añadir mas categorias de productos.
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
using StockTracking_Objecs_BryBorj.DAL;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmCategory : Form
    {
        CategoryBLL bll = new CategoryBLL();
        public CategoryDetailDTO detail = new CategoryDetailDTO();
        public bool isUpdate = false;


        public FrmCategory()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
            {
                MessageBox.Show("Por favor, escriba la categoría");
            }
            else
            {
                if (!isUpdate) //Añadir
                {
                    CategoryDetailDTO category = new CategoryDetailDTO();
                    category.CategoryName = txtCategoryName.Text.ToUpper();
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("La categoría ha sido agregada");
                        txtCategoryName.Clear();

                    }
                }
                else if (txtCategoryName.Text == detail.CategoryName)
                {
                    MessageBox.Show("No se ha detectado algun cambio");
                    this.Close();
                }
                else //Modificar 
                {
                    detail.CategoryName = txtCategoryName.Text.ToUpper(); ;
                    if (bll.Update(detail))
                    {
                        MessageBox.Show("La categoría ha sido actualizada");
                        this.Close();
                    }
                }
            }
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate == true)
                txtCategoryName.Text = detail.CategoryName;
        }
    }
}