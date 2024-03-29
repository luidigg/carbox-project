//APP DO USUÁRIO

using DocumentValidator;
using MySql.Data.MySqlClient;


MySqlConnection objcon = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");

objcon.Open();


RETORNO1:
Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("CarboxAPP 1.0 - Darla Juchum, Luidi Giacomelli & Ryan Gomes | Setrem 2022");
Console.ResetColor();
Console.WriteLine();
Console.WriteLine();


//tela de login abaixo

Console.ForegroundColor = ConsoleColor.Cyan;

Console.WriteLine("[a]  -  Criar conta");
Console.WriteLine("[b]  -  Fazer login");
Console.WriteLine("");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("[x]  -  Sair");
Console.WriteLine("");
Console.ResetColor();

string opcaoLogin = Console.ReadLine();


if (opcaoLogin != "a" && opcaoLogin != "b" && opcaoLogin != "x")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Nenhuma opção foi selecionada, digite 'a' ou 'b' e tecle Enter");
    await Task.Delay(2000);
    Console.Beep(600, 700);
    goto RETORNO1;
}


if (opcaoLogin == "x")
{
    return;
}

if (opcaoLogin == "")
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Nenhuma opção foi selecionada, digite 'a' ou 'b' e tecle Enter");
    await Task.Delay(3500);
    Console.Beep(600, 700);
    goto RETORNO1;
}

if (opcaoLogin == "a") //criar conta
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
        await Task.Delay(3500);
        goto RETORNO2;
    }

RETORNO3:
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("");
    Console.WriteLine("Insira seu número de telefone");
    string telefoneCliente = Console.ReadLine();

    if (telefoneCliente.Length < 8)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Digite um número de telefone válido");
        await Task.Delay(3500);
        goto RETORNO3;
    }

    Console.WriteLine("");
    Console.WriteLine("Insira sua data de nascimento || EXEMPLO > ' dd/mm/aaaa '.");
    string nascimentoInformado = Console.ReadLine();
    DateTime nascimentoCliente = Convert.ToDateTime(nascimentoInformado);
    DateTime anoAtual = DateTime.Now;

    TimeSpan verificaMaioridade = anoAtual - nascimentoCliente;

    string idade1 = verificaMaioridade.ToString("dd");
    uint idade2 = Convert.ToUInt32(idade1);

    if (idade2 < 6570 && idade2 >= 5840)
    {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Você possui menos de 18 anos, utilize o APP com cautela");
        Console.ResetColor();
    }

    else if (idade2 < 5840)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("");
        Console.WriteLine("Você possui menos de 16 anos, chame um responsável para se cadastrar no aplicativo");
        await Task.Delay(2000);
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
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Insira seu nome de usuário");
        string usernameCliente = Console.ReadLine();
        Console.WriteLine("");

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
            await Task.Delay(1200);
            Console.Clear();
            goto RETORNO6;
        }

        if (senhaClienteA == senhaClienteB)
        {
        RETORNOcreate:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
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


            if (confirmaConta == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelando criação de conta...");
                await Task.Delay(1500);
                Console.Beep(1500, 500);
                Console.Beep(1500, 500);

                Console.Clear();
                Console.ResetColor();
                goto RETORNO1;
            }

            if (confirmaConta == 1)
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
                Console.Beep(1800, 400);
                await Task.Delay(1500);
                break;

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



if (opcaoLogin == "b") //ATUALIZADO: FUNCIONANDO
{

RETORNOlog:
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("");
    Console.WriteLine("Digite seu nome de usuário");
    string userInf = Console.ReadLine();

    Console.WriteLine("");
    Console.WriteLine("Digite sua senha:");
    string senhaInf = Console.ReadLine();


    MySqlCommand login1 = new MySqlCommand("select USERNAME_CLIENTE from clientes where USERNAME_CLIENTE = ? and USERSENHA_CLIENTE = ?", objcon);

    login1.Parameters.Add("@USERNAME_CLIENTE", MySqlDbType.VarChar, 100).Value = userInf;
    login1.Parameters.Add("@USERSENHA_CLIENTE", MySqlDbType.VarChar, 100).Value = senhaInf;

    var reader = login1.ExecuteReader();

    if (reader.HasRows)
    {
        //continua para o menu
    }

    else
    {
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("");
        Console.WriteLine("Senha ou usuário incorreto");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Beep(300, 500);
        Console.ResetColor();
        reader.Close();
        goto RETORNOlog;
    }

}

objcon.Close();

//tela de login acima



//MENU ABAIXO



while (true)
{
RETORNOmenu:

    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine("___________________Menu Pricipal______________________");
    Console.WriteLine();
    Console.WriteLine("__________ Escolha uma das opções listadas: __________");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("[1]  -  Oficinas Disponíveis");
    Console.WriteLine("[2]  -  Agendar Manutenções");
    Console.WriteLine("[3]  -  Ajuda com o veículo");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("[4]  -  Meu Perfil");
    Console.WriteLine("[5]  -  Meus veículos");
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("[0]  -  Sair do Aplicativo");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.ResetColor();

    string opcaoSelecionada = Console.ReadLine();


    if (opcaoSelecionada == "")
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("#ERRO 1#  -  Você não selecionou nenhuma opção, selecione uma opção numérica da lista e dê 'enter' -  EX.: '1'");
        goto RETORNOmenu;
    }
    Console.ResetColor();


    if (opcaoSelecionada == "1")
    {
        MySqlConnection oficinaList = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
        oficinaList.Open();

        MySqlCommand option1 = new MySqlCommand("select OFICINA_NOME, OFICINA_NUMERO, OFICINA_LOCALIZACAO from oficinas;", oficinaList);
        option1.ExecuteNonQuery();

        MySqlDataReader reader1;

        reader1 = option1.ExecuteReader();

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;



        //cabeçalho da tabela        
        Console.WriteLine("");
        Console.WriteLine("");

        Console.Write("       OFICINA".PadRight(45));
        Console.Write("TELEFONE".PadRight(40));
        Console.Write("LINK DE LOCALIZAÇÃO (Google Maps)".PadRight(40));

        while (reader1.Read())
        {

            string READ1 = reader1.GetString(0);
            string READ2 = reader1.GetString(1);
            string READ3 = reader1.GetString(2);


            Console.WriteLine("");


            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write(">    ");
            Console.Write(READ1.PadRight(40, '.'));
            Console.Write(READ2.PadRight(40, '.'));
            Console.Write(READ3.PadRight(40));
            Console.Write(Environment.NewLine);
        }
        //Console.Write("Nome".PadRight(30, '.'));

        oficinaList.Close();

        Console.ResetColor();
        Console.Write(Environment.NewLine);
        Console.Write(Environment.NewLine);
        Console.WriteLine("Pressione enter para continuar");
        Console.ReadLine();


    }

    //falta acabar a parte de seleção de oficina > no caso colocar uma opção de selecionar oficina e
    // dai redirecionar para os agendamentos;


    if (opcaoSelecionada == "2")
    {
        //precisamos acabar o APP Oficinas para elaborar essa parte.
    }

    if (opcaoSelecionada == "3")
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Precisa de uma ajuda com o veículo?  Conte-nos o que aconteceu:");

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("(a)  >  O carro não dá partida");
        Console.WriteLine("(b)  >  Direção puxando para um dos lados");
        Console.WriteLine("(c)  >  Muita fumaça saindo da descarga");
        Console.WriteLine("");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("(x)  -  Voltar ao menu");
        Console.WriteLine("");

        string ajuda = Console.ReadLine();

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (ajuda == "a")
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Há várias causas para este problema, como por exemplo: bateria descarregada, problema no motor de partida ou falha na bomba de combustível.");
            Console.WriteLine("Recomendamos que chame um mecânico ou leve o carro até a oficina mais próxima.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pressione enter para voltar ao menu");
            Console.ReadLine();
            Console.Write("");
            goto RETORNOmenu;

        }

        if (ajuda == "b")
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Possível desalinhamento dos pneus  |  Neste caso, recomendamos a análise do veículo \npor um mecânico qualificado, sugerimos que agende um reparo em uma de nossas oficinas cadastradas.");
            Console.WriteLine("");
            Console.WriteLine(" O alinhamento dos pneus permite que o conjunto de rodas e pneus trabalhe da maneira mais eficiente. \n Um sinal de que os ajustes estão incorretos é a direção puxando para um dos lados com o carro em linha reta. \n Isso acontece pelo desgaste dos componentes da suspensão e direção e também por conta do impacto das rodas com buracos ou o meio-fio.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pressione enter para voltar ao menu");
            Console.ReadLine();
            goto RETORNOmenu;
        }

        if (ajuda == "c")
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Qual a cor da fumaça?   |   OBS: digite em letras minúsculas");
            Console.WriteLine("");
            string corFu = Console.ReadLine();

            if (corFu == "branca" || corFu == "branco")
            {
                Console.WriteLine("");
                Console.WriteLine("O motor já está aquecido?  | Insira [sim/não]");

                string temp = Console.ReadLine();

                if (temp == "nao" || temp == "não")
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Se a temperatura do motor ainda está baixa, não se preocupe, essa fumaça se deve muito provavelmente \na formação de vapores devido ao ar condensado");
                    Console.WriteLine("");
                }

                else if (temp == "sim")
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Possível vazamento de líquido do radiador ou queima do fluído de freio | Recomendamos que leve o veículo até a oficina mais próxima para a análise de um mecânico.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Pressione enter para voltar ao menu");
                    Console.ReadLine();
                    goto RETORNOmenu;
                }

                else
                {
                    Console.ResetColor();
                    goto RETORNOmenu;
                }


            }

            if (corFu == "preta" || corFu == "preto")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Mau funcionamento do motor  |  A fumaça preta, com um cheiro bem forte, é o maior indicativo de que o motor do seu veículo está consumindo mais combustível do que deveria. \n O problema é gerado pelo mau funcionamento do motor, que não gera oxigênio suficiente para queimar o combustível. \n Para resolver, o ideal é investigar uma possível desregulação do carburador, da injeção eletrônica ou um bloqueio no filtro de ar. \n Se a fumaça for visível apenas na primeira partida do veículo, o problema pode estar no afogador ou sistema de admissão.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pressione enter para voltar ao menu");
                Console.ReadLine();
                goto RETORNOmenu;

            }

            if (corFu == "azul" || corFu == "azulada")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Possível queima de óleo  |  Quando a fumaça do escapamento fica azulada, é preciso atenção redobrada e manutenção rápida. \n Isto por que, a causa pode estar na queima rápida do óleo lubrificante, gerando baixo nível de lubrificação podendo fundir o motor. \n A fumaça azul pode aparecer devido ao excesso ou vazamento de óleo na câmara de combustão.");
                Console.WriteLine("");
                Console.WriteLine("O principal indício para confirmar o escape de fumaça azulada é o aumento do consumo de óleo.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pressione enter para voltar ao menu");
                Console.ReadLine();
                goto RETORNOmenu;
            }

            if (corFu != "branca" || corFu != "branco" || corFu != "preto" || corFu != "preta" || corFu != "azul" || corFu != "azulada")
            {
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Essa cor não está prevista em nosso sistema, recomendamos que verifique com um mecânico");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Pressione enter para voltar ao menu");
                Console.ReadLine();
                goto RETORNOmenu;
            }
        }
    }

    if (opcaoSelecionada == "4")
    {
        //fazer
    }



    if (opcaoSelecionada == "5")
    {
    RETORNOveiculo:
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("(1) - Cadastrar novo veículo");
        Console.WriteLine("");
        Console.WriteLine("(2) - Exibir meus veículos");
        Console.WriteLine("");
        Console.WriteLine("(0) - Voltar ao menu");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");

        string opcaoVeiculo = Console.ReadLine();

        if (opcaoVeiculo != "1" && opcaoVeiculo != "2" && opcaoVeiculo != "0")
        {
            Console.ResetColor();
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Selecione uma opção da lista");
            Console.WriteLine("");
            goto RETORNOveiculo;
        }

        if (opcaoVeiculo == "1") //cadastrar veiculo
        {
        RETORNOcadveiculo:
            MySqlConnection verificaCliente = new MySqlConnection("server=192.168.0.125; port=3306; user=PC2; database=mydb; password=carbox321;");
            verificaCliente.Open();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Por favor, insira sua senha novamente"); //validar no banco se a senha está correta, depois puxar o ID do cliente pra inserir o carro
            string usersenha1 = Console.ReadLine();

            MySqlCommand verify = new MySqlCommand("select CLIENTE_ID from clientes where USERSENHA_CLIENTE = '" + usersenha1 + "';", verificaCliente);
            verify.ExecuteNonQuery();

            MySqlDataReader verificaID;
            verificaID = verify.ExecuteReader();
            verificaID.Read();

            string verificaID2 = verificaID.GetString(0);
            Int32 verificaID3 = Convert.ToInt32(verificaID2);

            if (verificaID.HasRows)
            {
                verificaCliente.Close();
                Console.Clear();
            }

            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("Usuário não encontrado. Verifique sua senha e tente novamente.");
                await Task.Delay(800);
                Console.Beep(900, 600);
                Console.ResetColor();
                goto RETORNOcadveiculo;
            }

            MySqlConnection cadastroVeiculo = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
            cadastroVeiculo.Open();

            Console.WriteLine("");
            Console.WriteLine("Insira o modelo do seu veículo");
            string modeloCarro = Console.ReadLine(); //INSERIR VERIFICAÇÃO DO RANGE DO NOME INFORMADO

            if (modeloCarro.Length < 7)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insira o nome completo do modelo de seu carro");
                goto RETORNOcadveiculo;
            }

            Console.WriteLine("");
            Console.WriteLine("Insira a placa do seu veículo  || EXEMPLO > ' BRA2E19 '");
            string placaCliente = Console.ReadLine();

            if (placaCliente.Length < 5)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insira uma placa válida");
                goto RETORNOcadveiculo;
            }

            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[a] - Confirmar cadastro do veículo");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[b] - Cancelar cadastro do veículo");
            Console.WriteLine("");
            Console.WriteLine("");

            string AddVeiculo = Console.ReadLine();

            if (AddVeiculo == "a")
            {

                MySqlCommand cadVeiculo = new MySqlCommand("insert into carro_cliente (CARRO_MODELO, CARRO_PLACA, CLIENTE_ID) values (?, ?, ?)", cadastroVeiculo);

                //parametros
                cadVeiculo.Parameters.Add("@CARRO_MODELO", MySqlDbType.VarChar, 100).Value = modeloCarro;
                cadVeiculo.Parameters.Add("@CARRO_PLACA", MySqlDbType.VarChar, 45).Value = placaCliente;
                cadVeiculo.Parameters.Add("@CLIENTE_ID", MySqlDbType.Int32, 10).Value = verificaID3;

                cadVeiculo.ExecuteNonQuery();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Veículo cadastrado com sucesso!");
                Console.Beep(2000, 700);
                Console.ResetColor();

                cadastroVeiculo.Close();

                await Task.Delay(1300);
                goto RETORNOveiculo;
            }

            if (AddVeiculo == "b")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelando cadastro do veículo...");
                await Task.Delay(1200);
                Console.Beep(1500, 500);
                Console.Beep(1500, 500);

                Console.Clear();
                Console.ResetColor();
                goto RETORNOveiculo;
            }

        }



        if (opcaoVeiculo == "2") //exibir veiculos cadastrados
        {
            MySqlConnection exibirVeiculo = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
            exibirVeiculo.Open();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Por favor, insira sua senha"); //validar no banco se a senha está correta, depois puxar o ID do cliente pra inserir o carro
            string usersenha1 = Console.ReadLine();

            MySqlCommand verify = new MySqlCommand("select CLIENTE_ID from clientes where USERSENHA_CLIENTE = '" + usersenha1 + "';", exibirVeiculo);
            verify.ExecuteNonQuery();

            MySqlDataReader readID;
            readID = verify.ExecuteReader();
            readID.Read();

            if (readID.HasRows)
            {
                //continua
            }

            else
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.WriteLine("Usuário não encontrado. Verifique sua senha e tente novamente.");
                Console.Beep(900, 600);
                await Task.Delay(1000);
                Console.ResetColor();
                goto RETORNOveiculo;
            }

            string readIDS = readID.GetString(0);

            exibirVeiculo.Close();

            MySqlConnection mostraVeiculo = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
            mostraVeiculo.Open();

            MySqlCommand showVeiculo = new MySqlCommand("select CARRO_MODELO, CARRO_PLACA from carro_cliente where CLIENTE_ID = '" + readIDS + "';", mostraVeiculo);
            showVeiculo.ExecuteNonQuery();


            MySqlDataReader readVeiculo;
            readVeiculo = showVeiculo.ExecuteReader();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");

            //cabeçalho da tabela
            Console.Write("       VEÍCULO".PadRight(45));
            Console.Write("PLACA");

            while (readVeiculo.Read())
            {

                string READv1 = readVeiculo.GetString(0);
                string READv2 = readVeiculo.GetString(1);

                Console.WriteLine("");

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(">    ");
                Console.Write(READv1.PadRight(40, '.'));
                Console.Write(READv2);
                Console.Write(Environment.NewLine);
            }

            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressione enter para continuar...");
            Console.ReadLine();
            Console.WriteLine("");

            mostraVeiculo.Close();


        }

        if (opcaoVeiculo == "0")
        {
            goto RETORNOmenu;
        }

    }


    //
    //implementações abaixo
    //



    if (opcaoSelecionada == "4")
    {
        MySqlConnection exibir = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
        exibir.Open();


        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");

        Console.WriteLine("Por favor, insira sua senha"); //buscar usuário no banco
        string userPass = Console.ReadLine();

        MySqlCommand verify = new MySqlCommand("select CLIENTE_ID from clientes where USERSENHA_CLIENTE = '" + userPass + "';", exibir);
        verify.ExecuteNonQuery();

        MySqlDataReader rdPerfil;
        rdPerfil = verify.ExecuteReader();
        rdPerfil.Read();

        if (rdPerfil.HasRows)
        {
            //continua
        }

        else
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("Usuário não encontrado. Verifique sua senha e tente novamente.");
            Console.Beep(900, 600);
            await Task.Delay(1000);
            Console.ResetColor();
            goto RETORNOmenu;
        }

        string profile = rdPerfil.GetString(0);

        exibir.Close();

        MySqlConnection mostraDados = new MySqlConnection("server=192.168.0.125;port=3306;user=PC2; database=mydb; password=carbox321;");
        mostraDados.Open();

        MySqlCommand showDados = new MySqlCommand("select CLIENTE_NOME, CLIENTE_NUMERO, DATA_NASCIMENTO, CPF_CLIENTE from clientes where CLIENTE_ID = '" + profile + "';", mostraDados);
        showDados.ExecuteNonQuery();

        MySqlDataReader readDados;
        readDados = showDados.ExecuteReader();

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("");

        //cabeçalho da tabela
        Console.Write("       NOME COMPLETO".PadRight(44));
        Console.Write("TELEFONE".PadRight(44));
        Console.Write("DATA DE NASCIMENTO".PadRight(44));
        Console.Write("CPF");

        while (readDados.Read())
        {

            string READv1 = readDados.GetString(0);
            string READv2 = readDados.GetString(1);
            string READv3 = readDados.GetString(2);
            string READv4 = readDados.GetString(3);

            Console.WriteLine("");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write(">    ");
            Console.Write(READv1.PadRight(40, '.'));
            Console.Write(READv2.PadRight(40, '.'));
            Console.Write(READv3.PadRight(40, '.'));
            Console.Write(READv4);
            
            Console.Write(Environment.NewLine);
        }

        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Pressione enter para continuar...");
        Console.ReadLine();
        Console.WriteLine("");

        mostraDados.Close();


    }


    if (opcaoSelecionada == "0")
    {
        break;
    }

}