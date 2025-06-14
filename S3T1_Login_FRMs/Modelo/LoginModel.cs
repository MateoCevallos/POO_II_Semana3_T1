using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S3T1_Login_FRMs.Modelo;
using System.Data.SqlClient;

namespace S3T1_Login_FRMs.Modelo
{
    public class LoginModel : UsuarioModel
    {
        //dataReader
        
        public string Error { get; set; }

    }
}
