using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S3T1_Login_FRMs.Controllers
{
    class AuthController
    {
        private Modelo.LoginModel _loginModel = new Modelo.LoginModel();

        public List<Modelo.LoginModel> _listaLoginModels = new List<Modelo.LoginModel>();

        public AuthController()
        {
            var usuario = new Modelo.LoginModel
            {
                Contrasenia = "123",
                Correo = "correo@gmail.com",
                Estado = true,
                Nombre = "Admin",
                NombreUsuario = "Admin",
                UsuarioId = 1
            };
            _listaLoginModels.Add(usuario);
        }

        public List<Modelo.LoginModel> todos()
        {
            return _listaLoginModels;
        }

        public Modelo.LoginModel uno(int id)
        {
            return _listaLoginModels.Find(u => u.UsuarioId == id);
        }

        public Modelo.LoginModel uno(string usuario)
        {
            return _listaLoginModels.Find(u => u.NombreUsuario == usuario);
        }

        public string login(Modelo.LoginModel Usuario)
        {
            var user = _listaLoginModels.Find(u => u.NombreUsuario == Usuario.NombreUsuario && u.Contrasenia == Usuario.Contrasenia);

            if (user != null)
            {
                Program.Nombreusuario = "";
                Program.Estado = 0;
                Program.UsuarioId = 0;
                return "ok";
            }
            else
            {
                return "Error: El usuario o la contraseña son incorrectas.";
            }

        }

        public void logOut()
        {
            Program.Nombreusuario = "";
            Program.Estado = 0;
            Program.UsuarioId = 0;
        }
    }
}