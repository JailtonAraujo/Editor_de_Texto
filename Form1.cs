using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Gerenciador_de_Arquivos
{
    public partial class Form1 : Form
    {
        StringReader ler = null;


        public Form1()
        {
            InitializeComponent();
        }

        //FUNÇÃO QUE LIMPA O RICHTEXT E ALINHA O CURSOR
        public void Novo() {
            richTextBox1.Clear();
            richTextBox1.Focus();

        }

        //METODO QUE SALVA TODO CONTEUDO DO RICHTEXT EM UM ARQUIVO .TXT//
        public void Salvar()
        {
            try {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter Escrever = new StreamWriter(arquivo);
                    Escrever.Flush();
                    Escrever.BaseStream.Seek(0, SeekOrigin.Begin);
                    Escrever.Write(this.richTextBox1.Text);
                    Escrever.Flush();
                    Escrever.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show("ERRO AO SALVAR ARQUIVO!" + ex.Message, "ERRO AO SALVAR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //METODO QUE ABRI ARQUIVO SELECIONADO NA OPENFILEDIALOG1 //
        public void Abrir() {
            this.openFileDialog1.Title = "ABRIR ARQUIVO";
            openFileDialog1.InitialDirectory = @"C:\Users\jailt\Documents\Editor de Texto\";
            openFileDialog1.Filter = "(*.TXT) | *.TXT";
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader Ler = new StreamReader(arquivo);
                    Ler.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = Ler.ReadLine();

                    //LENDO O ARQUIVO LINHA POR LINHA E PASSANDO A LINHA LIDA PARA O RichTextBox1!//
                    while (linha != null) {
                        this.richTextBox1.Text += linha + "\n";
                        linha = Ler.ReadLine();
                    }
                    Ler.Close();

                } catch (Exception ex) {
                    MessageBox.Show("ERRO AO ABRIR ARQUIVO!" + ex.Message, "ERRO AO ABRIR AQUIVO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




        }

        //METODO QUE COPIA TODO TEXTO CONTIDO NO RichTextBox//
        public void Copiar() {
            if (richTextBox1.SelectionLength > 0) {
                this.richTextBox1.Copy();
            }

        }

        //METODO QUE COLA O TEXTO COPIADO NO RichTextBox//
        public void Colar() {
            this.richTextBox1.Paste();
        }


        private void sALVARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Novo();
            //MessageBox.Show("Deseja salvar o arquivo!?");
        }

        //METODO QUE DEIXA OU OU RETIRA O TEXTO DE NEGRITO//
        public void Negrito() {
            string Nome_Fonte = null;
            float Tamanho_Fonte = 0;
            bool n, i, s = false;

            Nome_Fonte = richTextBox1.Font.Name; //ADICIONANDO A FONTE ATUAL A VARIAVEL Nome_Fonte
            Tamanho_Fonte = richTextBox1.Font.Size; //ADICIONANDO O TAMANHO ATUAL DO TEXTO  A VARIAVEL Tamanho_Fonte
            n = richTextBox1.SelectionFont.Bold; // PEGANDO O ESTILO ATUAL DO TEXTO  
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Regular);

            //VERIFICANDO SE O TEXTO JA ESTA EM NEGRITO. SE NÃO PASSANDO O MESMO PARA NEGRITO E SE JA ESTIVER PASSANDO  PARA FONTE REGULAR 
            if (n == false)
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);
                }

                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Italic);
                }

                else if (i == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold);
                }

            }

            else {

                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Underline);
                }

                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic);
                }

            }
        }

        //METODO QUE DEIXA OU OU RETIRA O TEXTO DE ITALICO//
        public void Italico() {
            string Nome_Fonte = null;
            float Tamanho_Fonte = 0;
            bool n, i, s = false;

            Nome_Fonte = richTextBox1.Font.Name; //ADICIONANDO A FONTE ATUAL A VARIAVEL Nome_Fonte
            Tamanho_Fonte = richTextBox1.Font.Size; //ADICIONANDO O TAMANHO ATUAL DO TEXTO  A VARIAVEL Tamanho_Fonte
            n = richTextBox1.SelectionFont.Bold; // PEGANDO O ESTILO ATUAL DO TEXTO  
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Regular);

            //VERIFICANDO SE O TEXTO JA ESTA EM NEGRITO. SE NÃO PASSANDO O MESMO PARA NEGRITO E SE JA ESTIVER PASSANDO  PARA FONTE REGULAR 
            if (i == false)
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);
                }

                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic | FontStyle.Bold);
                }

                else if (n == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic);
                }

            }

            else
            {

                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Underline);
                }

                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold);
                }

            }

        }

        public void Sobrinhado() {
            string Nome_Fonte = null;
            float Tamanho_Fonte = 0;
            bool n, i, s = false;

            Nome_Fonte = richTextBox1.Font.Name; //ADICIONANDO A FONTE ATUAL A VARIAVEL Nome_Fonte
            Tamanho_Fonte = richTextBox1.Font.Size; //ADICIONANDO O TAMANHO ATUAL DO TEXTO  A VARIAVEL Tamanho_Fonte
            n = richTextBox1.SelectionFont.Bold; // PEGANDO O ESTILO ATUAL DO TEXTO  
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Regular);

            //VERIFICANDO SE O TEXTO JA ESTA EM NEGRITO. SE NÃO PASSANDO O MESMO PARA NEGRITO E SE JA ESTIVER PASSANDO  PARA FONTE REGULAR 
            if (s == false)
            {
                if (i == true & n == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (i == false & n == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold | FontStyle.Underline);
                }

                else if (i == true & n == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic | FontStyle.Underline);
                }

                else if (i == false & n == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Underline);
                }

            }

            else
            {

                if (i == true & n == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic | FontStyle.Bold);

                }
                else if (i == false & n == true)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Bold);
                }

                else if (i == true & n == false)
                {
                    richTextBox1.SelectionFont = new Font(Nome_Fonte, Tamanho_Fonte, FontStyle.Italic);
                }

            }
        }

        public void Alinhar_Esquerda() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        public void Alinhar_Direita() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        public void Centralizar() {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        

        //METODO QUE IRÁ LER O DUCUMENTO E CHAMAR O PrintDialog PARA IMPRIMIR O DOCUMENTO//
        public void Imprimir() {
            printDialog1.Document = printDocument1;
            string text = this.richTextBox1.Text;
            ler = new StringReader(text);

            if (printDialog1.ShowDialog() == DialogResult.OK) {
                this.printDocument1.Print();
            }

        }

       


        private void sALVARCOMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Abrir();
        }

        

        private void btn_novo_Click(object sender, EventArgs e)
        {
            this.Novo();

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            this.Salvar();
        }

        private void aBRIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Salvar();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            this.Abrir();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            this.Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            this.Colar();
        }

        private void cOPIARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Copiar();
        }

        private void cOLARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Colar();
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            this.Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            this.Italico();
        }

        private void btn_sobrinhado_Click(object sender, EventArgs e)
        {
            this.Sobrinhado();
        }

        private void nEGRITOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Negrito();
        }

        private void iTALICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Italico();
        }

        private void sOBRINHADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Sobrinhado();
        }

        private void btn_maiusculo_Click(object sender, EventArgs e)
        {
            
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_diretita_Click(object sender, EventArgs e)
        {
            this.Alinhar_Direita();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            this.Alinhar_Esquerda();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            this.Centralizar();
        }

        private void cENTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Centralizar();
        }

        private void eSQUERDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Alinhar_Esquerda();
        }

        private void dIREITAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Alinhar_Direita();
        }


        //METODO QUE VAI DETERMINAR O ESPAÇAMENTO DA PAGINA A SER EMPRESSA E IMPRIMIR LINHA POR LINHA O DOCUMENTO//
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float posY = 0;
            int cont = 0;

            float margen_esquerda = e.MarginBounds.Left - 50;
            float margen_superior = e.MarginBounds.Top - 50;

            if (margen_esquerda < 5) {
                margen_esquerda = 20;
            }
            if (margen_superior < 5) {
                margen_superior = 20;
            }

            string linha = null;

            Font font = richTextBox1.Font;

            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / font.GetHeight(e.Graphics);
            linha = ler.ReadLine();

            while (cont < linhasPagina){
                posY = (margen_superior + (cont * font.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, font, pincel, margen_esquerda, posY, new StringFormat());
                cont +=  1;

                linha = ler.ReadLine();

            }

            //CASO O TEXTO OCUPE MAIS QUE UMA PAGINA ESTE CONDIÇÕES VAI ATRIBUIR ESSE REQUISITO E E INDICAR QUE O TEXTO SERA IMPRESSO EM OUTRA PAGINA//
            if (linha != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

            pincel.Dispose();
        }

        private void aBRIRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Imprimir();
        }
    }
}
