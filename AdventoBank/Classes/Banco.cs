namespace AdventoBank.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeBanco = "AdventoBank";
            this.CodigoBanco = "777";
        }
        public string NomeBanco { get; private set; }
        public string CodigoBanco { get; private set; }
    }
}
