namespace pong
{
    public partial class Form1
    {
        private Rectangle rectPlayBouton, rectSettingBouton, rectLogo, rectQuitButton;
        private bool rectPlayBoutonStatus = false;
        private bool rectSettingBoutonStatus = false;
        private bool rectQuitBoutonStatus = false;

        private void DessinerMenu(Graphics g)
        {
            int largeur = 250;
            int hauteur = 80;
            rectLogo = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 - 140, largeur, hauteur);
            rectPlayBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2, largeur, hauteur);
            rectSettingBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 70, largeur, hauteur);
            rectQuitButton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 140, largeur, hauteur);
            g.DrawImage(rectPlayBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectPlayBouton);
            g.DrawImage(rectSettingBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectSettingBouton);
            g.DrawImage(rectQuitBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectQuitButton);

            StringFormat centre = new StringFormat();
            centre.Alignment = StringAlignment.Center;
            centre.LineAlignment = StringAlignment.Center;
            g.DrawString("JOUER", police, Brushes.White, rectPlayBouton, centre);
            g.DrawString("PARAMETRE", police, Brushes.White, rectSettingBouton, centre);
            g.DrawString("QUITTER", police, Brushes.White, rectQuitButton, centre);
        }

        private void ClicMenu(Point souris)
        {
            if (rectPlayBouton.Contains(souris))
            {
                ecran = Ecran.Jeu;
                VBalle = vitesseDepart;
                gameTimer.Start();
                Invalidate();
            }
            else if (rectSettingBouton.Contains(souris))
            {
                ecran = Ecran.Parametres;
                Invalidate();
            }
        }

        private void SurvolMenu(Point souris)
        {
            bool survolPlay = rectPlayBouton.Contains(souris);
            bool survolSetting = rectSettingBouton.Contains(souris);

            if (survolPlay != rectPlayBoutonStatus || survolSetting != rectSettingBoutonStatus)
            {
                rectPlayBoutonStatus = survolPlay;
                rectSettingBoutonStatus = survolSetting;
                Invalidate();
            }
        }
    }
}
