var app = WebApplication.Create();



app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(config =>
{
    config.MapGet("asom", (IHostEnvironment service, ILogger<PhoneContact> logger) =>
    {
        logger.LogInformation("Testing Di in Minimal Api");
        var data = new
        {
            Env  = new
            {
                mode = service.EnvironmentName,
                appName = service.ApplicationName,
                appPath =service.ContentRootPath
            },
            name = new
            {
                firstName = "Alfred",
                lastName = "Obialo",
                middleName = "Ikechukwu"
            },
            age = 34,
            phoneContact = new List<PhoneContact>
            {
                new() { Tag = "Primary", Number = "08069273479" },
                new() { Tag = "Office", Number = "08039973479" },
                new() { Tag = "Pager", Number = "09089973479" },
            },
            gender = "Male"
        };
        return Results.Ok(data);
    }).RequireAuthorization();
});

app.Run("http://localhost:7111");

public class PhoneContact
{
    public string Tag { get; set; }
    public string Number { get; set; }
}
