using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntenseWork
{
    public partial class Form1 : Form
    {
        private string a;
        private bool stop;
        private Task t;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            date();

            //t = Task.Run(()=>ParallelStart());
            startComb();
            
        }

        public void ParallelStart()
        {
            Parallel.For(0, 10, new ParallelOptions {MaxDegreeOfParallelism = 3}, x => start());
        }

        public void date()
        {
            txbStart.Text = DateTime.Now.ToString("G");

        }

        public void start()
        {
            for (int i = 0; i < 10; i--)
            {

                a = a + "x";
                if (stop)
                {
                    break;
                }
            }
        }

        public void startComb()
        {
            StreamWriter sw = new StreamWriter("kombinacije1.txt",true);
            List<string> combination = new List<string>();
            string[] comb = {"Matej", "Grega", "Matjaž", "Irena", "Martin", "Ivan", "Gašper", "Primož","Petra","Franci","Sebastjan", "Marjeta"};
            foreach (var prvi in comb)
            {
                foreach (var drugi in comb)
                {
                    if (prvi != drugi)
                    {
                        sw.WriteLine(prvi+"/"+drugi);
                        
                    }
                }
            }
            sw.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbxEnd.Text = DateTime.Now.ToString("G");
            stop = true;
        }
    }
}
