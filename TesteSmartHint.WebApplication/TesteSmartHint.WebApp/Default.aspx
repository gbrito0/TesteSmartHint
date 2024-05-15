<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteSmartHint.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Teste SmartHint</h1>
            <div class="row">
                <section class="col-md-9 mx-3">
                    <p class="lead">Consulte os seus Clientes cadastrados na sua Loja ou realize o cadastro de novos Cliente</p>
                </section>
                <section class="col-md-2">
                    <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Adicionar Cliente</a></p>
                </section>
            </div>
        </section>
        <div>
            <button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePesquisa"
                aria-expanded="false" aria-controls="collapsePesquisa">
                Filtrar
            </button>
            <div id="collapsePesquisa" class="collapse show">
                <div id="divFiltros" class="row p-2">
                    <div class="col-sm-2">
                        <input type="checkbox" class="form-check-input" id="chkNome" name="chkNome" checked>
                        <label class="form-check-label" for="chkNome">Nome/Razão Social</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox" class="form-check-input" id="chkEmail" name="chkEmail" checked>
                        <label class="form-check-label" for="chkEmail">Email</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox" class="form-check-input" id="chkTelefone" name="chkTelefone" checked />
                        <label class="form-check-label" for="chkTelefone">Telefone</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox" class="form-check-input" id="chkDtCadastro" name="chkDtCadastro" checked />
                        <label class="form-check-label" for="chkDtCadastro">Data do Cadastro</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox" class="form-check-input" id="chkBloqueado" name="chkBloqueado" checked />
                        <label class="form-check-label" for="chkBloqueado">Bloqueado</label>
                    </div>
                </div>
                <div id="divPesquisa" runat="server" class="container p-3 my-3 border">
                    <div class="row">
                        <section class="col-md-6">
                            <div>
                                <label id="lblNome" class="form-label">Nome/Razão Social:</label>
                            </div>
                            <input id="txtNome" runat="server"
                                type="text" maxlength="150"
                                class="form-control "
                                placeholder="Nome ou Razão Social do Cliente" />
                        </section>
                        <section class="col-md-6">
                            <div>
                                <label id="lblEmail" class="form-label">Email:</label>
                            </div>
                            <input id="txtEmail" runat="server"
                                type="email" maxlength="150"
                                class="form-control "
                                placeholder="E-mail do Cliente" />
                        </section>
                        <section class="col-md-3 mt-2">
                            <div>
                                <label id="lblTelefone" class="form-label">Telefone:</label>
                            </div>
                            <input id="txtTelefone" runat="server"
                                type="number" min="11" max="11" step="1"
                                class="form-control telefone"
                                placeholder="Telefone do Cliente"
                                required />
                        </section>
                        <section class="col-md-3 mt-2">
                            <div>
                                <label id="lblDataCadastro" class="form-label">Data do Cadastro:</label>
                            </div>
                            <input id="txtDataCadastro" runat="server"
                                type="date" class="form-control" />
                        </section>
                        <section class="col-md-6 mt-2">
                            <div>
                                <label id="lblBloqueado" class="form-label">Cliente Bloqueado:</label>
                                <select id="ddlBloqueado" runat="server"
                                    class="form-select">
                                    <option>Sim</option>
                                    <option>Não</option>
                                </select>
                            </div>
                        </section>
                        <section class="col-md-10 mt-2">
                            <button id="btnAplicarFiltros" runat="server"
                                type="button" class="btn btn-primary"
                                data-bs-toggle="collapse" data-bs-target="#collapsePesquisa"
                                aria-expanded="false" aria-controls="collapsePesquisa">
                                Aplicar Filtros</button>
                            <button id="btnLimparFiltros" runat="server"
                                type="button" class="btn btn-primary">
                                Limpar Filtros</button>
                        </section>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:UpdatePanel ID="upGrid" runat="server">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="grvCompradores" runat="server"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            PageSize="20"
                            Width="100%"
                            Visible="true"
                            CssClass="table table-striped"
                            PagerStyle-CssClass="pagination"
                            OnPageIndexChanging="grvCompradores_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Nome/Razão Social">
                                    <ItemTemplate>
                                        <%#Eval("Nome") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="E-mail">
                                    <ItemTemplate>
                                        <%#Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Telefone">
                                    <ItemTemplate>
                                        <%#Eval("Telefone") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data de Cadastro">
                                    <ItemTemplate>
                                        <%#Eval("dtCadastro") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bloqueado">
                                    <ItemTemplate>
                                        <%#Eval("Bloqueado") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ações">
                                    <ItemTemplate>
                                        <%#Eval("Acao") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </main>
</asp:Content>
