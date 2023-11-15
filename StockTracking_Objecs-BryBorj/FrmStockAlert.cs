/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * Esta parte del programa maneja una tabla que muestra los productos en los que hay
 * muy poca cantidad de existencias a partir de que sean menor a 10
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
    public partial class FrmStockAlert : Form
    {
        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();

        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            this.Hide();
            frm.ShowDialog();
        }

        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Producto";
            dataGridView1.Columns[1].HeaderText = "Categoría";
            dataGridView1.Columns[2].HeaderText = "Existencia";
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            if (dto.Products.Count == 0)
            {
                FrmMain frm = new FrmMain();
                this.Hide();
                frm.ShowDialog();
            }
            /*
             * Este es un programa elaborado con el
             * Profesor:Francisco Javier Brachi Lopez
             * docente del CBTis N254
             * Alumno:Bryan Albino Borjes
             * El programa consiste en el manejo de ventas
             * de algun producto registrado en el, en este
             * caso maneja 4 tablas las cuales son 
             * CLIENTES, CATEGORIAS, PRODUCOS y VENTAS
             * 
             */
        }
    }
}
