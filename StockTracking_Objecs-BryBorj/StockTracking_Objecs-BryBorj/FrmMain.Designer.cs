namespace StockTracking_Objecs_BryBorj
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSingOut = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnSale = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(435, 484);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Acerca de...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnSingOut
            // 
            this.btnSingOut.BackColor = System.Drawing.Color.Transparent;
            this.btnSingOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSingOut.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSingOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnSingOut.ForeColor = System.Drawing.Color.White;
            this.btnSingOut.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.LogoOut;
            this.btnSingOut.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSingOut.Location = new System.Drawing.Point(340, 339);
            this.btnSingOut.Name = "btnSingOut";
            this.btnSingOut.Size = new System.Drawing.Size(158, 158);
            this.btnSingOut.TabIndex = 3;
            this.btnSingOut.Text = "Cerrar sesion";
            this.btnSingOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSingOut.UseVisualStyleBackColor = false;
            this.btnSingOut.Click += new System.EventHandler(this.btnSingOut_Click);
            // 
            // btnUser
            // 
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.Users;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUser.Location = new System.Drawing.Point(12, 339);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(158, 158);
            this.btnUser.TabIndex = 2;
            this.btnUser.Text = "Usuarios";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.exit_symbol_1_icon_icons_com_70162;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(176, 339);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 158);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDeleted
            // 
            this.btnDeleted.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleted.ForeColor = System.Drawing.Color.White;
            this.btnDeleted.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.window_deleted_10155;
            this.btnDeleted.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleted.Location = new System.Drawing.Point(340, 176);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(158, 158);
            this.btnDeleted.TabIndex = 0;
            this.btnDeleted.Text = "Informacion\r\nBorrada";
            this.btnDeleted.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleted.UseVisualStyleBackColor = true;
            this.btnDeleted.Click += new System.EventHandler(this.btnDeleted_Click);
            // 
            // btnSale
            // 
            this.btnSale.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.White;
            this.btnSale.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.Sales_by_payment_method_25410;
            this.btnSale.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSale.Location = new System.Drawing.Point(340, 12);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(158, 158);
            this.btnSale.TabIndex = 0;
            this.btnSale.Text = "Ventas";
            this.btnSale.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSale.UseVisualStyleBackColor = true;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources._1486486297_attribute_category_label_shop_price_price_tag_tag_81213;
            this.btnCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCategory.Location = new System.Drawing.Point(176, 176);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(158, 158);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Categorias";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.business_package_box_accept_productorpackagetoaccept_negocio_paquet_2334;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProduct.Location = new System.Drawing.Point(176, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(158, 158);
            this.btnProduct.TabIndex = 0;
            this.btnProduct.Text = "Productos";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.shopping_basket_add256_24909;
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddProduct.Location = new System.Drawing.Point(12, 176);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(158, 158);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Agregar\r\nProductos";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCustomer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Image = global::StockTracking_Objecs_BryBorj.Properties.Resources.customer_person_people_woman_you_1627;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCustomer.Location = new System.Drawing.Point(12, 12);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(158, 158);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "Clientes";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(512, 506);
            this.Controls.Add(this.btnSingOut);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleted);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnSale;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnSingOut;
        private System.Windows.Forms.Button btnUser;
    }
}