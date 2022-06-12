﻿using GAMER_TECHNOLOGY.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GAMER_TECHNOLOGY.Data.Service
{
    public interface IArticuloService
    {
        Task Delete(int id);
        Task<IEnumerable<Articulo>> GetAll();
        Task<Articulo> GetId(int IdArticulo);
        Task InsertArt(Articulo articulo);

        Task<IEnumerable<Articulo>> GetCategoria();
        Task UpdateArticulo(Articulo articulo);
    }
}