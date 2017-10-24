namespace SubmitHub_Automation
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
            this.ResumeCampaign = new System.Windows.Forms.Button();
            this.BlogsSubmittedTo = new System.Windows.Forms.Label();
            this.BlogSentCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ResumeCampaign
            // 
            this.ResumeCampaign.Location = new System.Drawing.Point(15, 255);
            this.ResumeCampaign.Name = "ResumeCampaign";
            this.ResumeCampaign.Size = new System.Drawing.Size(114, 23);
            this.ResumeCampaign.TabIndex = 0;
            this.ResumeCampaign.Text = "Resume Campaign";
            this.ResumeCampaign.UseVisualStyleBackColor = true;
            this.ResumeCampaign.Click += new System.EventHandler(this.ResumeCampaign_Click);
            // 
            // BlogsSubmittedTo
            // 
            this.BlogsSubmittedTo.AutoSize = true;
            this.BlogsSubmittedTo.Location = new System.Drawing.Point(13, 13);
            this.BlogsSubmittedTo.Name = "BlogsSubmittedTo";
            this.BlogsSubmittedTo.Size = new System.Drawing.Size(77, 13);
            this.BlogsSubmittedTo.TabIndex = 1;
            this.BlogsSubmittedTo.Text = "Blogs Sent To:";
            // 
            // BlogSentCounter
            // 
            this.BlogSentCounter.AutoSize = true;
            this.BlogSentCounter.Location = new System.Drawing.Point(93, 13);
            this.BlogSentCounter.Name = "BlogSentCounter";
            this.BlogSentCounter.Size = new System.Drawing.Size(0, 13);
            this.BlogSentCounter.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 290);
            this.Controls.Add(this.BlogSentCounter);
            this.Controls.Add(this.BlogsSubmittedTo);
            this.Controls.Add(this.ResumeCampaign);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ResumeCampaign;
        private System.Windows.Forms.Label BlogsSubmittedTo;
        private System.Windows.Forms.Label BlogSentCounter;
    }
}

