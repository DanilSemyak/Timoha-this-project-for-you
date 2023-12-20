using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Random rnd = new Random();



            g.Clear(Color.White);
            int kolPoint = int.Parse(textBox1.Text);
            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < kolPoint; i++)
            {
                List<int> arr1 = new List<int>();
                int x1 = rnd.Next(10, 600);
                int y1 = rnd.Next(10, 350);
                g.DrawRectangle(Pens.Black, x1, y1, 1, 1);
                arr1.Add(x1);
                arr1.Add(y1);
                arr.Add(arr1);

            }

            double s = int.MaxValue;
            List<Point> arr3 = new List<Point> {new Point(0,0), new Point(2, 0), new Point(1, 0)};
            for (int i = 0; i < kolPoint - 2; i++)
            {
                for (int j = i + 1; j < kolPoint - 1; j++)
                {

                    Point point1 = new Point(arr[i][0], arr[i][1]);
                    Point point2 = new Point(arr[j][0], arr[j][1]);
                    //g.DrawLine(Pens.Black, point1, point2);
                    double k = (arr[j][1] - arr[i][1]) / (arr[j][0] - arr[i][0]);
                    double b = arr[i][1] - (k * arr[i][0]);
                    for (int f = j + 1; f < kolPoint; f++)
                    {
                        if (((k * arr[f][0]) + b) != arr[f][1])
                        {
                            double ss = 0.5 * Math.Abs(((arr[j][1] - arr[i][1]) * (arr[f][0] - arr[i][0]) - (arr[f][1] - arr[i][1]) * (arr[j][0] - arr[i][0])));
                            if (ss < s)
                            {
                                s = ss;

                                Point p1 = new Point(arr[i][0], arr[i][1]);
                                Point p2 = new Point(arr[j][0], arr[j][1]);
                                Point p3 = new Point(arr[f][0], arr[f][1]);

                                arr3[0] = p1;
                                arr3[1] = p2;
                                arr3[2] = p3;
                            }
                        }
                    }
                }
            }
            g.DrawLine(Pens.Black, arr3[0], arr3[1]);
            g.DrawLine(Pens.Black, arr3[1], arr3[2]);
            g.DrawLine(Pens.Black, arr3[2], arr3[0]);
            label1.Text = "Площадь треушолника: " + s;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
