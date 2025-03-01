using System.CodeDom;
using System.Diagnostics;

namespace Xadrez;

partial class Form1 : Form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private const int TamanhoDaMatriz = 8;
    private Button[,] matriz = new Button[TamanhoDaMatriz, TamanhoDaMatriz];

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(350, 350);
        this.Text = "Xadrez";
        this.AutoSize = true;

        // try{
        //     tb.InicializarTabuleiro(this);
        // }catch(Exception e){
        //     MessageBox.Show($"Erro ao iniciar {e.Message}\n{e.StackTrace}");
        //     Console.WriteLine(e.StackTrace);
        //     // throw new InvalidOperationException("Alguma coisa deu muito errado " + e);
        // }
        //this.Load += new System.EventHandler(this.Form1_Load);
        
        for (int linha = 0; linha < TamanhoDaMatriz; linha++)
        {
            for (int coluna = 0; coluna < TamanhoDaMatriz; coluna++)
            {
                Button b = new Button();
                if ((coluna + linha) % 2 == 0)
                {
                    b.Size = new Size(50, 50);
                    b.Location = new Point(50 * linha, 50 * coluna);
                    b.BackColor = Color.White;
                    matriz[linha, coluna] = b;
                    this.Controls.Add(b);
                }
                else
                {
                    b.Size = new Size(50, 50);
                    b.Location = new Point(50 * linha, 50 * coluna);
                    b.BackColor = Color.Black;
                    matriz[linha, coluna] = b;
                }

                this.Controls.Add(b);
            }
        }
    }
    #endregion
}
