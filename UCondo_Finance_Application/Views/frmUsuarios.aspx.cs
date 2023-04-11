using CrossCutting_Extensions;
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
    public partial class frmUsuarios : System.Web.UI.Page
    {
        private readonly UsuariosRepository _repository = new UsuariosRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            var obj = new Usuarios()
            {
                Id = fldCodigo.Text.ToInt(),
                SenhaUsuario = fldSenhaUsuario.Text,
                NomeUsuario = fldNomeUsuario.Text,
                EmailUsuario = fldEmailUsuario.Text
            };
            //
            if (obj.Id > 0) { _repository.UpdateItem(obj); }
            else { _repository.InsertItem(obj); }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/views/frmUsuarios");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (fldCodigo.Text.ToInt() > 0) { _repository.DeleteItemById(fldCodigo.Text.ToInt()); }
        }
    }
}