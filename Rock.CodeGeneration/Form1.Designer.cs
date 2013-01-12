﻿namespace Rock.CodeGeneration
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cblModels = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.fbdServiceOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.cbRest = new System.Windows.Forms.CheckBox();
            this.cbService = new System.Windows.Forms.CheckBox();
            this.ofdAssembly = new System.Windows.Forms.OpenFileDialog();
            this.fbdRestOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 381);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cblModels
            // 
            this.cblModels.FormattingEnabled = true;
            this.cblModels.Location = new System.Drawing.Point(13, 38);
            this.cblModels.Name = "cblModels";
            this.cblModels.Size = new System.Drawing.Size(361, 334);
            this.cblModels.TabIndex = 3;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(305, 19);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(70, 17);
            this.cbSelectAll.TabIndex = 4;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // fbdServiceOutput
            // 
            this.fbdServiceOutput.Description = "Select the project folder that the Service and DTO files should be added to.  The" +
    " namespace of the objects will be used to create a relative folder path if necce" +
    "ssary.";
            this.fbdServiceOutput.ShowNewFolderButton = false;
            // 
            // cbRest
            // 
            this.cbRest.AutoSize = true;
            this.cbRest.Checked = true;
            this.cbRest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRest.Location = new System.Drawing.Point(178, 385);
            this.cbRest.Name = "cbRest";
            this.cbRest.Size = new System.Drawing.Size(48, 17);
            this.cbRest.TabIndex = 6;
            this.cbRest.Text = "Rest";
            this.cbRest.UseVisualStyleBackColor = true;
            // 
            // cbService
            // 
            this.cbService.AutoSize = true;
            this.cbService.Checked = true;
            this.cbService.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbService.Location = new System.Drawing.Point(99, 385);
            this.cbService.Name = "cbService";
            this.cbService.Size = new System.Drawing.Size(62, 17);
            this.cbService.TabIndex = 7;
            this.cbService.Text = "Service";
            this.cbService.UseVisualStyleBackColor = true;
            // 
            // ofdAssembly
            // 
            this.ofdAssembly.FileName = "openFileDialog1";
            this.ofdAssembly.Title = "Assembly";
            // 
            // fbdRestOutput
            // 
            this.fbdRestOutput.Description = "Select the project folder that the Rest files should be added to.  The namespace " +
    "of the objects will be used to create a relative folder path if neccessary.";
            this.fbdRestOutput.ShowNewFolderButton = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 416);
            this.Controls.Add(this.cbService);
            this.Controls.Add(this.cbRest);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.cblModels);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckedListBox cblModels;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.FolderBrowserDialog fbdServiceOutput;
        private System.Windows.Forms.CheckBox cbRest;
        private System.Windows.Forms.CheckBox cbService;
		private System.Windows.Forms.OpenFileDialog ofdAssembly;
		private System.Windows.Forms.FolderBrowserDialog fbdRestOutput;
    }
}

