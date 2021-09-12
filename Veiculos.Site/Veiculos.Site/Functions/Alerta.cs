using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Veiculos.Site.Functions
{
    public static class Alerta
    {
        public static void Show(this Page pagina, string mensagem)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MessageBox", "<script language='javascript'>alert('" + mensagem + "');</script>");
        }
    }
}