using System.Drawing.Text;

namespace pong
{
    public partial class Form1
    {
        private Rectangle rectPlayBouton, rectSettingBouton, rectLogo, rectQuitButton;
        private bool rectPlayBoutonStatus = false;
        private bool rectSettingBoutonStatus = false;
        private bool rectQuitBoutonStatus = false;
        private Font customPolice;
        private StringFormat centre;

        private void DessinerMenu(Graphics g)
        {
            int largeur = 270;
            int hauteur = 80;
            rectLogo = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 - 140, largeur, hauteur);
            rectPlayBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2, largeur, hauteur);
            rectSettingBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 70, largeur, hauteur);
            rectQuitButton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 140, largeur, hauteur);
            g.DrawImage(imgLogo, rectLogo);
            g.DrawImage(rectPlayBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectPlayBouton);
            g.DrawImage(rectSettingBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectSettingBouton);
            g.DrawImage(rectQuitBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectQuitButton);

            PrivateFontCollection customFont = new PrivateFontCollection();
            customFont.AddFontFile("font/SpaceGrotesk-VariableFont_wght.ttf");
            FontFamily ff = customFont.Families[0];
            centre = new StringFormat();

            customPolice = new Font(ff, 20, FontStyle.Bold);

            centre.Alignment = StringAlignment.Center;
            centre.LineAlignment = StringAlignment.Center;
            g.DrawString("JOUER", customPolice, Brushes.White, rectPlayBouton, centre);
            //g.DrawString("SKIN", police, Brushes.White, rectPlayBouton, centre);
            g.DrawString("PARAMETRES", customPolice, Brushes.White, rectSettingBouton, centre);
            g.DrawString("QUITTER", customPolice, Brushes.White, rectQuitButton, centre);
        }

        private void ClicMenu(Point souris)
        {
            if (rectPlayBouton.Contains(souris))
            {
                ecran = Ecran.GameMode;
                VBalle = vitesseDepart;
                gameTimer.Start();
                clientStatus = true;
                Invalidate();
            }
            else if (rectSettingBouton.Contains(souris))
            {
                ecran = Ecran.Parametres;
                Invalidate();
            }
            else if (rectQuitButton.Contains(souris))
            {
                this.Close();
            }
        }

        private void SurvolMenu(Point souris)
        {
            bool survolPlay = rectPlayBouton.Contains(souris);
            bool survolSetting = rectSettingBouton.Contains(souris);
            bool survolQuitter = rectQuitButton.Contains(souris);

            if (survolPlay != rectPlayBoutonStatus || survolSetting != rectSettingBoutonStatus || survolQuitter != rectQuitBoutonStatus)
            {
                rectPlayBoutonStatus = survolPlay;
                rectSettingBoutonStatus = survolSetting;
                rectQuitBoutonStatus = survolQuitter;
                Invalidate();
            }
        }
    }
}
