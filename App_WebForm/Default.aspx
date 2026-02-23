<%@ Page Title="Aplicativo Web Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="App_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET é uma estrutura web gratuita para criar excelentes sites e aplicações web usando HTML, CSS e JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Maiores detalhes &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Começando</h2>
                <p>
                    O ASP.NET Web Forms permite criar sites dinâmicos usando um modelo familiar de arrastar e soltar, orientado a eventos.
                    Uma superfície de design e centenas de controles e componentes permitem criar rapidamente sites sofisticados e poderosos, orientados à interface do usuário e com acesso a dados.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Maiores detalhes &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Obtenha mais bibliotecas</h2>
                <p>
                    O NuGet é uma extensão gratuita do Visual Studio que facilita a adição, remoção e atualização de bibliotecas e ferramentas em projetos do Visual Studio.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Maiores detalhes &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Hospedagem de sites</h2>
                <p>
                    Você pode facilmente encontrar uma empresa de hospedagem web que ofereça a combinação ideal de recursos e preço para seus aplicativos.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Maiores detalhes &raquo;</a>
                </p>
            </section>
        </div>

        <div class="row">
            <asp:TextBox ID="txtBusca" runat="server"></asp:TextBox>
            <asp:Button ID="btnTestes" runat="server" Text="Testes" OnClick="btnTestes_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </div>

    </main>

</asp:Content>
