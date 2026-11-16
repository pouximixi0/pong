using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace pong
{
  public partial class Form1
  {
    private List<BoutonSkin> boutonsSkins = new List<BoutonSkin>();

    private int skinSelectionneId = 1;

    private void InitialiserSkins()
    {
      boutonsSkins.Add(new BoutonSkin { Id = 1, Image = skinImg1, Zone = new Rectangle(15, 35, 120, 120) });
      boutonsSkins.Add(new BoutonSkin { Id = 2, Image = skinImg2, Zone = new Rectangle(150, 35, 120, 120) });
      boutonsSkins.Add(new BoutonSkin { Id = 3, Image = skinImg3, Zone = new Rectangle(285, 35, 120, 120) });
      boutonsSkins.Add(new BoutonSkin { Id = 4, Image = skinImg4, Zone = new Rectangle(420, 35, 120, 120) });
    }

    public void DessinerSkin(Graphics g)
    {
      if (boutonsSkins.Count == 0)
      {
        InitialiserSkins();
      }

      g.SmoothingMode = SmoothingMode.AntiAlias;

      for (int i = 0; i < boutonsSkins.Count; i++)
      {
        DessinerCellule(g, boutonsSkins[i]);
      }

      for (int i = 0; i < boutonsSkins.Count; i++)
      {
        if (boutonsSkins[i].Id == skinSelectionneId)
        {
          g.DrawImage(boutonsSkins[i].Image, 850, -10, 300, 720);
        }
      }
    }

    private void DessinerCellule(Graphics g, BoutonSkin btn)
    {
      Color couleur = Color.Gray;
      if (btn.EstSurvole == true)
      {
        couleur = Color.Cyan;
      }
      if (btn.Id == skinSelectionneId)
      {
        couleur = Color.Gold;
      }

      using (Pen halo = new Pen(Color.FromArgb(80, couleur), 8))
      using (Pen contour = new Pen(couleur, 2))
      {
        if (btn.Image != null)
        {
          g.DrawImage(btn.Image, new Rectangle(btn.Zone.X + 35, btn.Zone.Y, 50, 120));
        }

        g.DrawRoundedRectangle(halo, btn.Zone, new Size(20, 20));
        g.DrawRoundedRectangle(contour, btn.Zone, new Size(20, 20));
      }
    }

    private void ClicSkin(Point souris)
    {
      for (int i = 0; i < boutonsSkins.Count; i++)
      {
        if (boutonsSkins[i].Zone.Contains(souris))
        {
          skinSelectionneId = boutonsSkins[i].Id;
          Invalidate();
          break;
        }
      }
    }

    private void SurvolSkin(Point souris)
    {
      bool besoinRedessiner = false;

      for (int i = 0; i < boutonsSkins.Count; i++)
      {

        bool toucheSouris = boutonsSkins[i].Zone.Contains(souris);

        if (toucheSouris != boutonsSkins[i].EstSurvole)
        {
          boutonsSkins[i].EstSurvole = toucheSouris;
          besoinRedessiner = true;
        }
      }

      if (besoinRedessiner == true)
      {
        Invalidate();
      }
    }

    public class BoutonSkin
    {
      public int Id;
      public Image Image;
      public Rectangle Zone;
      public bool EstSurvole;
    }
  }
}
