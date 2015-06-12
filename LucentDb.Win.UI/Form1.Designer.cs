namespace LucentDb.Win.UI
{
    partial class Form1
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
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.scriptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewProjectTest1 = new LucentDb.Win.UI.Controls.ViewProject();
            ((System.ComponentModel.ISupportInitialize)(this.scriptBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProjects
            // 
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(12, 12);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(155, 21);
            this.cboProjects.TabIndex = 0;
            this.cboProjects.SelectionChangeCommitted += new System.EventHandler(this.cboProjects_SelectedIndexChanged);
            // 
            // scriptBindingSource
            // 
            this.scriptBindingSource.DataSource = typeof(LucentDb.Domain.Entities.Test);
            // 
            // viewProjectTest1
            // 
            this.viewProjectTest1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewProjectTest1.DataSource = null;
            this.viewProjectTest1.Location = new System.Drawing.Point(214, 3);
            this.viewProjectTest1.Name = "viewProjectTest1";
            this.viewProjectTest1.Size = new System.Drawing.Size(1007, 481);
            this.viewProjectTest1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 484);
            this.Controls.Add(this.viewProjectTest1);
            this.Controls.Add(this.cboProjects);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scriptBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.BindingSource scriptBindingSource;
        private Controls.ViewProject viewProjectTest1;
    }
}

