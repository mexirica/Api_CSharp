using System.Globalization;

namespace API.Services
{
    public class Conversao
    {

        public static string FormatarData( string campoData)
        {
            if (!string.IsNullOrEmpty(campoData))
            {
                string dataFormatada = DateTime.ParseExact(campoData, "yyyyMMdd", CultureInfo.InvariantCulture)
                    .ToString("dd/MM/yyyy");
                 return dataFormatada;
            }
            return campoData;
        }   

    }
}
