using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanie2
{
    public partial class Form1 : Form
    {
        private int numberToCompute = 0;
        private FolderBrowserDialog folderBrowserDialog1;
        public Form1()  
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        //zad 2
        private BigInteger fibo(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            BigInteger result = BigInteger.Parse("1");
            BigInteger a = BigInteger.Parse("0");
            BigInteger b = BigInteger.Parse("1");
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                for (int i = n; i > 0; i--)
                {
                    int percentComplete = (int)(((n - i * 1.0 + 1) / n) * 100);
                    worker.ReportProgress(percentComplete);
                    Thread.Sleep(30);
                    result = a + b;
                    if (i % 2 == 0) { b = result; } else { a = result; }
                }
            }
            return result;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = fibo((int)e.Argument, worker, e);
        }

        private void resultLabel_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                resultLabel.Text = "Canceled";
            }
            else
            {
                resultLabel.Text = e.Result.ToString();
            }
            startButton.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            startButton.Enabled = false;
            numberToCompute = 90;
            backgroundWorker1.RunWorkerAsync(numberToCompute);
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        //zad 3 compress
        private void button2_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog() { Description = "Select directory to open" };
            dlg.ShowDialog();
            DirectoryInfo temp = new DirectoryInfo(dlg.SelectedPath);
            FileInfo[] files = temp.GetFiles();
            Parallel.ForEach(files, (i) =>
            {
                FileStream originalFileStream = File.Open(i.FullName, FileMode.Open);
                FileStream compressedFileStream = File.Create($"{i.Name}.gz");
                var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
                originalFileStream.CopyTo(compressor);
                compressor.Dispose();
                compressedFileStream.Dispose();
                originalFileStream.Dispose();
            });
            dlg.Dispose();
        }

        //zad 3 decompress

        private void button3_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.ShowDialog();
            DirectoryInfo temp = new DirectoryInfo(dlg.SafeFileName);
            FileStream compressedFileStream = File.Open(temp.FullName, FileMode.Open);
            FileStream outputFileStream = File.Create(temp.Name.Split('.')[0] + '.' + temp.Name.Split('.')[1]);
            var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
            decompressor.Dispose();
            compressedFileStream.Dispose();
            outputFileStream.Dispose();
            dlg.Dispose();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}