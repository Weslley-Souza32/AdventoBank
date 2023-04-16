using AdventoBank.Classes;

namespace AdventoBank.Contratos
{
    public interface IConta
    {
        void Deposita(double valor);
        bool Saca (double valor);
        double ConsultaSaldo();
        string GetCodigoBank();
        string GetNumeroAgencia();
        string GetNumeroConta();
        List<Extrato> Extrato(); 
    }
}
