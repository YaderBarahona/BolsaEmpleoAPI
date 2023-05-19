﻿using System.Linq.Expressions;

namespace BolsaDeEmpleo.Repository.IRepository
    //interfaz generica para recibir cualquier tipo de entidad
    public interface IRepository<T> where T : class
    {
        Task Crear(T entidad);

        //obtiene la lista filtrada 
        //signo ? para indicar que no es obligatorio
        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null);

        Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true);

        Task Remover(T entidad);
         
        Task Grabar();

    }
}
