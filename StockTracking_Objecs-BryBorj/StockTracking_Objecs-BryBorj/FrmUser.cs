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
    public partial class FrmUser : Form
    {
        UserBLL bll = new UserBLL();
        public UserDTO dto = new UserDTO();
        public UserDetailDTO detail = new UserDetailDTO();
        public bool isUpdate = false;
        string root;

        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtUserName.Text = detail.UserName;
                txtPassword.Text = detail.Password;
                txtConfirmPassword.Text = detail.Password;
                cmbAccesLevel.Text = detail.AccesLevel;
                root = detail.PhotographyPth;
                pctAvatar.Load(root);
            }
        }

        private void pctAvatar_MouseClick(object sender, MouseEventArgs e)
        {
            //int i;
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.ShowDialog();
            root = filedialog.FileName;
            pctAvatar.Load(root);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese el nombre");
            else if (txtSurname.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese los apellidos");
            else if (txtUserName.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese un nombre de usuario");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Por favor, ingrese una contraseña");
            else if (txtPassword.Text.Length < 6)
                MessageBox.Show("La contraseña deve de ser minimo de 6 caracteres");
            else if (txtConfirmPassword.Text != txtPassword.Text)
                MessageBox.Show("La contraseña no coincide");
            else if (cmbAccesLevel.SelectedIndex == -1)
                MessageBox.Show("Por favor, Seleccione un nivel de acceso");
            else if (root == null)
                MessageBox.Show("Por favor, seleccione un avatar de su ordenador");
            else
            {
                if (!isUpdate)
                {
                    detail.Name = txtName.Text;
                    detail.Surname = txtSurname.Text;
                    detail.UserName = txtUserName.Text;
                    detail.Password = txtPassword.Text;
                    detail.AccesLevel = cmbAccesLevel.Text;
                    detail.PhotographyPth = root;
                    if (bll.Insert(detail))
                    {
                        MessageBox.Show("Se ha agregado exitosamente el usuario");
                        bll = new UserBLL();
                        dto = bll.Select();
                        ClearFilter();
                    }
                }
                else
                {
                    if (txtName.Text == detail.Name && txtSurname.Text == detail.Surname &&
                        txtUserName.Text == detail.UserName && txtPassword.Text == detail.Password && root == detail.PhotographyPth)
                    {
                        DialogResult result = MessageBox.Show("No ha realizado cambios \n ¿Desea cerrar esta ventana?", "Actializar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (result == DialogResult.Yes)
                            this.Close();
                        else
                            return;
                    }
                    else
                    {
                        detail.Name = txtName.Text;
                        detail.Surname = txtSurname.Text;
                        detail.UserName = txtUserName.Text;
                        detail.Password = txtPassword.Text;
                        detail.PhotographyPth = root;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Los campos del usuario \n han sido actualizados", "Actializar usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                    }
                }
            }
        }
        private void ClearFilter()
        {
            txtName.Clear();
            txtSurname.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cmbAccesLevel.SelectedIndex = -1;
        }

        private void pctAvatar_Click(object sender, EventArgs e)
        {

        }
    }
}
