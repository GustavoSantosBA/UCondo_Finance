using Hanssens.Net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCondo_Finance_Data.Repository;
using UCondo_Finance_Domain.Entities;

namespace UCondo_Finance_Application.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var rep = new UsuariosRepository().DoLogin(fldUsuario.Text, fldPassword.Text);
            if (!string.IsNullOrEmpty(rep.EmailUsuario))
            {
                HttpCookie cookie = new HttpCookie("LoginCookie");
                cookie["username"] = rep.EmailUsuario;
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
                //
                Response.Redirect("/views/default.aspx");
            }
            else
            {
                Response.Redirect("/views/Login");
            }
        }
    }
}