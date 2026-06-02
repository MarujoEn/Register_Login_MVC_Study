
//Adiciona a biblioteca de banco de dados
using Microsoft.EntityFrameworkCore;
using Register_Login_MVC_Study.Data; //Especifica que vamos usar a pasta .Data onde mantemos AppDbContext.cs gerenciando a conexão do banco de dados.

var builder = WebApplication.CreateBuilder(args);

//Função padrão do dotnet para ler a conexão feita no appsettings.json
var SQLConnectionString = builder.Configuration.GetConnectionString("PostgresConnection");

//Adiciona a 'caixa de ferramentas' o nosso banco de dados, avisando ao sistema que vamos usar PostgreeSQL
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(SQLConnectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
