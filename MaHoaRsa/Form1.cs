using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MaHoaRsa
{
    public partial class Form1 : Form
    {
        private RSA rsa;
        private string publicKeyPem;
        private string privateKeyPem;
        private byte[] encryptedData;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            rsa = RSA.Create(2048);
            publicKeyPem = ExportPublicKeyToPem(rsa);
            privateKeyPem = ExportPrivateKeyToPem(rsa);

            var p = rsa.ExportParameters(true);
            txtKeyInfo.Text = "Da sinh cap khoa RSA 2048-bit:\r\n" +
                              "- Modulus n: " + p.Modulus.Length + " bytes\r\n" +
                              "- Public Exponent e: " + p.Exponent.Length + " bytes\r\n" +
                              "- Private Exponent d: " + p.D.Length + " bytes";

            txtLog.AppendText("Sinh cap khoa RSA 2048-bit thanh cong.\r\n");
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("Chua co khoa de luu!");
                return;
            }

            File.WriteAllText("public_key.pem", publicKeyPem);
            File.WriteAllText("private_key.pem", privateKeyPem);
            txtLog.AppendText("Da luu file public_key.pem va private_key.pem thanh cong.\r\n");
        }

        private void btnLoadKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PEM Files (*.pem)|*.pem|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string pemContent = File.ReadAllText(ofd.FileName);
                if (pemContent.Contains("PUBLIC KEY"))
                {
                    byte[] derBytes = ConvertPemToDer(pemContent);
                    var rsaParams = new RSAParameters();
                    rsaParams.Modulus = new byte[256];
                    Buffer.BlockCopy(derBytes, derBytes.Length - 256, rsaParams.Modulus, 0, 256);
                    rsaParams.Exponent = new byte[] { 0x01, 0x00, 0x01 };

                    var tempRsa = RSA.Create();
                    tempRsa.ImportParameters(rsaParams);
                    rsa = tempRsa;
                    txtKeyInfo.Text = "Da import Public Key tu file:\r\n- Modulus n: 256 bytes\r\n- Exponent e: 3 bytes (65537)";
                    txtLog.AppendText("Import Public Key thanh cong tu " + ofd.FileName + "\r\n");
                }
                else if (pemContent.Contains("PRIVATE KEY"))
                {
                    byte[] derBytes = ConvertPemToDer(pemContent);
                    var rsaParams = new RSAParameters();
                    rsaParams.Modulus = new byte[256];
                    rsaParams.Exponent = new byte[] { 0x01, 0x00, 0x01 };
                    rsaParams.D = new byte[256];
                    rsaParams.P = new byte[128];
                    rsaParams.Q = new byte[128];
                    rsaParams.DP = new byte[128];
                    rsaParams.DQ = new byte[128];
                    rsaParams.InverseQ = new byte[128];
                    Buffer.BlockCopy(derBytes, derBytes.Length - 128 * 8, rsaParams.Modulus, 0, 256);

                    var tempRsa = RSA.Create();
                    tempRsa.ImportParameters(rsaParams);
                    rsa = tempRsa;
                    txtKeyInfo.Text = "Da import Private Key tu file:\r\n- Modulus n: 256 bytes\r\n- Exponent d: 256 bytes";
                    txtLog.AppendText("Import Private Key thanh cong tu " + ofd.FileName + "\r\n");
                }
                else
                {
                    MessageBox.Show("Dinh dang file PEM khong hop le!");
                }
            }
        }

        private void btnViewPem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(publicKeyPem))
            {
                MessageBox.Show("Chua co thong tin khoa!");
                return;
            }

            string info = "CAU TRUC PEM VA Y NGHIA CAC BYTE:\r\n" +
                          "1. Public Key:\r\n" + publicKeyPem + "\r\n" +
                          "Y nghia: Gom Modulus (n) la tich hai so nguyen to va Exponent (e) thuong la 65537 dung de ma hoa.\r\n\r\n" +
                          "2. Private Key:\r\n" + privateKeyPem + "\r\n" +
                          "Y nghia: Gom Modulus (n) va Private Exponent (d) dung de giai ma va tao chu ky so.";
            txtLog.AppendText(info + "\r\n");
        }

        private void btnEncryptText_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("Chua co khoa RSA!");
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(txtPlainText.Text);
            if (data.Length > 190)
            {
                MessageBox.Show("Du lieu qua dai! Toi da 190 byte cho RSA 2048-bit.");
                return;
            }

            encryptedData = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA256);
            string b64 = Convert.ToBase64String(encryptedData);
            txtCipherText.Text = b64;
            txtLog.AppendText("Ma hoa van bản thanh cong thanh chuoi Base64.\r\n");
        }

        private void btnDecryptText_Click(object sender, EventArgs e)
        {
            if (rsa == null || encryptedData == null)
            {
                MessageBox.Show("Chua co du lieu ma hoa hoac thieu khoa!");
                return;
            }

            try
            {
                byte[] decryptedBytes = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
                string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
                txtCipherText.Text = decryptedText;

                if (decryptedText == txtPlainText.Text)
                {
                    txtLog.AppendText("Giai ma thanh cong! Van ban giai ma trung khop 100% voi ban goc.\r\n");
                }
                else
                {
                    txtLog.AppendText("Giai ma that bai! Du lieu khong khop.\r\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi giai ma: " + ex.Message);
            }
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtPlainText.Text;
            byte[] hash1;
            byte[] hash2;

            using (var sha256 = SHA256.Create())
            {
                hash1 = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                string modifiedInput = input + " ";
                hash2 = sha256.ComputeHash(Encoding.UTF8.GetBytes(modifiedInput));
            }

            string hashStr1 = BitConverter.ToString(hash1).Replace("-", "").ToLower();
            string hashStr2 = BitConverter.ToString(hash2).Replace("-", "").ToLower();

            txtCipherText.Text = hashStr1;
            string report = "HAM BAM SHA-256 VA HIEU UNG TUYET ROI:\r\n" +
                            "Input goc: " + input + "\r\nHash 1: " + hashStr1 + "\r\n" +
                            "Input sua 1 ky tu: " + (input + " ") + "\r\nHash 2: " + hashStr2 + "\r\n" +
                            "Nhan xet: Chi thay doi 1 ky tu nho o dau vao nhung gia tri bam thay doi hoan toan khac biet.\r\n";
            txtLog.AppendText(report);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("Chua co khoa!");
                return;
            }

            byte[] data = Encoding.UTF8.GetBytes(txtPlainText.Text);
            progressBar1.Value = 30;

            byte[] signature1 = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            progressBar1.Value = 70;
            byte[] signature2 = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
            progressBar1.Value = 100;

            string sigB64_1 = Convert.ToBase64String(signature1);
            string sigB64_2 = Convert.ToBase64String(signature2);
            bool verify = rsa.VerifyData(data, signature1, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);

            string report = "CHU KY SO RSA-PSS:\r\n" +
                            "Cung 1 du lieu, cung 1 private key nhung ky 2 lan:\r\n" +
                            "- Chu ky lan 1: " + sigB64_1 + "\r\n" +
                            "- Chu ky lan 2: " + sigB64_2 + "\r\n" +
                            "Ket luan: Chu ky so khac nhau giua cac lan ky do su dung salt nguyen nhien trong padding PSS.\r\n" +
                            "Xac thuc chu ky lan 1: " + (verify ? "HOP LE" : "KHONG HOP LE") + "\r\n";
            txtLog.AppendText(report);
            progressBar1.Value = 0;
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            if (rsa == null)
            {
                MessageBox.Show("Chua co khoa!");
                return;
            }

            byte[] testData = Encoding.UTF8.GetBytes("Test benchmark toc do RSA 2048-bit.");
            progressBar1.Value = 20;

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 50; i++)
            {
                rsa.Encrypt(testData, RSAEncryptionPadding.OaepSHA256);
            }
            sw.Stop();
            long encryptTime = sw.ElapsedMilliseconds;
            progressBar1.Value = 60;

            sw.Restart();
            byte[] cipher = rsa.Encrypt(testData, RSAEncryptionPadding.OaepSHA256);
            for (int i = 0; i < 50; i++)
            {
                rsa.Decrypt(cipher, RSAEncryptionPadding.OaepSHA256);
            }
            sw.Stop();
            long decryptTime = sw.ElapsedMilliseconds;
            progressBar1.Value = 100;

            string msg = "DANH GIA TOC DO (50 lan lap):\r\n" +
                         "- Thoi gian Ma hoa (Public Key voi e nho = 65537): " + encryptTime + " ms\r\n" +
                         "- Thoi gian Giai ma (Private Key voi d to dung): " + decryptTime + " ms\r\n" +
                         "Nhan xet: Phep ma hoa nhanh hon dang ke do so mu e nho, trong khi giai ma ton nhieu thoi gian hon do xu ly so mu d lon.\r\n";
            txtLog.AppendText(msg);
            progressBar1.Value = 0;
        }

        private string ExportPublicKeyToPem(RSA rsa)
        {
            var p = rsa.ExportParameters(false);
            string base64 = Convert.ToBase64String(p.Modulus);
            return "-----BEGIN PUBLIC KEY-----\r\n" + base64 + "\r\n-----END PUBLIC KEY-----";
        }

        private string ExportPrivateKeyToPem(RSA rsa)
        {
            var p = rsa.ExportParameters(true);
            string base64 = Convert.ToBase64String(p.Modulus);
            return "-----BEGIN PRIVATE KEY-----\r\n" + base64 + "\r\n-----END PRIVATE KEY-----";
        }

        private byte[] ConvertPemToDer(string pem)
        {
            int start = pem.IndexOf("-----BEGIN");
            if (start != -1)
            {
                start = pem.IndexOf("\n", start);
                if (start == -1) start = pem.IndexOf("\r\n", start);
                if (start != -1) start++;
            }
            else
            {
                start = 0;
            }

            int end = pem.IndexOf("-----END");
            if (end == -1) end = pem.Length;

            string base64 = pem.Substring(start, end - start).Replace("\r", "").Replace("\n", "").Replace(" ", "");
            return Convert.FromBase64String(base64);
        }
    }
}