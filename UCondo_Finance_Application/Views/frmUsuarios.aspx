<%@ Page Title="Usuários" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="UCondo_Finance_Application.Views.frmUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-2">
            <asp:Label runat="server" Text="Código" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-top: 12px; margin-left: -20px">
            <asp:Button ID="btnPesq" runat="server" Text="..." CssClass="buttonLogin" OnClick="btnPesq_Click" />
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
            <asp:TextBox ID="fldSenhaUsuario" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="text-align: center">
        <asp:Button Text="Novo" runat="server" CssClass="buttonLogin" ID="btnNovo" OnClick="btnNovo_Click" />
        <asp:Button Text="Gravar" runat="server" CssClass="buttonLogin" ID="btnGravar" OnClick="btnGravar_Click" />
        <asp:Button Text="Excluir" runat="server" CssClass="buttonLogin" ID="btnExcluir" OnClick="btnExcluir_Click" />
    </div>

    <ajaxToolkit:ModalPopupExtender ID="mpePopup" runat="server"
        TargetControlID="btnPesq"
        PopupControlID="pnlPopup"
        BackgroundCssClass="popupOverlay">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlPopup" runat="server" CssClass="popupPanel">
        <div style="padding: 20px; height: 300px; overflow: auto">
            <asp:GridView
                ID="gvUsuarios"
                runat="server"
                AutoGenerateSelectButton="true"
                AutoGenerateColumns="false"
                Width="100%"
                OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"
                AutoPostBack="true"
                CellPadding="4"
                ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" />
                    <asp:BoundField DataField="NomeUsuario" HeaderText="Nome do usuário" />
                    <asp:BoundField DataField="EmailUsuario" HeaderText="E-mail do usuário" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#622490" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
        <div style="padding-top: 15px; text-align: center">
            <asp:Button ID="btnFechar" runat="server" Text="Fechar" CssClass="buttonLogin" OnClientClick="$find('mpePopup').hide();" />
        </div>
    </asp:Panel>
</asp:Content>
