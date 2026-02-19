using App_WebForm.Classe.code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace App_WebForm
{
    public partial class MySQL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var tb = new DataTable();
                tb.Columns.Add("Nome");
                tb.Columns.Add("Aniversario");
                tb.Columns.Add("Idade");
                tb.Columns.Add("Telefone");

                if (clMySQL.MySQL_Open())
                {
                    string xComando = "SELECT *," +
                                             "((MONTH(nascimento)*100)+DAY(nascimento)) AS _aniversario, " +
                                             "(" + DateTime.Now.Year.ToString() + " - YEAR(nascimento)) AS _idade " +
                                      "FROM iavn_cadastro ORDER BY nome";

                    if (clMySQL.MySQL_Executar(xComando))
                    {
                        while (!clMySQL.MySQL_Eof())
                        {
                            DataRow xrGrid = tb.NewRow();
                            xrGrid["Nome"] = clMySQL.MySQL_LeCampo("nome");
                            xrGrid["Aniversario"] = clMySQL.MySQL_LeCampo("_aniversario");
                            xrGrid["Idade"] = clMySQL.MySQL_LeCampo("_idade");
                            xrGrid["Telefone"] = clMySQL.MySQL_LeCampo("fone1");
                            tb.Rows.Add(xrGrid);

                            clMySQL.MySQL_Skip();
                        }
                    }

                    clMySQL.MySQL_Close();
                }

                gridPessoas.DataSource = tb;
                gridPessoas.DataBind();
            }
        }

    }
}