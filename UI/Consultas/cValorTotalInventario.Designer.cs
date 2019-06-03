namespace Parcial1_JuanRosa.UI.Consultas
{
    partial class cValorTotalInventario
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
            this.label1 = new System.Windows.Forms.Label();
            this.ValorTextBox = new System.Windows.Forms.TextBox();
            this.RefresacrButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Total del Inventario";
            // 
            // ValorTextBox
            // 
            this.ValorTextBox.Location = new System.Drawing.Point(16, 37);
            this.ValorTextBox.Name = "ValorTextBox";
            this.ValorTextBox.ReadOnly = true;
            this.ValorTextBox.Size = new System.Drawing.Size(213, 20);
            this.ValorTextBox.TabIndex = 1;
            // 
            // RefresacrButton
            // 
            this.RefresacrButton.BackColor = System.Drawing.SystemColors.Control;
            this.RefresacrButton.Image = global::Parcial1_JuanRosa.Properties.Resources.refresh_arrow_1546__1_;
            this.RefresacrButton.Location = new System.Drawing.Point(246, 28);
            this.RefresacrButton.Name = "RefresacrButton";
            this.RefresacrButton.Size = new System.Drawing.Size(44, 36);
            this.RefresacrButton.TabIndex = 2;
            this.RefresacrButton.UseVisualStyleBackColor = false;
            this.RefresacrButton.Click += new System.EventHandler(this.RefresacrButton_Click);
            // 
            // cValorTotalInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 84);
            this.Controls.Add(this.RefresacrButton);
            this.Controls.Add(this.ValorTextBox);
            this.Controls.Add(this.label1);
            this.Name = "cValorTotalInventario";
            this.Text = "cValorTotalInventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ValorTextBox;
        private System.Windows.Forms.Button RefresacrButton;
    }
}