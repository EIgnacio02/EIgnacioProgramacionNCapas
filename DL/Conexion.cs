using System;
using System.Collections.Generic;
using System.Configuration; //Importamos la libreria 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConexion()
        {
            //CREAMOS NUESTRA CONEXION 
            /*
             * APP.CONFING PL
            <connectionStrings>
		        <add name="EIgnacioProgramacionNCapas"
			         connectionString="Data Source=.;Initial Catalog=EIgnacioProgramacionNCapas;User ID=sa;Password=pass@word1"
			         providerName="System.Data.SqlClient"/>
	        </connectionStrings>
            */
            return ConfigurationManager.ConnectionStrings["EIgnacioProgramacionNCapas"].ConnectionString;

        }
    }
}
