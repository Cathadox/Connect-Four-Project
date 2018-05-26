using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        FourMatrix MatrixTable;
        DiskContainer DiskContainer;
        Player PlayerOne;
        Player PlayerTwo;
        bool turn;
        private void Form1_Load(object sender, EventArgs e)
        {

            this.Width = 1300;
            this.Height = 900;
            this.CenterToScreen();
            PlayerOne = new PlayerOne("Boban");
            PlayerTwo = new PlayerTwo("Dragan");
            MatrixTable = new FourMatrix(this.Width);
            DiskContainer = new DiskContainer(this.Width);
            redcounter.Location = new Point((int)DiskContainer.RedX-20, (int)DiskContainer.RedY-100);
            yellowcounter.Location = new Point((int)DiskContainer.YellowX-20, (int)DiskContainer.YellowY-100);
            redcounter.Text = "21";
            yellowcounter.Text = "21";
            turn = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            MatrixTable.Draw(g);
            DiskContainer.Draw(g);
            //Matrix.DrawMove(e.Graphics, PlayerOne, 2, 3);
        }

       

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (turn)
            {
                try
                {
                    MatrixTable.DrawMove(g, PlayerOne, e.Location, label1);
                    turn = !turn;
                }
                catch (Exception ex)
                {
                    label1.Text = "You Cannot Put Disks Outside Of The Table, They'll Fallout! ";
                }
            }
            else
            {
                try
                {
                    MatrixTable.DrawMove(g, PlayerTwo, e.Location, label1);
                    turn = !turn;
                }
                catch (Exception ex)
                {
                    label1.Text = "You Cannot Put Disks Outside Of The Table, They'll Fallout! ";
                }
            }
            if (PlayerOne.CheckWin(MatrixTable.Matrix))
                MessageBox.Show("YOU BOBAN HAVE WON THE DERBY");
            if(PlayerTwo.CheckWin(MatrixTable.Matrix))
                MessageBox.Show("YOU DRAGAN HAVE WON THE DERBY");
        }
    }
}
