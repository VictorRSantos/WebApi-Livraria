﻿using Microsoft.EntityFrameworkCore;
using WebApi_Livraria.Models;

namespace WebApi_Livraria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}