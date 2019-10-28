using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace BMWTEST
{
    public partial class Replicate : Form
    {
        public Replicate()
        {
            InitializeComponent();
            button1.Visible = false;
            txtDestination.Visible = false;
            label2.Visible = false;
            btnDestination.Visible = false;
            btnDelete.Visible = false;
            btnCopy.Visible = false;
            btnMove.Visible = false;
        }

        

        //public void LogFile(string sExceptionName, string sEventName, string sControlName, int nErrorLineNo, string sFormName)
        //{
        //    StreamWriter log;
        //    if (!File.Exists("logfile.txt"))
        //    {
        //        log = new StreamWriter("logfile.txt");
        //    }
        //    else
        //    {
        //        log = File.AppendText("logfile.txt");
        //    }

        //    log.WriteLine("Date Time:" + DateTime.Now);
        //    log.WriteLine("Exception Name:" + sExceptionName);
        //    log.WriteLine("Event Name:" + sEventName);
        //    log.WriteLine("Control Name:" + sControlName);
        //    log.WriteLine("Error Line No:" + nErrorLineNo);
        //    log.WriteLine("Form Name:" + sFormName);

        //    log.Close();
        //}




      

        private void btnSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtSource.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDestination.Text = folderBrowserDialog1.SelectedPath;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Value = progressBar1.Value + 2;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string path = txtSource.Text;

            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(path);
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Already Exists....!");
            }
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                btnCopy.Visible = true;
                txtDestination.Visible = true;
                label2.Visible = true;
                btnDestination.Visible = true;
            }
            else
            {
                btnCopy.Visible = false;
                txtDestination.Visible = false;
                label2.Visible = false;
                btnDestination.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                btnMove.Visible = true;
                txtDestination.Visible = true;
                label2.Visible = true;
                btnDestination.Visible = true;
            }
            else
            {
                btnMove.Visible = false;
                txtDestination.Visible = false;
                label2.Visible = false;
                btnDestination.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            string destination = txtDestination.Text;

            bool exists = System.IO.Directory.Exists(source);
            if (exists)
            {
                System.IO.Directory.CreateDirectory(destination);
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text;
            string destination = txtDestination.Text;

            bool exists = System.IO.Directory.Exists(source);
            if (exists)
            {
                System.IO.Directory.CreateDirectory(destination);

                System.IO.Directory.Delete(source, true);

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            System.IO.Directory.Delete(txtSource.Text, true);
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(10);
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.ReportProgress(i);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        

    }
}
