namespace pong
{
    public partial class Form1
    {
        private Rectangle rectPlayBouton;
        private Rectangle rectSettingBouton;
        private Rectangle rectLogo;
        private bool rectPlayBoutonStatus = false;
        private bool rectSettingBoutonStatus = false;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameStart && rectPlayBouton.Contains(e.Location))
            {
                gameStart = true;
                gameTimer.Start();
                Invalidate();
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameStart) return;

            bool survolPlay = rectPlayBouton.Contains(e.Location);
            bool survolSetting = rectSettingBouton.Contains(e.Location);

            if (survolPlay != rectPlayBoutonStatus || survolSetting != rectSettingBoutonStatus)
            {
                rectPlayBoutonStatus = survolPlay;
                rectSettingBoutonStatus = survolSetting;
                Invalidate();
            }
        }
    }
}
