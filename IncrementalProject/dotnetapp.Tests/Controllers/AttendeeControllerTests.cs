using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace dotnetapp.Tests.Controllers;

public class AttendeeControllerTests
{
    private static ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Test]
    public async Task GetAttendees_Returns_All_Attendees()
    {
        await using var context = CreateContext();
        context.Attendees.Add(new Attendee
        {
            Name = "Ria",
            Age = "24",
            Email = "ria@example.com"
        });
        await context.SaveChangesAsync();

        var controller = new AttendeeController(context);

        var result = await controller.GetAttendees();

        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value!.Count(), Is.EqualTo(1));
    }
}