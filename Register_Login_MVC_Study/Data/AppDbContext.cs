using Microsoft.EntityFrameworkCore;

using Register_Login_MVC_Study.Models; //Vamos usar nosso UserModel.cs

namespace Register_Login_MVC_Study.Data
{
    // ':' significa herança, nossa classe recebe todas as ferramentas do DbContext configurado no Program.cs
    public class AppDbContext : DbContext
    {
        // Ele serve para receber aquela string de conexão do appsettings.json e passar para a base do .NET
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        }

        //Fala para o sistema criar uma tabela com o nome 'user_table' utilizando das colunas que criamos no UserModel.cs
        public DbSet<UserModel> user_table { get; set; }
    }
}
