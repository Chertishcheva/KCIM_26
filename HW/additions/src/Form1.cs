namespace KSIM_HW
{
    public partial class gameOfLifeForm : Form
    {
        private const int MAP_SIZE = 500;
        private const int PIXEL_PER_CELL = 10;

        private static Bitmap pixelMap;
        private Graphics mapPainting;

        private int mapSize;
        private int pixelPerCell;
        private int numOfCell;

        private Cell[,] matrixOfCells;

        int generationCon;
        bool mouseHold;
        int cellStateInClick;

        public gameOfLifeForm()
        {
            mapSize = MAP_SIZE;
            pixelPerCell = PIXEL_PER_CELL;
            numOfCell = mapSize / pixelPerCell;

            InitializeComponent();
            InitializeGameOfLife();
        }

        private void InitializeGameOfLife() 
        {
            matrixOfCells = new Cell[numOfCell, numOfCell];
            for (int i = 0; i < numOfCell; i++)
                for (int j = 0; j < numOfCell; j++)
                    matrixOfCells[i, j] = new Cell();

            pixelMap = new Bitmap(mapSize + 1, mapSize + 1);
            canvas.Image = pixelMap;
            mapPainting = Graphics.FromImage(pixelMap);
            DrawGrid();

            generationCon = 0;
            mouseHold = false;
        }
        //---------------------------------------------------------

        private void skipGenerationButton_Click(object sender, EventArgs e)
        {
            SkipGeneration();

        }
        private void fastSkipGenerationButton_Click(object sender, EventArgs e)
        {
            skipGenerationButton.Enabled = false;
            restartButton.Enabled = false;
            timer1.Enabled = true;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            skipGenerationButton.Enabled = true;
            restartButton.Enabled = true;
            timer1.Enabled = false;
        }
        private void restartButton_Click(object sender, EventArgs e)
        {
            InitializeGameOfLife();
            generationNumber.Text = generationCon.ToString();
        }

        //---------------------------------------------------------

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            mouseHold = true;
            int xPos = e.X / 10;
            int yPos = e.Y / 10;

            if (xPos < numOfCell && yPos < numOfCell)
            {
                matrixOfCells[xPos, yPos].swapState();
                cellStateInClick = matrixOfCells[xPos, yPos].getStateCode();
                DrawCell(xPos, yPos, 2);
                canvas.Image = pixelMap;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHold)
            {
                int xPos = e.X / 10;
                int yPos = e.Y / 10;

                if (xPos < numOfCell && yPos < numOfCell && xPos >= 0 && yPos >= 0)
                {
                    matrixOfCells[xPos, yPos].swapState();
                    DrawCell(xPos, yPos, cellStateInClick);
                    canvas.Image = pixelMap;
                }
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e) { mouseHold = false; }
        private void canvas_MouseLeave(object sender, EventArgs e) { mouseHold = false; }

        //---------------------------------------------------------

        public void repaintCanvas()
        {
            for (int i = 1; i < numOfCell; i++)
                for (int j = 1; j < numOfCell; j++)
                    DrawCell(i, j, 2);

            for (int i = 0; i < numOfCell; i++)
                DrawCell(i, 0, 2);

            for (int j = 0; j < numOfCell; j++)
                DrawCell(0, j, 2);

            canvas.Image = pixelMap;
        }

        private void DrawCell(int x, int y, int beginningState)
        {
            SolidBrush mapBrush;
            Rectangle cellFiller;

            cellFiller = new Rectangle(x * 10 + 1, y * 10 + 1, pixelPerCell - 1, pixelPerCell - 1);
            mapBrush = new SolidBrush(Color.White);

            int cellState;
            if (beginningState > 1)
                cellState = matrixOfCells[x, y].getStateCode();
            else
                cellState = beginningState;

            if (cellState == 1)
                mapBrush.Color = Color.Black;
            else if (cellState == 0)
                mapBrush.Color = Color.White;
            else
                mapBrush.Color = Color.Red;

            mapPainting.FillRectangle(mapBrush, cellFiller);
        }

        private void DrawGrid()
        {

            Pen mapPen = new Pen(Color.LightGray);

            for (int y = 0; y <= numOfCell; y++)
                mapPainting.DrawLine(mapPen, 0, y * pixelPerCell, numOfCell * pixelPerCell, y * pixelPerCell);

            for (int x = 0; x <= numOfCell; x++)
                mapPainting.DrawLine(mapPen, x * pixelPerCell, 0, x * pixelPerCell, numOfCell * pixelPerCell);
        }

        //---------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            SkipGeneration();
        }
        private void SkipGeneration()
        {
            int neighCon;

            for (int i = 0; i < numOfCell; i++)
                for (int j = 0; j < numOfCell; j++)
                {
                    neighCon = NeighborsCounter(i, j);
                    matrixOfCells[i, j].generationalStateChange(neighCon);
                }

            for (int i = 0; i < numOfCell; i++)
                for (int j = 0; j < numOfCell; j++)
                    matrixOfCells[i, j].switchToNewGeneration();

            repaintCanvas();

            generationNumber.Text = (++generationCon).ToString();
        }

        private int NeighborsCounter(int x, int y)
        {
            int con = 0;
            bool sizeCheck = false;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    sizeCheck = x + i >= 0 && x + i < numOfCell && y + j >= 0 && y + j < numOfCell;
                    if (!(i == 0 && j == 0))
                        if (sizeCheck && matrixOfCells[x + i, y + j].canInfluenceNeighbors())
                            con++;
                }
            }
            return con;
        }
    }
}
