using System.Diagnostics;

namespace pong
{
  public partial class Form1
  {


    Rectangle rectVitMoins, rectVitPlus, rectScoreMoins, rectScorePlus, rectDebug, rectRetour;

    private void DessinerParametres(Graphics g)
    {
      StringFormat centre = new StringFormat();
      centre.Alignment = StringAlignment.Center;
      centre.LineAlignment = StringAlignment.Center;

      Rectangle rectTitre = new Rectangle(0, 60, ClientSize.Width, 80);
      g.DrawString("Parametres", police, Brushes.White, rectTitre, centre);

      int milieu = ClientSize.Width / 2;
      int yVitesse = 220;
      int tailleBouton = 60;
      rectVitMoins = new Rectangle(milieu - 250, yVitesse, tailleBouton, tailleBouton);
      rectVitPlus = new Rectangle(milieu + 190, yVitesse, tailleBouton, tailleBouton);
      Rectangle rectTexteVitesse = new Rectangle(milieu - 190, yVitesse, 380, tailleBouton);

      g.DrawImage(imgMoin, rectVitMoins);
      g.DrawImage(imgPlus, rectVitPlus);
      g.DrawString("Vitesse balle : " + vitesseDepart, police, Brushes.White, rectTexteVitesse, centre);

      rectRetour = new Rectangle(milieu - 125, ClientSize.Height - 150, 250, 80);
      g.DrawImage(imgMenuPlayRect, rectRetour);
      g.DrawString("RETOUR", police, Brushes.White, rectRetour, centre);
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
    }
  }
}
