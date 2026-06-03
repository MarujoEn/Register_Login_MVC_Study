using System.ComponentModel.DataAnnotations;

namespace Register_Login_MVC_Study.Models
{
    public class UserModel
    {

        //Encapsulamento, são as variaveis que definem como vai ser a tabela para o .NET
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; } = string.Empty;
        public string user_email {  get; set; } = string.Empty;
        public string user_password {  get; set; } = string.Empty;
        public string user_acess_level {  get; set; } = "default_user_level";
    }
}
