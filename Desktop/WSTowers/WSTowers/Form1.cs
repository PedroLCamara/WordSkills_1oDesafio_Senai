using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSTowers
{
    public partial class Form1 : Form
    {
        public WSTowersEntities context = new WSTowersEntities();
        public int CategoriaExibicao = 0;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SenhaInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            participante ParticipanteLogin;
            bool UsuarioEncontrado = false;
            List<participante> ListaParticipantes = context.participante.ToList();
            foreach (var item in ListaParticipantes)
            {
                string Senha = (item.cidade1.estado1.Sigla + item.genero1.Genero1 + item.idade.ToString()).ToUpper();
                string Usuario = (item.nome.Split(' ')[0].Substring(0,1) + item.nome.Split(' ')[1]).ToUpper();
                string SenhaForm = SenhaInput.Text.ToUpper();
                string UsuarioForm = UserInput.Text.ToUpper();
                if (Senha == SenhaForm)
                {
                    if (Usuario == UsuarioForm)
                    {
                        ParticipanteLogin = item;
                        UsuarioEncontrado = true;
                        break;
                    }
                }
            }
            if (UsuarioEncontrado == false)
            {
                label3.Text = "Usuário ou senha inválidos, tente novamente...";
            }
            else
            {
                label3.Text = "";
                LoadData();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserInput_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            if (CategoriaExibicao != 0)
            {
                var produtoList = context.produto.Select(x => new
                {
                    produto = x,
                    Sequencial = x.id,
                    Nome = x.produto1,
                    Valor = x.valor,
                    Categoria = x.categoria1.Categoria1
                }).ToList().FindAll(p => p.produto.categoria == CategoriaExibicao);

                dataGridView1.DataSource = produtoList;
                dataGridView1.Columns["produto"].Visible = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var produto = dataGridView1.Rows[i].Cells[0].Value as produto;
                    if (produto.valor > 250)
                    {
                        dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightBlue;
                    }
                }
            }
            else
            {
                var produtoList = context.produto.Select(x => new
                {
                    produto = x,
                    Sequencial = x.id,
                    Nome = x.produto1,
                    Valor = x.valor,
                    Categoria = x.categoria1.Categoria1
                }).ToList();

                dataGridView1.DataSource = produtoList;
                dataGridView1.Columns["produto"].Visible = false;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var produto = dataGridView1.Rows[i].Cells[0].Value as produto;
                    if (produto.valor > 250)
                    {
                        dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightBlue;
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                CategoriaExibicao++;
                if (context.categoria.ToList().FirstOrDefault(c => c.id == CategoriaExibicao) == null)
                {
                    CategoriaExibicao = 0;
                    LoadData();
                }
                else
                {
                    LoadData();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                string[] files = Directory.GetFiles("C:\\Users\\Pichau\\Desktop\\WordSkillsExercicios\\PrimeiroDesafio\\Desktop\\WSTowers\\WSTowers\\Produtos", "*");
                foreach (var item in files)
                {
                    string CaminhoSeparado = item.Split('\\')[10];
                    string IdArquivo = CaminhoSeparado.Split('.')[0];
                    if (Convert.ToInt32(IdArquivo) == Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value))
                    {
                        pictureBox1.ImageLocation = item;
                        break;
                    }
                }
            }
        }
    }
}