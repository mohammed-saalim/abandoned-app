var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", () => "Hello World!").AddEndpointFilter(async (efiContext, next) =>
    {
        app.Logger.LogInformation(efiContext.HttpContext.Request.Host.Value);
        var result = await next(efiContext);
        return result;
    });

app.Run();


