namespace TI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.railCipherCheck = new System.Windows.Forms.CheckBox();
            this.VisionerCheck = new System.Windows.Forms.CheckBox();
            this.PlayfairCheck = new System.Windows.Forms.CheckBox();
            this.EncryptBtn = new System.Windows.Forms.Button();
            this.DecryptBtn = new System.Windows.Forms.Button();
            this.keyEnter = new System.Windows.Forms.TextBox();
            this.startTextEnter = new System.Windows.Forms.RichTextBox();
            this.cipherText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.addPlainBtn = new System.Windows.Forms.Button();
            this.addCipherBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // railCipherCheck
            // 
            this.railCipherCheck.AutoSize = true;
            this.railCipherCheck.Location = new System.Drawing.Point(58, 23);
            this.railCipherCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.railCipherCheck.Name = "railCipherCheck";
            this.railCipherCheck.Size = new System.Drawing.Size(233, 24);
            this.railCipherCheck.TabIndex = 0;
            this.railCipherCheck.Text = "Железнодорожная изгородь";
            this.railCipherCheck.UseVisualStyleBackColor = true;
            this.railCipherCheck.CheckedChanged += new System.EventHandler(this.railCipherCheck_CheckedChanged);
            // 
            // VisionerCheck
            // 
            this.VisionerCheck.AutoSize = true;
            this.VisionerCheck.Location = new System.Drawing.Point(58, 66);
            this.VisionerCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.VisionerCheck.Name = "VisionerCheck";
            this.VisionerCheck.Size = new System.Drawing.Size(148, 24);
            this.VisionerCheck.TabIndex = 1;
            this.VisionerCheck.Text = "Шифр Виженера";
            this.VisionerCheck.UseVisualStyleBackColor = true;
            this.VisionerCheck.CheckedChanged += new System.EventHandler(this.VisionerCheck_CheckedChanged);
            // 
            // PlayfairCheck
            // 
            this.PlayfairCheck.AutoSize = true;
            this.PlayfairCheck.Location = new System.Drawing.Point(58, 105);
            this.PlayfairCheck.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlayfairCheck.Name = "PlayfairCheck";
            this.PlayfairCheck.Size = new System.Drawing.Size(157, 24);
            this.PlayfairCheck.TabIndex = 2;
            this.PlayfairCheck.Text = "Шифр Плейфейра";
            this.PlayfairCheck.UseVisualStyleBackColor = true;
            this.PlayfairCheck.CheckedChanged += new System.EventHandler(this.PlayfairCheck_CheckedChanged);
            // 
            // EncryptBtn
            // 
            this.EncryptBtn.Location = new System.Drawing.Point(318, 23);
            this.EncryptBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EncryptBtn.Name = "EncryptBtn";
            this.EncryptBtn.Size = new System.Drawing.Size(147, 27);
            this.EncryptBtn.TabIndex = 3;
            this.EncryptBtn.Text = "Шифровать";
            this.EncryptBtn.UseVisualStyleBackColor = true;
            this.EncryptBtn.Click += new System.EventHandler(this.EncryptBtn_Click);
            // 
            // DecryptBtn
            // 
            this.DecryptBtn.Location = new System.Drawing.Point(318, 66);
            this.DecryptBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DecryptBtn.Name = "DecryptBtn";
            this.DecryptBtn.Size = new System.Drawing.Size(147, 27);
            this.DecryptBtn.TabIndex = 4;
            this.DecryptBtn.Text = "Дешифровать";
            this.DecryptBtn.UseVisualStyleBackColor = true;
            this.DecryptBtn.Click += new System.EventHandler(this.DecryptBtn_Click);
            // 
            // keyEnter
            // 
            this.keyEnter.Location = new System.Drawing.Point(318, 105);
            this.keyEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.keyEnter.Name = "keyEnter";
            this.keyEnter.PlaceholderText = "Ключ";
            this.keyEnter.Size = new System.Drawing.Size(148, 27);
            this.keyEnter.TabIndex = 5;
            this.keyEnter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.keyEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyEnter_KeyPress);
            // 
            // startTextEnter
            // 
            this.startTextEnter.Location = new System.Drawing.Point(58, 161);
            this.startTextEnter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startTextEnter.Name = "startTextEnter";
            this.startTextEnter.Size = new System.Drawing.Size(236, 168);
            this.startTextEnter.TabIndex = 7;
            this.startTextEnter.Text = "";
            this.startTextEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.startTextEnter_KeyPress);
            // 
            // cipherText
            // 
            this.cipherText.Location = new System.Drawing.Point(360, 161);
            this.cipherText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cipherText.Name = "cipherText";
            this.cipherText.Size = new System.Drawing.Size(235, 168);
            this.cipherText.TabIndex = 8;
            this.cipherText.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 138);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Исходный текст";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Зашифрованный текст";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // addPlainBtn
            // 
            this.addPlainBtn.Location = new System.Drawing.Point(58, 333);
            this.addPlainBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addPlainBtn.Name = "addPlainBtn";
            this.addPlainBtn.Size = new System.Drawing.Size(90, 27);
            this.addPlainBtn.TabIndex = 11;
            this.addPlainBtn.Text = "Добавить";
            this.addPlainBtn.UseVisualStyleBackColor = true;
            this.addPlainBtn.Click += new System.EventHandler(this.addPlainBtn_Click);
            // 
            // addCipherBtn
            // 
            this.addCipherBtn.Location = new System.Drawing.Point(505, 333);
            this.addCipherBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addCipherBtn.Name = "addCipherBtn";
            this.addCipherBtn.Size = new System.Drawing.Size(90, 27);
            this.addCipherBtn.TabIndex = 12;
            this.addCipherBtn.Text = "Добавить";
            this.addCipherBtn.UseVisualStyleBackColor = true;
            this.addCipherBtn.Click += new System.EventHandler(this.addCipherBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 373);
            this.Controls.Add(this.addCipherBtn);
            this.Controls.Add(this.addPlainBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cipherText);
            this.Controls.Add(this.startTextEnter);
            this.Controls.Add(this.keyEnter);
            this.Controls.Add(this.DecryptBtn);
            this.Controls.Add(this.EncryptBtn);
            this.Controls.Add(this.PlayfairCheck);
            this.Controls.Add(this.VisionerCheck);
            this.Controls.Add(this.railCipherCheck);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox railCipherCheck;
        private CheckBox VisionerCheck;
        private CheckBox PlayfairCheck;
        private Button EncryptBtn;
        private Button DecryptBtn;
        private TextBox keyEnter;
        private RichTextBox startTextEnter;
        private RichTextBox cipherText;
        private Label label1;
        private Label label2;
        private OpenFileDialog openFileDialog1;
        private Button addPlainBtn;
        private Button addCipherBtn;
    }
}