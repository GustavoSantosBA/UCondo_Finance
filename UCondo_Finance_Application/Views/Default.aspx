<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UCondo_Finance_Application._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px;">
        <h2>Dashboard Financeiro</h2>
        <div class="row pb-2">
            <div class="col-lg-3">
                <asp:Label runat="server" Text="Período Inicial" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="fldPeriodoInicial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <asp:Label runat="server" Text="Período Fimal" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="fldPeriodoFinal" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="col-lg-4 pt-3">
                <asp:Button Text="Pesquisar" runat="server" CssClass="buttonLogin" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
                <asp:Button Text="Limpar Filtro" runat="server" CssClass="buttonLogin" ID="btnLimparFiltro" OnClick="btnLimparFiltro_Click" />
            </div>
        </div>
    </div>
    <div style="padding: 20px; height: 400px; overflow: auto">
        <asp:GridView
            ID="gvFinanceiro"
            runat="server"
            AutoGenerateColumns="false"
            Width="100%"
            AutoPostBack="true"
            CellPadding="4"
            ForeColor="#333333"
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-Width="100px" />
                <asp:BoundField DataField="DataVencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150px" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                <asp:BoundField DataField="ValorLancamento" HeaderText="Valor" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" />
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
        <h4 class="lblTotal"  runat="server" id="lbltotal"></h4>
    </div>
</asp:Content>
