namespace MyMailClient
{
    partial class EnterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.UserPasswordBox = new System.Windows.Forms.TextBox();
            this.UserEmailBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 23);
            this.label3.TabIndex = 13;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(55, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "email";
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(58, 98);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(161, 23);
            this.EnterButton.TabIndex = 10;
            this.EnterButton.Text = "Войти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // UserPasswordBox
            // 
            this.UserPasswordBox.Location = new System.Drawing.Point(58, 64);
            this.UserPasswordBox.Name = "UserPasswordBox";
            this.UserPasswordBox.PasswordChar = '*';
            this.UserPasswordBox.Size = new System.Drawing.Size(161, 20);
            this.UserPasswordBox.TabIndex = 9;
            // 
            // UserEmailBox
            // 
            this.UserEmailBox.Location = new System.Drawing.Point(58, 25);
            this.UserEmailBox.Name = "UserEmailBox";
            this.UserEmailBox.Size = new System.Drawing.Size(161, 20);
            this.UserEmailBox.TabIndex = 8;
            // 
            // EnterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 156);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.UserPasswordBox);
            this.Controls.Add(this.UserEmailBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnterForm";
            this.Text = "Вход";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.TextBox UserPasswordBox;
        private System.Windows.Forms.TextBox UserEmailBox;
    }
}