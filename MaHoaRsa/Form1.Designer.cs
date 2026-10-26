namespace MaHoaRsa
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeyInfo = new System.Windows.Forms.TextBox();
            this.btnLoadKey = new System.Windows.Forms.Button();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.btnViewPem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHash = new System.Windows.Forms.Button();
            this.btnDecryptText = new System.Windows.Forms.Button();
            this.btnEncryptText = new System.Windows.Forms.Button();
            this.txtCipherText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.btnSign = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKeyInfo);
            this.groupBox1.Controls.Add(this.btnViewPem);
            this.groupBox1.Controls.Add(this.btnLoadKey);
            this.groupBox1.Controls.Add(this.btnSaveKey);
            this.groupBox1.Controls.Add(this.btnGenerateKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Quản lý Cặp khóa RSA (Key Management)";
            // 
            // txtKeyInfo
            // 
            this.txtKeyInfo.Location = new System.Drawing.Point(330, 22);
            this.txtKeyInfo.Multiline = true;
            this.txtKeyInfo.Name = "txtKeyInfo";
            this.txtKeyInfo.ReadOnly = true;
            this.txtKeyInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyInfo.Size = new System.Drawing.Size(464, 75);
            this.txtKeyInfo.TabIndex = 4;
            // 
            // btnViewPem
            // 
            this.btnViewPem.Location = new System.Drawing.Point(164, 62);
            this.btnViewPem.Name = "btnViewPem";
            this.btnViewPem.Size = new System.Drawing.Size(150, 31);
            this.btnViewPem.TabIndex = 3;
            this.btnViewPem.Text = "Xem Cấu Trúc PEM";
            this.btnViewPem.UseVisualStyleBackColor = true;
            this.btnViewPem.Click += new System.EventHandler(this.btnViewPem_Click);
            // 
            // btnLoadKey
            // 
            this.btnLoadKey.Location = new System.Drawing.Point(8, 62);
            this.btnLoadKey.Name = "btnLoadKey";
            this.btnLoadKey.Size = new System.Drawing.Size(150, 31);
            this.btnLoadKey.TabIndex = 2;
            this.btnLoadKey.Text = "Import Khóa PEM...";
            this.btnLoadKey.UseVisualStyleBackColor = true;
            this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.Location = new System.Drawing.Point(164, 22);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(150, 31);
            this.btnSaveKey.TabIndex = 1;
            this.btnSaveKey.Text = "Xuất Khóa ra File";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(8, 22);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(150, 31);
            this.btnGenerateKey.TabIndex = 0;
            this.btnGenerateKey.Text = "Sinh Khóa (RSA-2048)";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHash);
            this.groupBox2.Controls.Add(this.btnDecryptText);
            this.groupBox2.Controls.Add(this.btnEncryptText);
            this.groupBox2.Controls.Add(this.txtCipherText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPlainText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 185);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Mã hóa / Giải mã Văn bản & Hàm băm SHA-256";
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(390, 148);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(130, 28);
            this.btnHash.TabIndex = 6;
            this.btnHash.Text = "Băm SHA-256";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // btnDecryptText
            // 
            this.btnDecryptText.Location = new System.Drawing.Point(250, 148);
            this.btnDecryptText.Name = "btnDecryptText";
            this.btnDecryptText.Size = new System.Drawing.Size(130, 28);
            this.btnDecryptText.TabIndex = 5;
            this.btnDecryptText.Text = "Giải mã RSA";
            this.btnDecryptText.UseVisualStyleBackColor = true;
            this.btnDecryptText.Click += new System.EventHandler(this.btnDecryptText_Click);
            // 
            // btnEncryptText
            // 
            this.btnEncryptText.Location = new System.Drawing.Point(110, 148);
            this.btnEncryptText.Name = "btnEncryptText";
            this.btnEncryptText.Size = new System.Drawing.Size(130, 28);
            this.btnEncryptText.TabIndex = 4;
            this.btnEncryptText.Text = "Mã hóa RSA";
            this.btnEncryptText.UseVisualStyleBackColor = true;
            this.btnEncryptText.Click += new System.EventHandler(this.btnEncryptText_Click);
            // 
            // txtCipherText
            // 
            this.txtCipherText.Location = new System.Drawing.Point(110, 85);
            this.txtCipherText.Multiline = true;
            this.txtCipherText.Name = "txtCipherText";
            this.txtCipherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCipherText.Size = new System.Drawing.Size(684, 55);
            this.txtCipherText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kết quả (B64/Hash):";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(110, 22);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlainText.Size = new System.Drawing.Size(684, 55);
            this.txtPlainText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Văn bản (Plaintext):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.btnBenchmark);
            this.groupBox3.Controls.Add(this.btnSign);
            this.groupBox3.Location = new System.Drawing.Point(12, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(810, 280);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Chữ ký số RSA-PSS & Đánh giá Hiệu năng";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(11, 95);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(783, 170);
            this.txtLog.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 65);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(783, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // btnBenchmark
            // 
            this.btnBenchmark.Location = new System.Drawing.Point(170, 25);
            this.btnBenchmark.Name = "btnBenchmark";
            this.btnBenchmark.Size = new System.Drawing.Size(150, 30);
            this.btnBenchmark.TabIndex = 1;
            this.btnBenchmark.Text = "Đánh giá Tốc độ";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(11, 25);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(150, 30);
            this.btnSign.TabIndex = 0;
            this.btnSign.Text = "Chữ ký số RSA-PSS";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 615);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Mã Hóa RSA và Chữ Ký Số - An Toàn Bảo Mật Thông Tin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Button btnLoadKey;
        private System.Windows.Forms.Button btnViewPem;
        private System.Windows.Forms.TextBox txtKeyInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCipherText;
        private System.Windows.Forms.Button btnEncryptText;
        private System.Windows.Forms.Button btnDecryptText;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtLog;
    }
}