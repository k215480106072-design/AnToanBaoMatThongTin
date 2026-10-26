using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MaHoaAes
{
    public partial class Form1 : Form
    {
        private byte[] currentKey;
        private byte[] currentIV;
        private string targetFolder = @"D:\Project\DuongHuuTao\MaHoaAes\Data";

        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.GenerateKey();
                aes.GenerateIV();
                currentKey = aes.Key;
                currentIV = aes.IV;

                txtKeyInfo.Text = $"Key (Base64): {Convert.ToBase64String(currentKey)}\r\nIV (Base64): {Convert.ToBase64String(currentIV)}";
            }
            MessageBox.Show("Sinh khóa AES-256 thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Chưa có khóa nào được sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = targetFolder;
                sfd.FileName = "aes_key.txt";
                sfd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string content = Convert.ToBase64String(currentKey) + "\n" + Convert.ToBase64String(currentIV);
                    File.WriteAllText(sfd.FileName, content);
                    MessageBox.Show("Lưu khóa ra file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = targetFolder;
                ofd.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] lines = File.ReadAllLines(ofd.FileName);
                        if (lines.Length >= 2)
                        {
                            currentKey = Convert.FromBase64String(lines[0]);
                            currentIV = Convert.FromBase64String(lines[1]);
                            txtKeyInfo.Text = $"Key (Base64): {lines[0]}\r\nIV (Base64): {lines[1]}";
                            MessageBox.Show("Import khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("File khóa không đúng định dạng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file khóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEncryptText_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui lòng sinh hoặc import khóa trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(txtPlainText.Text);
                byte[] cipherBytes;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = currentKey;
                    aes.IV = currentIV;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        cipherBytes = ms.ToArray();
                    }
                }
                txtCipherText.Text = Convert.ToBase64String(cipherBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mã hóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecryptText_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui lòng sinh hoặc import khóa trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(txtCipherText.Text);
                byte[] plainBytes;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = currentKey;
                    aes.IV = currentIV;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        plainBytes = ms.ToArray();
                    }
                }
                txtPlainText.Text = Encoding.UTF8.GetString(plainBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = targetFolder;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFile.Text = ofd.FileName;
                }
            }
        }

        private void btnBrowseDest_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = targetFolder;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtDestFile.Text = sfd.FileName;
                }
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui lòng sinh hoặc import khóa trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSourceFile.Text) || string.IsNullOrEmpty(txtDestFile.Text))
            {
                MessageBox.Show("Vui lòng chọn file nguồn và file đích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                using (Aes aes = Aes.Create())
                {
                    aes.Key = currentKey;
                    aes.IV = currentIV;

                    using (FileStream fsInput = new FileStream(txtSourceFile.Text, FileMode.Open, FileAccess.Read))
                    using (FileStream fsOutput = new FileStream(txtDestFile.Text, FileMode.Create, FileAccess.Write))
                    using (CryptoStream cs = new CryptoStream(fsOutput, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        long totalLength = fsInput.Length;
                        byte[] buffer = new byte[81920];
                        int bytesRead;
                        long totalRead = 0;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 100;

                        while ((bytesRead = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cs.Write(buffer, 0, bytesRead);
                            totalRead += bytesRead;
                            int percent = (int)((totalRead * 100) / totalLength);
                            progressBar1.Value = percent > 100 ? 100 : percent;
                            Application.DoEvents();
                        }
                    }
                }
                sw.Stop();
                lblTime.Text = $"Thời gian mã hóa: {sw.ElapsedMilliseconds} ms (~{sw.Elapsed.TotalSeconds:F2} giây)";
                MessageBox.Show("Mã hóa file lớn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mã hóa file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            if (currentKey == null || currentIV == null)
            {
                MessageBox.Show("Vui lòng sinh hoặc import khóa trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSourceFile.Text) || string.IsNullOrEmpty(txtDestFile.Text))
            {
                MessageBox.Show("Vui lòng chọn file nguồn và file đích!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                using (Aes aes = Aes.Create())
                {
                    aes.Key = currentKey;
                    aes.IV = currentIV;

                    using (FileStream fsInput = new FileStream(txtSourceFile.Text, FileMode.Open, FileAccess.Read))
                    using (FileStream fsOutput = new FileStream(txtDestFile.Text, FileMode.Create, FileAccess.Write))
                    using (CryptoStream cs = new CryptoStream(fsInput, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        long totalLength = fsInput.Length;
                        byte[] buffer = new byte[81920];
                        int bytesRead;
                        long totalRead = 0;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = 100;

                        while ((bytesRead = cs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsOutput.Write(buffer, 0, bytesRead);
                            totalRead += bytesRead;
                            int percent = (int)((totalRead * 100) / totalLength);
                            progressBar1.Value = percent > 100 ? 100 : percent > 0 ? percent : 0;
                            Application.DoEvents();
                        }
                    }
                }
                sw.Stop();
                lblTime.Text = $"Thời gian giải mã: {sw.ElapsedMilliseconds} ms (~{sw.Elapsed.TotalSeconds:F2} giây)";
                MessageBox.Show("Giải mã file lớn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompareFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFile.Text) || string.IsNullOrEmpty(txtDestFile.Text))
            {
                MessageBox.Show("Vui lòng chọn đủ 2 file để so sánh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FileInfo f1 = new FileInfo(txtSourceFile.Text);
                FileInfo f2 = new FileInfo(txtDestFile.Text);

                if (f1.Length != f2.Length)
                {
                    lblCompareResult.Text = "Kết quả: KHÔNG KHỚP (Kích thước khác nhau)";
                    lblCompareResult.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                bool isIdentical = true;
                int bufferSize = 81920;
                using (FileStream fs1 = f1.OpenRead())
                using (FileStream fs2 = f2.OpenRead())
                {
                    byte[] buffer1 = new byte[bufferSize];
                    byte[] buffer2 = new byte[bufferSize];

                    int read1, read2;
                    while ((read1 = fs1.Read(buffer1, 0, bufferSize)) > 0)
                    {
                        read2 = fs2.Read(buffer2, 0, bufferSize);
                        if (read1 != read2)
                        {
                            isIdentical = false;
                            break;
                        }
                        for (int i = 0; i < read1; i++)
                        {
                            if (buffer1[i] != buffer2[i])
                            {
                                isIdentical = false;
                                break;
                            }
                        }
                        if (!isIdentical) break;
                    }
                }

                if (isIdentical)
                {
                    lblCompareResult.Text = "Kết quả: KHỚP 100% (File nguyên vẹn, trùng khớp từng byte)";
                    lblCompareResult.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblCompareResult.Text = "Kết quả: KHÔNG KHỚP (Có sai lệch dữ liệu)";
                    lblCompareResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi so sánh file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}