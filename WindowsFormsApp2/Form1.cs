using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        PictureBox[] pb = new PictureBox[1000];
        public Form1()
        {
            InitializeComponent();
        }

        public static int[,] Figure = new int[3, 3];
        public static int[,] Map = new int[100, 100];
        public static int[,] MapTemp = new int[100, 100];
        public static int[,] MapHistore = new int[100, 100];
        public static int[,] MiniMash = new int[3, 3];

        public static void DrawMap(PictureBox[] pb)
        {
            
        }
        public static void DrawFigure(string value)
        {
            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            if (value == "Rectangle")
            {
                Figure[0, 0] = life.Lifeless; Figure[0, 1] = life.Lifeless; Figure[0, 2] = life.Lifeless;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = dead.Dead; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = life.Lifeless; Figure[2, 1] = life.Lifeless; Figure[2, 2] = life.Lifeless;

            }
            if (value == "X")
            {
                Figure[0, 0] = life.Lifeless; Figure[0, 1] = dead.Dead; Figure[0, 2] = life.Lifeless;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = life.Lifeless; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = life.Lifeless; Figure[2, 1] = dead.Dead; Figure[2, 2] = life.Lifeless;
            }
            if (value == "Plus")
            {
                Figure[0, 0] = dead.Dead; Figure[0, 1] = life.Lifeless; Figure[0, 2] = dead.Dead;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = life.Lifeless; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = dead.Dead; Figure[2, 1] = life.Lifeless; Figure[2, 2] = dead.Dead;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Map[50 + i, 50 + j] = Figure[i, j];
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Rectangle");
            comboBox1.Items.Add("X");
            comboBox1.Items.Add("Plus");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            int count = 0;
            int y = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    count++;
                    PictureBox pb2 = new PictureBox();
                    pb2.BorderStyle = BorderStyle.FixedSingle;
                    pb2.Size = new System.Drawing.Size(10, 10);
                    if (j % 2 == 0)
                    {
                        pb2.BackColor = Color.Blue;

                    }
                    else
                    {
                        pb2.BackColor = Color.White;
                    }
                    pb2.Location = new System.Drawing.Point(pb2.Location.X + (count * 10), pb2.Location.Y + y);
                    pb[j] = pb2;
                    Controls.Add(pb[j]);

                }
                y += 10;
                count = 0;
            }
            
            for (int i = 0; i < Map.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Map.GetUpperBound(0) + 1; j++)
                {
                    Map[i, j] = dead.Dead;
                }
            }
            //We maked our map all dead
            if (comboBox1.AccessibilityObject.Value == "Rectangle")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            if (comboBox1.AccessibilityObject.Value == "X")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            if (comboBox1.AccessibilityObject.Value == "Plus")
            {
                DrawFigure(comboBox1.AccessibilityObject.Value);
            }
            Form1_Load(sender, e);
            //Later we can add new figures

            //while (true)
            //{
            //    for (int i = 0; i < Map.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < Map.GetLength(1); j++)
            //        {
            //            if (Map[i, j] == dead.Dead)
            //            {
            //                MapTemp[i, j] = Map[i, j];
            //            }
            //            if (Map[i, j] == life.Lifeless)
            //            {
            //                if (i > 0 && i < 99 && j > 0 && j < 99)
            //                {
            //                    MiniMash[0, 0] = Map[i - 1, j - 1]; MiniMash[0, 1] = Map[i, j - 1]; MiniMash[0, 2] = Map[i + 1, j - 1];
            //                    MiniMash[1, 0] = Map[i - 1, j]; MiniMash[1, 1] = Map[i, j]; MiniMash[1, 2] = Map[i + 1, j];
            //                    MiniMash[2, 0] = Map[i - 1, j + 1]; MiniMash[2, 1] = Map[i, j + 1]; MiniMash[2, 2] = Map[i + 1, j + 1];
            //                    RewriteToSeconsArr.Checkking(MiniMash, ref MapTemp, i, j);
            //                }

            //            }
            //        }
            //    }
            //    Map = MapTemp;
            //    countOfDead++;
            //}


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Lifeless life = new Lifeless();
            Dead dead = new Dead();

            int countOfDead = 0;
            while (countOfDead!=100)
            {
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        if (Map[i, j] == dead.Dead)
                        {
                            MapTemp[i, j] = Map[i, j];
                        }
                        if (Map[i, j] == life.Lifeless)
                        {
                            if (i > 0 && i < 99 && j > 0 && j < 99)
                            {
                                MiniMash[0, 0] = Map[i - 1, j - 1]; MiniMash[0, 1] = Map[i, j - 1]; MiniMash[0, 2] = Map[i + 1, j - 1];
                                MiniMash[1, 0] = Map[i - 1, j]; MiniMash[1, 1] = Map[i, j]; MiniMash[1, 2] = Map[i + 1, j];
                                MiniMash[2, 0] = Map[i - 1, j + 1]; MiniMash[2, 1] = Map[i, j + 1]; MiniMash[2, 2] = Map[i + 1, j + 1];
                                RewriteToSeconsArr.Checkking(MiniMash, ref MapTemp, i, j);
                            }

                        }
                    }
                }
                Map = MapTemp;
                countOfDead++;
            }

        }
    }
}
