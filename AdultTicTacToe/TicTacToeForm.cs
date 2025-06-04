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
        int xPlayerMovesCount = 0;
        int oPlayerMovesCount = 0;
        private TableLayoutPanel table;
        LimitedDictionary<int, int[]> xPlayerDict = new LimitedDictionary<int, int[]>(4);
        LimitedDictionary<int, int[]> oPlayerDict = new LimitedDictionary<int, int[]>(4);

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
                    int[] buttonPositionArray = { i, j };
                    btn.Dock = DockStyle.Fill;
                    btn.Font = new System.Drawing.Font("Arial", 36, System.Drawing.FontStyle.Bold);
                    btn.Click += (sender, e) => Button_Click(sender, e, buttonPositionArray); //delegate
                    buttons[i, j] = btn;
                    table.Controls.Add(btn, j, i);
                }
            }
            ;
            this.Controls.Add(table);
            this.Controls.Add(AddLabels());
        }

        private void Button_Click(object sender, EventArgs e, int[] buttonPosition)
        {
            Button btn = sender as Button;
            if (btn.Text == "")
            {
                btn.Text = currentPlayer.ToString();
                btn.Enabled = false;
                if (currentPlayer == 'X') {
                    xPlayerMovesCount++;
                    btn.BackColor = Color.Red;
                    int xCurrentDictionaryKey = xPlayerMovesCount % 4; // key of dict
                    xPlayerDict.Add(xCurrentDictionaryKey, buttonPosition);
                    ResetButton(xPlayerDict, xPlayerMovesCount, xCurrentDictionaryKey);
                    Console.WriteLine(xCurrentDictionaryKey);
                } else
                {
                    oPlayerMovesCount++;
                    btn.BackColor = Color.DarkTurquoise;
                    int oTurnDiff = xPlayerMovesCount % 4;
                    oPlayerDict.Add(oTurnDiff, buttonPosition);
                    ResetButton(oPlayerDict, oPlayerMovesCount, oTurnDiff);

                }
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
                    if (currentPlayer == 'X')
                    {
                        currentPlayer = 'O';
                    }
                    else
                    {
                        currentPlayer = 'X';
                    }
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
            xPlayerMovesCount = 0;
            oPlayerMovesCount = 0;
            xPlayerDict = new LimitedDictionary<int, int[]>(4);
            oPlayerDict = new LimitedDictionary<int, int[]>(4);
        }
        private void UpdateScoreLabels()
        {
            labelScorePlayerX.Text = "Player X Score: " + xPlayerScore.ToString();
            labelScorePlayerO.Text = "Player O Score: " + oPlayerScore.ToString();
        }

        private FlowLayoutPanel AddLabels()
        {
            // add labels for scoring
            FlowLayoutPanel labelPanel = new FlowLayoutPanel();
            labelPanel.Dock = DockStyle.Top;
            labelPanel.Height = 50;
            labelPanel.Padding = new Padding(10);
            labelPanel.Controls.Add(labelScorePlayerX);
            labelPanel.Controls.Add(labelScorePlayerO);
            return labelPanel;
        }

        private void ResetButton(LimitedDictionary<int, int[]> playerDictionary, int playerMovesCount, int currentDictionaryKey)
        {

            if (playerMovesCount >= 4)
            {
                if (currentDictionaryKey >= 3)
                {
                    currentDictionaryKey = currentDictionaryKey + 1 > 3 ? -1 : 0; // loops over to next key in dictionary 
                }
                var buttonDictionaryHolder = buttons[playerDictionary[currentDictionaryKey+1][0], playerDictionary[currentDictionaryKey+1][1]]; //grabs next in dictionary by looping over

                buttonDictionaryHolder.Enabled = true;
                buttonDictionaryHolder.Text = "";
                buttonDictionaryHolder.Enabled = true;
                buttonDictionaryHolder.BackColor = Color.White;
            }
        }

    }
}
