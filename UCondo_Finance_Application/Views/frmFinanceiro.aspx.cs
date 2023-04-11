﻿using CrossCutting_Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCondo_Finance_Data.Repository;
using UCondo_Finance_Domain.Entities;
using UCondo_Finance_Domain.Enums;

namespace UCondo_Finance_Application.Views
{
    public partial class frmFinanceiro : System.Web.UI.Page
    {
        private readonly FinanceiroRepository _repository = new FinanceiroRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/views/frmFinanceiro");
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            var obj = new Financeiro()
            {
                Id = fldCodigo.Text.ToInt(),
                Descricao = fldDescricao.Text.ToString(),
                DataVencimento = fldDataVencimento.Text.ToDate(),
                ValorLancamento = fldValorLancamento.Text.ToDecimal(),
                StsLancamento = StatusEnum.Quitado
            };
            //
            if (obj.Id > 0) { _repository.UpdateItem(obj); }
            else { _repository.InsertItem(obj); }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (fldCodigo.Text.ToInt() > 0) { _repository.DeleteItemById(fldCodigo.Text.ToInt()); }
        }
    }
}