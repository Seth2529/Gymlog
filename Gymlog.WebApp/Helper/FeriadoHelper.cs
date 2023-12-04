public static class FeriadoHelper
{
    private static readonly HashSet<DateTime> DatasEscondidas = new HashSet<DateTime>
    {
        new DateTime(2023, 11, 25),
        new DateTime(2023, 11, 20),
    };

    public static string ObterMensagemOculta(DateTime data)
    {
        if (DatasEscondidas.Contains(data.Date))
        {
            return "Dias comuns";
        }
        return data.ToString("dd/MM/yyyy");
    }
}