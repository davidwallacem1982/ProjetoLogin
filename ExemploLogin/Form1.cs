using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ExemploLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Controle para limpar os campos quando os mesmos estiverem com foco

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuário")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuário";
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Senha")
            {
                txtSenha.Text = "";
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Senha";
                txtSenha.UseSystemPasswordChar = false;
            }
        }

        #endregion

        #region Minimizar e Fechar a aplicação

        private void btFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Para pode mover a Janela pela tela

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void DragForm(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm(sender, e);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm(sender, e);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            DragForm(sender, e);
        }

        #endregion       
    }
}
