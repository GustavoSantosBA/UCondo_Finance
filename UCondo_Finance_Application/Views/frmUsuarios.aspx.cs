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
            if (!IsPostBack) { ComporGrid(); }
        }

        private void ComporGrid()
        {
            var listObj = _repository.ListItem<Usuarios>();
            if (listObj != null)
            {
                gvUsuarios.DataSource = listObj;
                gvUsuarios.DataBind();
            }
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

            //
            Response.Redirect("/views/frmUsuarios");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/views/frmUsuarios");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (fldCodigo.Text.ToInt() > 0)
            {
                _repository.DeleteItemById(fldCodigo.Text.ToInt());
                Response.Redirect("/views/frmUsuarios");
            }
        }

        protected void btnPesq_Click(object sender, EventArgs e)
        {
            mpePopup.Show();
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid = ((GridView)sender);
            int index = grid.SelectedRow.RowIndex;
            if (index >= 0)
            {
                if (int.TryParse(grid.Rows[index].Cells[1].Text, out var id))
                {
                    var obj = _repository.ListItemById<Usuarios>(id);
                    if (obj != null)
                    {
                        fldCodigo.Text = obj.Id.ToString();
                        fldNomeUsuario.Text = obj.NomeUsuario;
                        fldEmailUsuario.Text = obj.EmailUsuario;
                        fldSenhaUsuario.Text = obj.SenhaUsuario;
                    }
                }
            }
        }
    }
}