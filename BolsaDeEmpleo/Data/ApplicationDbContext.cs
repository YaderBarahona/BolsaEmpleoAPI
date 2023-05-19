using BolsaDeEmpleo.Models;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Data
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

        //modelo villa de tipo dbset se creara en la db como una tabla
        public DbSet<Applicant> Applicants { get; set; }

        //
        public DbSet<ApplicantEducation> ApplicantsEducation { get; set; }

        public DbSet<ApplicantSkills> ApplicantsSkills { get; set; }

        public DbSet<ApplyOffer> ApplyOffers { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<OfferDescription> ApplicantsEducation { get; set; }

        public DbSet<OfferSkills> ApplicantsEducation { get; set; }


    }
}
