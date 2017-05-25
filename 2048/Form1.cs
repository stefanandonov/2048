using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public int[][] matrix { set; get; }
        public bool[][] filled { set; get; }
        public List<Control> controls = new List<Control>();

        

        

        public Form1()
        {
            InitializeComponent();
            matrix = new int [4][];
            filled = new bool[4][];
            


            for (int i=0;i<4;i++){
                matrix[i]=new int [4];
                filled[i]=new bool[4];

                for (int j=0;j<4;j++){
                    matrix[i][j] = 0;
                    filled[i][j] = false;
                }
                    
            }
            this.BackColor = Color.FromArgb(253, 247, 237);
            this.lbTitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.lbSubtitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.btnNewGame.ForeColor = Color.White;
            this.btnNewGame.BackColor = Color.FromArgb(118, 114, 103);
            panel1.BackColor = Color.FromArgb(118, 114, 103);
            label01.BackColor = Color.FromArgb(205, 193, 179);

            //label00.Text = this.Controls.Count.ToString();
            //label01.Text = this.Controls.ToString();
            //label01.Text = matrix[0][1].ToString();

            List<Control> controls = new List<Control>();

            foreach (Control c in this.Controls) {
                controls.AddRange(GetAllControls(c));
                
            }

           

            foreach (Control c in controls) { 
                if (c.Name.StartsWith("label"))
                    c.BackColor = Color.FromArgb(205, 193, 179);
            }

            generateStart();
            showNumbers();
            
            
        }

        public static IEnumerable<Control> GetAllControls(Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);

                yield return next;
            }
        }

        private void generateStart() { //funkcija koja generira 2 broja (2 ili 4) na 2 razlicni pozicii
            Random rdm = new Random();
            int i = 0;
            while (i < 2) {
                int x = rdm.Next(0, 4);
                int y = rdm.Next(0, 4);
                while (filled[x][y] == true) {
                    x = rdm.Next(0, 4);
                    y = rdm.Next(0, 4);
                }
                int nmbr=rdm.Next(2,5);
                while (nmbr == 3) {
                    nmbr = rdm.Next(2, 5);
                }
                matrix[x][y] = nmbr;
                filled[x][y] = true;
                ++i;
            }          
            
        }

        private void showNumbers() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    if (matrix[i][j] != 0) {
                        showNumber(i, j);
                    }
                }
            }
        }

        private void showNumber(int i, int j) {
            if (i == 0) { 
                if (j==0) 
                    label00.Text = matrix[i][j].ToString();
                else if (j == 1)
                    label01.Text = matrix[i][j].ToString();
                else if (j == 2)
                    label02.Text = matrix[i][j].ToString();
                else if (j == 3)
                    label03.Text = matrix[i][j].ToString();
            }
            else if (i == 1) {
                if (j == 0)
                    label10.Text = matrix[i][j].ToString();
                else if (j == 1)
                    label11.Text = matrix[i][j].ToString();
                else if (j == 2)
                    label12.Text = matrix[i][j].ToString();
                else if (j == 3)
                    label13.Text = matrix[i][j].ToString();
            }
            else if (i == 2) {
                if (j == 0)
                    label20.Text = matrix[i][j].ToString();
                else if (j == 1)
                    label21.Text = matrix[i][j].ToString();
                else if (j == 2)
                    label22.Text = matrix[i][j].ToString();
                else if (j == 3)
                    label23.Text = matrix[i][j].ToString();
            }
            else if (i == 3) {
                if (j == 0)
                    label30.Text = matrix[i][j].ToString();
                else if (j == 1)
                    label31.Text = matrix[i][j].ToString();
                else if (j == 2)
                    label32.Text = matrix[i][j].ToString();
                else if (j == 3)
                    label33.Text = matrix[i][j].ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
