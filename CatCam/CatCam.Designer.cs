namespace CatCam
{
    partial class CatCam
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
            this.previewPanel = new System.Windows.Forms.Panel();
            this.snapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // previewPanel
            // 
            this.previewPanel.Location = new System.Drawing.Point(204, 12);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(511, 453);
            this.previewPanel.TabIndex = 0;
            // 
            // snapButton
            // 
            this.snapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.snapButton.Location = new System.Drawing.Point(12, 12);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(163, 54);
            this.snapButton.TabIndex = 1;
            this.snapButton.Text = "Snap!";
            this.snapButton.UseVisualStyleBackColor = true;
            this.snapButton.Click += new System.EventHandler(this.snapButton_Click);
            // 
            // CatCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 477);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.previewPanel);
            this.Name = "CatCam";
            this.Text = "Harry Cam";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Button snapButton;
    }
}

