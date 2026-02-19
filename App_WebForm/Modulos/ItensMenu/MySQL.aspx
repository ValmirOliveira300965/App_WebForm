<%@ Page Title="Aplicativo Web Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MySQL.aspx.cs" Inherits="App_WebForm.MySQL" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Teste do uso do MySQL</h2>

        <asp:UpdatePanel ID="updGrid" runat="server" UpdateMode="Conditional">
            <ContentTemplate>


        <asp:GridView  ID="gridPessoas" 
                       runat="server" 
                       AutoGenerateColumns="false" 
                       Width="100%" 
                       BorderWidth="1"
                       EmptyDataText="Nenhum Registro foi Encontrado"
                       GridLines="Vertical">

            <Columns>

                <asp:BoundField 
                    DataField="Nome" 
                    HeaderText="Nome" />

                <asp:BoundField 
                    DataField="Aniversario" 
                    HeaderText="Aniversário" />

                <asp:BoundField 
                    DataField="Idade" 
                    HeaderText="Idade" />

                <asp:BoundField 
                    DataField="Telefone" 
                    HeaderText="Telefone" />

            </Columns>

        </asp:GridView>

            </ContentTemplate>
        </asp:UpdatePanel>

    </main>
</asp:Content>
