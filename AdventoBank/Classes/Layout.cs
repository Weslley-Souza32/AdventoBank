namespace AdventoBank.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;

        #region TelaPrincipal()
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("                 Digite a opção desejada :                ");
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 1 - Criar Conta                          ");
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 2 - Entrar com CPF e Senha               ");
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 3 - Sair da Aplicação                    ");


            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriaConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                case 3:
                    Console.WriteLine("Obrigado pela preferência!");
                    Console.WriteLine("       Volte Sempre!      ");
                    Thread.Sleep(3000);
                    Environment.Exit(3);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1000);
                    TelaPrincipal();
                    break;
            }
        }
        #endregion

        #region TelaCriarConta()
        private static void TelaCriaConta()
        {
            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("                 Digite seu nome:                         ");
            string nome = Console.ReadLine();
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 Digite seu CPF:                          ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 Digite sua senha:                        ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =========================                ");

            //Criando a Conta e salvando na nossa lista pessoas.
            ContaCorrente cc = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCPF(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = cc;

            pessoas.Add(pessoa);

            Console.Clear();
            Console.WriteLine("                 Conta Cadastrada Com Sucesso.            ");
            Console.WriteLine("                 =========================                ");

            //Codigo espera 2 segundos para ir para TelaContaLogada();
            Thread.Sleep(2000);

            TelaContaLogada(pessoa);
        }
        #endregion

        #region TelaLogin()
        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("                                                          ");
            Console.WriteLine("                 Digite seu CPF:                          ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 =========================                ");
            Console.WriteLine("                 Digite sua senha:                        ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 =========================                ");

            Pessoa pessoa = pessoas.FirstOrDefault(p => p.CPF == cpf && p.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("                 Pessoa não cadastrada.                   ");
                Console.WriteLine("                 =========================                ");

                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(2000);
                TelaPrincipal();

            }
        }
        #endregion

        #region TelaBoasVindas()
        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgBoasVindas =
                $"{pessoa.Nome} - Banco: {pessoa.Conta.GetCodigoBank()} - " +
                $"Agência: {pessoa.Conta.GetNumeroAgencia()} - " +
                $"Conta: {pessoa.Conta.GetNumeroConta()}";
            Console.WriteLine();
            Console.WriteLine($"Seja Bem Vindo, {msgBoasVindas}");
            Console.WriteLine();
        }
        #endregion

        #region TelaContaLogada()
        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("                  Digite a opção desejada:                   ");
            Console.WriteLine("                  ========================                   ");
            Console.WriteLine("                  1 - Realizar Deposito:                     ");
            Console.WriteLine("                  ========================                   ");
            Console.WriteLine("                  2 - Realizar Saque                         ");
            Console.WriteLine("                  ========================                   ");
            Console.WriteLine("                  3 - Consultar o saldo:                     ");
            Console.WriteLine("                  ========================                   ");
            Console.WriteLine("                  4 - Extrato:                               ");
            Console.WriteLine("                  ========================                   ");
            Console.WriteLine("                  5 - sair:                                  ");
            Console.WriteLine("                  ========================                   ");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("                 Opção inválida!                      ");
                    Console.WriteLine("                ========================              ");
                    Thread.Sleep(1000);
                    TelaContaLogada(pessoa);

                    break;
            }
        }
        #endregion

        #region TelaDeposito
        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do deposito:                 ");
            double valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("                 ===========================                 ");
            pessoa.Conta.Deposita(valor);
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                             ");
            Console.WriteLine("                                                             ");
            Console.WriteLine("                 Deposito realizado com sucesso!             ");
            Console.WriteLine("                 ============================                ");
            Console.WriteLine("                                                             ");
            OpcaoVoltarContaLogada(pessoa);
        }
        #endregion

        #region OpcaoVoltarContaLogada()
        private static void OpcaoVoltarContaLogada(Pessoa pessoa)
        {
            Console.WriteLine("                 Entre com uma das opções abaixo:            ");
            Console.WriteLine("                 ===============================             ");
            Console.WriteLine("                 1 - Voltar para minha conta                 ");
            Console.WriteLine("                 ===============================             ");
            Console.WriteLine("                 2 - Sair                                    ");
            Console.WriteLine("                 ===============================             ");

            opcao = Convert.ToInt32(Console.ReadLine());

            if(opcao == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {
                TelaPrincipal();
            }
        }
        #endregion

        #region OpcaoVoltarDeslogado()
        private static void OpcaoVoltarContaDeslogada()
        {
            Console.WriteLine("                 Entre com uma das opções abaixo:            ");
            Console.WriteLine("                 ===============================             ");
            Console.WriteLine("                 1 - Voltar para a Tela Principal            ");
            Console.WriteLine("                 ===============================             ");
            Console.WriteLine("                 2 - Sair                                    ");
            Console.WriteLine("                 ===============================             ");

            opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                TelaPrincipal();
            }
            else
            {
                Console.WriteLine("                   Opção Inválida!                       ");
                Console.WriteLine("                 ===================                     ");
            }
        }
        #endregion

        #region TelaSaque
        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                 Digite o valor do saque   :                 ");
            double valor = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("                 ===========================                 ");
            bool okSaque = pessoa.Conta.Saca(valor);
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                                                             ");
            Console.WriteLine("                                                             ");
            if (okSaque)
            {
                Console.WriteLine("                 Saque realizado com sucesso!            ");
                Console.WriteLine("                 ============================            ");
            }
            else
            {
                Console.WriteLine("                 Saldo insuficiente!                     ");
                Console.WriteLine("                 ============================            ");
            }
            Console.WriteLine("                                                             ");
            OpcaoVoltarContaLogada(pessoa);
        }
        #endregion

        #region TelaSaldo()
        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);
            Console.WriteLine($"               Seu saldo é: {pessoa.Conta.ConsultaSaldo()} ");
            Console.WriteLine("                ==========================================  ");
            Console.WriteLine("                                                            ");

            OpcaoVoltarContaLogada(pessoa);
        }
        #endregion

        #region TelaExtrato()
        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                //Soma todo valor que tem no nosso extrato da conta.
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine("                                                              ");
                    Console.WriteLine($"         Data: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"         Tipo de Movimentação: {extrato.Descricao}           ");
                    Console.WriteLine($"         Valor: {extrato.Valor}                              ");
                    Console.WriteLine("          ======================================              ");
                }

                Console.WriteLine("                                                         ");
                Console.WriteLine("                                                         ");
                Console.WriteLine($"                Sub Total: {total}                      ");
                Console.WriteLine("                =====================                    ");
            }
            else
            {  
                Console.WriteLine($"               Não há extrato a ser exibido!            ");
                Console.WriteLine("                ==============================           ");
            }

            OpcaoVoltarContaLogada(pessoa);

        }
        #endregion
    }
}
