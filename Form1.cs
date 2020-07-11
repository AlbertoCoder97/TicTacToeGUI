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

        string currentPlayer = "X";
        public static Button[,] buttons = new Button[3, 3];
        static string winner = "0";
        static int moveCounter = 0;

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

            button.Text = currentPlayer;
            if (currentPlayer == "X")
                currentPlayer = "O";
            else
                currentPlayer = "X";

            checkWinner();
            moveCounter += 1;
            
        }

        //Method to call when checking the winner
        public static void checkWinner()
        {
            //Let's check all the vertical lines
            for(int j = 0; j < 3; j++)
            {
                if (buttons[0, j].Text == buttons[1, j].Text && buttons[1, j].Text == buttons[2, j].Text)
                    winner = buttons[0, j].Text;
            }

            //Let's check all horizontal lines
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text)
                    winner = buttons[i, 0].Text;
            }

            //Let's check diagonal from 0,0 to 2,2
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text)
                winner = buttons[0, 0].Text;

            //Let's check diagonal from 0,2 to 2,0
            if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text)
                winner = buttons[0, 2].Text;

            //Let's send the message box
            if (winner == "X")
                MessageBox.Show("Player 1 Wins!");
            if(winner == "O")
                MessageBox.Show("Player 2 Wins!");
            //Match ends in a draw
            if (winner == "0" && moveCounter == 9)
                MessageBox.Show("Draw!");

        }
    }
}
