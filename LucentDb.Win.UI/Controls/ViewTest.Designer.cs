﻿namespace LucentDb.Win.UI.Controls
{
    partial class ViewTest
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
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtScriptValue = new ICSharpCode.TextEditor.TextEditorControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssertType = new System.Windows.Forms.Label();
            this.lblAssertValue = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.isActiveCheckBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isActiveCheckBox.Location = new System.Drawing.Point(627, 3);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(14, 24);
            this.isActiveCheckBox.TabIndex = 4;
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(12, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(77, 18);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "TestName";
            // 
            // txtScriptValue
            // 
            this.txtScriptValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScriptValue.Enabled = false;
            this.txtScriptValue.IsReadOnly = false;
            this.txtScriptValue.Location = new System.Drawing.Point(15, 39);
            this.txtScriptValue.Name = "txtScriptValue";
            this.txtScriptValue.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.txtScriptValue.Size = new System.Drawing.Size(698, 92);
            this.txtScriptValue.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 89;
            this.label1.Text = "Assert.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAssertType
            // 
            this.lblAssertType.AutoSize = true;
            this.lblAssertType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssertType.Location = new System.Drawing.Point(0, 8);
            this.lblAssertType.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblAssertType.Name = "lblAssertType";
            this.lblAssertType.Size = new System.Drawing.Size(85, 16);
            this.lblAssertType.TabIndex = 90;
            this.lblAssertType.Text = "lblAssertType";
            this.lblAssertType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAssertValue
            // 
            this.lblAssertValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAssertValue.AutoSize = true;
            this.lblAssertValue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAssertValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAssertValue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssertValue.Location = new System.Drawing.Point(85, 5);
            this.lblAssertValue.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblAssertValue.Name = "lblAssertValue";
            this.lblAssertValue.Padding = new System.Windows.Forms.Padding(3);
            this.lblAssertValue.Size = new System.Drawing.Size(97, 24);
            this.lblAssertValue.TabIndex = 91;
            this.lblAssertValue.Text = "lblAssertValue";
            this.lblAssertValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.SystemColors.Control;
            this.btnRun.Location = new System.Drawing.Point(644, 142);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 92;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.lblAssertType);
            this.flowLayoutPanel1.Controls.Add(this.lblAssertValue);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(57, 133);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 31);
            this.flowLayoutPanel1.TabIndex = 94;
            // 
            // ViewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtScriptValue);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ViewTest";
            this.Size = new System.Drawing.Size(727, 176);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.Label lblName;
        internal ICSharpCode.TextEditor.TextEditorControl txtScriptValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssertType;
        private System.Windows.Forms.Label lblAssertValue;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
