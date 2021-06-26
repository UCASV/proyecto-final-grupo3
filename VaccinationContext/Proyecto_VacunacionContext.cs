using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProyectoVacunacionCovid.VaccinationContext
{
    public partial class Proyecto_VacunacionContext : DbContext
    {
        public Proyecto_VacunacionContext()
        {
        }

        public Proyecto_VacunacionContext(DbContextOptions<Proyecto_VacunacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentEffect> AppointmentEffects { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<ChronicleDisease> ChronicleDiseases { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<ManagerxCabin> ManagerxCabins { get; set; }
        public virtual DbSet<SecundaryEffect> SecundaryEffects { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<UserDisease> UserDiseases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=localhost;Database=Proyecto_Vacunacion;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.HasOne(d => d.IdCityNavigation)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.IdCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ADDRESS__id_city__403A8C7D");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateHourProcessed)
                    .HasColumnType("datetime")
                    .HasColumnName("date_hour_processed");

                entity.Property(e => e.DateHourSchedule)
                    .HasColumnType("datetime")
                    .HasColumnName("date_hour_schedule");

                entity.Property(e => e.DateHourVaccination)
                    .HasColumnType("datetime")
                    .HasColumnName("date_hour_vaccination");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__dui_c__46E78A0C");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_ca__45F365D3");
            });

            modelBuilder.Entity<AppointmentEffect>(entity =>
            {
                entity.ToTable("APPOINTMENT_EFFECT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.Property(e => e.IdSecundaryEffect).HasColumnName("id_secundary_effect");

                entity.Property(e => e.Minute).HasColumnName("minute");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.AppointmentEffects)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_ap__4D94879B");

                entity.HasOne(d => d.IdSecundaryEffectNavigation)
                    .WithMany(p => p.AppointmentEffects)
                    .HasForeignKey(d => d.IdSecundaryEffect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_se__4CA06362");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.HasIndex(e => e.PhoneNumber, "UQ__CABIN__A1936A6B46738754")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAddress).HasColumnName("id_address");

                entity.Property(e => e.IdManager).HasColumnName("id_manager");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Cabins)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CABIN__id_addres__44FF419A");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.Cabins)
                    .HasForeignKey(d => d.IdManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CABIN__id_manage__440B1D61");
            });

            modelBuilder.Entity<ChronicleDisease>(entity =>
            {
                entity.ToTable("CHRONICLE_DISEASE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChronicleDisease1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chronicle_disease");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__CITIZEN__C03671B88A2CBB4B");

                entity.ToTable("CITIZEN");

                entity.HasIndex(e => e.PhoneNumber, "UQ__CITIZEN__A1936A6BA547BF24")
                    .IsUnique();

                entity.Property(e => e.Dui)
                    .ValueGeneratedNever()
                    .HasColumnName("DUI");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAddress).HasColumnName("id_address");

                entity.Property(e => e.IdInstitution).HasColumnName("id_institution");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_addr__47DBAE45");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_inst__3F466844");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.IdState).HasColumnName("id_state");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITY__id_state__412EB0B6");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdAddress).HasColumnName("id_address");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TypeEmployee)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type_employee");

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_add__4222D4EF");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("INSTITUTION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("MANAGER");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANAGER__id_empl__4316F928");
            });

            modelBuilder.Entity<ManagerxCabin>(entity =>
            {
                entity.ToTable("MANAGERxCABIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatetimeLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_login");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdManager).HasColumnName("id_manager");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.ManagerxCabins)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANAGERxC__id_ca__4BAC3F29");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.ManagerxCabins)
                    .HasForeignKey(d => d.IdManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MANAGERxC__id_ma__4AB81AF0");
            });

            modelBuilder.Entity<SecundaryEffect>(entity =>
            {
                entity.ToTable("SECUNDARY_EFFECT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SecundaryEffect1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("secundary_effect");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("STATE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.State1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("state");
            });

            modelBuilder.Entity<UserDisease>(entity =>
            {
                entity.HasKey(e => new { e.IdChronicleDisease, e.DuiCitizen })
                    .HasName("PK_user_disease");

                entity.ToTable("USER_DISEASE");

                entity.Property(e => e.IdChronicleDisease).HasColumnName("id_chronicle_disease");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.UserDiseases)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER_DISE__dui_c__49C3F6B7");

                entity.HasOne(d => d.IdChronicleDiseaseNavigation)
                    .WithMany(p => p.UserDiseases)
                    .HasForeignKey(d => d.IdChronicleDisease)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER_DISE__id_ch__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
