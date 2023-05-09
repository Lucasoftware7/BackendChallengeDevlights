var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Create the Cors variable 
var CorsConfiguration = "_CorsConfiguration";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Creating a CORS policy that allows the usage of the API from any origin 
builder.Services.AddCors(options=>

{
    options.AddPolicy(name: CorsConfiguration, builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

});
}


);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(CorsConfiguration);


app.MapControllers();

app.Run();
