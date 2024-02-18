using Pokemon_FireRed.Entities.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pokemon_FireRed
{
    public partial class FormInventory : Form
    {
        private Panel panelInventory;
        public FormInventory()
        {
            InitializeComponent();
            LoadComponent();
        }

        private void FormInventory_Load(object sender, EventArgs e)
        {

        }
        private void LoadComponent()
        {
            ClientSize = new Size(Inf.SCREENW, Inf.SCREENH);
            BackColor = Color.Black;
            this.CenterToScreen();

            panelInventory = new Panel();
            panelInventory.BackColor = Color.PeachPuff;
            panelInventory.Size = new Size(Inf.WIDTH, Inf.HEIGHT);

            int pointX = (Screen.PrimaryScreen.Bounds.Width - panelInventory.Width) / 2;
            int pointY = (Screen.PrimaryScreen.Bounds.Height - panelInventory.Height) / 2;

            panelInventory.Location = new Point(pointX, pointY);


        }
    }
}
