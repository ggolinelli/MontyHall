//Monty Hall Problem Simulator
//Author: Gianluca Golinelli

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MontyHall
{
    public partial class Form1 : Form
    {
        int giocate;
        int vincite;
        int iterazioni;
        public Form1()
        {
            InitializeComponent();
            giocate = 0;
            vincite = 0;
            iterazioni = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1=capra1; 2=capra2; 3=auto
            int porta1 = 0;
            int porta2 = 0;
            int porta3 = 0;
            string str1="", str2="", str3 = "";
            int num = 0, scelta=0, proposta = 0, cambio=0;


            if (radioButton3.Checked == true)
            {
                iterazioni = trackBar1.Value;
                giocate = 0;
                vincite = 0;
                listBox1.Items.Clear();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;
            }
            else
            {
                iterazioni = 1;
            }

            Random rnd = new Random();

            for (int i=iterazioni; i>0; i--)
            {

                giocate++;
                textBox6.Text = giocate.ToString();

                textBox2.BackColor = Color.White;
                textBox3.BackColor = Color.White;
                textBox4.BackColor = Color.White;


                porta1 = rnd.Next(1, 4);  // creates a number between 1 and 3
                while (true)
                {
                    num = rnd.Next(1, 4);
                    if (num != porta1)
                    {
                        porta2 = num;
                        break;
                    }
                }
                while (true)
                {
                    num = rnd.Next(1, 4);
                    if (num != porta1 && num != porta2)
                    {
                        porta3 = num;
                        break;
                    }
                }

                switch (porta1)
                {
                    case 1:
                        str1 = "Goat1";
                        break;
                    case 2:
                        str1 = "Goat2";
                        break;
                    case 3:
                        str1 = "Car";
                        break;
                }

                switch (porta2)
                {
                    case 1:
                        str2 = "Goat1";
                        break;
                    case 2:
                        str2 = "Goat2";
                        break;
                    case 3:
                        str2 = "Car";
                        break;
                }

                switch (porta3)
                {
                    case 1:
                        str3 = "Goat1";
                        break;
                    case 2:
                        str3 = "Goat2";
                        break;
                    case 3:
                        str3 = "Car";
                        break;
                }

                textBox2.Text = str1;
                textBox3.Text = str2;
                textBox4.Text = str3;

                //scelta giocatore
                scelta = rnd.Next(1, 4);
                if (scelta == 1)
                {
                    textBox5.Text = "Door1";
                }
                else if (scelta == 2)
                {
                    textBox5.Text = "Door2";
                }
                else if (scelta == 3)
                {
                    textBox5.Text = "Door3";
                }

                //apertura porta da parte del conduttore
                while (true)
                {
                    proposta = rnd.Next(1, 4);
                    if (proposta != scelta)
                    {
                        if (proposta == 1)
                        {
                            if (textBox2.Text != "Car")
                            {
                                textBox2.BackColor = Color.Yellow;
                                if (scelta == 2)
                                {
                                    cambio = 3;
                                }
                                else
                                {
                                    cambio = 2;
                                }
                                break;
                            }
                        }
                        else if (proposta == 2)
                        {
                            if (textBox3.Text != "Car")
                            {
                                textBox3.BackColor = Color.Yellow;
                                if (scelta == 1)
                                {
                                    cambio = 3;
                                }
                                else
                                {
                                    cambio = 1;
                                }
                                break;
                            }
                        }
                        else if (proposta == 3)
                        {
                            if (textBox4.Text != "Car")
                            {
                                textBox4.BackColor = Color.Yellow;
                                if (scelta == 2)
                                {
                                    cambio = 1;
                                }
                                else
                                {
                                    cambio = 2;
                                }
                                break;
                            }
                        }
                    }
                }

                if (radioButton1.Checked == true) //cambio
                {
                    if (cambio == 1)
                    {
                        if (textBox2.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }
                    else if (cambio == 2)
                    {
                        if (textBox3.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }
                    else if (cambio == 3)
                    {
                        if (textBox4.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }
                }
                else //non cambio
                {
                    if (scelta == 1)
                    {
                        if (textBox2.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }
                    else if (scelta == 2)
                    {
                        if (textBox3.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }
                    else if (scelta == 3)
                    {
                        if (textBox4.Text == "Car")
                        {
                            listBox1.Items.Add(giocate + " You won");
                            vincite++;
                        }
                        else
                        {
                            listBox1.Items.Add(giocate + " You lost");
                        }
                    }

                }

                textBox7.Text = vincite.ToString();
            }

        }

        //non cambio
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            giocate = 0;
            vincite = 0;
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;

        }

        //cambio
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            giocate = 0;
            vincite = 0;
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            giocate = 0;
            vincite = 0;
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            giocate = 0;
            vincite = 0;
            listBox1.Items.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
        }

        private void exitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Gianluca Golinelli");
        }
    }
}
