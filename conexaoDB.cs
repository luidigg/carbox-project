//teste inicial

using MySql.Data.MySqlClient;

namespace DAL
{
    public class DatabaseService
    {
        private MySqlConnection _connection;
        public DatabaseService()
        {
            _connection = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=classicmodels");
            _connection.Open();
        }

        public MySqlDataReader Select(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, _connection);
            return command.ExecuteReader();
        }
    }

}

//https://www.devmedia.com.br/como-criar-um-sistema-sistema-de-autenticacao-em-asp-net-e-csharp/31701

// precisamos programar a:
// > criação de conta por parte do usuário e das oficinas
// > login de clientes cadastrados
// > depois partimos pras outras etapas...


// abaixo segue o codigo simples da parte do menu principal do app, só um esboço, depois vamos adicionando as coisas. ___esse aqui é o app do usuário__
// cada menu tem uma cor;


//string nome = "Maurício";
//string sobrenome = "Schiavo";

//Console.Write("Nome".PadRight(30, '.'));
//Console.WriteLine(nome.PadLeft(20));

//Console.Write("Sobrenome".PadRight(30, '.'));
//Console.WriteLine(sobrenome.PadLeft(20));

//Console.BackgroundColor = ConsoleColor.Blue;
//Console.ForegroundColor = ConsoleColor.Black;
//Console.WriteLine("Oi galera!");
//Console.ResetColor();
//Console.WriteLine("Tudo bem com vocês?!");


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("CarboxAPP 1.0 - Darla Juchum e Luidi Giacomelli | Setrem 2022");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();

//tela de login aparece agora, após logado, aparece o menu abaixo:

Console.ForegroundColor = ConsoleColor.Cyan;

Console.WriteLine("Menu Pricipal");
Console.WriteLine();
Console.WriteLine("__________ Escolha uma das opções listadas: __________");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("[1]  -  Oficinas Disponíveis");
Console.WriteLine("[2]  -  Manutenções Agendadas");
Console.WriteLine("[3]  -  Mapa de Oficinas | (Google Maps)");
Console.WriteLine();
Console.WriteLine("[4]  -  Chamada de Emergência");
Console.WriteLine();
Console.WriteLine("[5]  -  Meu Perfil");
Console.WriteLine("[6]  -  Meus veículos");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("[0]  -  Sair do Aplicativo");
Console.ResetColor();

string opcaoSelecionada = Console.ReadLine();

if(opcaoSelecionada == null)
    {
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("#ERRO 1#  -  Selecione uma opção numérica  //  ex.: '1'");
    }

if(opcaoSelecionada == "1"){}

if(opcaoSelecionada == "2"){}

if(opcaoSelecionada == "3"){}

if(opcaoSelecionada == "4"){}

if(opcaoSelecionada == "5"){}

if(opcaoSelecionada == "6"){}

if(opcaoSelecionada == "0")
{
    break;
}

