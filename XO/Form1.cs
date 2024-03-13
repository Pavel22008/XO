using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        int XCount = 0;
        int OCount = 0;
        Button[,] field;
        string player = "X";
        bool freespace = true;
        string Bot = "O";
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateField()
        {
            field = new Button[3, 3];

            field[0, 0] = button1;
            field[0, 1] = button2;
            field[0, 2] = button3;

            field[1,0] = button6;
            field[1,1] = button5;
            field[1,2] = button4;

            field[2,0] = button9;
            field[2,1] = button8;
            field[2,2] = button7;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    field[i, j].Text = "";
                    field[i, j].Enabled = true;
                    field[i, j].Visible = true;
                }
            }
        }
        public bool Win()
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i,0].Text == field[i,1].Text && field[i,1].Text == field[i,2].Text && field[i,0].Text != "")
                {
                    return true;
                }
                
                
            }
            for (int i = 0; i < 3; i++)
            {
             if (field[0, i].Text == field[1, i].Text && field[1, i].Text == field[2, i].Text && field[0, i].Text != "")
             {
                return true;
             }


            }
            if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text == field[2, 2].Text && field[0, 0].Text != "")
            {
                return true;
            }
            if (field[2, 0].Text == field[1, 1].Text && field[1, 1].Text == field[0, 2].Text && field[2, 0].Text != "")
            {
                return true;
            }
            return false;

        }
       private void BotTurn()
       {
            Random r = new Random();
            int corner = 0;
            int udlr = 0;
            while(true)
            {
                corner = r.Next(0, 4);
                udlr = r.Next(0, 4);

                if (field[1, 1].Text == "")
                {
                    field[1, 1].Text = "O";
                    break;
                }
                else if (corner == 0)
                {
                    if (field[0, 0].Text == "")
                    {
                        field[0, 0].Text = "O";
                        break;
                    }
                }

                else if (corner == 1)
                {
                    if (field[0, 2].Text == "")
                    {
                        field[0, 2].Text = "O";
                        break;
                    }
                }

                else if (corner == 2)
                {
                    if (field[2, 0].Text == "")
                    {
                        field[2, 0].Text = "O";
                        break;
                    }
                }

                else if (corner == 3)
                {
                    if (field[2, 2].Text == "")
                    {       
                        field[2, 2].Text = "O";
                        break;
                    }
                }

                if (udlr == 0)
                {
                    if (field[0, 1].Text == "")
                    {
                        field[0, 1].Text = "O";
                        break;
                    }
                }
                if (udlr == 1)
                {
                    if (field[1, 2].Text == "")
                    {
                        field[1, 2].Text = "O";
                        break;
                    }
                }
                if (udlr == 2)
                {
                    if (field[1, 0].Text == "")
                    {
                        field[1, 0].Text = "O";
                        break;
                    }
                }
                if (udlr == 3)
                {
                    if (field[2, 1].Text == "")
                    {
                        field[2, 1].Text = "O";
                        break;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0].Text == field[i, 1].Text && field[i, 1].Text == field[i, 2].Text && field[i, 0].Text != "")
                {
                    player = "O";
                }


            }
            for (int i = 0; i < 3; i++)
            {
                if (field[0, i].Text == field[1, i].Text && field[1, i].Text == field[2, i].Text && field[0, i].Text != "")
                {
                    player = "O";
                }


            }
            if (field[0, 0].Text == field[1, 1].Text && field[1, 1].Text == field[2, 2].Text && field[0, 0].Text != "")
            {
                player = "O";
            }
            if (field[2, 0].Text == field[1, 1].Text && field[1, 1].Text == field[0, 2].Text && field[2, 0].Text != "")
            {
                player = "O";
            }
            if (Win())
            {
                if (player == "X")
                {
                    XCount++;
                    label1.Text = $"Победы Игрока:{XCount}";
                    MessageBox.Show($"Выйграл {player}");
                    freespace = false;
                }
                else if (player == "O")
                {
                    OCount++;
                    label2.Text = $"Победы Бота:{OCount}";
                    MessageBox.Show($"Выйграл {player}");
                    freespace = false;

                }
            }
            if (FreeSpace() == false)
            {
                MessageBox.Show("Ничья");
                CreateField();
            }
        }

        private bool FreeSpace()
        {
            if (field[0,0].Text == field[0,1].Text && field[0,1] == field[0,2] && field[1, 0].Text == field[1, 1].Text && field[1, 1] == field[1, 2] && field[2, 0].Text == field[2, 1].Text && field[2, 1].Text == field[2, 2].Text)
            {
                return true;
            }
            return true;
        }
        private void FieldElemClick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (((Button)sender).Equals(field[i, j]))
                    {
                        if (field[i, j].Text == "")
                        {
                            field[i, j].Text = player;
                        }
                        if (Win())
                        {
                            if (player == "X")
                            {
                                XCount++;
                                label1.Text = $"Победы Игрока:{XCount}";
                                MessageBox.Show($"Выйграл {player}");
                                freespace = false;
                            }
                            else if (player == "O")
                            {
                                OCount++;
                                label2.Text = $"Победы Бота:{OCount}";
                                MessageBox.Show($"Выйграл {player}");
                                freespace = false;

                            }
                        }


                        if (player == "X")
                        {
                            if (freespace == true)
                            {
                                BotTurn();
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            player = Bot;
                        }
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CreateField();
            button10.Visible = false;
            новаяИграToolStripMenuItem.Enabled = true;
            player = "X";

        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateField();
            player = "X";
            freespace = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
