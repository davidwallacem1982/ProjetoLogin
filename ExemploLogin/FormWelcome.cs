using System;
using System.Windows.Forms;

namespace ExemploLogin
{
    public partial class FormWelcome : Form
    {
        public FormWelcome()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Baixe o nuget circularProgressBar quando vc for criar um novo projeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;

            circularProgressBar.Value += 1;
            circularProgressBar.Text = circularProgressBar.Value.ToString();

            if (circularProgressBar.Value == 100)
            {
                timerLoad.Stop();
                timerLoad2.Start();
            }
        }

        private void timerLoad2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timerLoad2.Stop();
                this.Close();
            }
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            lbUserLoad.Text = "David Wallace";
            this.Opacity = 0.0;
            circularProgressBar.Value = 0;
            circularProgressBar.Minimum = 0;
            circularProgressBar.Maximum = 100;
            timerLoad.Start();
        }
    }
}
