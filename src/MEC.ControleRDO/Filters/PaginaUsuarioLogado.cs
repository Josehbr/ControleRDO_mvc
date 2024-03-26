﻿using MEC.ControleRDO.Data.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace MEC.ControleRDO.Filters
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string SessionUser = context.HttpContext.Session.GetString("sessaoUsuaioLogado");

            if (string.IsNullOrEmpty(SessionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login"}, {"action", "Index"} });
            }
            else
            {
                UsuarioVO usuario = JsonConvert.DeserializeObject<UsuarioVO>(SessionUser);

                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

            }

            base.OnActionExecuting(context);
        }
    }
}
