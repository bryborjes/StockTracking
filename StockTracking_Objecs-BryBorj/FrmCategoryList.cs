/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * Fecha de inicio de proyecto 26 de Septiembre del 2022
 * "FrmCategoryList" este formulario muestra un listado
 * que visualiza las categorias 
 * */
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
    public partial class FrmCategoryList : Form
    {
        CategoryDTO dto = new CategoryDTO();
        CategoryBLL bll = new CategoryBLL();
        CategoryDetailDTO detail = new CategoryDetailDTO();
        ProductDTO pDTO = new ProductDTO();
        ProductBLL pBLL = new ProductBLL();
        List<ProductDetailDTO> list = new List<ProductDetailDTO>();

        public FrmCategoryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            this.Hide();
            category.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;
        }

        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Nombre de la categoría";
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            List<CategoryDetailDTO> list = dto.Categories;
            list = list.Where(x => x.CategoryName.Contains(txtCategoryName.Text.ToUpper())).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CategoryDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Por favor, Seleccione una categoria de la lista");
            else
            {
                FrmCategory frm = new FrmCategory();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                dataGridView1.DataSource = dto.Categories;
                this.Visible = true;
                bll = new CategoryBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Categories;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Por favor, seleccione una categoría del listado");
            else
            {
                pDTO = pBLL.Select();
                list = pDTO.Products;
                list = list.Where(x => x.CategoryID == detail.ID).ToList();
                if (list.Count > 0)
                    MessageBox.Show("Hay productos asociados a esta categoria \n Eliminelos primero");
                else if (list.Count == 0)
                {
                    DialogResult result = MessageBox.Show("La categoría seleccionada sera eliminada \n ¿Deseas continuar?", "!Precaución¡", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        if (bll.Delete(detail))
                        {
                            MessageBox.Show("La categoría ha sido eliminada");
                            bll = new CategoryBLL();
                            dto = bll.Select();
                            dataGridView1.DataSource = dto.Categories;
                        }
                    }
                }
            }
        }
    }
}
