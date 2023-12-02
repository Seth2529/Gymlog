using System;
namespace Gymlog.WebApp.Helper
{
     public static class PerfilHelper
     {
         public static string GetPerfilDescricao(int perfilId)
         {
            return perfilId switch
            {
                 1 => "1-Funcionário",
                 2 => "2-Padrão",
                 _ => "Desconhecido"
            };
         }
     }
}
