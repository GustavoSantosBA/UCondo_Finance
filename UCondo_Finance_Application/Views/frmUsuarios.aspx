<%@ Page Title="Usuários" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="UCondo_Finance_Application.Views.frmUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-2">
            <asp:Label runat="server" Text="Código" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Label runat="server" Text="Nome Usuário" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldNomeUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-12">
            <asp:Label runat="server" Text="E-Mail" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldEmailUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Senha" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldSenhaUsuario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div style="text-align: center">
        <asp:Button Text="Novo" runat="server" CssClass="buttonLogin" ID="btnNovo" OnClick="btnNovo_Click" />
        <asp:Button Text="Gravar" runat="server" CssClass="buttonLogin" ID="btnGravar" OnClick="btnGravar_Click" />
        <asp:Button Text="Excluir" runat="server" CssClass="buttonLogin" ID="btnExcluir" OnClick="btnExcluir_Click" />
    </div>
</asp:Content>
