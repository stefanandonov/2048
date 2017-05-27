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
        public int points;
        

        

        public Form1()
        {
            InitializeComponent();
            /*
            * Test primeri za 4 tipa na dvizenja:
            */
            //matrix[1][0] = 4;
            //matrix[1][1] = 2;
            //matrix[1][2] = 2;
            // matrix[1][3] = 128;
            this.BackColor = Color.FromArgb(253, 247, 237);
            this.lbTitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.lbSubtitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.btnNewGame.ForeColor = Color.White;
            this.btnNewGame.BackColor = Color.FromArgb(118, 114, 103);
            panel1.BackColor = Color.FromArgb(118, 114, 103);
            //label01.BackColor = Color.FromArgb(205, 193, 179);
            lbPoints.BackColor = Color.FromArgb(118, 114, 103);
            lbPoints.ForeColor = Color.White;
            lbPoints.Text = points.ToString();

            //label00.Text = this.Controls.Count.ToString();
            //label01.Text = this.Controls.ToString();
            //label01.Text = matrix[0][1].ToString();
            newGame();
            
            
        }
        public void newGame()
        {
            matrix = new int[4][];
            filled = new bool[4][];
            points = 0;

            this.Focus();

            for (int i = 0; i < 4; i++)
            {
                matrix[i] = new int[4];
                filled[i] = new bool[4];

                for (int j = 0; j < 4; j++)
                {
                    matrix[i][j] = 0;
                    filled[i][j] = false;
                }

            }
           

            List<Control> controls = new List<Control>();

            foreach (Control c in this.Controls)
            {
                controls.AddRange(GetAllControls(c));

            }



            foreach (Control c in controls)
            {
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

        private void generateNumberAfterMove() {
            Random rdm = new Random();
            int x = rdm.Next(0, 4);
            int y = rdm.Next(0, 4);
            while (matrix[x][y] != 0) {
                x = rdm.Next(0, 4);
                y = rdm.Next(0, 4); 
            }

            matrix[x][y] = 2;

            showNumbers();
        }

        private void showNumbers() {
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    if (true) {
                        showNumber(i, j);
                    }
                }
            }
        }

        private bool gameOver() {
            bool flag = true;

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    if(matrix[i][j]==0)
                        flag=false;
                    }
                }
            if (flag)
            {
                for (int i = 0; i < 4; i++)
                {                                //proveruva dali postojat mozni potezi
                    for (int j = 2; j >= 0; j--)
                    {
                        if (matrix[i][j] == matrix[i][j + 1])
                        {
                            flag = false;
                          
                        }
                    }
                } 
            }

              
            

            return flag;
        }

        private void updatePoints()
        {
            lbPoints.Text = points.ToString();
        }

        private void showColor(Label lb, int number) {
            switch (number) { 
                case 0:
                    lb.BackColor = Color.FromArgb(205, 193, 179);
                    break;
                case 2:
                    lb.BackColor = Color.FromArgb(250, 248, 239);
                    lb.ForeColor = Color.FromArgb(187, 173, 160);
                    break;
                case 4:
                    lb.BackColor = Color.FromArgb(255,240 ,245 );
                    lb.ForeColor = Color.FromArgb(187, 173, 160);
                    break;
                case 8: 
                    lb.BackColor = Color.FromArgb(242, 177, 121);
                    lb.ForeColor = Color.White;
                    break;
                case 16:
                    lb.BackColor = Color.FromArgb(245, 149, 101);
                    lb.ForeColor = Color.White;
                    break;
                case 32:
                    lb.BackColor = Color.FromArgb(245, 124, 95);
                    lb.ForeColor = Color.White;
                    break;
                case 64:
                    lb.BackColor = Color.FromArgb(246, 93, 59);
                    lb.ForeColor = Color.White;
                    break;
                case 128:
                    lb.BackColor = Color.FromArgb(236, 207, 113);
                    lb.ForeColor = Color.White;
                    lb.Font = new Font("Arial", 22, FontStyle.Bold);
                    break;
                case 256:
                    lb.BackColor = Color.FromArgb(237, 204, 99);
                    lb.ForeColor = Color.White;
                    lb.Font = new Font("Arial", 22, FontStyle.Bold);
                    break;
                case 512:
                    lb.BackColor = Color.FromArgb(237, 204, 99);
                    lb.ForeColor = Color.White;
                    lb.Font = new Font("Arial", 22, FontStyle.Bold);
                    break;
                default:
                    break;
            }
        }

        private void showNumber(int i, int j) {
            int x = matrix[i][j];
            if (i == 0) {
                if (j == 0)
                    if (x != 0)
                    {
                        label00.Text = x.ToString();
                        showColor(label00, x);
                    }
                    else{
                        label00.Text = "";
                        showColor(label00, 0);
                    }
                        
                else if (j == 1)
                    if (x != 0)
                    {
                        label01.Text = x.ToString();
                        showColor(label01, x);
                    }
                    else
                    {
                        label01.Text = "";
                        showColor(label01, 0);
                    }
                else if (j == 2)
                    if (x != 0){
                        label02.Text = x.ToString();
                        showColor(label02,x);}
                    else
                    {
                        label02.Text = "";
                        showColor(label02, 0);
                    }
                else if (j == 3)
                    if (x != 0){
                        label03.Text = x.ToString();
                        showColor(label03,x);}
                    else
                    {
                        label03.Text = "";
                        showColor(label03, 0);
                    }
            }
            else if (i == 1) {
                if (j == 0)
                    if (x != 0)
                    {
                        label10.Text = x.ToString();
                        showColor(label10, x);
                    }
                    else
                    {
                        label10.Text = "";
                        showColor(label10, 0);
                    }
                else if (j == 1)
                    if (x != 0)
                    {
                        showColor(label11, x);
                        label11.Text = x.ToString();
                    }
                    else
                    {
                        label11.Text = "";
                        showColor(label11, 0);
                    }
                else if (j == 2)
                    if (x != 0)
                    {
                        showColor(label12, x);
                        label12.Text = x.ToString();
                    }
                    else
                    {
                        label12.Text = "";
                        showColor(label12, 0);
                    }
                else if (j == 3)
                    if (x != 0)
                    {
                        showColor(label13, x);
                        label13.Text = x.ToString();
                    }
                    else
                    {
                        label12.Text = "";
                        showColor(label12, 0);
                    }
            }
            else if (i == 2) {
                if (j == 0)
                    if (x != 0)
                    {
                        showColor(label20, x);
                        label20.Text = x.ToString();
                    }
                    else
                    {
                        label20.Text = "";
                        showColor(label20, 0);
                    }
                else if (j == 1)
                    if (x != 0)
                    {
                        showColor(label21, x);
                        label21.Text = x.ToString();
                    }
                    else
                    {
                        label21.Text = "";
                        showColor(label21, 0);
                    }
                else if (j == 2)
                    if (x != 0)
                    {
                        showColor(label22, x);
                        label22.Text = x.ToString();
                    }
                    else
                    {
                        label22.Text = "";
                        showColor(label22, 0);
                    }
                else if (j == 3)
                    if (x != 0)
                    {
                        showColor(label23, x);
                        label23.Text = x.ToString();
                    }
                    else
                    {
                        label23.Text = "";
                        showColor(label23, 0);
                    }
            }
            else if (i == 3) {
                if (j == 0)
                    if (x != 0)
                    {
                        showColor(label30, x);
                        label30.Text = x.ToString();
                    }
                    else
                    {
                        label30.Text = "";
                        showColor(label30, 0);
                    }
                else if (j == 1)
                    if (x != 0)
                    {
                        showColor(label31, x);
                        label31.Text = x.ToString();
                    }
                    else
                    {
                        label31.Text = "";
                        showColor(label31, 0);
                    }
                else if (j == 2)
                    if (x != 0)
                    {
                        showColor(label32, x);
                        label32.Text = x.ToString();
                    }
                    else
                    {
                        label32.Text = "";
                        showColor(label32, 0);
                    }
                else if (j == 3)
                    if (x != 0)
                    {
                        showColor(label33, x);
                        label33.Text = x.ToString();
                    }
                    else
                    {
                        label33.Text = "";
                        showColor(label33, 0);
                    }
            }
        }

        private void toRight() {

            if (gameOver()) {
                if (MessageBox.Show("GAME OVER", "Game over", MessageBoxButtons.RetryCancel) == System.Windows.Forms.DialogResult.Retry) {
                    newGame();
                }
            }

            for (int i = 0; i < 4; i++) { //pravi pomestuvanje na site broevi do desnata granica
                for (int j = 2; j >=0 ; j--) {
                    if (matrix[i][j] != 0) {
                        for (int k = j+1; k < 4; k++)
                        {
                            if (matrix[i][k] == 0) { 
                                matrix[i][k]=matrix[i][k-1];
                                matrix[i][k-1]=0;                               
                            }
                        }
                    }
                    
                }
            }

            for (int i = 0; i < 4; i++) { //proveruva za sumi 
                for (int j = 2; j >= 0; j--) {
                    if (matrix[i][j] == matrix[i][j + 1] && matrix[i][j] != 0 && matrix[i][j+1] != 0) {
                        matrix[i][j + 1] += matrix[i][j];
                        points += (2 * matrix[i][j]);
                        matrix[i][j] = 0;
                        for (int k = j; k > 0; k--) {
                            if (matrix[i][k] == 0) {
                                matrix[i][k] = matrix[i][k - 1];
                                matrix[i][k - 1] = 0;
                            }
                        }
                    }
                }
            }
            updatePoints();
            generateNumberAfterMove();   
        }

        private void toLeft() {
            for (int i = 0; i < 4; i++) { //pomestuva se na levo
                for (int j = 1; j < 4; j++) {
                    if (matrix[i][j] != 0) {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (matrix[i][k] == 0)
                            {
                                matrix[i][k] = matrix[i][k + 1];
                                matrix[i][k + 1] = 0;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 4; i++) { //proveruva za sumi
                for (int j = 1; j < 4; j++) {
                    if (matrix[i][j]==matrix[i][j-1] && matrix[i][j-1]!=0 && matrix[i][j]!=0){
                        matrix[i][j-1]+=matrix[i][j];
                        points += (2 * matrix[i][j]);
                        matrix[i][j]=0;
                        for (int k = j; k < 3; k++) {
                            if (matrix[i][k] == 0) {
                                matrix[i][k] = matrix[i][k + 1];
                                matrix[i][k + 1] = 0;
                            }
                        }
                    }

                }
            }


            updatePoints();
            generateNumberAfterMove();  
        }

        private void toUp() {
            for (int j = 0; j < 4; j++) {
                for (int i = 1; i < 4; i++) {
                    if (matrix[i][j] != 0) {
                        for (int k = i - 1; k >= 0; k--) 
                        {
                            if (matrix[k][j] == 0) {
                                matrix[k][j] = matrix[k+1][j];
                                matrix[k+1][j] = 0;
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < 4; j++) {
                for (int i = 1; i < 4; i++) {
                    if (matrix[i][j] == matrix[i - 1][j] && matrix[i][j] != 0) {
                        matrix[i-1][j] += matrix[i][j];
                        points += (2 * matrix[i][j]);
                        matrix[i][j] = 0;
                        for (int k = i; k < 3; k++) {
                            if (matrix[k][j] == 0) {
                                matrix[k][j] = matrix[k + 1][j];
                                matrix[k + 1][j] = 0;
                            }
                        }
                    }
                }
            }
            updatePoints();
            generateNumberAfterMove();
        }

        private void toDown() {
            for (int j = 0; j < 4; j++) {
                for (int i = 2; i >= 0; i--) {
                    if (matrix[i][j] != 0) {
                        for (int k = i + 1; k < 4; k++) {
                            if (matrix[k][j] == 0) {
                                matrix[k][j] = matrix[k-1][j];
                                matrix[k - 1][j] = 0; 
                            }
                            
                        }
                    }
                }
            }

            for (int j = 0; j < 4; j++) {
                for (int i = 2; i >= 0; i--) {
                    if (matrix[i][j] == matrix[i + 1][j] && matrix[i][j] != 0) {
                        matrix[i+1][j] += matrix[i][j];
                        points += (2 * matrix[i][j]);
                        matrix[i][j] = 0;
                        for (int k = i; k > 0; k--) {
                            if (matrix[k][j] == 0) {
                                matrix[k][j] = matrix[k - 1][j];
                                matrix[k - 1][j] = 0;
                            }
                        }
                    }
                }
            }
            updatePoints();
            generateNumberAfterMove(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        protected override bool  ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                toUp();
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                
                toDown();
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                
                toLeft();
                showNumbers();
                return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                //label1.Text = "KEY.RIGHT";
                toRight();
                //showNumbers();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Delete) {
                toRight();
                //label1.Text = "True";
                showNumbers();
            }
                
            
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    toRight();
                    break;
                case Keys.Up:
                    break;
                   
            }

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            newGame();
        }

        

       

        
    }
}
