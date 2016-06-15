namespace EventApp
{
    partial class inspectionApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inspectionApp));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_PeopleRegistered = new System.Windows.Forms.Button();
            this.tb_PeopleRegistered = new System.Windows.Forms.TextBox();
            this.tb_PeopleEntered = new System.Windows.Forms.TextBox();
            this.btn_PeopleEntered = new System.Windows.Forms.Button();
            this.tb_PeopleYetToEnter = new System.Windows.Forms.TextBox();
            this.btn_PeopleYetToEnter = new System.Windows.Forms.Button();
            this.tb_CheckOutPeople = new System.Windows.Forms.TextBox();
            this.btn_CheckOutPeople = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_PeopleInsideATM = new System.Windows.Forms.TextBox();
            this.btn_PeopleInsideATM = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox_Search = new System.Windows.Forms.ListBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_LastName = new System.Windows.Forms.TextBox();
            this.tb_FirstName = new System.Windows.Forms.TextBox();
            this.label_LastName = new System.Windows.Forms.Label();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.Inspection_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(512, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 117;
            this.pictureBox1.TabStop = false;
            // 
            // btn_PeopleRegistered
            // 
            this.btn_PeopleRegistered.Location = new System.Drawing.Point(44, 17);
            this.btn_PeopleRegistered.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_PeopleRegistered.Name = "btn_PeopleRegistered";
            this.btn_PeopleRegistered.Size = new System.Drawing.Size(111, 37);
            this.btn_PeopleRegistered.TabIndex = 1;
            this.btn_PeopleRegistered.Text = "People registered";
            this.btn_PeopleRegistered.UseVisualStyleBackColor = true;
            this.btn_PeopleRegistered.Click += new System.EventHandler(this.btn_PeopleRegistered_Click);
            // 
            // tb_PeopleRegistered
            // 
            this.tb_PeopleRegistered.Enabled = false;
            this.tb_PeopleRegistered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_PeopleRegistered.Location = new System.Drawing.Point(171, 24);
            this.tb_PeopleRegistered.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_PeopleRegistered.Name = "tb_PeopleRegistered";
            this.tb_PeopleRegistered.ReadOnly = true;
            this.tb_PeopleRegistered.Size = new System.Drawing.Size(71, 26);
            this.tb_PeopleRegistered.TabIndex = 119;
            // 
            // tb_PeopleEntered
            // 
            this.tb_PeopleEntered.Enabled = false;
            this.tb_PeopleEntered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_PeopleEntered.Location = new System.Drawing.Point(171, 64);
            this.tb_PeopleEntered.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_PeopleEntered.Name = "tb_PeopleEntered";
            this.tb_PeopleEntered.ReadOnly = true;
            this.tb_PeopleEntered.Size = new System.Drawing.Size(71, 26);
            this.tb_PeopleEntered.TabIndex = 123;
            // 
            // btn_PeopleEntered
            // 
            this.btn_PeopleEntered.Location = new System.Drawing.Point(44, 58);
            this.btn_PeopleEntered.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_PeopleEntered.Name = "btn_PeopleEntered";
            this.btn_PeopleEntered.Size = new System.Drawing.Size(111, 42);
            this.btn_PeopleEntered.TabIndex = 2;
            this.btn_PeopleEntered.Text = "Nr of people entered in total";
            this.btn_PeopleEntered.UseVisualStyleBackColor = true;
            this.btn_PeopleEntered.Click += new System.EventHandler(this.btn_PeopleEntered_Click);
            // 
            // tb_PeopleYetToEnter
            // 
            this.tb_PeopleYetToEnter.Enabled = false;
            this.tb_PeopleYetToEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_PeopleYetToEnter.Location = new System.Drawing.Point(171, 110);
            this.tb_PeopleYetToEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_PeopleYetToEnter.Name = "tb_PeopleYetToEnter";
            this.tb_PeopleYetToEnter.ReadOnly = true;
            this.tb_PeopleYetToEnter.Size = new System.Drawing.Size(71, 26);
            this.tb_PeopleYetToEnter.TabIndex = 125;
            // 
            // btn_PeopleYetToEnter
            // 
            this.btn_PeopleYetToEnter.Location = new System.Drawing.Point(44, 104);
            this.btn_PeopleYetToEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_PeopleYetToEnter.Name = "btn_PeopleYetToEnter";
            this.btn_PeopleYetToEnter.Size = new System.Drawing.Size(111, 41);
            this.btn_PeopleYetToEnter.TabIndex = 3;
            this.btn_PeopleYetToEnter.Text = "People yet to enter";
            this.btn_PeopleYetToEnter.UseVisualStyleBackColor = true;
            this.btn_PeopleYetToEnter.Click += new System.EventHandler(this.btn_PeopleYetToEnter_Click);
            // 
            // tb_CheckOutPeople
            // 
            this.tb_CheckOutPeople.Enabled = false;
            this.tb_CheckOutPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_CheckOutPeople.Location = new System.Drawing.Point(171, 161);
            this.tb_CheckOutPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_CheckOutPeople.Name = "tb_CheckOutPeople";
            this.tb_CheckOutPeople.ReadOnly = true;
            this.tb_CheckOutPeople.Size = new System.Drawing.Size(71, 26);
            this.tb_CheckOutPeople.TabIndex = 127;
            // 
            // btn_CheckOutPeople
            // 
            this.btn_CheckOutPeople.Location = new System.Drawing.Point(44, 154);
            this.btn_CheckOutPeople.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_CheckOutPeople.Name = "btn_CheckOutPeople";
            this.btn_CheckOutPeople.Size = new System.Drawing.Size(111, 40);
            this.btn_CheckOutPeople.TabIndex = 4;
            this.btn_CheckOutPeople.Text = "Nr of people who left ";
            this.btn_CheckOutPeople.UseVisualStyleBackColor = true;
            this.btn_CheckOutPeople.Click += new System.EventHandler(this.btn_CheckOutPeople_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_PeopleInsideATM);
            this.groupBox1.Controls.Add(this.btn_PeopleInsideATM);
            this.groupBox1.Controls.Add(this.btn_PeopleRegistered);
            this.groupBox1.Controls.Add(this.tb_CheckOutPeople);
            this.groupBox1.Controls.Add(this.tb_PeopleRegistered);
            this.groupBox1.Controls.Add(this.btn_CheckOutPeople);
            this.groupBox1.Controls.Add(this.btn_PeopleEntered);
            this.groupBox1.Controls.Add(this.tb_PeopleYetToEnter);
            this.groupBox1.Controls.Add(this.tb_PeopleEntered);
            this.groupBox1.Controls.Add(this.btn_PeopleYetToEnter);
            this.groupBox1.Location = new System.Drawing.Point(44, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(279, 253);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event information";
            // 
            // tb_PeopleInsideATM
            // 
            this.tb_PeopleInsideATM.Enabled = false;
            this.tb_PeopleInsideATM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_PeopleInsideATM.Location = new System.Drawing.Point(171, 205);
            this.tb_PeopleInsideATM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_PeopleInsideATM.Name = "tb_PeopleInsideATM";
            this.tb_PeopleInsideATM.ReadOnly = true;
            this.tb_PeopleInsideATM.Size = new System.Drawing.Size(71, 26);
            this.tb_PeopleInsideATM.TabIndex = 129;
            // 
            // btn_PeopleInsideATM
            // 
            this.btn_PeopleInsideATM.Location = new System.Drawing.Point(44, 198);
            this.btn_PeopleInsideATM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_PeopleInsideATM.Name = "btn_PeopleInsideATM";
            this.btn_PeopleInsideATM.Size = new System.Drawing.Size(111, 40);
            this.btn_PeopleInsideATM.TabIndex = 5;
            this.btn_PeopleInsideATM.Text = "People inside right now";
            this.btn_PeopleInsideATM.UseVisualStyleBackColor = true;
            this.btn_PeopleInsideATM.Click += new System.EventHandler(this.btn_PeopleInsideATM_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_Search);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Controls.Add(this.tb_LastName);
            this.groupBox2.Controls.Add(this.tb_FirstName);
            this.groupBox2.Controls.Add(this.label_LastName);
            this.groupBox2.Controls.Add(this.label_FirstName);
            this.groupBox2.Location = new System.Drawing.Point(44, 277);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(722, 273);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person information";
            // 
            // listBox_Search
            // 
            this.listBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Search.FormattingEnabled = true;
            this.listBox_Search.ItemHeight = 20;
            this.listBox_Search.Location = new System.Drawing.Point(380, 38);
            this.listBox_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_Search.Name = "listBox_Search";
            this.listBox_Search.Size = new System.Drawing.Size(319, 184);
            this.listBox_Search.TabIndex = 124;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(159, 184);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(111, 44);
            this.btn_Search.TabIndex = 8;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_LastName
            // 
            this.tb_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_LastName.Location = new System.Drawing.Point(150, 107);
            this.tb_LastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_LastName.Name = "tb_LastName";
            this.tb_LastName.Size = new System.Drawing.Size(151, 23);
            this.tb_LastName.TabIndex = 7;
            // 
            // tb_FirstName
            // 
            this.tb_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_FirstName.Location = new System.Drawing.Point(150, 55);
            this.tb_FirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_FirstName.Name = "tb_FirstName";
            this.tb_FirstName.Size = new System.Drawing.Size(151, 23);
            this.tb_FirstName.TabIndex = 6;
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.Location = new System.Drawing.Point(46, 110);
            this.label_LastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(59, 13);
            this.label_LastName.TabIndex = 119;
            this.label_LastName.Text = "Last name:";
            // 
            // label_FirstName
            // 
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.Location = new System.Drawing.Point(46, 57);
            this.label_FirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.Size = new System.Drawing.Size(58, 13);
            this.label_FirstName.TabIndex = 118;
            this.label_FirstName.Text = "First name:";
            // 
            // Inspection_Timer
            // 
            this.Inspection_Timer.Interval = 30000;
            this.Inspection_Timer.Tick += new System.EventHandler(this.Inspection_Timer_Tick);
            // 
            // inspectionApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "inspectionApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspection of the event";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_PeopleRegistered;
        private System.Windows.Forms.TextBox tb_PeopleRegistered;
        private System.Windows.Forms.TextBox tb_PeopleEntered;
        private System.Windows.Forms.Button btn_PeopleEntered;
        private System.Windows.Forms.TextBox tb_PeopleYetToEnter;
        private System.Windows.Forms.Button btn_PeopleYetToEnter;
        private System.Windows.Forms.TextBox tb_CheckOutPeople;
        private System.Windows.Forms.Button btn_CheckOutPeople;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_PeopleInsideATM;
        private System.Windows.Forms.Button btn_PeopleInsideATM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_LastName;
        private System.Windows.Forms.TextBox tb_FirstName;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.Timer Inspection_Timer;
    }
}