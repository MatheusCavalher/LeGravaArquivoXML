using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace LeEGravaArquivoXML
{
    class GravarXML
    {
        public Boolean gravarConf(string _ipBanco, string _usuario, string _senha, string _dataBase)
        {
            try
            {
                string pasta = Application.StartupPath + @"\dbconnect";
                if (!File.Exists(pasta))
                {
                    Directory.CreateDirectory(pasta);
                }
                string arquivo = Application.StartupPath + @"\dbconnect\configBanco.xml";
                XmlTextWriter writer = new XmlTextWriter(arquivo, null);

                //inicia o documento xml
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                //escreve o elmento raiz
                writer.WriteStartElement("Conexao");
                //Escreve os sub-elementos
                writer.WriteElementString("ipBanco", _ipBanco);
                writer.WriteElementString("usuario", _usuario);
                writer.WriteElementString("senha", _senha);
                writer.WriteElementString("dataBase", _dataBase);
                // encerra o elemento raiz
                writer.WriteEndElement();
                //Escreve o XML para o arquivo e fecha o objeto escritor
                writer.Flush();
                writer.Close();

                MessageBox.Show("Arquivo de configuração gerado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("não foi possivel gravar arquivo de configurção de banco de dados.");
                return false;
            }           
        }
    }
}
