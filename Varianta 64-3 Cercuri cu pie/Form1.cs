using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Varianta_64_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        System.Drawing.Graphics Desen;
        System.Drawing.Pen Creion_negru;
        System.Drawing.SolidBrush Pensula_neagra;
        System.Drawing.SolidBrush Pensula_fundal;
        public Cerc cerc1;
        public Cerc cerc2;
        public Cerc cerc3;
        Point Cp1 = new Point(0, 0);
        Point Cp2 = new Point(0, 0);

        private void Form1_Load(object sender, EventArgs e)
        {
            Desen = this.CreateGraphics();
            Creion_negru = new System.Drawing.Pen(System.Drawing.Color.Black);
            Pensula_neagra = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Pensula_fundal = new System.Drawing.SolidBrush(this.BackColor);
            cerc1 = new Cerc();
            cerc2 = new Cerc();
            cerc3 = new Cerc();
            cerc1.Initializare_cerc(150, 60, 90);
            cerc2.Initializare_cerc(60, 155, 150);
            cerc3.Initializare_cerc(270, 190, 50);
        }
        public class Cerc
        {
            int x0, y0, Diametrul;
            int cateta_x, cateta_y;
            
            public void Desenez_cerc(System.Drawing.Graphics Zona_desenare, System.Drawing.Pen Creion_n)
            {
                Zona_desenare.DrawEllipse(Creion_n, x0, y0, Diametrul, Diametrul);
            }
            public void setc(System.Drawing.Graphics Zona_desenare, System.Drawing.Pen creion, int r)
            {
                int x = System.Convert.ToInt16(System.Convert.ToDouble(x0) + System.Convert.ToDouble(Diametrul - r) / 2);
                int y = System.Convert.ToInt16(System.Convert.ToDouble(y0) + System.Convert.ToDouble(Diametrul - r) / 2);
                Zona_desenare.DrawEllipse(creion, x + 1, y + 1, r, r);
            }
            public void Initializare_cerc(int pozx, int pozy, int diametrul)
            {
                x0 = pozx;
                y0 = pozy;
                Diametrul = diametrul;
            }
            public void Deseneaza_interior(System.Drawing.Graphics Zona_desenare, System.Drawing.Pen Creion_n, System.Drawing.SolidBrush Pensula_n, int unghi, int Unghi_start, Point Tangent_cerc, Point Centru_cerc)
            {
                cateta_x = Convert.ToInt32(Math.Sin(unghi) * (Diametrul / 2));
                cateta_y = Convert.ToInt32(Math.Cos(unghi) * (Diametrul / 2));
                Tangent_cerc.X = x0 + Diametrul / 2 - cateta_x;
                Tangent_cerc.Y = y0 + Diametrul / 2 + cateta_y;
                Centru_cerc.X = x0 + Diametrul / 2;
                Centru_cerc.Y = y0 + Diametrul / 2;
                Zona_desenare.DrawLine(Creion_n, Tangent_cerc, Centru_cerc);
                Zona_desenare.FillPie(Pensula_n, x0, y0, Diametrul, Diametrul, Unghi_start, 140);
            }
            public void Cerc_interior(System.Drawing.Graphics Zona_desenare, System.Drawing.SolidBrush Pensula_fond, int x1, int y1, int diametrul, int unghi_start)
            {
                Zona_desenare.FillPie(Pensula_fond, x1, y1, diametrul, diametrul, unghi_start, 140);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            cerc1.Desenez_cerc(Desen, Creion_negru);
            cerc1.Deseneaza_interior(Desen, Creion_negru,Pensula_neagra, 60, 288, Cp1, Cp2);
            cerc1.Cerc_interior(Desen, Pensula_fundal, 160, 70, 70, 292);

            cerc2.Desenez_cerc(Desen, Creion_negru);
            cerc2.Deseneaza_interior(Desen, Creion_negru, Pensula_neagra, 100, 60, Cp1, Cp2);
            cerc1.Cerc_interior(Desen, Pensula_fundal, 70, 165, 130, 56);

            cerc3.Desenez_cerc(Desen, Creion_negru);
            cerc3.Deseneaza_interior(Desen, Creion_negru, Pensula_neagra, 10,212, Cp1, Cp2);
            cerc1.Cerc_interior(Desen, Pensula_fundal, 280, 200, 30, 205);
        }
       
    }
}
