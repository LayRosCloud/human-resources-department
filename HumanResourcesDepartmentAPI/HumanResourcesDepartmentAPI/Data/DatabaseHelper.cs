using HumanResourcesDepartmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesDepartmentAPI.Data
{
    public class DatabaseHelper: DbContext
    {
        private const string UserId = "root";
        private const string Password = "1234567890";
        private const string DatabaseName = "humanbd";
        private const string Host = "127.0.0.1";
        private const int Port = 3306;
        private readonly string _connectionString = $"User Id={UserId};Password={Password};Host={Host};Database={DatabaseName};port={Port};";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
        
        public DbSet<RoleEntity> roles { get; set; } = null!;
        public DbSet<PersonEntity> people { get; set; } = null!;
        public DbSet<TypeOfPhoneEntity> types_of_phone { get; set; } = null!;
        public DbSet<TypeOfSessionEntity> types_of_sessions { get; set; } = null!;
        public DbSet<CountryEntity> countries { get; set; } = null!;
        public DbSet<RegionEntity> regions { get; set; } = null!;
        public DbSet<AreaEntity> areas { get; set; } = null!;
        public DbSet<CityEntity> cities { get; set; } = null!;
        public DbSet<StreetEntity> streets { get; set; } = null!;
        public DbSet<CityStreetEntity> cities_streets { get; set; } = null!;
        public DbSet<AddressEntity> addresses { get; set; } = null!;
        public DbSet<PhoneEntity> phones { get; set; } = null!;
        public DbSet<SeparationEntity> separations { get; set; } = null!;
        public DbSet<DisciplineBanEntity> discipline_bans { get; set; } = null!;
        public DbSet<SessionEntity> sessions { get; set; } = null!;
        public DbSet<PassportEntity> passports { get; set; } = null!;
    }
}
