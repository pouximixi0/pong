namespace pong
{
    public partial class Form1
    {
        private void GameLoop(object sender, EventArgs e)
        {
            VBalle += 0.008;
            VR += 0.002;
            // ball movment
            Balle[0] += Convert.ToInt32(VBalle) * sensH;
            Balle[1] += Convert.ToInt32(VBalle) * sensV;

            // up
            if (Balle[1] <= 0)
            {
                sensV = 1;
            }

            // down
            if (Balle[1] + Balle[3] >= this.ClientSize.Height)
            {
                sensV = -1;
            }

            // left
            if (Balle[0] <= 0)
            {
                SJ2++;
                resetGame(-1);
            }
            // right
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

            Invalidate();
        }

        private void resetGame(int sens)
        {
            Balle[0] = 290;
            Balle[1] = 290;
            VBalle = 5;
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
