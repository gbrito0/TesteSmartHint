<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="TesteSmartHint.WebApp.Secure.Cadastro" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            $("#txtDataCadastro")[0].value = new Date().toLocaleDateString("pt-BR");
            if ($("#ddlPessoa").val() == 1)
                collapseCadastro();
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
                            data-bs-toggle="tooltip" data-bs-placement="bottom" title="Nome completo ou Razão Social do Cliente"
                            placeholder="Nome/Razão Social" required />
                    </section>
                    <section class="col-md-6">
                        <div>
                            <label id="lblEmail" class="form-label">Email:</label>
                        </div>
                        <input id="txtEmail" runat="server"
                            type="email" maxlength="150"
                            class="form-control "
                            data-bs-toggle="tooltip" data-bs-placement="bottom" title="E-mail do Cliente"
                            placeholder="E-mail" required />
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblTelefone" class="form-label">Telefone:</label>
                        </div>
                        <input id="txtTelefone" runat="server"
                            type="text" data-mask="(00) 00000-0000"
                            class="form-control telefone"
                            data-bs-toggle="tooltip" data-bs-placement="bottom" title="Telefone do Cliente"
                            placeholder="Telefone"
                            required />
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblDataCadastro" class="form-label">Data do Cadastro:</label>
                        </div>
                        <input id="txtDataCadastro"
                            type="text" class="form-control" disabled />
                    </section>
                    <section class="col-md-3 mt-5">
                        <div>
                            <input type="checkbox"
                                id="chkBloqueado" runat="server" clientidmode="Static"
                                class="form-check-input chk" name="chkBloqueado" />
                            <label class="form-check-label" for="chkBloqueado">Bloqueado</label>
                        </div>
                    </section>
                </div>
            </div>
            <div id="divInformacoesPessoais" runat="server" class="container p-3 my-3 border">
                <div class="row">
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblTipoPessoa" class="form-label">Tipo de Pessoa:</label>
                            <select id="ddlPessoa" runat="server" clientidmode="Static"
                                class="form-select"
                                data-bs-toggle="tooltip" data-bs-placement="bottom" title="Selecione o tipo de Pessoa">
                                <option value="0">Física</option>
                                <option value="1">Jurídica</option>
                            </select>
                        </div>
                    </section>
                    <section class="col-md-3 mt-2">
                        <div>
                            <label id="lblDocumento" class="form-label">CPF/CNPJ:</label>
                            <input id="txtDocumento" runat="server" clientidmode="static"
                                type="text" class="form-control documento"
                                data-mask="000.000.000-00" data-mask-reverse="true"
                                data-bs-toggle="tooltip" data-bs-placement="bottom" title="Insira o CPF ou o CNPJ do Cliente"
                                placeholder="CPF/CNPJ" required />
                        </div>
                    </section>
                    <section class="col-md-6 mt-2">
                        <div class="row">
                            <section class="col-6">
                                <label id="lblInscricaoEstadual" class="form-label">Inscrição Estadual:</label>
                            </section>
                            <section class="col-6">
                                <input type="checkbox"
                                    id="chkIsento" runat="server" clientidmode="Static"
                                    class="form-check-input chk" name="chkIsento" />
                                <label id="lblIsento" class="form-label">Isento</label>
                            </section>
                        </div>
                        <input id="txtInscricaoEstadual" runat="server" clientidmode="static"
                            type="text" data-mask="000.000.000-000"
                            class="form-control"
                            data-bs-toggle="tooltip" data-bs-placement="bottom" title="Inscrição Estadual do Cliente, Selecionar Isento caso assim for."
                            placeholder="Inscrição Estadual"
                            required />
                    </section>
                    <div id="collapsePessoaFisica" class="collapse show">
                        <div class="row">
                            <section class="col-md-3 mt-2">
                                <div>
                                    <label id="lblGenero" class="form-label">Gênero:</label>
                                    <select id="ddlGenero" runat="server" clientidmode="Static"
                                        class="form-select"
                                        data-bs-toggle="tooltip" data-bs-placement="bottom" title="Selecione o gênero do Cliente">
                                        <option value="0">Masculino</option>
                                        <option value="1">Feminino</option>
                                        <option value="2">Outro</option>
                                    </select>
                                </div>
                            </section>
                            <section class="col-md-3 mt-2">
                                <div>
                                    <label id="lblDtNasicmento" class="form-label">Data de Nascimento:</label>
                                </div>
                                <input id="txtDataNascimento" runat="server" clientidmode="Static"
                                    type="date" class="form-control" required/>
                            </section>
                        </div>
                    </div>
                    <div class="row">
                        <section class="col-md-5 mt-2">
                            <label class="form-label">Senha:</label>
                            <input id="txtSenha" runat="server" clientidmode="Static"
                                type="password" autocomplete="off" class="form-control"
                                maxlength="15" minlength="8"
                                name="up" placeholder="Senha" required>
                        </section>
                        <section class="col-md-5 mt-2">
                            <label class="form-label">Confirmação de Senha:</label>
                            <input id="txtConfirmarSenha" runat="server" clientidmode="Static"                                                                
                                type="password" autocomplete="off" class="form-control"
                                name="up2" maxlength="15" placeholder="Confirme a Senha" required>
                        </section>
                    </div>
                    <div>
                        <section class="col-md-3 mt-2">
                            <div>
                                <asp:Button ID="btnCadastrar" runat="server"
                                    type="button" class="btn btn-primary" Text="Adicionar" OnClick="btnCadastrar_Click" />
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
