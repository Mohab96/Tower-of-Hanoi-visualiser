using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi_tower_visualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int disk = 0, movesCnt = 0;
        int lastA = 0, lastB = 0, lastC = 0;
        double speed = 0.5;
        bool start = false;

        private void button2_Click(object sender, EventArgs e)
        {
            speed = 1.0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            speed = 0.5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            speed = 0.2;
        }

        void towerOfHanoi(int n, char from_rod, char to_rod, char aux_rod)
        {
            if (n == 0)
                return;

            towerOfHanoi(n - 1, from_rod, aux_rod, to_rod);
            string instruction = "Move disk " + n + " from rod " + from_rod + " to rod " + to_rod;
            toDo.Text = instruction;

            Task.Delay(TimeSpan.FromSeconds(speed)).Wait();

            if (n == 1) move(tile1, from_rod, to_rod);
            else if (n == 2) move(tile2, from_rod, to_rod);
            else if (n == 3) move(tile3, from_rod, to_rod);
            else if (n == 4) move(tile4, from_rod, to_rod);
            else if (n == 5) move(tile5, from_rod, to_rod);
            else if (n == 6) move(tile6, from_rod, to_rod);
            else if (n == 7) move(tile7, from_rod, to_rod);
            else if (n == 8) move(tile8, from_rod, to_rod);
            else if (n == 9) move(tile9, from_rod, to_rod);

            movesCnt++;

            towerOfHanoi(n - 1, aux_rod, to_rod, from_rod);
        }

        void ArrangeDisks()
        {
            lastA = baseA.Top - 20;
            lastB = baseB.Top - 20;
            lastC = baseC.Top - 20;

            for (int i = disk; i >= 1; i--)
            {
                if (i == 9) { tile9.Top = lastA; lastA -= tile9.Height + 5; }
                else if (i == 8) { tile8.Top = lastA; lastA -= tile8.Height + 5; }
                else if (i == 7) { tile7.Top = lastA; lastA -= tile7.Height + 5; }
                else if (i == 6) { tile6.Top = lastA; lastA -= tile6.Height + 5; }
                else if (i == 5) { tile5.Top = lastA; lastA -= tile5.Height + 5; }
                else if (i == 4) { tile4.Top = lastA; lastA -= tile4.Height + 5; }
                else if (i == 3) { tile3.Top = lastA; lastA -= tile3.Height + 5; }
                else if (i == 2) { tile2.Top = lastA; lastA -= tile2.Height + 5; }
                else if (i == 1) { tile1.Top = lastA; lastA -= tile1.Height + 5; }
            }

            for (int i = disk + 1; i <= 9; i++)
            {
                if (i == 9) { tile9.Visible = false; }
                else if (i == 8) { tile8.Visible = false; }
                else if (i == 7) { tile7.Visible = false; }
                else if (i == 6) { tile6.Visible = false; }
                else if (i == 5) { tile5.Visible = false; }
                else if (i == 4) { tile4.Visible = false; }
                else if (i == 3) { tile3.Visible = false; }
                else if (i == 2) { tile2.Visible = false; }
                else if (i == 1) { tile1.Visible = false; }
            }
        }

        void move(PictureBox tile, char from, char to)
        {
            Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
            tile.Top = label1.Top;
            Task.Delay(TimeSpan.FromSeconds(speed)).Wait();

            if (from == 'A')
            {
                if (to == 'B')
                {
                    // from a to b
                    int diff = baseB.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label7.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseB.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastB;
                    lastB -= 20;
                    lastA += 20;
                }
                else if (to == 'C')
                {
                    // from a to c
                    int diff = baseC.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label7.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label5.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label6.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseC.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastC;
                    lastC -= 20;
                    lastA += 20;
                }
            }
            else if (from == 'B')
            {
                if (to == 'A')
                {
                    // from b to a
                    int diff = baseA.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label7.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseA.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastA;
                    lastA -= 20;
                    lastB += 20;
                }
                else if (to == 'C')
                {
                    // from b to c
                    int diff = baseC.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label6.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseC.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastC;
                    lastC -= 20;
                    lastB += 20;
                }
            }
            else if (from == 'C')
            {
                if (to == 'B')
                {
                    // from c to b
                    int diff = baseB.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label6.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseB.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastB;
                    lastB -= 20;
                    lastC += 20;
                }
                else if (to == 'A')
                {
                    // form c to a
                    int diff = baseA.Width - tile.Width;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label6.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label5.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = label7.Left;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Left = baseA.Left + diff / 2;
                    Task.Delay(TimeSpan.FromSeconds(speed)).Wait();
                    tile.Top = lastA;
                    lastA -= 20;
                    lastC += 20;
                }
            }
        }

        private void Visualise_Tick(object sender, EventArgs e)
        {
            if (start)
            {
                Task.Factory.StartNew(() => towerOfHanoi(disk, 'A', 'C', 'B'));
                start = false;
                Visualise.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disk = int.Parse(numberOfTiles.Text);
            ArrangeDisks();
            start = true;
        }
    }
}
