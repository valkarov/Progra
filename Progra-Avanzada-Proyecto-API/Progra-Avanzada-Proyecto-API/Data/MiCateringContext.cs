using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PrograAvanzadaProyectoAPI.Models;

public class MiCateringContext : DbContext
{
    public MiCateringContext() : base("name=MiCateringDatabase")
    {
        // Si estás utilizando una base de datos existente y no quieres que Entity Framework intente crear o modificar la estructura de la base de datos, puedes deshabilitar la inicialización aquí. Por ejemplo:
        // Database.SetInitializer<MiCateringContext>(null);
    }

    public DbSet<EmpleadoModel> Empleado { get; set; }
    public DbSet<EventoModel> Eventos { get; set; }
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ProductoModel> Productos { get; set; }
    public DbSet<InventarioModel> Inventario { get; set; }

    // Si necesitas configurar aspectos específicos del modelo o de las relaciones entre tablas, puedes sobrescribir el método OnModelCreating
    // Ejemplo:
    // protected override void OnModelCreating(DbModelBuilder modelBuilder)
    // {
    //     // Configuraciones personalizadas
    // }
}