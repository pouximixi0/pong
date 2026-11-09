using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

        enum Ecran { Menu, Parametres, Jeu, JeuSolo, JeuServeur, JeuClient, GameMode, FinJeux }
        Ecran ecran = Ecran.Menu;

        int impactX, impactY;

        Random hasard = new Random();

        int vitesseDepart = 5;
        int scoreMax = 5;
        string pseudo2;
        bool afficherDebug = true;
        private bool estEnPause = false;
        private System.Windows.Forms.Timer relanceTimer;
        private string joueurGagnant = "";
        private bool finDePartie = false;
        private string messagePause = "";
        private DateTime derniereReception = DateTime.MinValue;


        UdpClient? udp;
        const int PORT = 8080;
        IPEndPoint? clientDistant;
        private string pseudo;


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
            this.KeyPress += SaisirPseudo;

            gameTimer.Interval = 20;
            gameTimer.Tick += new EventHandler(GameLoop);
            gameTimer.Start();

            relanceTimer = new System.Windows.Forms.Timer();
            relanceTimer.Tick += (s, e) =>
            {
                relanceTimer.Stop();

                if (finDePartie)
                {
                    SJ1 = 0;
                    SJ2 = 0;
                    finDePartie = false;
                    resetGame(hasard.Next(0, 2) == 0 ? 1 : -1);
                }

                estEnPause = false;
                messagePause = "";
            };


            sensH = -1;
            sensV = -1;

            var data = loadJson();

            if (data != null)
            {
                vitesseDepart = data["VitesseDepart"].GetInt32();
                afficherDebug = data["AfficherDebug"].GetBoolean();
                pseudo = data["Pseudo"].GetString();


            }
            scoreMax = 5;
        }


        void DemarrerServeur()
        {
            if (udp == null) udp = new UdpClient(PORT);

            ecran = Ecran.JeuServeur;
            this.Text = "Serveur en attente...";
            Console.WriteLine("Serveur en attente sur le port " + PORT);
        }

        void DemarrerClient()
        {
            if (udp == null)
            {
                udp = new UdpClient();
                udp.Connect("172.17.3.5", PORT);
            }

            ecran = Ecran.JeuClient;
            this.Text = "Client connecté";
        }

        void EnvoyerMessage(Dictionary<string, string> message)
        {
            if (udp == null) return;

            string json = JsonSerializer.Serialize(message);
            byte[] data = Encoding.UTF8.GetBytes(json);

            if (ecran == Ecran.JeuClient)
            {
                udp.Send(data, data.Length);
            }
            else if (clientDistant != null)
            {
                udp.Send(data, data.Length, clientDistant);
            }

            //Console.WriteLine("Envoyé : " + json);
        }

    }

}
