using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace LeEGravaArquivoXML
{
    public partial class Form1 : Form
    {
        GravarXML xmlGravacao = new GravarXML();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cria uma instância de um documento XML
            XmlDocument oXML = new XmlDocument();

            //Define o caminho do arquivo XML 
            string ArquivoXML = Application.StartupPath + @"\dbconnect\configBanco.xml";
            if (!File.Exists(ArquivoXML))
            {
                if (MessageBox.Show("Você não tem um arquivo de configuração de banco de dados. Deseja criar um ?", "Configurãção de Banco de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                }
                else
                    Application.Exit();
            }
            else
            {
                try
                {
                    //carrega o arquivo XML
                    oXML.Load(ArquivoXML);

                    //Lê o filho de um Nó Pai específico 
                    txtIpBanco.Text = oXML.SelectSingleNode("Conexao").ChildNodes[0].InnerText;
                    txtLogin.Text = oXML.SelectSingleNode("Conexao").ChildNodes[1].InnerText;
                    txtSenha.Text = oXML.SelectSingleNode("Conexao").ChildNodes[2].InnerText;
                    txtDataBase.Text = oXML.SelectSingleNode("Conexao").ChildNodes[3].InnerText;
                }
                catch
                {
                    MessageBox.Show("Erro ao carregar dados de configuração de banco de dados!");
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            xmlGravacao.gravarConf(txtIpBanco.Text, txtLogin.Text, txtSenha.Text, txtDataBase.Text);
            Application.Exit();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtIpBanco.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtDataBase.Text = "";
        }
    }
}
