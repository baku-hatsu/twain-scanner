namespace TWAIN
{
    partial class TWSelectDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TWSelectDevice));
            this.cancel_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.header_label = new System.Windows.Forms.Label();
            this.selection_listView = new System.Windows.Forms.ListView();
            this.selection_imageList = new System.Windows.Forms.ImageList(this.components);
            this.properties_groupBox = new System.Windows.Forms.GroupBox();
            this.properties_button = new System.Windows.Forms.Button();
            this.name_data_label = new System.Windows.Forms.Label();
            this.description_data_label = new System.Windows.Forms.Label();
            this.manufacturer_data_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.description_label = new System.Windows.Forms.Label();
            this.manufacturer_label = new System.Windows.Forms.Label();
            this.properties_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(397, 256);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 10;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // ok_button
            // 
            this.ok_button.Enabled = false;
            this.ok_button.Location = new System.Drawing.Point(316, 256);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(75, 23);
            this.ok_button.TabIndex = 11;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // header_label
            // 
            this.header_label.AutoSize = true;
            this.header_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header_label.Location = new System.Drawing.Point(12, 9);
            this.header_label.Name = "header_label";
            this.header_label.Size = new System.Drawing.Size(298, 24);
            this.header_label.TabIndex = 0;
            this.header_label.Text = "Which device do you want to use?";
            // 
            // selection_listView
            // 
            this.selection_listView.HideSelection = false;
            this.selection_listView.LargeImageList = this.selection_imageList;
            this.selection_listView.Location = new System.Drawing.Point(12, 36);
            this.selection_listView.MultiSelect = false;
            this.selection_listView.Name = "selection_listView";
            this.selection_listView.Size = new System.Drawing.Size(460, 110);
            this.selection_listView.TabIndex = 1;
            this.selection_listView.TileSize = new System.Drawing.Size(50, 50);
            this.selection_listView.UseCompatibleStateImageBehavior = false;
            this.selection_listView.SelectedIndexChanged += new System.EventHandler(this.Selection_listView_SelectedIndexChanged);
            this.selection_listView.DoubleClick += new System.EventHandler(this.Ok_button_Click);
            // 
            // selection_imageList
            // 
            this.selection_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("selection_imageList.ImageStream")));
            this.selection_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.selection_imageList.Images.SetKeyName(0, "scanner_adf.ico");
            this.selection_imageList.Images.SetKeyName(1, "generic_scanner.ico");
            // 
            // properties_groupBox
            // 
            this.properties_groupBox.Controls.Add(this.properties_button);
            this.properties_groupBox.Controls.Add(this.name_data_label);
            this.properties_groupBox.Controls.Add(this.description_data_label);
            this.properties_groupBox.Controls.Add(this.manufacturer_data_label);
            this.properties_groupBox.Controls.Add(this.name_label);
            this.properties_groupBox.Controls.Add(this.description_label);
            this.properties_groupBox.Controls.Add(this.manufacturer_label);
            this.properties_groupBox.Location = new System.Drawing.Point(12, 152);
            this.properties_groupBox.Name = "properties_groupBox";
            this.properties_groupBox.Size = new System.Drawing.Size(460, 98);
            this.properties_groupBox.TabIndex = 2;
            this.properties_groupBox.TabStop = false;
            this.properties_groupBox.Text = "Properties";
            // 
            // properties_button
            // 
            this.properties_button.Enabled = false;
            this.properties_button.Location = new System.Drawing.Point(379, 37);
            this.properties_button.Name = "properties_button";
            this.properties_button.Size = new System.Drawing.Size(75, 23);
            this.properties_button.TabIndex = 9;
            this.properties_button.Text = "Properties";
            this.properties_button.UseVisualStyleBackColor = true;
            this.properties_button.Click += new System.EventHandler(this.Properties_button_Click);
            // 
            // name_data_label
            // 
            this.name_data_label.AutoSize = true;
            this.name_data_label.Location = new System.Drawing.Point(86, 61);
            this.name_data_label.Name = "name_data_label";
            this.name_data_label.Size = new System.Drawing.Size(10, 13);
            this.name_data_label.TabIndex = 8;
            this.name_data_label.Text = " ";
            // 
            // description_data_label
            // 
            this.description_data_label.AutoSize = true;
            this.description_data_label.Location = new System.Drawing.Point(86, 42);
            this.description_data_label.Name = "description_data_label";
            this.description_data_label.Size = new System.Drawing.Size(10, 13);
            this.description_data_label.TabIndex = 6;
            this.description_data_label.Text = " ";
            // 
            // manufacturer_data_label
            // 
            this.manufacturer_data_label.AutoSize = true;
            this.manufacturer_data_label.Location = new System.Drawing.Point(86, 23);
            this.manufacturer_data_label.Name = "manufacturer_data_label";
            this.manufacturer_data_label.Size = new System.Drawing.Size(10, 13);
            this.manufacturer_data_label.TabIndex = 4;
            this.manufacturer_data_label.Text = " ";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(7, 61);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(38, 13);
            this.name_label.TabIndex = 7;
            this.name_label.Text = "Name:";
            // 
            // description_label
            // 
            this.description_label.AutoSize = true;
            this.description_label.Location = new System.Drawing.Point(7, 42);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(63, 13);
            this.description_label.TabIndex = 5;
            this.description_label.Text = "Description:";
            // 
            // manufacturer_label
            // 
            this.manufacturer_label.AutoSize = true;
            this.manufacturer_label.Location = new System.Drawing.Point(7, 23);
            this.manufacturer_label.Name = "manufacturer_label";
            this.manufacturer_label.Size = new System.Drawing.Size(73, 13);
            this.manufacturer_label.TabIndex = 3;
            this.manufacturer_label.Text = "Manufacturer:";
            // 
            // TWSelectDevice
            // 
            this.AcceptButton = this.ok_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(484, 291);
            this.Controls.Add(this.properties_groupBox);
            this.Controls.Add(this.selection_listView);
            this.Controls.Add(this.header_label);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.cancel_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TWSelectDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Device";
            this.properties_groupBox.ResumeLayout(false);
            this.properties_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Label header_label;
        private System.Windows.Forms.ListView selection_listView;
        private System.Windows.Forms.ImageList selection_imageList;
        private System.Windows.Forms.GroupBox properties_groupBox;
        private System.Windows.Forms.Label name_data_label;
        private System.Windows.Forms.Label description_data_label;
        private System.Windows.Forms.Label manufacturer_data_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.Label manufacturer_label;
        private System.Windows.Forms.Button properties_button;
    }
}

