using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSmartHint.WebApp.BLL;
using TesteSmartHint.WebApp.Models;

namespace TesteSmartHint.WebApp
{
    public partial class _Default : Page
    {
        private HttpClient _client;
        public _Default()
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
        protected void grvCompradores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnFiltraCampos_Click(object sender, EventArgs e)
        {
            var pessoasByFiltro = PessoaBLL.RetornaPessoasByFiltro(_client, montaFiltros());
            CarregaGrid(pessoasByFiltro);
        }

        private IDictionary<string, string> montaFiltros()
        {
            var dict = new Dictionary<string, string>();

            if (chkNome.Checked && !String.IsNullOrEmpty(txtNome.Value))
                dict.Add("nome", txtNome.Value.ToString());
            if (chkTelefone.Checked && !String.IsNullOrEmpty(txtTelefone.Value))
                dict.Add("telefone", txtTelefone.Value.ToString());
            if (chkEmail.Checked && !String.IsNullOrEmpty(txtEmail.Value))
                dict.Add("email", txtEmail.Value.ToString());
            if (chkDtCadastro.Checked && !String.IsNullOrEmpty(txtDataCadastro.Value))
            {
                var datas = txtDataCadastro.Value.Split('-');
                dict.Add("dtInicio", datas[0].Trim());
                dict.Add("dtFim", datas[1].Trim());                
            }                
            if (chkBloqueado.Checked)
                dict.Add("bloqueado", ddlBloqueado.Items[ddlBloqueado.SelectedIndex].Value.ToString());            

            return dict;
        }

        private void CarregaGrid(List<Pessoa> pessoas)
        {
            if (pessoas == null || pessoas.Count == 0)
                grvCompradores.DataSource = null;
            else
                grvCompradores.DataSource = pessoas;

            grvCompradores.DataBind();
        }
    }
}