using System;

namespace Gymlog.WebApp.Helper
{
    public static class TipoRepeticaoHelper
    {
        public static string GetTipoRepeticaoDescricao(int tipoRepeticaoId)
        {
            return tipoRepeticaoId switch
            {
                1 => "8",
                2 => "10",
                3 => "12",
                4 => "15",
                5 => "Rest-Pause",
                6 => "Drop-set",
                7 => "Repetições negativas",
                8 => "Repetições em tempo sob tensão",
                9 => "Repetições parciais",
                10 => "Repetições descendentes",
                11 => "Repetições forçadas",
                12 => "Circuito",
                13 => "Bi-set",
                14 => "Pirâmide",
                15 => "Super-sets",
                16 => "Tri-sets",
                _ => "Desconhecido"
            };
        }
    }
}
