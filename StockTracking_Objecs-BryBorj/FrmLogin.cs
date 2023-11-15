/*
 * Este es un programa elaborado con el
 * Profesor:Francisco Javier Brachi Lopez
 * docente del CBTis N254
 * Alumno:Bryan Albino Borjes
 * "FrmLogin" realia el logeo de un usuario 
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
using StockTracking_Objecs_BryBorj.DAL;

namespace StockTracking_Objecs_BryBorj
{
    public partial class FrmLogin : Form
    {
        UserBLL bll = new UserBLL();
        UserDTO dto = new UserDTO();
        List<UserDetailDTO> list = new List<UserDetailDTO>();
        StockContext s = new StockContext();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.BackColor == Color.Black)
            {
                this.BackColor = Color.White;
            }
            else
            {
                this.BackColor = Color.Black;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tmrCount.Enabled = true;
            pgbLogin.Visible = false;
            lblMessage.Visible = false;
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            dto = bll.Select();
            list = dto.Users;
            if (txtPassword.Text.Trim() == "" && txtUserName.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese sus datos de usuario", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtUserName.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese un nombre de ususario", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Por favor, ingresa la contraseña", "Iniciar seción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txtUserName.Text == "cbtis254" && txtPassword.Text == "admin123")
            {
                pgbLogin.Visible = true;
                lblMessage.Visible = true;
                pgbLogin.Value = 100;
                FrmStockAlert frm = new FrmStockAlert();
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                list = list.Where(x => x.UserName == txtUserName.Text.Trim()).ToList();
                if (list.Count != 0)
                {
                    pctAvatar.BackgroundImage = null;
                    USER user = s.db.USER.First(x => x.UserName == txtUserName.Text.Trim());
                    pctAvatar.Load(user.PhotographyPth);
                }
                else if (list.Count == 0)
                {
                    
                }
                pgbLogin.Visible = true;
                tmrLoad.Enabled = true;
                lblMessage.Visible = true;
                lblMessage.Text = "Espere";
            }
        }
        private int countAttempts;
        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            if (lblMessage.Text.Length < 9)
                lblMessage.Text += ".";
            else
                lblMessage.Text = "Espere";
            if (pgbLogin.Value < 100)
            {
                pgbLogin.Value = pgbLogin.Value + 20;
            }
            else
            {
                tmrLoad.Stop();
                lblMessage.Visible = false;
                pgbLogin.Value = 0;
                pgbLogin.Visible = false;
                if (list.Count == 0)
                {
                    if (countAttempts < 3)
                    {
                        countAttempts++;
                        MessageBox.Show("El usuario o la contraseña son incorrectos " + "\n Intento " + countAttempts + "/3", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Has superado el numero de intentos", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Exit();
                    }
                }
                else if (list.Count != 0)
                {
                    USER user = s.db.USER.First(x => x.UserName == txtUserName.Text.Trim());
                    pctAvatar.Load(user.PhotographyPth);
                    if (user.Password != txtPassword.Text.Trim())
                    {

                        countAttempts++;
                        if (countAttempts <= 2)
                        {
                            MessageBox.Show("La contraseña es incorrecta " + "\n Intento " + countAttempts + "/3", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("La contraseña es incorrecta " + "\n Intento " + countAttempts + "/3", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Has superado el numero de intentos", "Iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        FrmStockAlert frm = new FrmStockAlert();
                        this.Hide();
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
