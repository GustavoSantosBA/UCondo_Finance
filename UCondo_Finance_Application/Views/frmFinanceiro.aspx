<%@ Page Title="Financeiro" Culture="pt-BR" EnableEventValidation="true" Language="C#" MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" CodeBehind="frmFinanceiro.aspx.cs" Inherits="UCondo_Finance_Application.Views.frmFinanceiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-2">
            <asp:Label runat="server" Text="Código" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldCodigo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-1" style="padding-top: 12px; margin-left: -20px">
            <asp:Button ID="btnPesq" runat="server" Text="..." OnClick="btnPesq_Click" CssClass="buttonLogin" />
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
            <asp:Label runat="server" Text="Periodicidade" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlPeriodicidade" runat="server" CssClass="form-control">
                <asp:ListItem Text="Único" Value="0" />
                <asp:ListItem Text="Mensal" Value="1" />
            </asp:DropDownList>
        </div>
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Tipo Lançamento" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlTipoLanc" runat="server" CssClass="form-control">
                <asp:ListItem Text="Entrada" Value="0" />
                <asp:ListItem Text="Saída" Value="1" />
            </asp:DropDownList>
        </div>
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Status" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                <asp:ListItem Text="Aberto" Value="0" />
                <asp:ListItem Text="Quitado" Value="1" />
            </asp:DropDownList>
        </div>
        <div class="col-lg-3">
            <asp:Label runat="server" Text="Valor" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="fldValorLancamento" runat="server" CssClass="form-control" />
        </div>
    </div>
    <div style="text-align: center; padding-top: 50px">
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
        <div style="padding: 20px;">
            <div class="row pb-2">
                <div class="col-lg-3">
                    <asp:Label runat="server" Text="Período Inicial" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="fldPeriodoInicial" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <asp:Label runat="server" Text="Período Fimal" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="fldPeriodoFinal" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-lg-6 pt-1">
                    <asp:Button Text="Pesquisar" runat="server" CssClass="buttonLogin" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
                    <asp:Button Text="Limpar Filtro" runat="server" CssClass="buttonLogin" ID="btnLimparFiltro" OnClick="btnLimparFiltro_Click" />
                </div>
            </div>
        </div>
        <div style="padding: 20px; height: 250px; overflow: auto">
            <asp:GridView
                ID="gvFinanceiro"
                runat="server"
                AutoGenerateSelectButton="true"
                AutoGenerateColumns="false"
                Width="100%"
                OnSelectedIndexChanged="gvFinanceiro_SelectedIndexChanged"
                AutoPostBack="true"
                CellPadding="4"
                ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="DataVencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-Width="150px" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="ValorLancamento" HeaderText="Valor" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
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
