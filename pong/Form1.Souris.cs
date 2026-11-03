namespace pong
{
    public partial class Form1
    {
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (ecran)
            {
                case Ecran.Menu:
                    ClicMenu(e.Location);
                    break;
                case Ecran.Parametres:
                    ClicParametres(e.Location);
                    break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (ecran)
            {
                case Ecran.Menu:
                    SurvolMenu(e.Location);
                    break;
                case Ecran.Parametres:
                    SurvolParametres(e.Location);
                    break;
            }
        }
    }
}
