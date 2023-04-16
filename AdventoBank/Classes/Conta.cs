using AdventoBank.Contratos;

namespace AdventoBank.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroContaSequencial { get; private set; }
        private List<Extrato> Movimentacoes;

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor));
            this.Saldo += valor;
        }

        public bool Saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
            {
                return false;
            }
            else
            {
                DateTime dataAtual = DateTime.Now;
                this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));
                this.Saldo -= valor;
                return true;
            }
        }

        public string GetCodigoBank()
        {
            return this.CodigoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}
