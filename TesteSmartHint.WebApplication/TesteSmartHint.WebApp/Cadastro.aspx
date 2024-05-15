<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TesteSmartHint.WebApp.Secure.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            //bloqueiaCampos();//inicia bloqueando campos
        })
    </script>
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Teste SmartHint - Cadastro</h1>
            <div class="row">
                <section class="col-md-3 mx-3">
                    <p class="lead">Cadastro de Clientes</p>
                </section>
                <section class="col-md-2">
                    <p><a href="./Default.aspx" class="btn btn-primary btn-md">Voltar</a></p>
                </section>
            </div>
        </section>
        <div>
            <div id="divPrincipal" runat="server" class="container p-3 my-3 border">
                <div class="row">
                    <section class="col-md-6">
                        <div>
                            <label id="lblNome" class="form-label">Nome/Razão Social:</label>
                        </div>
                        <input id="txtNome" runat="server"
                            type="text" maxlength="150"
                            class="form-control "
                            placeholder="Nome Completo ou Razão Social do Cliente" required />
                    </section>
                    <section class="col-md-6">
                        <div>
                            <label id="lblEmail" class="form-label">Email:</label>
                        </div>
                        <input id="txtEmail" runat="server"
                            type="email" maxlength="150"
                            class="form-control "
                            placeholder="E-mail do Cliente" required />
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblTelefone" class="form-label">Telefone:</label>
                        </div>
                        <input id="txtTelefone" runat="server"
                            type="text" data-mask="(00) 00000-0000"
                            class="form-control telefone"
                            placeholder="Telefone do Cliente"
                            required />
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblDataCadastro" class="form-label">Data do Cadastro:</label>
                        </div>
                        <input id="txtDataCadastro" runat="server"
                            type="date" class="form-control" disabled />
                    </section>
                </div>
            </div>
            <div id="divInformacoesPessoais" runat="server" class="container p-3 my-3 border">
                <div class="row">
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblTipoPessoa" class="form-label">Tipo de Pessoa:</label>
                            <select id="ddlPessoa" runat="server" clientidmode="Static"
                                class="form-select">
                                <option>Física</option>
                                <option>Jurídica</option>
                            </select>
                        </div>
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblDocumento" class="form-label">CPF/CNPJ:</label>
                            <input id="txtDocumento" runat="server"
                                type="text" class="form-control documento"
                                data-mask="000.000.000-00" data-mask-reverse="true"
                                placeholder="CPF do Cliente" />
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
