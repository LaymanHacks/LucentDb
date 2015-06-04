namespace LucentDb.Win.UI.Controls
{
    partial class ScriptGroup
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
            this.tlpScripts.AutoScrollMargin = new System.Drawing.Size(100, 100);
            this.tlpScripts.AutoSize = true;
            this.tlpScripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpScripts.ColumnCount = 1;
            this.tlpScripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpScripts.Location = new System.Drawing.Point(0, 0);
            this.tlpScripts.Name = "tlpScripts";
            this.tlpScripts.RowCount = 1;
            this.tlpScripts.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpScripts.Size = new System.Drawing.Size(687, 155);
            this.tlpScripts.TabIndex = 0;
            // 
            // ScriptGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpScripts);
            this.Name = "ScriptGroup";
            this.Size = new System.Drawing.Size(687, 155);
            this.Load += new System.EventHandler(this.ScriptGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpScripts;
    }
}
