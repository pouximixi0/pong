using System.Diagnostics;
using System.Drawing.Text;

namespace pong
{
  public partial class Form1
  {


    Rectangle rectVitMoins, rectVitPlus, rectScoreMoins, rectScorePlus, rectDebug, rectRetour;

    private bool rectDebugBoutonStatus = false;
    private bool rectRetourBoutonStatus = false;

    private void DessinerParametres(Graphics g)
    {
      PrivateFontCollection customFont = new PrivateFontCollection();
      customFont.AddFontFile("font/SpaceGrotesk-VariableFont_wght.ttf");
      FontFamily ff = customFont.Families[0];
      Font customPolice = new Font(ff, 20, FontStyle.Bold); 
      StringFormat centre = new StringFormat();
      centre.Alignment = StringAlignment.Center;
      centre.LineAlignment = StringAlignment.Center;

      Rectangle rectTitre = new Rectangle(0, 60, ClientSize.Width, 80);
      g.DrawString("Parametres", customPolice, Brushes.White, rectTitre, centre);

      int milieu = ClientSize.Width / 2;
      int tailleBouton = 60;
      rectVitMoins = new Rectangle(milieu - 250, 220, tailleBouton, tailleBouton);
      rectVitPlus = new Rectangle(milieu + 190, 220, tailleBouton, tailleBouton);
      Rectangle rectTexteVitesse = new Rectangle(milieu - 190, 220, 380, tailleBouton);
      rectDebug = new Rectangle(milieu - 250/2, 280, 250, 80);

      g.DrawImage(imgMoin, rectVitMoins);
      g.DrawImage(imgPlus, rectVitPlus);
      g.DrawString("Vitesse balle : " + vitesseDepart, customPolice, Brushes.White, rectTexteVitesse, centre);

      g.DrawImage(rectDebugBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectDebug);
      g.DrawString("Debug : " + Convert.ToString(afficherDebug), customPolice, Brushes.White, rectDebug, centre);

      rectRetour = new Rectangle(milieu - 125, ClientSize.Height - 150, 250, 80);
      g.DrawImage(rectRetourBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectRetour);
      g.DrawString("Quitter & sauv", customPolice, Brushes.White, rectRetour, centre);
    }

        private void ClicParametres(Point souris)
    {
      if (rectVitMoins.Contains(souris) && vitesseDepart > 1)
      {
        vitesseDepart--;
        Invalidate();
      }
      else if (rectVitPlus.Contains(souris) && vitesseDepart < 20)
      {
        vitesseDepart++;
        Invalidate();
      }
      else if (rectDebug.Contains(souris))
      {
        afficherDebug = !afficherDebug;
        Invalidate();
      }
      else if (rectRetour.Contains(souris))
      {
        saveJson(new Dictionary<string, object>
        {
          { "VitesseDepart", vitesseDepart },
          { "ScoreMax", scoreMax },
          { "AfficherDebug", afficherDebug }
        });

        ecran = Ecran.Menu;
        Invalidate();
      }
    }
    private void SurvolParametres(Point souris)
        {
            bool survolDebug = rectDebug.Contains(souris);
            bool survolRetour = rectRetour.Contains(souris);

            if (survolDebug != rectDebugBoutonStatus || survolRetour != rectRetourBoutonStatus)
            {
                rectDebugBoutonStatus = survolDebug;
                rectRetourBoutonStatus = survolRetour;
                Invalidate();
            }
        }
  }
}
