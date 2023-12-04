﻿using Gymlog.Dominio.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Gymlog.WebApp.Filters
{
    public class PaginaSomenteFuncionario : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                Pessoa pessoa = JsonConvert.DeserializeObject<Pessoa>(sessaoUsuario);
                
                if (pessoa == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if(pessoa.PerfilID != 1)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }


            base.OnActionExecuting(context);
        }
    }
}
