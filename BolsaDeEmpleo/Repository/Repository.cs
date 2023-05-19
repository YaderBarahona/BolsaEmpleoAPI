using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BolsaDeEmpleo.Repositorio
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //variable para inyectar el db context
        private readonly ApplicationDbContext _context;

        //variable dbset para la conversion con T que se recibe para convertirlo en una entidad
        internal DbSet<T> dbSet;

        //inyectamos el dbcontext para trabajar desde aqui y ya no en el controlador
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            //convertimos la T en una entidad
            this.dbSet = _context.Set<T>();    

        }

        //agregamos un registro de cualquier entidad que se mande
        public async Task Crear(T entidad)
        {
            //
            await dbSet.AddAsync(entidad);

            await Grabar();
        }

        public async Task Grabar()
        {
           await _context.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true)
        {
            //variable para poder hacer consultas
            IQueryable<T> query = dbSet;

            //
            if(!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);

            }

            return await query.ToListAsync();

        }

        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }
    }
}
