using App_WebForm.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_WebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTestes_Click(object sender, EventArgs e)
        {
            try
            {
                var termo = ProdutoRules.NormalizarBusca(txtBusca.Text);
                lblMensagem.Text = $"Buscando por: {termo}";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}