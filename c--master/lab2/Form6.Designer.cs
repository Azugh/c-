namespace lab2
{
    partial class Form6
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.stepUpButton = new System.Windows.Forms.Button();
            this.stepDownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(460, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(139, 43);
            this.deleteButton.TabIndex = 0;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(605, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(139, 43);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(460, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(139, 43);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(605, 110);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(139, 43);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "Ок";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // stepUpButton
            // 
            this.stepUpButton.Location = new System.Drawing.Point(605, 61);
            this.stepUpButton.Name = "stepUpButton";
            this.stepUpButton.Size = new System.Drawing.Size(139, 43);
            this.stepUpButton.TabIndex = 4;
            this.stepUpButton.Text = "Шаг вверх";
            this.stepUpButton.UseVisualStyleBackColor = true;
            this.stepUpButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // stepDownButton
            // 
            this.stepDownButton.Location = new System.Drawing.Point(460, 110);
            this.stepDownButton.Name = "stepDownButton";
            this.stepDownButton.Size = new System.Drawing.Size(139, 43);
            this.stepDownButton.TabIndex = 5;
            this.stepDownButton.Text = "Шаг вниз";
            this.stepDownButton.UseVisualStyleBackColor = true;
            this.stepDownButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 286);
            this.Controls.Add(this.stepDownButton);
            this.Controls.Add(this.stepUpButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Name = "Form6";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button stepUpButton;
        private System.Windows.Forms.Button stepDownButton;
    }
}