namespace pong
{
    public partial class Form1
    {
        private void GameLoop(object sender, EventArgs e)
        {
            VBalle += 0.008;
            VR += 0.002;
            Balle[0] += Convert.ToInt32(VBalle) * sensH;
            Balle[1] += Convert.ToInt32(VBalle) * sensV;

            if (Balle[1] <= 0)
            {
                sensV = 1;
            }

            if (Balle[1] + Balle[3] >= this.ClientSize.Height)
            {
                sensV = -1;
            }

            if (Balle[0] <= 0)
            {
                SJ2++;
                resetGame(-1);
            }
            if (Balle[0] >= this.ClientSize.Width)
            {
                SJ1++;
                resetGame(1);
            }

            Rectangle rectBalle = new Rectangle(Balle[0] + 20, Balle[1] + 20, Balle[2] - 40, Balle[3] - 40);
            Rectangle rectRJ1 = new Rectangle(RJ1[0] + 38, RJ1[1] + 25, RJ1[2] - 76, RJ1[3] - 50);
            Rectangle rectRJ2 = new Rectangle(RJ2[0] + 38, RJ2[1] + 25, RJ2[2] - 76, RJ2[3] - 50);

            if (rectBalle.IntersectsWith(rectRJ1))
            {
                sensH = 1;
                lancerImpact("Cyan");
                //Balle[0] = RJ1[0] + RJ1[2];
            }
            if (rectBalle.IntersectsWith(rectRJ2))
            {
                sensH = -1;
                lancerImpact("Rose");
                //Balle[0] = RJ2[0] - RJ2[2];
            }

            if (impactCaseCyan >= 0)
            {
                impactCaseCyan++;
                if (impactCaseCyan >= imgImpactCyan.Width / imgImpactCyan.Height)
                {
                    impactCaseCyan = -1;
                }
            }
            if (impactCaseRose >= 0)
            {
                impactCaseRose++;
                if (impactCaseRose >= imgImpactRose.Width / imgImpactRose.Height)
                {
                    impactCaseRose = -1;
                }
            }

            if (toucheZ && RJ1[1] > 0) RJ1[1] -= Convert.ToInt32(VR);
            if (toucheS && RJ1[1] + RJ1[3] < this.ClientSize.Height) RJ1[1] += Convert.ToInt32(VR);
            if (toucheHaut && RJ2[1] > 0) RJ2[1] -= Convert.ToInt32(VR);
            if (toucheBas && RJ2[1] + RJ2[3] < this.ClientSize.Height) RJ2[1] += Convert.ToInt32(VR);
            
            if (toucheEsc) ecran = Ecran.Menu;

            Invalidate();
        }

        private void DessinerJeu(Graphics g)
        {
            drawBalle(g, Balle);
            drawObjet(g, RJ1, imgRaquetteJ1);
            drawObjet(g, RJ2, imgRaquetteJ2);

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
                g.DrawString("Key Z : " + toucheZ.ToString(), policeScore, Brushes.White, 10, 10);
                g.DrawString("Key S : " + toucheS.ToString(), policeScore, Brushes.White, 10, 30);
                g.DrawString("Key UP : " + toucheHaut.ToString(), policeScore, Brushes.White, 10, 50);
                g.DrawString("Key DOWN : " + toucheBas.ToString(), policeScore, Brushes.White, 10, 70);
                g.DrawString("winHeight : " + this.Height.ToString() + " win : " + this.Width.ToString(), policeScore, Brushes.White, 10, 90);
                g.DrawString("X: " + Balle[0].ToString() + " Y : " + Balle[1].ToString(), policeScore, Brushes.White, 10, 110);
                g.DrawString("p1 : " + SJ1.ToString() + " p2 : " + SJ2.ToString(), policeScore, Brushes.White, 10, 130);
                g.DrawString("Vballe : " + VBalle.ToString() + "VR : " + VR.ToString(), policeScore, Brushes.White, 10, 150);
                g.DrawString("impact : " + impactCaseCyan.ToString(), policeScore, Brushes.White, 10, 170);
            }

            g.DrawImage(Image.FromFile(dossierImages + @"chiffres\chiffre_cyan_" + SJ1 + ".png"), 555, 50, 60, 100);
            g.DrawImage(Image.FromFile(dossierImages + @"chiffres\chiffre_rose_" + SJ2 + ".png"), 645, 50, 60, 100);

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

        private void resetGame(int sens)
        {
            Balle[0] = 290;
            Balle[1] = 290;
            VBalle = vitesseDepart;
            VR = 12;
            RJ1[1] = 250;
            RJ2[1] = 250;

            sensH = sens;

            sensV = hasard.Next(0, 2) == 0 ? 1 : -1;
        }

        private void lancerImpact(String color)
        {
            if (color == "Cyan")
            {
                impactCaseCyan = 0;
            }
            else if (color == "Rose")
            {
                impactCaseRose = 0;
            }
            impactX = Balle[0] + Balle[2] / 2;
            impactY = Balle[1] + Balle[3] / 2;
        }
    }
}
