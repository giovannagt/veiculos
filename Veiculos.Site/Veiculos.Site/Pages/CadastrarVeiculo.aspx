<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Layout.Master" AutoEventWireup="true" Async="true" CodeBehind="CadastrarVeiculo.aspx.cs" Inherits="Veiculos.Site.Pages.CadastrarVeiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form>
        <h1>Cadastro de Veículo</h1>

        <div class="row mt-4">
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Text="Placa"></asp:Label>
                <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control"  MaxLength="7"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Informe a placa" ControlToValidate="txtPlaca" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <asp:Label ID="Label3" runat="server" Text="Modelo"></asp:Label>
                <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Informe o modelo" ControlToValidate="txtModelo" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" Text="Marca"></asp:Label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Selecione a marca" ControlToValidate="ddlMarca" ValueToCompare="0" Operator="NotEqual" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:CompareValidator>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label4" runat="server" Text="Ano Fabricação"></asp:Label>
                <asp:TextBox ID="txtAnoFabricacao" runat="server" CssClass="form-control" onkeypress="return onlyNumbers(event)" MaxLength ="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Informe o ano de fabricação" ControlToValidate="txtAnoFabricacao" ForeColor="Red" ValidationGroup="ValidarInformacoes" ></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-2">
                <asp:Label ID="Label5" runat="server" Text="Ano Modelo"></asp:Label>
                <asp:TextBox ID="txtAnoModelo" runat="server" CssClass="form-control" onkeypress="return onlyNumbers(event)" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Informe o ano do modelo" ControlToValidate="txtAnoModelo" ForeColor="Red" ValidationGroup="ValidarInformacoes" ></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Label ID="Label6" runat="server" Text="Cor"></asp:Label>
                <asp:TextBox ID="txtCor" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Informe a cor" ControlToValidate="txtCor" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:RequiredFieldValidator>
            </div>

            <div class="col-md-2">
                <asp:Label ID="Label7" runat="server" Text="Tipo Veículo"></asp:Label>
                <asp:DropDownList ID="ddlTipoVeiculo" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Selecione o tipo do veículo" ControlToValidate="ddlTipoVeiculo" ValueToCompare="0" Operator="NotEqual" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:CompareValidator>
            </div>

            <div class="col-md-2">
                <asp:Label ID="Label8" runat="server" Text="Combustível"></asp:Label>
                <asp:DropDownList ID="ddlCombustivel" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Selecione o combustível" ControlToValidate="ddlCombustivel" ValueToCompare="0" Operator="NotEqual" ForeColor="Red" ValidationGroup="ValidarInformacoes"></asp:CompareValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" ValidationGroup="ValidarInformacoes" OnClick="btnSalvar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-dark m-2" OnClick="btnCancelar_Click" />
            </div>
        </div>

    </form>

    <script>      
        function onlyNumbers(event) {
            var charCode = (event.which) ? event.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>

</asp:Content>
