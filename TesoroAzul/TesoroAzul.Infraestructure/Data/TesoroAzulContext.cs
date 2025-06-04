using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TesoroAzul.Infraestructure.Models;

namespace TesoroAzul.Infraestructure.Data;

public partial class TesoroAzulContext : DbContext
{
    public TesoroAzulContext(DbContextOptions<TesoroAzulContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barco> Barco { get; set; }

    public virtual DbSet<BarcoHabitacion> BarcoHabitacion { get; set; }

    public virtual DbSet<Calendario> Calendario { get; set; }

    public virtual DbSet<CalendarioHabitacion> CalendarioHabitacion { get; set; }

    public virtual DbSet<Complemento> Complemento { get; set; }

    public virtual DbSet<Crucero> Crucero { get; set; }

    public virtual DbSet<CruceroPuerto> CruceroPuerto { get; set; }

    public virtual DbSet<CuentaCobrar> CuentaCobrar { get; set; }

    public virtual DbSet<Habitacion> Habitacion { get; set; }

    public virtual DbSet<Huesped> Huesped { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Puerto> Puerto { get; set; }

    public virtual DbSet<ReservaComplemento> ReservaComplemento { get; set; }

    public virtual DbSet<ReservaDetalle> ReservaDetalle { get; set; }

    public virtual DbSet<ReservaEncabezado> ReservaEncabezado { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barco>(entity =>
        {
            entity.HasKey(e => e.IdBarco);

            entity.Property(e => e.IdBarco).HasColumnName("id_barco");
            entity.Property(e => e.CapacidadHuespedes).HasColumnName("capacidadHuespedes");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(700)
                .HasColumnName("descripcion");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<BarcoHabitacion>(entity =>
        {
            entity.HasKey(e => new { e.IdBarco, e.IdHabitacion });

            entity.Property(e => e.IdBarco).HasColumnName("id_barco");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdBarcoNavigation).WithMany(p => p.BarcoHabitacion)
                .HasForeignKey(d => d.IdBarco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CruceroHabitacion_Barco");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.BarcoHabitacion)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CruceroHabitacion_Habitacion");
        });

        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.HasKey(e => new { e.FechaInicio, e.IdCrucero });

            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCrucero).HasColumnName("id_crucero");
            entity.Property(e => e.FechaPago).HasColumnName("fecha_pago");

            entity.HasOne(d => d.IdCruceroNavigation).WithMany(p => p.Calendario)
                .HasForeignKey(d => d.IdCrucero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calendario_Crucero");
        });

        modelBuilder.Entity<CalendarioHabitacion>(entity =>
        {
            entity.HasKey(e => new { e.IdHabitacion, e.FechaInicio, e.IdCrucero });

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCrucero).HasColumnName("id_crucero");
            entity.Property(e => e.Disponible).HasColumnName("disponible");
            entity.Property(e => e.Precio).HasColumnName("precio");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.CalendarioHabitacion)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalendarioHabitacion_Habitacion");

            entity.HasOne(d => d.Calendario).WithMany(p => p.CalendarioHabitacion)
                .HasForeignKey(d => new { d.FechaInicio, d.IdCrucero })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CalendarioHabitacion_Calendario");
        });

        modelBuilder.Entity<Complemento>(entity =>
        {
            entity.HasKey(e => e.IdComplemento);

            entity.Property(e => e.IdComplemento).HasColumnName("id_complemento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(700)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.PrecioAplicado)
                .HasMaxLength(50)
                .HasColumnName("precio_aplicado");
        });

        modelBuilder.Entity<Crucero>(entity =>
        {
            entity.HasKey(e => e.IdCrucero);

            entity.Property(e => e.IdCrucero).HasColumnName("id_crucero");
            entity.Property(e => e.CantidadDias).HasColumnName("cantidad_dias");
            entity.Property(e => e.Foto).HasColumnName("foto");
            entity.Property(e => e.IdBarco).HasColumnName("id_barco");
            entity.Property(e => e.Nombre)
                .HasMaxLength(300)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdBarcoNavigation).WithMany(p => p.Crucero)
                .HasForeignKey(d => d.IdBarco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Crucero_Barco");
        });

        modelBuilder.Entity<CruceroPuerto>(entity =>
        {
            entity.HasKey(e => new { e.IdCrucero, e.IdPuerto, e.NumeroDia }).HasName("PK_CruceroPuerto_1");

            entity.Property(e => e.IdCrucero).HasColumnName("id_crucero");
            entity.Property(e => e.IdPuerto).HasColumnName("id_puerto");
            entity.Property(e => e.NumeroDia).HasColumnName("numero_dia");
            entity.Property(e => e.HoraLlegada)
                .HasMaxLength(50)
                .HasColumnName("hora_llegada");
            entity.Property(e => e.HoraSalida)
                .HasMaxLength(50)
                .HasColumnName("hora_salida");

            entity.HasOne(d => d.IdCruceroNavigation).WithMany(p => p.CruceroPuerto)
                .HasForeignKey(d => d.IdCrucero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CruceroPuerto_Crucero");

            entity.HasOne(d => d.IdPuertoNavigation).WithMany(p => p.CruceroPuerto)
                .HasForeignKey(d => d.IdPuerto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CruceroPuerto_Puerto");
        });

        modelBuilder.Entity<CuentaCobrar>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK_CuentaCobrar_1");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("id_reserva");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.MontoCobrar).HasColumnName("montoCobrar");

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.CuentaCobrar)
                .HasForeignKey<CuentaCobrar>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CuentaCobrar_ReservaEncabezado");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion);

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasColumnName("descripcion");
            entity.Property(e => e.Imagen).HasColumnName("imagen");
            entity.Property(e => e.MaximoHuespedes).HasColumnName("maximo_huespedes");
            entity.Property(e => e.MinimoHuespedes).HasColumnName("minimo_huespedes");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Tamanio).HasColumnName("tamanio");
        });

        modelBuilder.Entity<Huesped>(entity =>
        {
            entity.HasKey(e => e.IdHuesped);

            entity.Property(e => e.IdHuesped).HasColumnName("id_huesped");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("genero");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdReservaDetalle).HasColumnName("id_reserva_detalle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.ReservaDetalle).WithMany(p => p.Huesped)
                .HasForeignKey(d => new { d.IdReserva, d.IdReservaDetalle })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Huesped_ReservaDetalle1");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.IdPais)
                .ValueGeneratedNever()
                .HasColumnName("id_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Puerto>(entity =>
        {
            entity.HasKey(e => e.IdPuerto);

            entity.Property(e => e.IdPuerto)
                .ValueGeneratedNever()
                .HasColumnName("id_puerto");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Puerto)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puerto_Pais");
        });

        modelBuilder.Entity<ReservaComplemento>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdComplemento });

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdComplemento).HasColumnName("id_complemento");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");

            entity.HasOne(d => d.IdComplementoNavigation).WithMany(p => p.ReservaComplemento)
                .HasForeignKey(d => d.IdComplemento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaComplemento_Complemento");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaComplemento)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaComplemento_ReservaEncabezado");
        });

        modelBuilder.Entity<ReservaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdReservaDetalle });

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdReservaDetalle)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_reserva_detalle");
            entity.Property(e => e.CantidadHuespedes).HasColumnName("cantidad_huespedes");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.ReservaDetalle)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaDetalle_Habitacion");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.ReservaDetalle)
                .HasForeignKey(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaDetalle_ReservaEncabezado");
        });

        modelBuilder.Entity<ReservaEncabezado>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.CantidadHabitaciones).HasColumnName("cantidad_habitaciones");
            entity.Property(e => e.CantidadPasajeros).HasColumnName("cantidad_pasajeros");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCrucero).HasColumnName("id_crucero");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Impuestos).HasColumnName("impuestos");
            entity.Property(e => e.Pendiente).HasColumnName("pendiente");
            entity.Property(e => e.Subtotal).HasColumnName("subtotal");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.TotalComplementos).HasColumnName("total_complementos");
            entity.Property(e => e.TotalHabitaciones).HasColumnName("total_habitaciones");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ReservaEncabezado)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaEncabezado_Usuario");

            entity.HasOne(d => d.Calendario).WithMany(p => p.ReservaEncabezado)
                .HasForeignKey(d => new { d.FechaInicio, d.IdCrucero })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservaEncabezado_Calendario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
