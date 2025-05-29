using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdultTicTacToe
{
    public partial class TicTacToeForm : Form
    {
        private char currentPlayer = 'X';
        private Button[,] buttons = new Button[3, 3];
        int xPlayerScore = 0;
        int oPlayerScore = 0;
        private TableLayoutPanel table;

        public TicTacToeForm()
        {
            InitializeComponent();
            CreateBoard();
            UpdateScoreLabels();
        }

        private void CreateBoard()
        {
            //prevent collapse
            this.MinimumSize = new System.Drawing.Size(350, 450);
            this.Text = "Tic Tac Toe";

            //initialise table
            table = new TableLayoutPanel();
            table.RowCount = 3;
            table.ColumnCount = 3;
            table.Dock = DockStyle.Fill;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            
            //add buttons using 2 dimensional array
            for (int i = 0; i < 3; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Font = new System.Drawing.Font("Arial", 36, System.Drawing.FontStyle.Bold);
                    btn.Click += Button_Click;
                    buttons[i, j] = btn;
                    table.Controls.Add(btn, j, i);
                }
            }

            // add labels for scoring
            FlowLayoutPanel labelPanel = new FlowLayoutPanel();
            labelPanel.Dock = DockStyle.Top;
            labelPanel.Height = 50;
            labelPanel.Padding = new Padding(10);
            labelPanel.Controls.Add(labelScorePlayerX);
            labelPanel.Controls.Add(labelScorePlayerO);

            this.Controls.Add(table);
            this.Controls.Add(labelPanel);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
            {
                btn.Text = currentPlayer.ToString();
                btn.Enabled = false;
                btn.BackColor = currentPlayer == 'X' ?  Color.Red : Color.DarkTurquoise;

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
                    currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
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
                btn.BackColor = Color.White;
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
