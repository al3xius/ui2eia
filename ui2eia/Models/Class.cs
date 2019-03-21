using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ui2eia.Models
{
    public class AccessContext : DbContext
    {
        public AccessContext(DbContextOptions<AccessContext> options)
            : base(options)
        { }

        public DbSet<Segment> Segments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }


    public class Segment
    {
        public int SegmentId { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public bool Access { get; set; }
        public string State { get; set; }
        public string Comment { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Tag { get; set; }
        public string UserName { get; set; }
        public int Rights { get; set; }
    }

    public class Log
    {
        public int LogId { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public Segment Segment { get; set; }
    }
}
