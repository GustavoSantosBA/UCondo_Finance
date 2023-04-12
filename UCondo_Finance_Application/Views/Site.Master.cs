using Hanssens.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UCondo_Finance_Application
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["LoginCookie"];

                if (cookie != null && cookie["username"] != null)
                {
                    string username = cookie["username"];
                    lblUsuario.Text = $@"Usuário: {username}";
                }
                else { Response.Redirect("/views/Login"); }
            }
            catch
            {

            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["LoginCookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                Response.Redirect("/views/Login");
            }
        }
    }
}