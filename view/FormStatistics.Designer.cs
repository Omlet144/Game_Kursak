namespace Game_Kursak.view
{
    partial class FormStatistics
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
            this.button_Refresh = new System.Windows.Forms.Button();
            this.dataGridView_local_results = new System.Windows.Forms.DataGridView();
            this.dataGridView_network_results = new System.Windows.Forms.DataGridView();
            this.label_Your_results = new System.Windows.Forms.Label();
            this.label_Rating_results = new System.Windows.Forms.Label();
            this.button_Back_to_Menu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_local_results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_network_results)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(669, 378);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(144, 72);
            this.button_Refresh.TabIndex = 0;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_local_results
            // 
            this.dataGridView_local_results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_local_results.Location = new System.Drawing.Point(12, 67);
            this.dataGridView_local_results.Name = "dataGridView_local_results";
            this.dataGridView_local_results.Size = new System.Drawing.Size(468, 278);
            this.dataGridView_local_results.TabIndex = 1;
            // 
            // dataGridView_network_results
            // 
            this.dataGridView_network_results.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_network_results.Location = new System.Drawing.Point(504, 67);
            this.dataGridView_network_results.Name = "dataGridView_network_results";
            this.dataGridView_network_results.Size = new System.Drawing.Size(468, 278);
            this.dataGridView_network_results.TabIndex = 2;
            // 
            // label_Your_results
            // 
            this.label_Your_results.AutoSize = true;
            this.label_Your_results.Location = new System.Drawing.Point(218, 38);
            this.label_Your_results.Name = "label_Your_results";
            this.label_Your_results.Size = new System.Drawing.Size(65, 13);
            this.label_Your_results.TabIndex = 3;
            this.label_Your_results.Text = "Your results:";
            // 
            // label_Rating_results
            // 
            this.label_Rating_results.AutoSize = true;
            this.label_Rating_results.Location = new System.Drawing.Point(710, 38);
            this.label_Rating_results.Name = "label_Rating_results";
            this.label_Rating_results.Size = new System.Drawing.Size(74, 13);
            this.label_Rating_results.TabIndex = 4;
            this.label_Rating_results.Text = "Rating results:";
            // 
            // button_Back_to_Menu
            // 
            this.button_Back_to_Menu.Location = new System.Drawing.Point(189, 378);
            this.button_Back_to_Menu.Name = "button_Back_to_Menu";
            this.button_Back_to_Menu.Size = new System.Drawing.Size(144, 72);
            this.button_Back_to_Menu.TabIndex = 5;
            this.button_Back_to_Menu.Text = "Back to Menu";
            this.button_Back_to_Menu.UseVisualStyleBackColor = true;
            this.button_Back_to_Menu.Click += new System.EventHandler(this.button_Back_to_Menu_Click);
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.button_Back_to_Menu);
            this.Controls.Add(this.label_Rating_results);
            this.Controls.Add(this.label_Your_results);
            this.Controls.Add(this.dataGridView_network_results);
            this.Controls.Add(this.dataGridView_local_results);
            this.Controls.Add(this.button_Refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormStatistics";
            this.Text = "FormStatistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_local_results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_network_results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DataGridView dataGridView_local_results;
        private System.Windows.Forms.DataGridView dataGridView_network_results;
        private System.Windows.Forms.Label label_Your_results;
        private System.Windows.Forms.Label label_Rating_results;
        private System.Windows.Forms.Button button_Back_to_Menu;
    }
}