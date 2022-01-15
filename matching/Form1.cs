using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matching
{

    public partial class Form1 : Form
    {

        Random random = new Random();

        List<string> list = new List<string>()
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };
        Label firstClicked=null, lastClicked=null;
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSqures();
        }

        private void AssignIconsToSqures()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel=control as Label;
                if (iconLabel != null)
                {
                    int randomNumber=random.Next(list.Count);
                    iconLabel.Text=list[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    list.RemoveAt(randomNumber);
                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
            Label labelClicked=sender as Label;
            if(labelClicked != null)
            {
                if (labelClicked.ForeColor == labelClicked.BackColor)
                {

                    if (firstClicked == null)
                    {
                        firstClicked = labelClicked;
                        firstClicked.ForeColor = Color.Red;
                        return;
                    }
                    lastClicked = labelClicked;
                    lastClicked.ForeColor = Color.Red;

                    checkForWinner();
                    if (firstClicked.Text == lastClicked.Text){
                        firstClicked=null;
                        lastClicked=null;
                        return;
                    }
                    timer1.Start();
                }
                   
            }
        }

        void checkForWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label label = control as Label;
                if(label != null)
                    if (label.ForeColor == label.BackColor)
                        return;

            }
            MessageBox.Show("you matched all the icons,Congratulations!");
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
            firstClicked.ForeColor = firstClicked.BackColor;
            lastClicked.ForeColor = lastClicked.BackColor;
            firstClicked=null;
            lastClicked=null;

        }
    }
}
