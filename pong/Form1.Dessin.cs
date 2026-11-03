namespace pong
{
    public partial class Form1
    {
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(imgFond, ClientRectangle);
            if (!gameStart)
            {
                int largeur = 250;
                int hauteur = 80;
                rectLogo = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 - 140, largeur, hauteur);
                rectPlayBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2, largeur, hauteur);
                rectSettingBouton = new Rectangle((ClientSize.Width - largeur) / 2, (ClientSize.Height - hauteur) / 2 + 70, largeur, hauteur);
                g.DrawImage(rectPlayBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectPlayBouton);
                g.DrawImage(rectSettingBoutonStatus ? imgMenuPlayUpRect : imgMenuPlayRect, rectSettingBouton);
                g.DrawImage(imgLogo, rectLogo);

                using (Font policeBouton = new Font("Arial", 20, FontStyle.Bold))
                using (StringFormat centre = new StringFormat())
                {
                    centre.Alignment = StringAlignment.Center;
                    centre.LineAlignment = StringAlignment.Center;
                    g.DrawString("JOUER", policeBouton, Brushes.White, rectPlayBouton, centre);
                    g.DrawString("PARAMETRE", policeBouton, Brushes.White, rectSettingBouton, centre);
                }
            }


            if (gameStart)
            {
                drawBalle(e.Graphics, Balle);
                drawObjet(e.Graphics, RJ1, imgRaquetteJ1);
                drawObjet(e.Graphics, RJ2, imgRaquetteJ2);

                if (impactCaseCyan >= 0)
                {
                    int taille = imgImpactCyan.Height;
                    Rectangle source = new Rectangle(impactCaseCyan * taille, 0, taille, taille);
                    Rectangle destination = new Rectangle(impactX - taille / 2, impactY - taille / 2, taille, taille);
                    g.DrawImage(imgImpactCyan, destination, source, GraphicsUnit.Pixel);
                }
                if (impactCaseRose >= 0)
                {
                    int taille = imgImpactRose.Height;
                    Rectangle source = new Rectangle(impactCaseRose * taille, 0, taille, taille);
                    Rectangle destination = new Rectangle(impactX - taille / 2, impactY - taille / 2, taille, taille);
                    g.DrawImage(imgImpactRose, destination, source, GraphicsUnit.Pixel);
                }

                using (Font policeScore = new Font("Arial", 14, FontStyle.Bold))
                {
                    e.Graphics.DrawString("Key Z : " + toucheZ.ToString(), policeScore, Brushes.White, 10, 10);
                    e.Graphics.DrawString("Key S : " + toucheS.ToString(), policeScore, Brushes.White, 10, 30);
                    e.Graphics.DrawString("Key UP : " + toucheHaut.ToString(), policeScore, Brushes.White, 10, 50);
                    e.Graphics.DrawString("Key DOWN : " + toucheBas.ToString(), policeScore, Brushes.White, 10, 70);
                    e.Graphics.DrawString("winHeight : " + this.Height.ToString() + " win : " + this.Width.ToString(), policeScore, Brushes.White, 10, 90);
                    e.Graphics.DrawString("X: " + Balle[0].ToString() + " Y : " + Balle[1].ToString(), policeScore, Brushes.White, 10, 110);
                    e.Graphics.DrawString("p1 : " + SJ1.ToString() + " p2 : " + SJ2.ToString(), policeScore, Brushes.White, 10, 130);
                    e.Graphics.DrawString("Vballe : " + VBalle.ToString() + "VR : " + VR.ToString(), policeScore, Brushes.White, 10, 150);
                    e.Graphics.DrawString("impact : " + impactCaseCyan.ToString(), policeScore, Brushes.White, 10, 170);

                }
            }
        }

        private void drawBalle(Graphics g, int[] o)
        {
            //g.FillEllipse(Brushes.White, o[0], o[1], o[2], o[3]);
            g.DrawImage(imgBalle, o[0], o[1], o[2], o[3]);
        }
        private void drawObjet(Graphics g, int[] o, Image img)
        {
            //g.FillRectangle(Brushes.White, o[0], o[1], o[2], o[3]);
            g.DrawImage(img, o[0], o[1], o[2], o[3]);
        }
    }
}
