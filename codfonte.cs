//APP DO USUÁRIO

using DocumentValidator;
using MySql.Data.MySqlClient;


MySqlConnection objcon = new MySqlConnection("server=localhost;port=3306;user=root; database=test; password=;");

objcon.Open();

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

RETORNO1:
Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("CarboxAPP 1.0 - Darla Juchum, Luidi Giacomelli & Ryan Gomes | Setrem 2022");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();


//tela de login abaixo

Console.ForegroundColor = ConsoleColor.Cyan; //verificar com professor.

Console.WriteLine("[a]  -  Criar conta");
Console.WriteLine("[b]  -  Fazer login");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("[x]  -  Sair");
Console.ResetColor();

string opcaoLogin = Console.ReadLine();


if(opcaoLogin == "x")
{
    return;
}

if (opcaoLogin == "")
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Nenhuma opção foi selecionada, digite 'a' ou 'b' e tecle Enter");
    Thread.Sleep(3500);
    Console.Beep(600, 700);
    goto RETORNO1;
}

if (opcaoLogin == "a")
{
    RETORNO2:
    Console.ResetColor();
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("");
    Console.WriteLine("Insira o seu nome completo");
    string nomeCliente = Console.ReadLine();
    if (nomeCliente.Length < 8)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("O nome inserido está incompleto ou é muito curto, tente novamente.");
        Thread.Sleep(3500);
        goto RETORNO2;
    }

    RETORNO3:
    Console.WriteLine("");
    Console.WriteLine("Insira seu número de telefone");
    string telefoneCliente = Console.ReadLine();

    if (telefoneCliente.Length < 8)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Digite um número de telefone válido");
        Thread.Sleep(3500);
        goto RETORNO3;
    }

    Console.WriteLine("");
    Console.WriteLine("Insira a placa do seu veículo  || EXEMPLO > ' BRA2E19 '");
    string placaCliente = Console.ReadLine();

    Console.WriteLine("");
    Console.WriteLine("Insira sua data de nascimento || EXEMPLO > ' dd/mm/aaaa '.");
    string nascimentoInformado = Console.ReadLine();
    DateTime nascimentoCliente = Convert.ToDateTime(nascimentoInformado);
    DateTime anoAtual = DateTime.Now;

    TimeSpan verificaMaioridade = anoAtual - nascimentoCliente;

    string idade1 = verificaMaioridade.ToString("dd");
    int idade2 = Convert.ToInt32(idade1);

    if (idade2 < 5840)
    {
        Console.WriteLine("Você possui menos de 18 anos, utilize o APP com cautela");
    }

    else if (idade2 < 6570)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Você possui menos de 16 anos, chame um responsável para se cadastrar no aplicativo");
        Thread.Sleep(2000);
        Console.Beep(2000, 600);
        Console.Beep(2000, 600);
        Console.ResetColor();
        goto RETORNO1;
    }



    while (true)
    {
        RETORNO4:
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("Insira seu CPF"); //implementar sistema de validação do CPF aqui
        string cpfCliente = Console.ReadLine();

        if (cpfCliente == "")
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Insira um CPF válido");
            goto RETORNO4;
        }

        else if (cpfCliente.Length < 11)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("CPF muito curto, insira um CPF válido");
            goto RETORNO4;
        }

        bool IsValid = CpfValidation.Validate(cpfCliente);

        if (IsValid == false)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Insira um CPF válido");
            goto RETORNO4;
        }

        else
        {
            Console.Clear();
            Console.ResetColor();
        }

        RETORNO5:
        Console.WriteLine("Insira seu nome de usuário");
        string usernameCliente = Console.ReadLine();

        if (usernameCliente.Length > 15)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("# Insira um nome de usuário com menos de 15 caracteres #");
            Console.WriteLine("");
            goto RETORNO5;
        }

        RETORNO6:
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Insira sua senha");
        string senhaClienteA = Console.ReadLine();
        Console.WriteLine("");

        Console.WriteLine("Confirme sua senha");
        string senhaClienteB = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine("");

        if (senhaClienteA != senhaClienteB)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("As senhas devem ser iguais.");
            Console.WriteLine("");
            goto RETORNO6;
        }

        if (senhaClienteA == senhaClienteB)
        {
            RETORNOcreate:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("[0]  -  Cancelar");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1]  -  Confirmar Conta");
            Console.WriteLine("");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            
            string confirm = Console.ReadLine();
            int confirmaConta = Convert.ToInt16(confirm);


            if(confirmaConta == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelando criação de conta...");
                Thread.Sleep(1500);
                Console.Beep(1500, 500);
                Console.Beep(1500, 500);

                Console.Clear();
                Console.ResetColor();
                goto RETORNO1;
            }

            if(confirmaConta == 1)
            {
                MySqlCommand objCmd = new MySqlCommand("insert into clientes (CLIENTE_NOME, CLIENTE_NUMERO, DATA_NASCIMENTO, USERNAME_CLIENTE, USERSENHA_CLIENTE, CPF_CLIENTE) values (?, ?, ?, ?, ?, ?)", objcon);
                
                //parametros
                objCmd.Parameters.Add("@CLIENTE_NOME", MySqlDbType.VarChar, 100).Value = nomeCliente;
                objCmd.Parameters.Add("@CLIENTE_NUMERO", MySqlDbType.VarChar, 85).Value = telefoneCliente;
                objCmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = nascimentoCliente;
                objCmd.Parameters.Add("@USERNAME_CLIENTE", MySqlDbType.VarChar, 100).Value = usernameCliente;
                objCmd.Parameters.Add("@USERSENHA_CLIENTE", MySqlDbType.VarChar, 100).Value = senhaClienteB;
                objCmd.Parameters.Add("@CPF_CLIENTE", MySqlDbType.VarChar, 45).Value = cpfCliente;
                
                //executa o insert no banco
                objCmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Conta cadastrada com sucesso!");
                
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Nenhuma opção foi selecionada, digite '0' ou '1' e tecle Enter");
                goto RETORNOcreate;
            }
        }

    }

}



if (opcaoLogin == "b")
{
    //inserir criação de contas
}


//tela de login acima

Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("___________________Menu Pricipal______________________");
Console.WriteLine();
Console.WriteLine("__________ Escolha uma das opções listadas: __________");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("[1]  -  Oficinas Disponíveis");
Console.WriteLine("[2]  -  Manutenções Agendadas");
Console.WriteLine("[3]  -  Mapa de Oficinas | (Google Maps)");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("[4]  -  Meu Perfil");
Console.WriteLine("[5]  -  Meus veículos");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("[0]  -  Sair do Aplicativo");
Console.ResetColor();

string opcaoSelecionada = Console.ReadLine();


if (opcaoSelecionada == "")
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.WriteLine("#ERRO 1#  -  Você não selecionou nenhuma opção, selecione uma opção numérica da lista e dê 'enter' -  EX.: '1'");
}
Console.ResetColor();


if (opcaoSelecionada == "1") { }

if (opcaoSelecionada == "2") { }

if (opcaoSelecionada == "3") { }

if (opcaoSelecionada == "4") { }

if (opcaoSelecionada == "5") { }

if (opcaoSelecionada == "6") { }

if (opcaoSelecionada == "0")
{
    //break;
}