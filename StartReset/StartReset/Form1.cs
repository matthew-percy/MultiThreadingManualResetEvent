using System;
using System.Threading;
using System.Windows.Forms;

namespace StartReset
{
    public partial class Form1 : Form
    {
        Thread thread;
        ManualResetEvent mre;

        public Form1()
        {
            InitializeComponent();
            //mre = new ManualResetEvent(false);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            mre = new ManualResetEvent(false);
            new Thread(() => 
            {
                bool state = mre.WaitOne(2000);
                if (state == false) MessageBox.Show("Too Slow");//MessageBox.Show(state.ToString());

            }).Start();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {

            mre.Set();//Reset();//Set();
        }
    }
}
