using System.Data;
using System.Data.SqlClient;
using ApiEscuela.Dtos;
using Domain.Entities;

namespace ApiEscuela.Services;

public class Login
{ 
    public string getTokenLogin(string email, string password)
    {
        Encriptacion encrip = new Encriptacion();
        string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        string tokenLogin = encrip.AES256_Encriptar(encrip.AES256_LOGIN_Key, fecha + '#' + email + '#' + encrip.GetSHA256(password));
        return tokenLogin;
    }

    public string LoginByToken(string loginToken,User registerDto)
    {
        try
        {
            Encriptacion encrip = new Encriptacion();
            string tokenUsuario = "";

            string tokenDescoficado = encrip.AES256_Desencriptar(encrip.AES256_LOGIN_Key, loginToken);
            string fecha = tokenDescoficado.Split('#')[0];
            string email = tokenDescoficado.Split('#')[1];
            string password = tokenDescoficado.Split('#')[2];

            // Validar fecha
            DateTime fechaLogin = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            if (DateTime.UtcNow.Subtract(fechaLogin).TotalSeconds >= 60)
            {
                return "-1";    // -1 = Límite de tiempo excedido
            }

            // Validar contraseña y correo
            if (email == registerDto.Email && password == registerDto.Password)
            {
                // Usuario autenticado, genera un nuevo token
                tokenUsuario = email + "#" + DateTime.UtcNow.AddHours(18).ToString("yyyyMMddHHmmss");
                tokenUsuario = encrip.AES256_Encriptar(encrip.AES256_USER_Key, tokenUsuario);
                return tokenUsuario;
            }
            else
            {
                return "-2";    // -2 = Usuario o contraseña incorrectos
            }
        }
        catch (Exception)
        {
            return "-3";        // -3 = Error
        }
    }

    public bool ValidarTokenUsuario(string tokenUsuario)
        {
            try
            {
                Encriptacion encrip = new Encriptacion();
                tokenUsuario = encrip.CorregirToken(tokenUsuario);
                string tokenDescodificado = encrip.AES256_Desencriptar(encrip.AES256_USER_Key, tokenUsuario);
                string emailUsuario = tokenDescodificado.Split('#')[0];
                string fecha = tokenDescodificado.Split('#')[1];

                // Validar fecha
                DateTime fechaCaducidad = DateTime.ParseExact(fecha, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.UtcNow > fechaCaducidad)
                    return false; 
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

}
