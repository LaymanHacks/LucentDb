namespace LucentDb.Win.UI.Controls
{
    partial class ViewProjectTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTestName = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.scriptGroup = new LucentDb.Win.UI.Controls.ScriptGroup();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTestName);
            this.panel1.Controls.Add(this.lblProjectName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 59);
            this.panel1.TabIndex = 1;
            // 
            // lblTestName
            // 
            this.lblTestName.AutoSize = true;
            this.lblTestName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestName.Location = new System.Drawing.Point(26, 30);
            this.lblTestName.Name = "lblTestName";
            this.lblTestName.Size = new System.Drawing.Size(77, 18);
            this.lblTestName.TabIndex = 1;
            this.lblTestName.Text = "TestName";
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.Location = new System.Drawing.Point(13, 11);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(115, 19);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "ProjectName";
            // 
            // scriptGroup
            // 
            this.scriptGroup.DataSource = null;
            this.scriptGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptGroup.Location = new System.Drawing.Point(0, 59);
            this.scriptGroup.Name = "scriptGroup";
            this.scriptGroup.Size = new System.Drawing.Size(914, 405);
            this.scriptGroup.TabIndex = 2;
            // 
            // ViewProjectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scriptGroup);
            this.Controls.Add(this.panel1);
            this.Name = "ViewProjectTest";
            this.Size = new System.Drawing.Size(914, 464);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTestName;
        private System.Windows.Forms.Label lblProjectName;
        private ScriptGroup scriptGroup;
    }
}
