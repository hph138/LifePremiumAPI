using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifePremiumAPI.Model
{
    public class ApiContext : DbContext
    {
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public ApiContext(DbContextOptions options) : base(options)
        {
            LoadOccupations();
            LoadFactors();
        }

        public void LoadFactors()
        {
            Factor factor = new Factor() { Id = 1, Name = "Professional", Point = 1.0 };
            Factors.Add(factor);
            factor = new Factor() { Id = 2, Name = "White Collar", Point = 1.25 };
            Factors.Add(factor);
            factor = new Factor() { Id = 3, Name = "Light Manual", Point = 1.50 };
            Factors.Add(factor);
            factor = new Factor() { Id = 4, Name = "Heavy Manual", Point = 1.75 };
            Factors.Add(factor);
        }
        public void LoadOccupations()
        {
            Occupation occupation = new Occupation() { Id = 1, Name= "Cleaner", RateId = 3 };
            Occupations.Add(occupation);
            occupation = new Occupation() { Id = 2, Name = "Doctor", RateId = 1 };
            Occupations.Add(occupation);
            occupation = new Occupation() { Id = 3, Name = "Author", RateId = 2 };
            Occupations.Add(occupation);
            occupation = new Occupation() { Id = 4, Name = "Farmer", RateId = 4 };
            Occupations.Add(occupation);
            occupation = new Occupation() { Id = 5, Name = "Mechanic", RateId = 4 };
            Occupations.Add(occupation);
            occupation = new Occupation() { Id = 6, Name = "Florist", RateId = 3 };
            Occupations.Add(occupation);

        }

        public List<Occupation> GetOccupations()
        {
            return Occupations.Local.ToList<Occupation>();
        }

        public List<Factor> GetFactors()
        {
            return Factors.Local.ToList<Factor>();
        }

    }
}
