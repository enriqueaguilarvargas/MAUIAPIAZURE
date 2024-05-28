using System.Data;
using System.Data.SqlClient;
namespace APIExpo
{
   public class Consultas
    {
        public List<Datos>? ListadeConferencistas;
        public List<Datos> ConsultaRegistro(int ID)
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                        ("Server=tcp:enrique.database.windows.net,1433;Initial Catalog=InformacionExpo;Persist Security Info=False;User ID=enrique;Password=Mexico2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        var cmd = new SqlCommand("SELECT * From Datos WHERE Id= '" + ID + "'", connect);
        try
        {
            ListadeConferencistas = new List<Datos>();
            connect.Open();
            var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            connect.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Datos cliente = new Datos();
                cliente.Id = int.Parse((dt.Rows[i]["Id"]).ToString());
                cliente.Nombre = ((dt.Rows[i]["Nombre"]).ToString());
                cliente.Apellido = ((dt.Rows[i]["Apellido"]).ToString());
                cliente.Conferencia = ((dt.Rows[i]["Conferencia"]).ToString());
                cliente.Fecha = ((dt.Rows[i]["Fecha"]).ToString());
                cliente.Imagen = ((dt.Rows[i]["Imagen"]).ToString());
                cliente.ImagenFondo = ((dt.Rows[i]["ImagenFondo"]).ToString());
                cliente.Pais = ((dt.Rows[i]["Pais"]).ToString());
                cliente.Semblanza = ((dt.Rows[i]["Semblanza"]).ToString());
                cliente.Latitud = ((dt.Rows[i]["Latitud"]).ToString());
                cliente.Longitud = ((dt.Rows[i]["Longitud"]).ToString());
                ListadeConferencistas.Add(cliente);
            }
            return ListadeConferencistas;
        }
        catch (Exception ex)
        {
            connect.Close();
            return ListadeConferencistas;
        }
    }
        public List<Datos> ConsultaTodo()
        {
            var dt = new DataTable();
            var connect = new SqlConnection
                        ("Server=tcp:enrique.database.windows.net,1433;Initial Catalog=InformacionExpo;Persist Security Info=False;User ID=enrique;Password=Mexico2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var cmd = new SqlCommand("SELECT * From Datos", connect);
            try
            {
                ListadeConferencistas = new List<Datos>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Datos cliente = new Datos();
                    cliente.Id = int.Parse((dt.Rows[i]["Id"]).ToString());
                    cliente.Nombre = ((dt.Rows[i]["Nombre"]).ToString());
                    cliente.Apellido = ((dt.Rows[i]["Apellido"]).ToString());
                    cliente.Conferencia = ((dt.Rows[i]["Conferencia"]).ToString());
                    cliente.Fecha = ((dt.Rows[i]["Fecha"]).ToString());
                    cliente.Imagen = ((dt.Rows[i]["Imagen"]).ToString());
                    cliente.ImagenFondo = ((dt.Rows[i]["ImagenFondo"]).ToString());
                    cliente.Pais = ((dt.Rows[i]["Pais"]).ToString());
                    cliente.Semblanza = ((dt.Rows[i]["Semblanza"]).ToString());
                    cliente.Latitud = ((dt.Rows[i]["Latitud"]).ToString());
                    cliente.Longitud = ((dt.Rows[i]["Longitud"]).ToString());
                    ListadeConferencistas.Add(cliente);
                }
                return ListadeConferencistas;
            }
            catch (Exception ex)
            {
                connect.Close();
                return ListadeConferencistas;
            }
        }
    }
}