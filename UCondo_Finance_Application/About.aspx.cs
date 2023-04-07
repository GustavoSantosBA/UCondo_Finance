using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCondo_Finance_Data.Repository;
using UCondo_Finance_Domain.Entities;

namespace UCondo_Finance_Application
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            var rep = new FinanceiroRepository();
            var dados = rep.ListItem<Financeiro>();
        }
    }
}