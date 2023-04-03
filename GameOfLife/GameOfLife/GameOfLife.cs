using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GameOfLife
{
    public partial class GameOfLife : Form
    {
        //Constants
        private const int MIN_GRID_SIZE = 10;
        private const int MAX_GRID_SIZE = 50;
        private const int DEFAULT_GRID_SIZE = 25;

        private const int MIN_SPEED = 1;
        private const int MAX_SPEED = 250;
        private const int DEFAULT_SPEED = 50;

        private const string DEAD_CELL_TAG = "dead";
        private const string ALIVE_CELL_TAG = "alive";
        private readonly Color DEAD_CELL_COLOR = Color.White;
        private readonly Color ALIVE_CELL_COLOR = Color.Black;

        //Variables
        private int gridSize = DEFAULT_GRID_SIZE;
        private bool isGameRunning = false;

        private int nbGenerations = 0;
        private int nbCellsAlive = 0;
        private int nbCellsDead = 0;

        private Label[,] grid;
        private Stack<List<Label>> lastsGenerations = new Stack<List<Label>>();
        private Timer generationsTimer = new Timer();


        public GameOfLife()
        {
            InitializeComponent();

            //Confugure the taskbar for speed
            tbSpeed.Minimum = MIN_SPEED;
            tbSpeed.Maximum = MAX_SPEED;
            tbSpeed.Value = DEFAULT_SPEED;
            DisplaySpeed();

            //Configure the input for the grid size
            numSize.Minimum = MIN_GRID_SIZE;
            numSize.Maximum = MAX_GRID_SIZE;
            numSize.Value = DEFAULT_GRID_SIZE;
            DisplayGridSize();
        }

        private void Init()
        {
            panContainer.Visible = false;
            panContainer.SuspendLayout();

            //Get the grid size
            gridSize = (int)numSize.Value;

            pbGridGeneration.Minimum = 1;
            pbGridGeneration.Maximum = gridSize * gridSize;
            pbGridGeneration.Value = 1;
            pbGridGeneration.Step = 1;

            //Clear the pannel
            panContainer.Controls.Clear();

            //Init the grid
            grid = new Label[gridSize, gridSize];

            //Generate the cells
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    //Create the cell
                    Label cell = new Label();

                    //Set the size
                    cell.Size = new Size(panContainer.Width / gridSize, panContainer.Height / gridSize);

                    //Set the location
                    cell.Location = new Point(x * cell.Width, y * cell.Height);

                    //Set the color
                    cell.BackColor = DEAD_CELL_COLOR;

                    //Set the border
                    cell.BorderStyle = BorderStyle.FixedSingle;

                    //Set the index
                    cell.TabStop = false;

                    //Set the tag
                    cell.Tag = DEAD_CELL_TAG;

                    //Handle the click event
                    cell.Click += new EventHandler(CellChangeState);

                    //Add the cell to the container panel
                    panContainer.Controls.Add(cell);

                    //Add the cell in the grid array
                    grid[y, x] = cell;

                    //Dispaly the step on the progress bar
                    pbGridGeneration.PerformStep();
                }
            }

            //Display the stats
            nbGenerations = 0;
            nbCellsAlive = 0;
            nbCellsDead = gridSize * gridSize;
            DisplayStats();

            panContainer.ResumeLayout();
            panContainer.Visible = true;
        }

        private void CellChangeState(object sender, EventArgs e)
        {
            //Get the cell that cause the event
            Label cell = (Label)sender;

            //If the cell is dead
            if((string)cell.Tag == DEAD_CELL_TAG)
            {
                //Set the cell to alive
                cell.Tag = ALIVE_CELL_TAG;
                cell.BackColor = ALIVE_CELL_COLOR;
            }
            //If the cell is alive
            else if ((string)cell.Tag == ALIVE_CELL_TAG)
            {
                //Set the cell to dead
                cell.Tag = DEAD_CELL_TAG;
                cell.BackColor = DEAD_CELL_COLOR;
            }
        }

        private void Generation()
        {
            //Set the number of alive and dead cell to 0 
            nbCellsAlive = 0;
            nbCellsDead = 0;

            //Array with if the cells are alives
            bool[,] gridIsAlive = new bool[gridSize, gridSize];

            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    //Get the number of neighbors
                    int nbNeighbours = GetNumOfNeighbours(x, y);

                    //Any live cell with two or three live neighbours survives
                    if ((string)grid[y, x].Tag == ALIVE_CELL_TAG && (nbNeighbours == 2 || nbNeighbours == 3))
                    {
                        gridIsAlive[y, x] = true;
                    }
                    //Any dead cell with three live neighbours becomes a live cell.
                    else if ((string)grid[y, x].Tag == DEAD_CELL_TAG && nbNeighbours == 3)
                    {
                        gridIsAlive[y, x] = true;
                    }
                    //All other live cells die in the next generation. Similarly, all other dead cells stay dead.
                    else
                    {
                        gridIsAlive[y, x] = false;
                    }
                }
            }


            for (int y = 0; y < gridIsAlive.GetLength(0); y++)
            {
                for (int x = 0; x < gridIsAlive.GetLength(1); x++)
                {
                    //If the cell is alive
                    if (gridIsAlive[y, x])
                    {
                        grid[y, x].Tag = ALIVE_CELL_TAG;
                        grid[y, x].BackColor = ALIVE_CELL_COLOR;
                        nbCellsAlive++;
                    }
                    //If the cell is dead
                    else
                    {
                        grid[y, x].Tag = DEAD_CELL_TAG;
                        grid[y, x].BackColor = DEAD_CELL_COLOR;
                        nbCellsDead++;
                    }
                }
            }


            //Dispaly the stats
            nbGenerations++;
            DisplayStats();
        }

        private List<Label> GetCellsAlives()
        {
            //List with all alives cells
            List<Label> cells = new List<Label>();

            //Browse all the cells
            foreach(Label lbl in panContainer.Controls)
            {
                //If the cell is alive
                if((string)lbl.Tag == ALIVE_CELL_TAG)
                {
                    cells.Add(lbl);
                }
            }

            return cells;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private int GetNumOfNeighbours(int posX, int posY)
        {
            int nbNeighbours = 0;
            int[,] possibleCoords = new int[,] { {-1, -1 }, {0, -1 }, {1, -1 }, {-1, 0 }, {1, 0 }, {-1, 1 }, {0, 1 }, {1, 1 }};

            for (int i = 0; i < possibleCoords.GetLength(0); i++)
            {
                if(posX + possibleCoords[i,0] >= 0 && posX + possibleCoords[i, 0] < gridSize && posY + possibleCoords[i, 1] >= 0 && posY + possibleCoords[i, 1] < gridSize)
                {
                    if ((string)grid[posY + possibleCoords[i, 1], posX + possibleCoords[i, 0]].Tag == "alive")
                    {
                        nbNeighbours++;
                    }                    
                }
            }

            return nbNeighbours;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartAndStop_Click(object sender, EventArgs e)
        {
            //If the game isn't running
            if (!isGameRunning)
            {
                //Start the game
                Start();
            }
            //If the game is running
            else
            {
                //Stop the game
                Stop();
            }

        }

        private void Start()
        {
            isGameRunning = true;
            generationsTimer.Interval = tbSpeed.Value;
            generationsTimer.Tick += new EventHandler(TimerTick);
            generationsTimer.Start();
            btnStartAndStop.Text = "Stop";
        }

        private void Stop()
        {
            isGameRunning = false;
            generationsTimer.Stop();
            generationsTimer = new Timer();
            btnStartAndStop.Text = "Start";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            //Put all cells alives in the stack
            lastsGenerations.Push(GetCellsAlives());

            //Start 1 generation
            Generation();
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            //Change the tick interval of the timer with the new speed
            generationsTimer.Interval = tbSpeed.Value;

            //Display the new speed
            DisplaySpeed();
        }

        private void NumSize_ValueChanged(object sender, EventArgs e)
        {
            //Stop the game
            Stop();

            //Reset the lasts generations
            lastsGenerations = new Stack<List<Label>>();

            //Iinitialize the game
            Init();

            //Display the size of the grid
            DisplayGridSize();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Stop the game
            Stop();

            //Reset the lasts generations
            lastsGenerations = new Stack<List<Label>>();

            //Set all cells to dead
            foreach (Label lbl in panContainer.Controls)
            {
                lbl.Tag = DEAD_CELL_TAG;
                lbl.BackColor = DEAD_CELL_COLOR;
            }

            //Dispaly the stats
            nbGenerations = 0;
            nbCellsAlive = 0;
            nbCellsDead = gridSize * gridSize;
            DisplayStats();
        }

        private void BtnRandomGrid_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            //Browse all the cells
            foreach (Label lbl in panContainer.Controls)
            {
                //40% of chance of being alive
                if(rnd.Next(0, 100) < 40)
                {
                    //Set the cell to alive
                    lbl.Tag = ALIVE_CELL_TAG;
                    lbl.BackColor = ALIVE_CELL_COLOR;
                }
                else
                {
                    //Set the cell to dead
                    lbl.Tag = DEAD_CELL_TAG;
                    lbl.BackColor = DEAD_CELL_COLOR;
                }
                
            }
        }

        private void BtnLastGeneration_Click(object sender, EventArgs e)
        {
            //If the stack with the lasts generations isn't empty
            if(lastsGenerations.Count > 0)
            {
                //Get all alives cells from the last generation
                List<Label> aliveCells = lastsGenerations.Pop();

                //Browse all the alive cells
                foreach (Label lbl in panContainer.Controls)
                {
                    //If the cell is in the alives from the last generation
                    if (aliveCells.Contains(lbl))
                    {
                        //Set the cell to alive
                        lbl.Tag = ALIVE_CELL_TAG;
                        lbl.BackColor = ALIVE_CELL_COLOR;
                    }
                    else
                    {
                        //Set the cell to dead
                        lbl.Tag = DEAD_CELL_TAG;
                        lbl.BackColor = DEAD_CELL_COLOR;
                    }
                }
            }
            
        }

        private void BtnSingleGeneration_Click(object sender, EventArgs e)
        {
            //Start 1 generation
            TimerTick(null, null);
        }

        private void DisplayStats()
        {
            lblStats.Text = $"" +
                $"Nombre de générations : {nbGenerations}\n" +
                $"Nombre de cellules vivantes : {nbCellsAlive}\n" +
                $"Nombre de cellules mortes : {nbCellsDead}";
        }

        private void DisplayGridSize()
        {
            lblGridSize.Text = $"Taille de la grille : {numSize.Value}";
        }

        private void DisplaySpeed()
        {
            lblSpeed.Text = $"Speed : {tbSpeed.Value}ms";
        }
    }
}
