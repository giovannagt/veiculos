<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Layout.Master" AutoEventWireup="true" Async="true" CodeBehind="ListarVeiculos.aspx.cs" Inherits="Veiculos.Site.Pages.ListarVeiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="gridVeiculos" runat="server">
                <HeaderTemplate>
                    <h1>Lista de Veículos</h1>
                    <table class="table table-hover">
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Placa</th>
                            <th scope="col">Marca</th>
                            <th scope="col">Modelo</th>
                            <th scope="col">Ano Fabricacao</th>
                            <th scope="col">Ano modelo</th>
                            <th scope="col">Cor</th>
                            <th scope="col">Tipo Veiculo</th>
                            <th scope="col">Combustivel</th>
                            <th scope="col">Ações</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblVeiculoId" runat="server" Text='<%#  DataBinder.Eval(Container.DataItem, "VeiculoId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPlaca" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Placa") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblMarca" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Marca") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblModelo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Modelo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAnoFabricacao" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AnoFabricacao") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAnoModelo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AnoModelo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCor" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Cor") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblTipoVeiculo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TipoVeiculo") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblCombustivel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Combustivel") %>' />
                        </td>
                        <td>
                            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" CssClass="btn btn-success"
                                CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "VeiculoId") %>' OnClick="btnAlterar_Click"  />                            

                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn btn-danger"
                                CommandArgument='<%#  DataBinder.Eval(Container.DataItem, "VeiculoId") %>' OnClick="btnExcluir_Click" OnClientClick="javascript:return confirm('Deseja realmente excluir?')" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
