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

namespace proxy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new SchuelerDbContext()) {
                var s1 = new Schueler { Name = "Max Mustermann" };
                db.Sus.Add(s1);
                db.SaveChanges();

                var sus = db.Sus
                    .Where(s => s.Name.Contains("M"));

                foreach (var s in sus) {
                    Console.WriteLine(s.Name);
                }
            }
                BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public class Klasse {
        public int KlasseId { get; set; }
        public string Bezeichnung { get; set; }
        public List<Schueler> Sus { get; set; }
    }

    public class Schueler {
        public int SchuelerId { get; set; }
        public string Name { get; set; }
    }

    public class SchuelerDbContext : DbContext {
        public DbSet<Schueler> Sus { get; set; }
        public DbSet<Klasse> Klassen { get; set; }

        public SchuelerDbContext(DbContextOptions<SchuelerDbContext> options)
            : base(options)
        {
        }

    }
}
