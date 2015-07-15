namespace LucentDb.Win.UI.Controls
{
    partial class TestList
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
            this.tlpScripts = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tlpScripts
            // 
            this.tlpScripts.AutoScroll = true;
            this.tlpScripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpScripts.ColumnCount = 1;
            this.tlpScripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScripts.Location = new System.Drawing.Point(0, 0);
            this.tlpScripts.Name = "tlpScripts";
            this.tlpScripts.RowCount = 1;
            this.tlpScripts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpScripts.Size = new System.Drawing.Size(563, 288);
            this.tlpScripts.TabIndex = 0;
            // 
            // TestList
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.tlpScripts);
            this.Name = "TestList";
            this.Size = new System.Drawing.Size(563, 288);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpScripts;

    }
}
