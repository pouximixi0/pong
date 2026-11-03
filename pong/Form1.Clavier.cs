namespace pong
{
    public partial class Form1
    {
        bool toucheZ, toucheS, toucheHaut, toucheBas;

        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) toucheZ = true;
            if (e.KeyCode == Keys.S) toucheS = true;
            if (e.KeyCode == Keys.Up) toucheHaut = true;
            if (e.KeyCode == Keys.Down) toucheBas = true;

        }
        private void keyReleased(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) toucheZ = false;
            if (e.KeyCode == Keys.S) toucheS = false;
            if (e.KeyCode == Keys.Up) toucheHaut = false;
            if (e.KeyCode == Keys.Down) toucheBas = false;

        }
    }
}
