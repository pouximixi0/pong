namespace pong
{
  public partial class Form1
  {
    private Rectangle rectSoloButton, rectMultiServeurButton, rectMultiClientButton;
    private bool rectSoloButtonStatus = false;
    private bool rectMultiServeurButtonStatus = false;
    private bool rectMultiClientButtonStatus = false;
    private void DessinerGameMode(Graphics g)
    {

      int largeur = 270;
      int hauteur = 80;
      rectSoloButton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2, largeur, hauteur);
      rectMultiServeurButton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 70, largeur, hauteur);
      rectMultiClientButton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 140, largeur, hauteur);


      g.DrawImage(imgLogo, rectLogo);
      g.DrawImage(rectSoloButtonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectSoloButton);
      g.DrawImage(rectMultiServeurButtonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectMultiServeurButton);
      g.DrawImage(rectMultiClientButtonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectMultiClientButton);

      g.DrawString("Solo", customPolice, Brushes.White, rectPlayBouton, centre);
      g.DrawString("Multi (host)", customPolice, Brushes.White, rectSettingBouton, centre);
      g.DrawString("Multi (client)", customPolice, Brushes.White, rectQuitButton, centre);

    }

    private void ClicMode(Point souris)
    {
      if (rectSoloButton.Contains(souris))
      {
        ecran = Ecran.Jeu;
        Invalidate();
      }
      else if (rectMultiServeurButton.Contains(souris))
      {
        ecran = Ecran.Menu;
        Invalidate();
      }
      else if (rectMultiClientButton.Contains(souris))
      {
        ecran = Ecran.Menu;
        Invalidate();
      }
    }

    private void SurvolMode(Point souris)
    {
      bool survolSolo = rectSoloButton.Contains(souris);
      bool survolMultiServeur = rectMultiServeurButton.Contains(souris);
      bool survolMultiClient = rectMultiClientButton.Contains(souris);


      if (survolSolo != rectSoloButtonStatus || survolMultiServeur != rectMultiServeurButtonStatus || survolMultiClient != rectMultiClientButtonStatus)
      {
        rectSoloButtonStatus = survolSolo;
        rectMultiServeurButtonStatus = survolMultiServeur;
        rectMultiClientButtonStatus = survolMultiClient;
        Invalidate();
      }
    }
  }
}