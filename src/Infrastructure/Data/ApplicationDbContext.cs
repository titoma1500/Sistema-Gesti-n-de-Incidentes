using Microsoft.EntityFrameworkCore;
using Proyecto.Domain.Entities;
using Proyecto.Domain.Enums;

namespace Proyecto.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Incidente> Incidentes { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
    public DbSet<BaseConocimiento> BaseConocimiento { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Nombre).IsRequired().HasMaxLength(200);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(u => u.Email).IsUnique();
            entity.Property(u => u.PasswordHash).IsRequired();
            entity.Property(u => u.Nivel).HasConversion<int>();
            entity.Property(u => u.Especialidad).HasMaxLength(200);
        });

        // Configuración Incidente
        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.Titulo).IsRequired().HasMaxLength(300);
            entity.Property(i => i.Descripcion).IsRequired();
            entity.Property(i => i.Estado).HasConversion<int>();
            entity.Property(i => i.Prioridad).HasConversion<int>();

            // Relación Usuario Reporta
            entity.HasOne(i => i.UsuarioReporta)
                .WithMany(u => u.IncidentesReportados)
                .HasForeignKey(i => i.UsuarioReportaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Usuario Asignado
            entity.HasOne(i => i.UsuarioAsignado)
                .WithMany(u => u.IncidentesAsignados)
                .HasForeignKey(i => i.UsuarioAsignadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Auto-relación para escalación
            entity.HasOne(i => i.IncidentePadre)
                .WithMany(i => i.IncidentesEscalados)
                .HasForeignKey(i => i.IncidentePadreId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos con Etiquetas
            entity.HasMany(i => i.Etiquetas)
                .WithMany(e => e.Incidentes)
                .UsingEntity(j => j.ToTable("IncidenteEtiqueta"));
        });

        // Configuración Etiqueta
        modelBuilder.Entity<Etiqueta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Categoria).HasConversion<int>();
            entity.HasIndex(e => e.Nombre).IsUnique();
        });

        // Configuración BaseConocimiento
        modelBuilder.Entity<BaseConocimiento>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Titulo).IsRequired().HasMaxLength(300);
            entity.Property(b => b.Descripcion).IsRequired();
            entity.Property(b => b.Solucion).IsRequired();

            // Relación con Usuario creador
            entity.HasOne(b => b.CreadoPor)
                .WithMany()
                .HasForeignKey(b => b.CreadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos con Etiquetas
            entity.HasMany(b => b.Etiquetas)
                .WithMany(e => e.ArticulosConocimiento)
                .UsingEntity(j => j.ToTable("BaseConocimientoEtiqueta"));
        });

        // Configuración Notificacion
        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(n => n.Id);
            entity.Property(n => n.Tipo).HasConversion<int>();
            entity.Property(n => n.Mensaje).IsRequired();

            // Relación con Usuario
            entity.HasOne(n => n.Usuario)
                .WithMany(u => u.Notificaciones)
                .HasForeignKey(n => n.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con Incidente (opcional)
            entity.HasOne(n => n.Incidente)
                .WithMany(i => i.Notificaciones)
                .HasForeignKey(n => n.IncidenteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Datos de prueba
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Usuarios de prueba
        modelBuilder.Entity<Usuario>().HasData(
            // Admin
            new Usuario
            {
                Id = 1,
                Nombre = "Admin Principal",
                Email = "admin@universidad.edu",
                PasswordHash = "admin123",
                Nivel = NivelUsuario.Nivel5,
                Especialidad = "Administración General",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            // Técnicos Nivel 4 - Infraestructura y Seguridad
            new Usuario
            {
                Id = 2,
                Nombre = "Carlos Mendoza",
                Email = "carlos.mendoza@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel4,
                Especialidad = "Infraestructura Cloud",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 3,
                Nombre = "Ana Patricia Ruiz",
                Email = "ana.ruiz@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel4,
                Especialidad = "Seguridad Informática",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 4,
                Nombre = "Roberto Sánchez",
                Email = "roberto.sanchez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel4,
                Especialidad = "Arquitectura de Sistemas",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 5,
                Nombre = "Laura Fernández",
                Email = "laura.fernandez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel4,
                Especialidad = "DevOps y Automatización",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 6,
                Nombre = "Miguel Ángel Torres",
                Email = "miguel.torres@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel4,
                Especialidad = "Ciberseguridad",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            // Técnicos Nivel 3 - Redes y Servidores
            new Usuario
            {
                Id = 7,
                Nombre = "Patricia Morales",
                Email = "patricia.morales@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel3,
                Especialidad = "Administración de Redes",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 8,
                Nombre = "Jorge Luis Ramírez",
                Email = "jorge.ramirez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel3,
                Especialidad = "Servidores y Virtualización",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 9,
                Nombre = "Sofía Castro",
                Email = "sofia.castro@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel3,
                Especialidad = "Redes Inalámbricas",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 10,
                Nombre = "Diego Herrera",
                Email = "diego.herrera@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel3,
                Especialidad = "Bases de Datos",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 11,
                Nombre = "Valentina López",
                Email = "valentina.lopez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel3,
                Especialidad = "Almacenamiento y Backup",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            // Técnicos Nivel 2 - Software y Aplicaciones
            new Usuario
            {
                Id = 12,
                Nombre = "Andrés Jiménez",
                Email = "andres.jimenez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel2,
                Especialidad = "Desarrollo Web",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 13,
                Nombre = "Camila Vargas",
                Email = "camila.vargas@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel2,
                Especialidad = "Aplicaciones Empresariales",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 14,
                Nombre = "Felipe Ortiz",
                Email = "felipe.ortiz@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel2,
                Especialidad = "Integración de Sistemas",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 15,
                Nombre = "Daniela Rojas",
                Email = "daniela.rojas@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel2,
                Especialidad = "Plataformas Educativas",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 16,
                Nombre = "Sebastián Peña",
                Email = "sebastian.pena@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel2,
                Especialidad = "Software de Gestión",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            // Técnicos Nivel 1 - Soporte Básico
            new Usuario
            {
                Id = 17,
                Nombre = "Gabriela Muñoz",
                Email = "gabriela.munoz@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel1,
                Especialidad = "Soporte Técnico General",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 18,
                Nombre = "Alejandro Cruz",
                Email = "alejandro.cruz@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel1,
                Especialidad = "Atención al Usuario",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 19,
                Nombre = "Isabella Romero",
                Email = "isabella.romero@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel1,
                Especialidad = "Hardware y Mantenimiento",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 20,
                Nombre = "Mateo Silva",
                Email = "mateo.silva@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel1,
                Especialidad = "Soporte de Office",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 21,
                Nombre = "Lucía Martínez",
                Email = "lucia.martinez@universidad.edu",
                PasswordHash = "tecnico123",
                Nivel = NivelUsuario.Nivel1,
                Especialidad = "Conectividad y Accesos",
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            // Estudiantes
            new Usuario
            {
                Id = 22,
                Nombre = "Juan Pablo Pérez",
                Email = "juan.perez@universidad.edu",
                PasswordHash = "estudiante123",
                Nivel = NivelUsuario.Estudiante,
                Especialidad = null,
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 23,
                Nombre = "María José González",
                Email = "maria.gonzalez@universidad.edu",
                PasswordHash = "estudiante123",
                Nivel = NivelUsuario.Estudiante,
                Especialidad = null,
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 24,
                Nombre = "David Rodríguez",
                Email = "david.rodriguez@universidad.edu",
                PasswordHash = "estudiante123",
                Nivel = NivelUsuario.Estudiante,
                Especialidad = null,
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 25,
                Nombre = "Carolina Díaz",
                Email = "carolina.diaz@universidad.edu",
                PasswordHash = "estudiante123",
                Nivel = NivelUsuario.Estudiante,
                Especialidad = null,
                Activo = true,
                FechaCreacion = DateTime.Now
            },
            new Usuario
            {
                Id = 26,
                Nombre = "Nicolás Gómez",
                Email = "nicolas.gomez@universidad.edu",
                PasswordHash = "estudiante123",
                Nivel = NivelUsuario.Estudiante,
                Especialidad = null,
                Activo = true,
                FechaCreacion = DateTime.Now
            }
        );

        // Etiquetas de prueba
        modelBuilder.Entity<Etiqueta>().HasData(
            new Etiqueta { Id = 1, Nombre = "Hardware", Categoria = CategoriaEtiqueta.Hardware, Descripcion = "Problemas de hardware" },
            new Etiqueta { Id = 2, Nombre = "Software", Categoria = CategoriaEtiqueta.Software, Descripcion = "Problemas de software" },
            new Etiqueta { Id = 3, Nombre = "Red", Categoria = CategoriaEtiqueta.Red, Descripcion = "Problemas de red" },
            new Etiqueta { Id = 4, Nombre = "Impresora", Categoria = CategoriaEtiqueta.Impresora, Descripcion = "Problemas con impresoras" },
            new Etiqueta { Id = 5, Nombre = "Email", Categoria = CategoriaEtiqueta.Email, Descripcion = "Problemas con correo electrónico" },
            new Etiqueta { Id = 6, Nombre = "Windows", Categoria = CategoriaEtiqueta.SistemaOperativo, Descripcion = "Problemas con Windows" },
            new Etiqueta { Id = 7, Nombre = "Office", Categoria = CategoriaEtiqueta.Aplicacion, Descripcion = "Problemas con Office" }
        );
    }
}
