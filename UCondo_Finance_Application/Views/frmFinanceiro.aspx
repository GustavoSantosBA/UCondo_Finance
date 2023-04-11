<%@ Page Title="Financeiro" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="frmFinanceiro.aspx.cs" Inherits="UCondo_Finance_Application.Views.frmFinanceiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-2">
            <asp:Label runat="server" Text="Código" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Data de Vencimento" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldDataVencimento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Label runat="server" Text="Descrição" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldDescricao" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Valor" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldValorLancamento" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
    </div>
    <div style="text-align: center">
        <asp:Button Text="Novo" runat="server" CssClass="buttonLogin" ID="btnNovo" OnClick="btnNovo_Click" />
        <asp:Button Text="Gravar" runat="server" CssClass="buttonLogin" ID="btnGravar" OnClick="btnGravar_Click" />
        <asp:Button Text="Excluir" runat="server" CssClass="buttonLogin" ID="btnExcluir" OnClick="btnExcluir_Click" />
    </div>
</asp:Content>
