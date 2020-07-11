using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GenerateButtons();
        }

        public static string currentPlayer = "X";
        public static Button[,] buttons = new Button[3, 3];
        public static string winner = "0";
        public static int moveCounter = 0;

        public void GenerateButtons()
        {
            //Create a 3x3 grid of buttons
            

            //Let's position the buttons
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    buttons[i,j] = new Button();
                    //Size is the Object to create a Size and buttons[i,j] will have that size
                    buttons[i, j].Size = new Size(100,100);
                    //This allows us to define from which point the button gets drawn
                    buttons[i, j].Location = new Point(i * 100, j * 100);
                    //This will make our buttons look like a pane but in truth they are buttons.
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].TextAlign = ContentAlignment.MiddleCenter;

                    //Let's choose a Font to make it look nice
                    buttons[i, j].Font = new System.Drawing.Font(DefaultFont.FontFamily, 80, FontStyle.Bold);

                    //Before adding the buttons to the panel now we gotta assign the method button_Click to the button event.
                    //To add event handlers use +=
                    buttons[i, j].Click += new EventHandler(button_Click);

                    //This allows us to add the buttons to the Window
                    panel1.Controls.Add(buttons[i,j]);

                }
            }
        }

        //This method allows us to control what happens when a button is clicked.
        void button_Click(object sender, EventArgs e)
        {
            //Let's convert sender in button
            Button button = sender as Button;

            if (button.Text != "")
                return;
            button.Text = currentPlayer;
            if (currentPlayer == "X")
                currentPlayer = "O";
            else
                currentPlayer = "X";

            moveCounter += 1;
            //There's no need to check for the winner if not at least 5 moves were done.
            if (moveCounter >= 5)
                checkWinner();
            
            
        }

        //Method to call when checking the winner
        public static void checkWinner()
        {
            
            //Let's scroll Vertically
            for(int i = 0; i < 3; i++)
            { 
                if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text)
                {
                    winner = buttons[i, 0].Text;
                    break;
                } 
            }

            //Let's scroll Horizontally
            for (int j = 0; j < 3; j++)
            {
                if (buttons[0, j].Text == buttons[1, j].Text && buttons[1, j].Text == buttons[2, j].Text)
                {
                    winner = buttons[0, j].Text;
                    break;
                }
            }

            //Diagonal Check
            if (buttons[0,0].Text.Equals(buttons[1,1].Text) && buttons[1,1].Text.Equals(buttons[2,2].Text))
            {
                winner = buttons[0, 0].Text;
            }

            //Other diagonal Check
            if (buttons[0, 2].Text.Equals(buttons[1, 1].Text) && buttons[1, 1].Text.Equals(buttons[2, 0].Text))
            {
                winner = buttons[0, 2].Text;
            }

            if(winner == "X")
            {
                MessageBox.Show("The winner is Player 1");
                GameReset();
                return;
            }

            if (winner == "O")
            {
                MessageBox.Show("The winner is Player 2");
                GameReset();
                return;
            }

            if (moveCounter > 8 && winner == "0")
            {
                MessageBox.Show("The match ended in a draw!");
                GameReset();
                return;
            }
        }

        public static void GameReset()
        {
            MessageBox.Show("Game has been reset! It's Player1's turn!");
            currentPlayer = "X";
            winner = "0";
            moveCounter = 0;
            foreach (Button btn in buttons)
            {
                btn.Text = "";
            }
    }
    }
}
