using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S3T1_Login_FRMs.Controllers;

namespace S3T1_Login_FRMs
{
    public partial class Form1 : Form
    {
        Controllers.AuthController _authController = new Controllers.AuthController();

        int intentos=3;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var usuario = new Modelo.LoginModel
            {
                NombreUsuario = txtUsuario.Text.Trim(),
                Contrasenia = txtContrasenia.Text.Trim(),
            };

            var res = _authController.login(usuario);
            if (res == "ok")
            {
                MessageBox.Show("Bienvenido al Sistema");
                //enviar a abrir al formulario de dashboard

                var frmMenuPrincipal = new Vistas.FRM_MenuPrincipal();

                this.Hide();  //oculta el formulario

                frmMenuPrincipal.Show();
            }
            else
            {
                intentos--;
                MessageBox.Show(res + "\nIntentos restantes: " + intentos);
                lbl_Mensaje.Text = res;
                lbl_Mensaje.Visible = true;

                if (intentos == 0)
                {
                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            txtContrasenia.Text = "";
            txtUsuario.Text = "";
        }
    }
}
