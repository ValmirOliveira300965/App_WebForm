<%@ Page Title="Aplicativo Web Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contatos.aspx.cs" Inherits="App_WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your contact page.</h3>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:valmiroliveira.vo@gmail.com">valmiroliveira.vo@gmail.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing</a>
        </address>
    </main>
</asp:Content>
