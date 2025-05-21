using System;
using System.Windows.Forms;

namespace AdultTicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private char currentPlayer = 'X';
        private Button[,] buttons = new Button[3, 3];
        int xPlayerScore = 0;
        int oPlayerScore = 0;

        public TicTacToeForm()
        {
            InitializeComponent();
            CreateBoard();
            UpdateScoreLabels();
        }

        private void CreateBoard()
        {
            int size = 100;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Font = new System.Drawing.Font("Arial", 24);
                    btn.Width = size;
                    btn.Height = size;
                    btn.Left = j * size;
                    btn.Top = i * size;
                    btn.Click += new EventHandler(Button_Click);
                    buttons[i, j] = btn;
                    Controls.Add(btn);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
            {
                btn.Text = currentPlayer.ToString();
                btn.Enabled = false;

                if (CheckWinner())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    if (currentPlayer == 'X')
                    {
                        xPlayerScore += 1;
                    }
                    else
                    {
                        oPlayerScore += 1;
                    }
                    UpdateScoreLabels();
                    ResetBoard();
                }
                else if (IsDraw())
                {
                    MessageBox.Show("It's a draw!");
                    ResetBoard();
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        private bool CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                // Rows
                if (buttons[i, 0].Text == currentPlayer.ToString() &&
                    buttons[i, 1].Text == currentPlayer.ToString() &&
                    buttons[i, 2].Text == currentPlayer.ToString())
                    return true;

                // Columns
                if (buttons[0, i].Text == currentPlayer.ToString() &&
                    buttons[1, i].Text == currentPlayer.ToString() &&
                    buttons[2, i].Text == currentPlayer.ToString())
                    return true;
            }

            // Diagonals
            if (buttons[0, 0].Text == currentPlayer.ToString() &&
                buttons[1, 1].Text == currentPlayer.ToString() &&
                buttons[2, 2].Text == currentPlayer.ToString())
                return true;

            if (buttons[0, 2].Text == currentPlayer.ToString() &&
                buttons[1, 1].Text == currentPlayer.ToString() &&
                buttons[2, 0].Text == currentPlayer.ToString())
                return true;

            return false;
        }

        private bool IsDraw()
        {
            foreach (Button btn in buttons)
            {
                if (btn.Text == "")
                    return false;
            }
            return true;
        }

        private void ResetBoard()
        {
            foreach (Button btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            currentPlayer = 'X';
        }
        private void UpdateScoreLabels()
        {
            labelScorePlayerX.Text = "Player X Score: " + xPlayerScore.ToString();
            labelScorePlayerO.Text = "Player O Score: " + oPlayerScore.ToString();
        }
    }
}
