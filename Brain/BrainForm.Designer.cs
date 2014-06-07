namespace Brainspace
{
    partial class BrainForm
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
            this.btnZero = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFitness = new System.Windows.Forms.Label();
            this.lblMature = new System.Windows.Forms.Label();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(13, 13);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(75, 23);
            this.btnZero.TabIndex = 0;
            this.btnZero.Text = "Zero";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZeroClick);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(13, 43);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 13);
            this.lblResult.TabIndex = 1;
            this.lblResult.Text = "lblResult";
            // 
            // lblFitness
            // 
            this.lblFitness.AutoSize = true;
            this.lblFitness.Location = new System.Drawing.Point(13, 67);
            this.lblFitness.Name = "lblFitness";
            this.lblFitness.Size = new System.Drawing.Size(40, 13);
            this.lblFitness.TabIndex = 2;
            this.lblFitness.Text = "Fitness";
            // 
            // lblMature
            // 
            this.lblMature.AutoSize = true;
            this.lblMature.Location = new System.Drawing.Point(13, 91);
            this.lblMature.Name = "lblMature";
            this.lblMature.Size = new System.Drawing.Size(40, 13);
            this.lblMature.TabIndex = 3;
            this.lblMature.Text = "Mature";
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(94, 12);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(75, 23);
            this.btnOne.TabIndex = 4;
            this.btnOne.Text = "One";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOneClick);
            // 
            // btnFour
            // 
            this.btnFour.Location = new System.Drawing.Point(337, 12);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(75, 23);
            this.btnFour.TabIndex = 5;
            this.btnFour.Text = "Four";
            this.btnFour.UseVisualStyleBackColor = true;
            this.btnFour.Click += new System.EventHandler(this.btnFourClick);
            // 
            // btnThree
            // 
            this.btnThree.Location = new System.Drawing.Point(256, 12);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(75, 23);
            this.btnThree.TabIndex = 6;
            this.btnThree.Text = "Three";
            this.btnThree.UseVisualStyleBackColor = true;
            this.btnThree.Click += new System.EventHandler(this.btnThreeClick);
            // 
            // btnTwo
            // 
            this.btnTwo.Location = new System.Drawing.Point(175, 13);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(75, 23);
            this.btnTwo.TabIndex = 7;
            this.btnTwo.Text = "Two";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.btnTwoClick);
            // 
            // BrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 219);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.btnThree);
            this.Controls.Add(this.btnFour);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.lblMature);
            this.Controls.Add(this.lblFitness);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnZero);
            this.Name = "BrainForm";
            this.Text = "Brain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblFitness;
        private System.Windows.Forms.Label lblMature;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnTwo;
    }
}

