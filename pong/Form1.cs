using System.Text.Json;
namespace pong
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();

        int[] Balle = { 290, 290, 80, 80 };
        int[] RJ1 = { 30, 250, 100, 180 };
        int[] RJ2 = { 1135, 250, 100, 180 };

        int SJ1 = 0;
        int SJ2 = 0;
        double VBalle = 5;
        double VR = 12;
        int sensH, sensV;

        int impactCaseCyan = -1;
        int impactCaseRose = -1;

        enum Ecran { Menu, Parametres, Jeu, GameMode, FinJeux }
        Ecran ecran = Ecran.Menu;

        int impactX, impactY;

        Random hasard = new Random();

        int vitesseDepart = 5;
        int scoreMax = 5;
        bool afficherDebug = true;


        public Form1()
        {
            InitializeComponent();
            this.Width = 1280;
            this.Height = 720;
            this.BackColor = Color.Black;
            this.KeyPreview = true;
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(keyPressed);
            this.KeyUp += new KeyEventHandler(keyReleased);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);

            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(GameLoop);
            gameTimer.Start();

            sensH = -1;
            sensV = -1;

            var data = loadJson();

            if (data != null)
            {
                vitesseDepart = data["VitesseDepart"].GetInt32();
                afficherDebug = data["AfficherDebug"].GetBoolean();

            }
            scoreMax = 5;


        }
    }
}
