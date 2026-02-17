using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace dotnetapp.Tests.Controllers;

public class EventControllerTests
{
    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Test]
    public async Task GetEvents_Returns_All_Events()
    {
        await using var context = CreateContext();
        context.Events.Add(new Event
        {
            Name = "Demo Event",
            Location = "Chennai",
            Date = DateTime.UtcNow,
            Budget = 1000
        });
        await context.SaveChangesAsync();

        var controller = new EventController(context);

        var result = await controller.GetEvents();

        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value!.Count(), Is.EqualTo(1));
    }
}