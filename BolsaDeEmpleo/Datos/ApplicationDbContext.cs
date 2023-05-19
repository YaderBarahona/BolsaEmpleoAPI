using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Datos
{    
    //clase para la creacion de los modelos como tablas en la db

    //hereda de DbContext
    public class ApplicationDbContext : DbContext
    {
        //aplicamos inyeccion de dependencias
        //mediante base indica el padre de donde se hereda "DbContex" mandamos toda la configuracion que se tiene en el servicio mediante la inyeccion de dependencias
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
