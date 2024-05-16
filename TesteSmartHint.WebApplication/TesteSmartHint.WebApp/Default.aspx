<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TesteSmartHint.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Teste SmartHint - Consulta</h1>
            <div class="row">
                <section class="col-md-9 mx-3">
                    <p class="lead">Consulte os seus Clientes cadastrados na sua Loja ou realize o cadastro de novos Cliente</p>
                </section>
                <section class="col-md-2">
                    <p><a href="./Cadastro.aspx" class="btn btn-primary btn-md">Adicionar Cliente</a></p>
                </section>
            </div>
        </section>
        <div>
            <button class="btn btn-primary" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePesquisa"
                aria-expanded="false" aria-controls="collapsePesquisa">
                Filtrar
            </button>
            <div id="collapsePesquisa" class="collapse">
                <div id="divFiltros" class="row p-2">
                    <div class="col-sm-2">
                        <input type="checkbox"
                            id="chkNome" runat="server"
                            class="form-check-input chk" name="chkNome" checked>
                        <label class="form-check-label">Nome/Razão Social</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox"
                            id="chkEmail" runat="server"
                            class="form-check-input chk" name="chkEmail" checked>
                        <label class="form-check-label" for="chkEmail">Email</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox"
                            id="chkTelefone" runat="server" clientidmode="Static"
                            class="form-check-input chk" name="chkTelefone" checked />
                        <label class="form-check-label" for="chkTelefone">Telefone</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox"
                            id="chkDtCadastro" runat="server" clientidmode="Static"
                            class="form-check-input chk" name="chkDtCadastro" checked />
                        <label class="form-check-label" for="chkDtCadastro">Data do Cadastro</label>
                    </div>
                    <div class="col-sm-2">
                        <input type="checkbox"
                            id="chkBloqueado" runat="server" clientidmode="Static"
                            class="form-check-input chk" name="chkBloqueado" checked />
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
                                type="text" maxlength="150"
                                class="form-control"
                                placeholder="E-mail do Cliente" />
                        </section>
                        <section class="col-md-3 mt-2">
                            <div>
                                <label id="lblTelefone" class="form-label">Telefone:</label>
                            </div>
                            <input id="txtTelefone" runat="server"
                                type="text" data-mask="(00) 00000-0000"
                                class="form-control telefone"
                                placeholder="Telefone do Cliente" />
                        </section>
                        <section class="col-md-3 mt-2">
                            <div>
                                <label id="lblDtCadastro" class="form-label">Data do Cadastro:</label>
                            </div>
                            <input id="daterange"
                                name="daterange" type="text" class="form-control" />
                            <input id="txtDataCadastro" runat="server" clientidmode="Static"
                                type="hidden" class="form-control" />
                        </section>
                        <section class="col-md-6 mt-2">
                            <div>
                                <label id="lblBloqueado" class="form-label">Cliente Bloqueado:</label>
                                <select id="ddlBloqueado" runat="server"
                                    class="form-select cbo">
                                    <option value="0">Nao</option>
                                    <option value="1">Sim</option>
                                </select>
                            </div>
                        </section>
                        <section class="col-md-10 mt-2">
                            <asp:Button ID="btnFiltraCampos" runat="server"
                                class="btn btn-primary" Text="Aplicar Filtros"
                                OnClientClick="collapseAll();return true;" OnClick="btnFiltraCampos_Click" />
                            <button id="btnLimparFiltros" runat="server"
                                type="button" class="btn btn-primary" onclick="limparCampos();">
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
                        <asp:GridView ID="grvCompradores" runat="server" ClientIDMode="Static"
                            AutoGenerateColumns="false"
                            AllowPaging="true"
                            PageSize="20"
                            Width="100%"
                            Visible="true"
                            CssClass="table table-striped"
                            PagerStyle-CssClass="pagination"
                            OnPageIndexChanging="grvCompradores_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="1%">
                                    <HeaderTemplate>
                                        <div style="margin-left: 7px;">
                                            <input id="chkAllItems" onclick="selectAllCheckGrid(this)"
                                                runat="server" type="checkbox" />
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelecionar" runat="server" class="grvchk" ClientIDMode="Static" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                                        <asp:CheckBox ID="chkGridBloqueado" runat="server" Checked='<%# Eval("Bloqueado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ação">
                                    <ItemTemplate>
                                        <asp:Button ID="btnGridEditar" runat="server"
                                            class="btn btn-primary" Text="Editar" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </main>
    <script type="text/javascript">

        //Configura daterange picker
        $(function () {
            $('input[name="daterange"]').daterangepicker({
                showDropdowns: true,
                minYear: 1901,
                maxYear: parseInt(moment().format('YYYY'), 10),
                locale: {
                    format: 'DD/MM/YYYY'
                }
            });
            $('#daterange').on('apply.daterangepicker', function (ev, picker) {
                $('#txtDataCadastro').val($('#daterange').val());
            });
        });

        //Evento para pesquisar ao remover filtro
        $(".form-check-input, .chk").change(function () {
            if (this.checked == false)
                $("[id*=btnFiltraCampos]").click();
        });
    </script>
</asp:Content>
