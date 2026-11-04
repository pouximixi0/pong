using System.Drawing.Text;
using System.Windows.Forms.VisualStyles;

namespace pong
{
    public partial class Form1
    {
        private Font police = new Font("Calibri", 20, FontStyle.Bold);        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(imgFond, ClientRectangle);

            switch (ecran)
            {
                case Ecran.Menu:
                    DessinerMenu(g);
                    break;
                case Ecran.Parametres:
                    DessinerParametres(g);
                    break;
                case Ecran.Jeu:
                    DessinerJeu(g);
                    break;
            }
        }
    }
}
