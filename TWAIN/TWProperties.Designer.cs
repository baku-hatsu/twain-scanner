namespace TWAIN
{
    partial class TWProperties
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
            this.dpi_groupBox = new System.Windows.Forms.GroupBox();
            this.dpi_comboBox = new System.Windows.Forms.ComboBox();
            this.page_groupBox = new System.Windows.Forms.GroupBox();
            this.page_size_comboBox = new System.Windows.Forms.ComboBox();
            this.image_groupBox = new System.Windows.Forms.GroupBox();
            this.duplex_checkBox = new System.Windows.Forms.CheckBox();
            this.autofeeder_checkBox = new System.Windows.Forms.CheckBox();
            this.cancel_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.dpi_groupBox.SuspendLayout();
            this.page_groupBox.SuspendLayout();
            this.image_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpi_groupBox
            // 
            this.dpi_groupBox.Controls.Add(this.dpi_comboBox);
            this.dpi_groupBox.Location = new System.Drawing.Point(13, 12);
            this.dpi_groupBox.Name = "dpi_groupBox";
            this.dpi_groupBox.Size = new System.Drawing.Size(209, 100);
            this.dpi_groupBox.TabIndex = 0;
            this.dpi_groupBox.TabStop = false;
            this.dpi_groupBox.Text = "DPI";
            // 
            // dpi_comboBox
            // 
            this.dpi_comboBox.FormattingEnabled = true;
            this.dpi_comboBox.Location = new System.Drawing.Point(6, 19);
            this.dpi_comboBox.Name = "dpi_comboBox";
            this.dpi_comboBox.Size = new System.Drawing.Size(197, 21);
            this.dpi_comboBox.TabIndex = 0;
            this.dpi_comboBox.SelectedIndexChanged += new System.EventHandler(this.Dpi_comboBox_SelectedIndexChanged);
            // 
            // page_groupBox
            // 
            this.page_groupBox.Controls.Add(this.page_size_comboBox);
            this.page_groupBox.Location = new System.Drawing.Point(13, 118);
            this.page_groupBox.Name = "page_groupBox";
            this.page_groupBox.Size = new System.Drawing.Size(209, 100);
            this.page_groupBox.TabIndex = 1;
            this.page_groupBox.TabStop = false;
            this.page_groupBox.Text = "Page";
            // 
            // page_size_comboBox
            // 
            this.page_size_comboBox.FormattingEnabled = true;
            this.page_size_comboBox.Location = new System.Drawing.Point(6, 19);
            this.page_size_comboBox.Name = "page_size_comboBox";
            this.page_size_comboBox.Size = new System.Drawing.Size(197, 21);
            this.page_size_comboBox.TabIndex = 0;
            this.page_size_comboBox.SelectedIndexChanged += new System.EventHandler(this.Page_size_comboBox_SelectedIndexChanged);
            // 
            // image_groupBox
            // 
            this.image_groupBox.Controls.Add(this.duplex_checkBox);
            this.image_groupBox.Controls.Add(this.autofeeder_checkBox);
            this.image_groupBox.Location = new System.Drawing.Point(13, 224);
            this.image_groupBox.Name = "image_groupBox";
            this.image_groupBox.Size = new System.Drawing.Size(209, 100);
            this.image_groupBox.TabIndex = 2;
            this.image_groupBox.TabStop = false;
            this.image_groupBox.Text = "Image";
            // 
            // duplex_checkBox
            // 
            this.duplex_checkBox.AutoSize = true;
            this.duplex_checkBox.Location = new System.Drawing.Point(6, 42);
            this.duplex_checkBox.Name = "duplex_checkBox";
            this.duplex_checkBox.Size = new System.Drawing.Size(79, 17);
            this.duplex_checkBox.TabIndex = 1;
            this.duplex_checkBox.Text = "Use duplex";
            this.duplex_checkBox.UseVisualStyleBackColor = true;
            this.duplex_checkBox.CheckedChanged += new System.EventHandler(this.Duplex_checkBox_CheckedChanged);
            // 
            // autofeeder_checkBox
            // 
            this.autofeeder_checkBox.AutoSize = true;
            this.autofeeder_checkBox.Location = new System.Drawing.Point(6, 19);
            this.autofeeder_checkBox.Name = "autofeeder_checkBox";
            this.autofeeder_checkBox.Size = new System.Drawing.Size(93, 17);
            this.autofeeder_checkBox.TabIndex = 0;
            this.autofeeder_checkBox.Text = "Use auto feed";
            this.autofeeder_checkBox.UseVisualStyleBackColor = true;
            this.autofeeder_checkBox.CheckedChanged += new System.EventHandler(this.Autofeeder_checkBox_CheckedChanged);
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(147, 336);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(66, 336);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 4;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // TWProperties
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(234, 371);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.image_groupBox);
            this.Controls.Add(this.page_groupBox);
            this.Controls.Add(this.dpi_groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TWProperties";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.dpi_groupBox.ResumeLayout(false);
            this.page_groupBox.ResumeLayout(false);
            this.image_groupBox.ResumeLayout(false);
            this.image_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox dpi_groupBox;
        private System.Windows.Forms.GroupBox page_groupBox;
        private System.Windows.Forms.GroupBox image_groupBox;
        private System.Windows.Forms.ComboBox dpi_comboBox;
        private System.Windows.Forms.ComboBox page_size_comboBox;
        private System.Windows.Forms.CheckBox duplex_checkBox;
        private System.Windows.Forms.CheckBox autofeeder_checkBox;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button ok_button;
    }
}