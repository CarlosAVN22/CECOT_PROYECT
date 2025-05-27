using System.IO;
using CECOT_PROYECT.AdministradoresForms;
using Newtonsoft.Json;

public static class GestorUsuarios
{
    private static string ruta = "credenciales.json";

    public static void GuardarUsuario(string usuario, string contraseña,string cargo)
    {
        var user = new Usuario
        {
            UsuarioID = usuario,
            PasswordHash = Seguridad.HashPassword(contraseña),
            Cargo=cargo
        };

        string json = JsonConvert.SerializeObject(user);
        File.WriteAllText(ruta, json);
    }

    public static Usuario CargarUsuario()
    {
        if (!File.Exists(ruta)) return null;
        string json = File.ReadAllText(ruta);
        return JsonConvert.DeserializeObject<Usuario>(json);
    }

    public static bool ValidarLogin(string usuario, string contraseña)
    {
        var user = CargarUsuario();
        if (user == null) return false;
        return user.UsuarioID == usuario && Seguridad.VerificarPassword(contraseña, user.PasswordHash);
    }
}

