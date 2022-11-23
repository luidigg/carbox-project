//APP DO USUÁRIO

using MySql.Data.MySqlClient;


MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;user=root; database=test; password=;");
    
    objcon.Open();

MySqlCommand objCmd = new MySqlCommand("insert into clientes (CLIENTE_NOME, CLIENTE_NUMERO, CLIENTE_PLACA, DATA_NASCIMENTO) values ('Carlos Ribeiro', '(55) 123456789', 'YEP2030', '2010-08-12')",objcon);

    objCmd.ExecuteNonQuery();

//https://www.devmedia.com.br/como-criar-um-sistema-sistema-de-autenticacao-em-asp-net-e-csharp/31701


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
Console.WriteLine("CarboxAPP 1.0 - Darla Juchum e Luidi Giacomelli & Ryan Gomes | Setrem 2022");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();

//tela de login abaixo

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("[a]  -  Criar conta");
Console.WriteLine("[b]  -  Fazer login");

string opcaoLogin = Console.ReadLine();

if(opcaoLogin == "a")
{

    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Insira o seu nome");
    string nomeCliente = Console.ReadLine();

    Console.WriteLine("Insira seu número de celular");
    string telefoneCliente = Console.ReadLine();

    Console.WriteLine("Insira a placa do seu veículo");
    string placaCliente = Console.ReadLine();

    Console.WriteLine("Insira sua data de nascimento");
    string nascimentoCliente = Console.ReadLine();

    Console.Clear(); /////////


    Console.WriteLine("Insira seu nome de usuário");
    string usernameCliente = Console.ReadLine();

    Console.WriteLine("Insira sua senha");
    string senhaClienteA = Console.ReadLine();
    Console.Write

    //nome
    //numero
    //placa
    //nascimento
    //username
    //senha
    //cpf








}


if(opcaoLogin == "b")
{

}


//tela de login acima

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
Console.WriteLine();
Console.WriteLine("[4]  -  Meu Perfil");
Console.WriteLine("[5]  -  Meus veículos");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("[0]  -  Sair do Aplicativo");
Console.ResetColor();

string opcaoSelecionada = Console.ReadLine();


if(opcaoSelecionada == "")
    {
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("#ERRO 1#  -  Você não selecionou nenhuma opção, selecione uma opção numérica da lista e dê 'enter' -  EX.: '1'");
    }
Console.ResetColor();


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

