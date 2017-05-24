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
        /*public static List<Control> FilterControls(Control root) {
            if (root == null)
                return null;
            List<Control> controls = new List<Control>();
            Stack<Control> stack = new Stack<Control>();

            stack.Push(root);
            controls.Add(root);

            while (stack.Any()) {
                var next = stack.Pop();
                //controls.Add(next);
                foreach (Control c1 in next.Controls)
                    stack.Push(c1);
            }

            

            return controls;
            
        }*/

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

        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(253, 247, 237);
            this.lbTitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.lbSubtitle.ForeColor = Color.FromArgb(118, 114, 103);
            this.btnNewGame.ForeColor = Color.White;
            this.btnNewGame.BackColor = Color.FromArgb(118, 114, 103);
            panel1.BackColor = Color.FromArgb(118, 114, 103);
            label01.BackColor = Color.FromArgb(205, 193, 179);

            label00.Text = this.Controls.Count.ToString();
            label01.Text = this.Controls.ToString();

            List<Control> controls = new List<Control>();

            foreach (Control c in this.Controls) {
                controls.AddRange(GetAllControls(c));
            }

            foreach (Control c in controls) { 
                if (c.Name.StartsWith("label"))
                    c.BackColor = Color.FromArgb(205, 193, 179);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
