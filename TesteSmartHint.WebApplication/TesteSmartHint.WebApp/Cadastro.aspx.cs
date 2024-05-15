using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSmartHint.WebApp.BLL;
using System.Text;
using TesteSmartHint.WebApp.Models;

namespace TesteSmartHint.WebApp.Secure
{
    public partial class Cadastro : System.Web.UI.Page
    {
        private HttpClient _client;
        public Cadastro()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri(string.Format("{0}", ConfigurationManager.AppSettings["APITesteSmartHint_URL"]));
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var mensagem = ValidaCampos(txtEmail.Value, txtDocumento.Value, txtInscricaoEstadual.Value);
            if (mensagem != string.Empty)
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alerta", $"alert('{mensagem}');", true);
                return;
            }

            var obj = PessoaBLL.CadastraPessoa(_client, new Pessoa
            {
                Nome = txtNome.Value,
                Email = txtEmail.Value,
                Telefone = txtTelefone.Value,
                Bloqueado = false,
                InscricaoEstadual = txtInscricaoEstadual.Value
            });

            if (ddlPessoa.Value == "0")
            {
                var pf = PessoaFisicaBLL.CadastraPessoaFisica(_client, new PessoaFisica
                {
                    Id = obj.Id,                    
                    CPF = txtDocumento.Value,
                    Genero = ddlGenero.Items[ddlGenero.SelectedIndex].Text,
                    dtNascimento = DateTime.ParseExact(txtDataNascimento.Value, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture)
                });
            }
            else if (ddlPessoa.Value == "1")
            {
                var pf = PessoaJuridicaBLL.CadastraPessoaJuridica(_client, new PessoaJuridica
                {
                    Id = obj.Id,
                    CNPJ = txtDocumento.Value
                });
            }
        }
        private string ValidaCampos(string email, string documento, string inscricaoEstadual)
        {

            if (!PessoaBLL.ValidaEmail(_client, email))
                return ("Este e-mail já está cadastrado para outro Cliente");
            if (ddlPessoa.Value == "0" && !PessoaFisicaBLL.ValidaCPF(_client, documento))
                return ("Este CPF já está cadastrado para outro Cliente");
            if (ddlPessoa.Value == "1" && !PessoaJuridicaBLL.ValidaCNPJ(_client, documento))
                return ("Este CNPJ já está cadastrado para outro Cliente");

            return string.Empty;
        }
    }
}