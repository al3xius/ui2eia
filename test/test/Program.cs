using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
        
            using (var db = new SchuelerDbContext())
            {
                var s1 = new Schueler { Name = "Max Mustermann" };
                db.Sus.Add(s1);
                db.SaveChanges();

                /*var Sus = db.Sus.Where(s => s.Name.Contains("M"));

                foreach (var s in Sus)
                {
                    Console.WriteLine(s.Name);
                }*/
            }
            
        }
    }


    public class Klasse
    {
        public int KlasseId { get; set; }
        public string Bezeichnung { get; set; }
        public List<Schueler> Sus { get; set; }
    }

    public class Schueler
    {
        public int SchuelerId { get; set; }
        public string Name { get; set; }
    }

    public class SchuelerDbContext : DbContext
    {
        public SchuelerDbContext(DbContextOptions<SchuelerDbContext> options)
            : base(options)
        { }
        public DbSet<Schueler> Sus { get; set; }
        public DbSet<Klasse> Klassen { get; set; }

    }
}
