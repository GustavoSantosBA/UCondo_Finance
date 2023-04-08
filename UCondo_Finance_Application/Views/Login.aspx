<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UCondo_Finance_Application.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login-box">
                <h2>Login</h2>
                <form>
                    <div class="user-box">
                        <input type="text" name="" required="">
                        <label>Usuário</label>
                    </div>
                    <div class="user-box">
                        <input type="password" name="" required="">
                        <label>Senha</label>
                    </div>
                    <div style="text-align : center">
                        <asp:Button Text="Entrar" runat="server" CssClass="buttonLogin" />
                    </div>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
