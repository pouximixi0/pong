namespace pong
{
    public partial class Form1
    {
        private static string dossierImages = AppContext.BaseDirectory + @"images\";

        private Image imgFond = Image.FromFile(dossierImages + @"terrain\fond_terrain.png");
        private Image imgRaquetteJ1 = Image.FromFile(dossierImages + @"raquettes\raquette_capsule_cyan.png");
        private Image imgRaquetteJ2 = Image.FromFile(dossierImages + @"raquettes\raquette_capsule_rose.png");
        private Image imgBalle = Image.FromFile(dossierImages + @"balles\balle_blanche.png");

        private Image imgImpactCyan = Image.FromFile(dossierImages + @"effets\impact_cyan.png");
        private Image imgImpactRose = Image.FromFile(dossierImages + @"effets\impact_rose.png");

        private Image imgMenuPlayRect = Image.FromFile(dossierImages + @"boutons\bouton_cyan_repos.png");
        private Image imgMenuPlayUpRect = Image.FromFile(dossierImages + @"boutons\bouton_cyan_survol.png");
        private Image imgLogo = Image.FromFile(dossierImages + @"logo\logo_pong.png");
    }
}
