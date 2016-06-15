namespace EventApp
{
    partial class shopApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shopApp));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Finnish = new System.Windows.Forms.Button();
            this.numericUpDown_Quantity = new System.Windows.Forms.NumericUpDown();
            this.label_Quantity = new System.Windows.Forms.Label();
            this.tb_ProductID = new System.Windows.Forms.TextBox();
            this.btn_AddProduct = new System.Windows.Forms.Button();
            this.listBox_Products = new System.Windows.Forms.ListBox();
            this.label_ProductID = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_RemoveProd_shop = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(476, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Finnish
            // 
            this.btn_Finnish.Location = new System.Drawing.Point(153, 415);
            this.btn_Finnish.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Finnish.Name = "btn_Finnish";
            this.btn_Finnish.Size = new System.Drawing.Size(158, 57);
            this.btn_Finnish.TabIndex = 48;
            this.btn_Finnish.Text = "Finish";
            this.btn_Finnish.UseVisualStyleBackColor = true;
            this.btn_Finnish.Click += new System.EventHandler(this.btn_Finnish_Click);
            // 
            // numericUpDown_Quantity
            // 
            this.numericUpDown_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_Quantity.Location = new System.Drawing.Point(104, 83);
            this.numericUpDown_Quantity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Quantity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown_Quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Quantity.Name = "numericUpDown_Quantity";
            this.numericUpDown_Quantity.Size = new System.Drawing.Size(150, 32);
            this.numericUpDown_Quantity.TabIndex = 47;
            this.numericUpDown_Quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Quantity
            // 
            this.label_Quantity.AutoSize = true;
            this.label_Quantity.Location = new System.Drawing.Point(16, 83);
            this.label_Quantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Quantity.Name = "label_Quantity";
            this.label_Quantity.Size = new System.Drawing.Size(49, 13);
            this.label_Quantity.TabIndex = 45;
            this.label_Quantity.Text = "Quantity:";
            // 
            // tb_ProductID
            // 
            this.tb_ProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ProductID.Location = new System.Drawing.Point(104, 37);
            this.tb_ProductID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_ProductID.Multiline = true;
            this.tb_ProductID.Name = "tb_ProductID";
            this.tb_ProductID.Size = new System.Drawing.Size(151, 32);
            this.tb_ProductID.TabIndex = 44;
            // 
            // btn_AddProduct
            // 
            this.btn_AddProduct.Location = new System.Drawing.Point(126, 148);
            this.btn_AddProduct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_AddProduct.Name = "btn_AddProduct";
            this.btn_AddProduct.Size = new System.Drawing.Size(120, 45);
            this.btn_AddProduct.TabIndex = 43;
            this.btn_AddProduct.Text = "Add product";
            this.btn_AddProduct.UseVisualStyleBackColor = true;
            this.btn_AddProduct.Click += new System.EventHandler(this.btn_AddProduct_Click);
            // 
            // listBox_Products
            // 
            this.listBox_Products.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Products.FormattingEnabled = true;
            this.listBox_Products.ItemHeight = 20;
            this.listBox_Products.Location = new System.Drawing.Point(370, 164);
            this.listBox_Products.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_Products.Name = "listBox_Products";
            this.listBox_Products.Size = new System.Drawing.Size(407, 264);
            this.listBox_Products.TabIndex = 41;
            this.listBox_Products.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Products_MouseDoubleClick);
            // 
            // label_ProductID
            // 
            this.label_ProductID.AutoSize = true;
            this.label_ProductID.Location = new System.Drawing.Point(6, 40);
            this.label_ProductID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ProductID.Name = "label_ProductID";
            this.label_ProductID.Size = new System.Drawing.Size(61, 13);
            this.label_ProductID.TabIndex = 38;
            this.label_ProductID.Text = "Product ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ProductID);
            this.groupBox1.Controls.Add(this.label_ProductID);
            this.groupBox1.Controls.Add(this.btn_AddProduct);
            this.groupBox1.Controls.Add(this.numericUpDown_Quantity);
            this.groupBox1.Controls.Add(this.label_Quantity);
            this.groupBox1.Location = new System.Drawing.Point(42, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(269, 214);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add product";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(659, 405);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(94, 31);
            this.btn_Clear.TabIndex = 54;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_RemoveProd_shop
            // 
            this.btn_RemoveProd_shop.Location = new System.Drawing.Point(387, 407);
            this.btn_RemoveProd_shop.Name = "btn_RemoveProd_shop";
            this.btn_RemoveProd_shop.Size = new System.Drawing.Size(106, 29);
            this.btn_RemoveProd_shop.TabIndex = 55;
            this.btn_RemoveProd_shop.Text = "Remove product";
            this.btn_RemoveProd_shop.UseVisualStyleBackColor = true;
            this.btn_RemoveProd_shop.Click += new System.EventHandler(this.btn_RemoveProd_shop_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(42, 230);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(269, 147);
            this.listBox1.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 269);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 45);
            this.button1.TabIndex = 48;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shopApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_RemoveProd_shop);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Finnish);
            this.Controls.Add(this.listBox_Products);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "shopApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.shopApp_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Quantity)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Finnish;
        private System.Windows.Forms.NumericUpDown numericUpDown_Quantity;
        private System.Windows.Forms.Label label_Quantity;
        private System.Windows.Forms.TextBox tb_ProductID;
        private System.Windows.Forms.Button btn_AddProduct;
        private System.Windows.Forms.ListBox listBox_Products;
        private System.Windows.Forms.Label label_ProductID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_RemoveProd_shop;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
    }
}