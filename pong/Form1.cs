namespace pong
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();

        int[] Balle = { 290, 290, 15, 15 };
        int[] RJ1 = { 30, 250, 15, 100 };
        int[] RJ2 = { 540, 250, 15, 100 };

        int SJ1 = 0;
        int SJ2 = 0;
        double VBalle = 5;
        int VR = 12;
        int sensH, sensV;

        bool toucheZ, toucheS, toucheHaut, toucheBas;
        Random hasard = new Random();
        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 600;
            this.BackColor = Color.Black;
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);

            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(keyPressed);
            this.KeyUp += new KeyEventHandler(keyReleased);

            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(GameLoop); 
            gameTimer.Start();

            sensH = -1;
            sensV = -1;

        }
        private void GameLoop(object sender, EventArgs e)
        {
            VBalle += 0.008;
            // ball movment
            Balle[0] += Convert.ToInt32(VBalle) * sensH;
            Balle[1] += Convert.ToInt32(VBalle) * sensV;

            // up
            if (Balle[1] <= 0)
            {
                sensV = 1; 
            }

            // down
            if (Balle[1] + Balle[3] >= this.ClientSize.Height)
            {
                sensV = -1; 
            }

            // left
            if (Balle[0] <= 0)
            {
                SJ2++;
                resetGame(-1);
            }
            // right
            if (Balle[0] >= this.ClientSize.Width)
            {
                SJ1++;
                resetGame(1);
            }

            Rectangle rectBalle = new Rectangle(Balle[0], Balle[1], Balle[2], Balle[3]);
            Rectangle rectRJ1 = new Rectangle(RJ1[0], RJ1[1], RJ1[2], RJ1[3]);
            Rectangle rectRJ2 = new Rectangle(RJ2[0], RJ2[1], RJ2[2], RJ2[3]);
            if (rectBalle.IntersectsWith(rectRJ1))
            {
                sensH = 1;
                Balle[0] = RJ1[0] + RJ1[2];
            }
            if (rectBalle.IntersectsWith(rectRJ2))
            {
                sensH = -1;
                Balle[0] = RJ2[0] - RJ2[2];
            }

                if (toucheZ && RJ1[1] > 0) RJ1[1] -= VR;
            if (toucheS && RJ1[1] + RJ1[3] < this.ClientSize.Height) RJ1[1] += VR;
            if (toucheHaut && RJ2[1] > 0) RJ2[1] -= VR;
            if (toucheBas && RJ2[1] + RJ2[3] < this.ClientSize.Height) RJ2[1] += VR;

            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawBalle(e.Graphics, Balle);
            drawObjet(e.Graphics, RJ1);
            drawObjet(e.Graphics, RJ2);

            using (Font policeScore = new Font("Arial", 14, FontStyle.Bold))
            {
                e.Graphics.DrawString("Key Z : " + toucheZ.ToString(), policeScore, Brushes.White, 10, 10);
                e.Graphics.DrawString("Key S : " + toucheS.ToString(), policeScore, Brushes.White, 10, 30);
                e.Graphics.DrawString("Key UP : " + toucheHaut.ToString(), policeScore, Brushes.White, 10, 50);
                e.Graphics.DrawString("Key DOWN : " + toucheBas.ToString(), policeScore, Brushes.White, 10, 70);
                e.Graphics.DrawString("winHeight : " + this.Height.ToString() + " win : " + this.Width.ToString(), policeScore, Brushes.White, 10, 90);
                e.Graphics.DrawString("X: " + Balle[0].ToString() + " Y : " + Balle[1].ToString(), policeScore, Brushes.White, 10, 110);
                e.Graphics.DrawString("p1 : " + SJ1.ToString() + " p2 : " + SJ2.ToString(), policeScore, Brushes.White, 10, 130);
                e.Graphics.DrawString("Vballe : " + VBalle.ToString(), policeScore, Brushes.White, 10, 150);
            }
        }
        private void drawBalle(Graphics g, int[] o)
        {
            g.FillEllipse(Brushes.White, o[0], o[1], o[2], o[3]);
        }
        private void drawObjet(Graphics g, int[] o)
        {
            g.FillRectangle(Brushes.White, o[0], o[1], o[2], o[3]);
        }

        private void keyPressed(object sender,  KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) toucheZ = true;
            if (e.KeyCode == Keys.S) toucheS = true;
            if (e.KeyCode == Keys.Up) toucheHaut = true;
            if (e.KeyCode == Keys.Down) toucheBas = true;

        }
        private void keyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) toucheZ = false;
            if (e.KeyCode == Keys.S) toucheS = false;
            if (e.KeyCode == Keys.Up) toucheHaut = false;
            if (e.KeyCode == Keys.Down) toucheBas = false;

        }
        private void resetGame(int sens)
        {
            Balle[0] = 290;
            Balle[1] = 290;
            VBalle = 5;
            RJ1[1] = 250;
            RJ2[1] = 250;

            sensH = sens;

            sensV = hasard.Next(0, 2) == 0 ? 1 : -1;
        }
    }
}
