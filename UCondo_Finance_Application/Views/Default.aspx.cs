using CrossCutting_Extensions;
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
    public partial class _Default : Page
    {
        private readonly FinanceiroRepository _repository = new FinanceiroRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var listObj = _repository.ListItem<Financeiro>();
                ComporGrid(listObj);
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var listObj = _repository.ListItemByPeriodo<Financeiro>(fldPeriodoInicial.Text.ToDate(), fldPeriodoFinal.Text.ToDate());
            ComporGrid(listObj);
        }

        private void ComporGrid(IEnumerable<Financeiro> listObj)
        {
            if (listObj != null)
            {
                gvFinanceiro.DataSource = listObj;
                gvFinanceiro.DataBind();
                lbltotal.InnerText = $@"Total: {listObj.Sum(x => x.ValorLancamento).ToString("###,##0.00")}";
            }
        }
        protected void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            Response.Redirect("/views/default");
        }
    }
}