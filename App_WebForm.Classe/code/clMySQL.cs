using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace App_WebForm.Classe.code
{
    public class clMySQL
    {
        static public string conexao = "Persist Security Info = False; server=SERVIDOR;database=BANCO;uid=USUARIO;Pwd=SENHA";
        static public string servidorMySQL = "";
        static public string bancoMySQL = "";
        static public string usuarioMySQL = "";
        static public string senhaMySQL = "";
        static public string msgMySQL = "";

        static public int reccountMySQL = 0;                     // Quantidade de registros (linhas na lista - 1)
        static public int recnoMySQL = 0;                     // Registro corrente
        static public int colunasMySQL = 0;                     // Quantidade de campos na última instrução SELECT ou SHOW
        static public bool eofMySQL = true;                  // Indica, em um loop, se o fim da lista foi atingido

        static public List<string> browseSQL = new List<string>();    // Lista com o resultado do SELECT ou SHOW

        static public MySqlConnection idSQL = new MySqlConnection();


        static public string[,] MySQL_Browse()    /* Alimenta uma matriz de duas dimensões com registros e conteúdos de campos */
        {
            /*      ____________________
                    EXEMPLO DE APLICAÇÃO
                    ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯     
                    string[,] tabelaFinal = DataBaseMySQL.MySQL_Browse();

                    for (int recnoLoop = 0; recnoLoop <= DataBaseMySQL.MySQL_Reccount(); recnoLoop++)
                    {
                        for (int colunaLoop = 1; colunaLoop <= DataBaseMySQL.MySQL_Colunas(); colunaLoop++)
                        {
                            Console.WriteLine("Recno/coluna: " + recnoLoop  + 
                                              "/"              + colunaLoop + 
                                              " = "            + tabelaFinal[recnoLoop, colunaLoop]);
                        }
                    }
            */

            string[,] browseRetorno = null;

            if (colunasMySQL == 0 || reccountMySQL == 0)
            {
                return browseRetorno;
            }

            browseRetorno = new string[reccountMySQL + 2, colunasMySQL + 2];

            string[] campoSelect;
            int indiceLista = 0;

            foreach (string linhaLista in browseSQL)
            {
                campoSelect = linhaLista.Split(new char[] { '|' });

                for (int colunaLoop = 0; colunaLoop < campoSelect.Length; colunaLoop++)
                {
                    browseRetorno[indiceLista, colunaLoop + 1] = campoSelect[colunaLoop];
                }

                indiceLista++;
            }

            return browseRetorno;
        }

        static public bool MySQL_Open(string parametroServidorMySQL, string parametroBancoMySQL, string parametroUsuarioMySQL, string parametroSenhaMySQL)
        {
            servidorMySQL = parametroServidorMySQL;
            bancoMySQL = parametroBancoMySQL;
            usuarioMySQL = parametroUsuarioMySQL;
            senhaMySQL = parametroSenhaMySQL;

            return MySQL_Open();
        }
        static public bool MySQL_Open()
        {
            if (servidorMySQL == "")
            {
                //                conexao = "Persist Security Info = False; server=helena_g.mysql.dbaas.com.br;database=helena_g;uid=helena_g;Pwd=gerensys1366";
                conexao = "server=helena_g.mysql.dbaas.com.br;" +
                          "database=helena_g;" +
                          "uid=helena_g;" +
                          "Pwd=gerensys1366;" +
                          "Persist Security Info = True;" +
                          "Convert Zero Datetime = True";
            }
            else
            {
                conexao = "Persist Security Info = False; server=" + servidorMySQL + ";database=" + bancoMySQL + ";uid=" + usuarioMySQL + ";Pwd=" + senhaMySQL;
            }

            msgMySQL = "";
            idSQL = new MySqlConnection(conexao);

            try
            {
                idSQL.Open();
            }
            catch (System.Exception e)
            {
                msgMySQL = "Erro na abertura do banco: " + e.Message.ToString();
            }

            if (msgMySQL == "")
            {
                msgMySQL = idSQL.State.ToString();
            }

            return (idSQL.State == ConnectionState.Open);
        }


        public static bool MySQL_Executar(string comandoSQL)
        {
            MySqlDataReader respSQL = null;
            msgMySQL = "";
            bool selectBancoOk = (comandoSQL.Substring(0, 6).ToLower() == "select" || comandoSQL.Substring(0, 4).ToLower() == "show");

            if (selectBancoOk)       // Instrução SELECT ou SHOW?
            {
                /*
                   A lista "browseSQL" será alimentada:
                     * O índice 0 (zero) conterá a lista dos campos separados por "|"
                     * Cada índice maior que zero representa o conteúdo dos registros separados por "|"

                     ____________________________________________
                     EXEMPLO DE APLICAÇÃO NUMA VARREDURA DA LISTA
                     ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯     
                     if(DataBaseMySQL.MySQL_Executar("SELECT * FROM valmir_pagto"))
                     {
                          while (!DataBaseMySQL.MySQL_Eof())
                          {
                              Console.WriteLine("Registro: " + DataBaseMySQL.MySQL_Recno()       + 
                                                " -> "       + DataBaseMySQL.MySQL_LeCampo("id") + 
                                                " - "        + DataBaseMySQL.MySQL_LeCampo("pagamento"));
                              DataBaseMySQL.MySQL_Skip();
                          }
                     }
                 */

                browseSQL.Clear();
                recnoMySQL = 0;
                reccountMySQL = 0;
                colunasMySQL = 0;
                eofMySQL = true;
            }

            try
            {
                MySqlCommand ioSQL = new MySqlCommand(comandoSQL, idSQL);
                respSQL = ioSQL.ExecuteReader();
            }
            catch (System.Exception e)
            {
                msgMySQL = e.Message.ToString() + " - Instrução=[" + comandoSQL + "]";
            }

            if (msgMySQL != "")
            {
                return false;
            }

            // Resultado do comando SELECT
            if (selectBancoOk)
            {
                colunasMySQL = respSQL.FieldCount;

                msgMySQL = "";
                for (int colBrowse = 0; colBrowse < respSQL.FieldCount; colBrowse++)
                {
                    msgMySQL = msgMySQL + respSQL.GetName(colBrowse) + "|";
                }
                browseSQL.Add(msgMySQL);    // O índice 0 conterá os nomes dos campos

                while (respSQL.Read())
                {
                    msgMySQL = "";
                    for (int colBrowse = 0; colBrowse < colunasMySQL; colBrowse++)
                    {
                        msgMySQL = msgMySQL + respSQL.GetValue(colBrowse) + "|";
                    }
                    browseSQL.Add(msgMySQL);    // Cada índice corresponde a um registro
                    reccountMySQL++;
                }

                if (reccountMySQL > 0)
                {
                    recnoMySQL = 1;
                    eofMySQL = false;
                }

                msgMySQL = "Registros lidos: " + reccountMySQL.ToString();
            }
            else
            {
                msgMySQL = "Registros afetados: " + respSQL.RecordsAffected.ToString();
            }

            respSQL.Close();

            return true;
        }


        static public void MySQL_Close()
        {
            browseSQL.Clear();
            recnoMySQL = 0;
            reccountMySQL = 0;
            colunasMySQL = 0;
            eofMySQL = true;

            if (idSQL.State == ConnectionState.Open)
            {
                idSQL.Close();
            }
        }


        static public string MySQL_LeCampo(string nomeCampo)
        {
            if (reccountMySQL == 0 || recnoMySQL == 0)
            {
                return "";
            }

            int indexCampo = 0;
            string conteudoCampo = "";
            string linhaDados = browseSQL.ElementAt(0);                 // Le o cabeçalho (lista dos nomes dos campos)

            string[] campoSelect = linhaDados.Split(new char[] { '|' });
            foreach (string descricaoCampo in campoSelect)
            {
                if (descricaoCampo == nomeCampo)
                {
                    linhaDados = browseSQL.ElementAt(recnoMySQL);
                    campoSelect = linhaDados.Split(new char[] { '|' });
                    conteudoCampo = campoSelect[indexCampo];
                    if (conteudoCampo.Contains("/"))
                    {
                        int posicaoBarra = 0;
                        indexCampo = 0;
                        linhaDados = "|";
                        foreach (char checkBarra in conteudoCampo)
                        {
                            if (checkBarra == '/')
                            {
                                linhaDados = linhaDados + posicaoBarra.ToString() + "|";        // Posição da barra na string.
                                indexCampo++;
                            }
                            posicaoBarra++;
                        }
                        if (indexCampo == 2                                                        // A string tem duas barras?
                           && ((linhaDados.IndexOf("1") == 1 && linhaDados.IndexOf("3") == 3)   // "|1|3|" Ex.:  "1/ 1/2024"
                           || (linhaDados.IndexOf("2") == 1 && linhaDados.IndexOf("4") == 3)   // "|2|4|" Ex.: "10/ 1/2024"
                           || (linhaDados.IndexOf("1") == 1 && linhaDados.IndexOf("4") == 3))) // "|1|4|" Ex.:  "1/10/2024"
                        {
                            indexCampo = conteudoCampo.Length;

                            if (linhaDados.IndexOf("1") == 1 && linhaDados.IndexOf("3") == 3)
                            {
                                conteudoCampo = "0" + conteudoCampo.Substring(0, 2) + "0" + conteudoCampo.Substring(2, indexCampo - 2);
                            }
                            if (linhaDados.IndexOf("2") == 1 && linhaDados.IndexOf("4") == 3)
                            {
                                conteudoCampo = conteudoCampo.Substring(0, 3) + "0" + conteudoCampo.Substring(3, indexCampo - 3);
                            }
                            if (linhaDados.IndexOf("1") == 1 && linhaDados.IndexOf("4") == 3)
                            {
                                conteudoCampo = "0" + conteudoCampo;
                            }
                        }
                    }
                    break;
                }
                indexCampo++;
            }

            return conteudoCampo;
        }


        static public void MySQL_Skip()                       // Movimenta o índice da lista um registro para frente
        {
            MySQL_Skip(1);
        }
        static public void MySQL_Skip(int movimentoRecno)     // Movimenta o índice da lista para frente ou para trás (parâmetro negativo)
        {
            if ((recnoMySQL + movimentoRecno) > reccountMySQL || (recnoMySQL + movimentoRecno) <= 0)
            {
                if ((recnoMySQL + movimentoRecno) > reccountMySQL)
                {
                    eofMySQL = true;
                }
                return;
            }

            eofMySQL = false;
            recnoMySQL = recnoMySQL + movimentoRecno;
        }


        static public int MySQL_Recno()                       // Só retorna o RECNO corrente
        {
            return recnoMySQL;
        }
        static public void MySQL_Recno(int movimentoRecno)    // Se posiciona no RECNO definido no parâmetro
        {
            if (movimentoRecno > reccountMySQL || movimentoRecno <= 0)
            {
                if (movimentoRecno > reccountMySQL)
                {
                    eofMySQL = true;
                }
                return;
            }

            eofMySQL = false;
            recnoMySQL = movimentoRecno;
            return;
        }


        // Funções de retorno de variáveis dessa classe

        static public string MySQL_Mensagem()
        {
            return msgMySQL;
        }

        static public int MySQL_Reccount()
        {
            return reccountMySQL;
        }

        static public int MySQL_Colunas()
        {
            return colunasMySQL;
        }

        static public bool MySQL_Eof()
        {
            return eofMySQL;
        }
    }
}
