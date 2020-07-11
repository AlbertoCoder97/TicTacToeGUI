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

        public void GenerateButtons()
        {
            //Create a 3x3 grid of buttons
            Button[,] buttons = new Button[3, 3];

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

            button.Text = "X";
            
        }
    }
}
