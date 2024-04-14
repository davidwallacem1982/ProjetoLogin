using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ExemploLogin
{
    public partial class Login : Form
    {
        private Timer errorTimer;
        public Login()
        {
            InitializeComponent();
            errorTimer = new Timer();
            errorTimer.Interval = 5000; // 7 segundos
            errorTimer.Tick += ErrorTimer_Tick;
        }

        #region Controle para limpar os campos quando os mesmos estiverem com foco

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Username")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Username";
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "Password")
            {
                txtSenha.Text = "";
                txtSenha.UseSystemPasswordChar = true;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "Password";
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

        private void btAcessar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Username")
            {
                msgError("Por favor digite o seu usuário");
                return;
            }

            if (txtSenha.Text == "Password")
            {
                msgError("Por favor digite a sua senha");
                return;
            }

            if(true)
            {
                this.Hide();
                var welcome = new FormWelcome();
                welcome.ShowDialog();
                var mainMenu = new FormTest();
                mainMenu.Show();
                mainMenu.FormClosed += Logout;
                this.Hide();
            }


            // Aqui você pode adicionar a lógica para verificar a autenticação do usuário
            msgError("Usuário ou senha incorretos, por favor tente novamente!!!");
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario_Leave(sender, e);
            txtSenha_Leave(sender, e);
            txtUsuario.Focus();
        }

        private void msgError(string msg)
        {
            lbErrorMessage.Text = $"    {msg}";
            lbErrorMessage.Visible = true;
            errorTimer.Start(); // Inicia o temporizador quando exibe a mensagem de erro
        }

        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            lbErrorMessage.Visible = false; // Oculta a mensagem de erro após 3 segundos
            errorTimer.Stop(); // Para o temporizador após ocultar a mensagem
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Clear();
            txtSenha.Clear();
            txtUsuario_Leave(sender, e);
            txtSenha_Leave(sender, e);
            txtUsuario.Focus();
            this.Show();
        }

        private void buttomEmail_Click(object sender, EventArgs e)
        {
            recoverPassword();
        }

        public string recoverPassword()
        {
            var userName = "David Teste Wallace";
            var userMail = "david.mnemonic@gmail.com";
            var accountPassword = "teste";
            //List<string> listEmail = new List<string>();
            //listEmail.Add(userRequesting);

            var mailService = new SystemSupportMail();
            mailService.SendMail(
                subject: "SYSTEM: Password recovery request",
                body: "Olá, estou testando isso aqui",
                recipientMail: new List<string> { userMail }
                );
            return "SYSTEM: Password recovery request";
        }
    }
}
