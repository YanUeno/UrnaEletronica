using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UrnaEletronica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ArrayList listCandidatos = new ArrayList();
        List<Candidatos> listCandidatos = new List<Candidatos>();
        private void Form1_Load(object sender, EventArgs e)
        {
            listCandidatos.Add(new Candidatos("messi", "12/12/2003","argentina", 1111, "https://upload.wikimedia.org/wikipedia/commons/b/b4/Lionel-Messi-Argentina-2022-FIFA-World-Cup_%28cropped%29.jpg"));
            listCandidatos.Add(new Candidatos("Pele", "12/12/2004","Brasil" , 2222, "https://capitalist.com.br/wp-content/uploads/2021/08/pele.jpg"));
            listCandidatos.Add(new Candidatos("neymay", "12/12/2005","PSG", 3333, "https://static.quizur.com/i/b/5ba929fe3eb162.932951178858759192dc33350b81600803fe2158.jpg"));
            listCandidatos.Add(new Candidatos("pombo", "12/12/2006","Brasil", 4444, "https://s2.glbimg.com/iGCPV8MU-QElvpyGQNTOf8EWli0=/0x0:1027x1284/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_71a8fe14ac6d40bd993eb59f7203fe6f/internal_photos/bs/2022/M/z/MvrbabQHerBX6muBXecg/richarlison-derrota-croacia-gq.jpg"));
            listCandidatos.Add(new Candidatos("ronaldinho", "12/12/2007","FBF", 5555, "https://s2.glbimg.com/wpnXlOEofDtm9F4G4Ct-Ctbn13s=/0x0:3000x2220/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_bc8228b6673f488aa253bbcb03c80ec5/internal_photos/bs/2022/f/H/Env5wPSiSC2nHA7rkdlA/gettyimages-56034481.jpg"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        public void LimpaCampos()
        {
            txtNome.Text = null;
            txtDigito.Text = null;
            txtPartido.Text = null;
            txtData.Text = null;
            foto.ImageLocation = null;
        }
        public string GerarHash(String nome, String codigo)
        {
            string input = nome + codigo;
            SHA256 sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            String hashString = BitConverter.ToString(hash).Replace("-","").ToLower();
            return hashString;
        }
        public void Salvar()//String nome,String Codigo
        {
            if (okSalvar && txtNome.Text != "")
            {
                try
                {
                    //Open the File
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    StreamWriter sw = new StreamWriter(desktop + "/votos.txt", true, Encoding.ASCII);

                    sw.Write(txtDigito.Text + "\r\n");
                    sw.Write(GerarHash(txtNome.Text, txtDigito.Text) + "\r\n");
                    sw.Write("------" + "\r\n");
                    //close the file
                    sw.Close();
                    txtCodigo.Clear();
                    txtData.Clear();
                    txtDigito.Clear();
                    txtNome.Clear();
                    txtPartido.Clear();
                    foto.ImageLocation = null;
                    MessageBox.Show("Voto computado !");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            else
            {
                MessageBox.Show("codico invalido");
            }
        }
        Boolean okSalvar = false;
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length == 4)
            {
                listCandidatos.ForEach(item =>
                {
                    if(item.getCodigo().ToString() == txtCodigo.Text)
                    {
                        txtNome.Text = item.getNome();
                        txtDigito.Text = item.getCodigo().ToString();
                        txtPartido.Text = item.getPartido();
                        txtData.Text = item.getdataNascimento();
                        foto.ImageLocation = item.getCaminhoImagem();
                        okSalvar = true;
                    }
                });
            }
            else
            {
                okSalvar = false;
                LimpaCampos();
            }
        }
    }
}