using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstComeFirstServed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(burestTB1.Text == "" || burestTB2.Text == "" 
                || burestTB3.Text == "" || burestTB4.Text == "" 
                || burestTB1.Text == "" || burestTB2.Text == "" 
                || burestTB3.Text == "" || burestTB4.Text == "")
            {
                MessageBox.Show("Please enter values first", "FCFS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // burset time for each process
                int[] burest = new int[] {Convert.ToInt32(burestTB1.Text),
            Convert.ToInt32(burestTB2.Text),
            Convert.ToInt32(burestTB3.Text),
            Convert.ToInt32(burestTB4.Text)};

                // waiting time dor each process
                int[] wait = new int[] {0,
                burest[0] ,
                burest[1] + burest[0],
                burest[0] + burest[1] + burest[2]
            };

                // show waiting time 

                waitingTB1.Text = Convert.ToString(wait[0]);
                waitingTB2.Text = Convert.ToString(wait[1]);
                waitingTB3.Text = Convert.ToString(wait[2]);
                waitingTB4.Text = Convert.ToString(wait[3]);

                // grantt chart process names
                pLbl1.Text = processTB1.Text;
                pLbl2.Text = processTB2.Text;
                pLbl3.Text = processTB3.Text;
                pLbl4.Text = processTB4.Text;

                // grant chart time for each process

                // process 1
                timeLbl1.Text = "0";
                timeLbl2.Text = Convert.ToString(burest[0]);
                // process 2
                timeLbl3.Text = Convert.ToString(burest[0]);
                timeLbl4.Text = Convert.ToString(burest[1] + burest[0]);
                // process 3
                timeLbl5.Text = Convert.ToString(burest[1] + burest[0]);
                timeLbl6.Text = Convert.ToString(burest[0] + burest[1] + burest[2]);
                // process 4
                timeLbl7.Text = Convert.ToString(burest[0] + burest[1] + burest[2]);
                timeLbl8.Text = Convert.ToString(burest[0] + burest[1] + burest[2] + burest[3]);

                // average waiting time 
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                int awt = wait[0] + wait[1] + wait[2] + wait[3];
                divlbl.Text = Convert.ToString("/ " + wait.Length);
                valuelbl.Text = Convert.ToString("= " + awt / wait.Length);
                divlbl.Visible = true;
                valuelbl.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter the process by order", "FCFS");
        }

        private void waitingTB1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void burestTB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
