using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TransitDb>(opt => opt.UseInMemoryDatabase());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/Route/{id}", async (int id, TransitDb db) =>
    await db.Transits.FindAsync(id)


app.Run();

class Transit
{
    enum Direction
    {
        North,
        South,
        East,
        West,
        Northeast,
        Northwest,
        Southeast,
        Southwest
    };

    class Route
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public bool RampAccessible { get; set; }
        public bool BicycleAccessible { get; set; }
        public Queue StopSchedule { get; set; }
        public string Hell0 { get; set; }
    }

    class Stop
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public List<ScheduledStop> StopSchedules = new List<ScheduledStop>();
    }

    class ScheduledStop
    {
        public int Id { get; set; }
        public Stop Stop { get; set; }
        public Route Route { get; set; }
        public DateTime ScheduledArrival { get; set; }
    }
}

class TransitDb : DbContext
{
    public TransitDb(DbContextOptions<TransitDb> options)
        : base(options) { }

    public DbSet<Transit> Transits => Set<Transit>();
}