namespace MaHoaAes
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDecryptText = new System.Windows.Forms.Button();
            this.btnEncryptText = new System.Windows.Forms.Button();
            this.txtCipherText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlainText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCompareResult = new System.Windows.Forms.Label();
            this.btnCompareFile = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDecryptFile = new System.Windows.Forms.Button();
            this.btnEncryptFile = new System.Windows.Forms.Button();
            this.btnBrowseDest = new System.Windows.Forms.Button();
            this.txtDestFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtSourceFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKeyInfo);
            this.groupBox1.Controls.Add(this.btnLoadKey);
            this.groupBox1.Controls.Add(this.btnSaveKey);
            this.groupBox1.Controls.Add(this.btnGenerateKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Quản lý khóa AES (Key & IV)";
            // 
            // txtKeyInfo
            // 
            this.txtKeyInfo.Location = new System.Drawing.Point(340, 22);
            this.txtKeyInfo.Multiline = true;
            this.txtKeyInfo.Name = "txtKeyInfo";
            this.txtKeyInfo.ReadOnly = true;
            this.txtKeyInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyInfo.Size = new System.Drawing.Size(454, 60);
            this.txtKeyInfo.TabIndex = 3;
            // 
            // btnLoadKey
            // 
            this.btnLoadKey.Location = new System.Drawing.Point(220, 59);
            this.btnLoadKey.Name = "btnLoadKey";
            this.btnLoadKey.Size = new System.Drawing.Size(100, 25);
            this.btnLoadKey.TabIndex = 2;
            this.btnLoadKey.Text = "Import Khóa...";
            this.btnLoadKey.UseVisualStyleBackColor = true;
            this.btnLoadKey.Click += new System.EventHandler(this.btnLoadKey_Click);
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.Location = new System.Drawing.Point(114, 59);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(100, 25);
            this.btnSaveKey.TabIndex = 1;
            this.btnSaveKey.Text = "Lưu Khóa ra File";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(8, 22);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(306, 31);
            this.btnGenerateKey.TabIndex = 0;
            this.btnGenerateKey.Text = "Sinh Khóa Mới (AES-256)";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecryptText);
            this.groupBox2.Controls.Add(this.btnEncryptText);
            this.groupBox2.Controls.Add(this.txtCipherText);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPlainText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 160);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Mã hóa / Giải mã Văn bản";
            // 
            // btnDecryptText
            // 
            this.btnDecryptText.Location = new System.Drawing.Point(408, 125);
            this.btnDecryptText.Name = "btnDecryptText";
            this.btnDecryptText.Size = new System.Drawing.Size(110, 25);
            this.btnDecryptText.TabIndex = 5;
            this.btnDecryptText.Text = "Giải mã Văn bản";
            this.btnDecryptText.UseVisualStyleBackColor = true;
            this.btnDecryptText.Click += new System.EventHandler(this.btnDecryptText_Click);
            // 
            // btnEncryptText
            // 
            this.btnEncryptText.Location = new System.Drawing.Point(292, 125);
            this.btnEncryptText.Name = "btnEncryptText";
            this.btnEncryptText.Size = new System.Drawing.Size(110, 25);
            this.btnEncryptText.TabIndex = 4;
            this.btnEncryptText.Text = "Mã hóa Văn bản";
            this.btnEncryptText.UseVisualStyleBackColor = true;
            this.btnEncryptText.Click += new System.EventHandler(this.btnEncryptText_Click);
            // 
            // txtCipherText
            // 
            this.txtCipherText.Location = new System.Drawing.Point(100, 72);
            this.txtCipherText.Multiline = true;
            this.txtCipherText.Name = "txtCipherText";
            this.txtCipherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCipherText.Size = new System.Drawing.Size(694, 47);
            this.txtCipherText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kết quả (B64):";
            // 
            // txtPlainText
            // 
            this.txtPlainText.Location = new System.Drawing.Point(100, 19);
            this.txtPlainText.Multiline = true;
            this.txtPlainText.Name = "txtPlainText";
            this.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlainText.Size = new System.Drawing.Size(694, 47);
            this.txtPlainText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Văn bản (Plaintext):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCompareResult);
            this.groupBox3.Controls.Add(this.btnCompareFile);
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.btnDecryptFile);
            this.groupBox3.Controls.Add(this.btnEncryptFile);
            this.groupBox3.Controls.Add(this.btnBrowseDest);
            this.groupBox3.Controls.Add(this.txtDestFile);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnBrowseSource);
            this.groupBox3.Controls.Add(this.txtSourceFile);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(810, 225);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Xử lý File lớn (Hỗ trợ GB) & Đo hiệu suất";
            // 
            // lblCompareResult
            // 
            this.lblCompareResult.AutoSize = true;
            this.lblCompareResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompareResult.Location = new System.Drawing.Point(150, 195);
            this.lblCompareResult.Name = "lblCompareResult";
            this.lblCompareResult.Size = new System.Drawing.Size(126, 13);
            this.lblCompareResult.TabIndex = 11;
            this.lblCompareResult.Text = "Chưa thực hiện so sánh";
            // 
            // btnCompareFile
            // 
            this.btnCompareFile.Location = new System.Drawing.Point(11, 190);
            this.btnCompareFile.Name = "btnCompareFile";
            this.btnCompareFile.Size = new System.Drawing.Size(130, 25);
            this.btnCompareFile.TabIndex = 10;
            this.btnCompareFile.Text = "So sánh Byte 2 File";
            this.btnCompareFile.UseVisualStyleBackColor = true;
            this.btnCompareFile.Click += new System.EventHandler(this.btnCompareFile_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(260, 155);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(107, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Thời gian thực thi: 0 ms";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 115);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(783, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // btnDecryptFile
            // 
            this.btnDecryptFile.Location = new System.Drawing.Point(135, 149);
            this.btnDecryptFile.Name = "btnDecryptFile";
            this.btnDecryptFile.Size = new System.Drawing.Size(110, 25);
            this.btnDecryptFile.TabIndex = 7;
            this.btnDecryptFile.Text = "Giải mã File";
            this.btnDecryptFile.UseVisualStyleBackColor = true;
            this.btnDecryptFile.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnEncryptFile
            // 
            this.btnEncryptFile.Location = new System.Drawing.Point(11, 149);
            this.btnEncryptFile.Name = "btnEncryptFile";
            this.btnEncryptFile.Size = new System.Drawing.Size(110, 25);
            this.btnEncryptFile.TabIndex = 6;
            this.btnEncryptFile.Text = "Mã hóa File";
            this.btnEncryptFile.UseVisualStyleBackColor = true;
            this.btnEncryptFile.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // btnBrowseDest
            // 
            this.btnBrowseDest.Location = new System.Drawing.Point(720, 57);
            this.btnBrowseDest.Name = "btnBrowseDest";
            this.btnBrowseDest.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDest.TabIndex = 5;
            this.btnBrowseDest.Text = "Chọn...";
            this.btnBrowseDest.UseVisualStyleBackColor = true;
            this.btnBrowseDest.Click += new System.EventHandler(this.btnBrowseDest_Click);
            // 
            // txtDestFile
            // 
            this.txtDestFile.Location = new System.Drawing.Point(100, 59);
            this.txtDestFile.Name = "txtDestFile";
            this.txtDestFile.Size = new System.Drawing.Size(614, 20);
            this.txtDestFile.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File Kết quả:";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(720, 25);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Chọn...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // txtSourceFile
            // 
            this.txtSourceFile.Location = new System.Drawing.Point(100, 27);
            this.txtSourceFile.Name = "txtSourceFile";
            this.txtSourceFile.Size = new System.Drawing.Size(614, 20);
            this.txtSourceFile.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Nguồn :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 515);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Mã Hóa AES - Bài Tập An Toàn Bảo Mật Thông Tin";
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
        private System.Windows.Forms.Button btnLoadKey;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.TextBox txtKeyInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDecryptText;
        private System.Windows.Forms.Button btnEncryptText;
        private System.Windows.Forms.TextBox txtCipherText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlainText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtSourceFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseDest;
        private System.Windows.Forms.TextBox txtDestFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDecryptFile;
        private System.Windows.Forms.Button btnEncryptFile;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCompareResult;
        private System.Windows.Forms.Button btnCompareFile;
    }
}