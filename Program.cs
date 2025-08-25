var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    var process = new System.Diagnostics.Process();
    process.StartInfo.FileName = "open";
    process.StartInfo.Arguments = "http://localhost:5000/swagger";
    process.Start();
}


app.Run();
