using Siticone.UI.HtmlRenderer.Adapters.Entities;
using Siticone.UI.WinForms.Suite;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Interface1.MyPoints;
using static Siticone.UI.Native.WinApi;

namespace Interface1
{
    public partial class InfoPoints : Form
    {
        public InfoPoints()
        {
            InitializeComponent();

        }

        public InfoPoints(List<Point> points)
        {
            InitializeComponent();
            foreach (var point in points)
            {
                listBox1.Items.Add($"X: {point.X} Y: {point.Y}");
            }
        }


        private void Form4_Load(object sender, EventArgs e)
        {
          
        }
        public void LoadPointsFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show("Файл не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] pointData = line.Split(';');

                    if (pointData.Length != 2)
                    {
                        continue;
                    }

                    int x, y;

                    if (int.TryParse(pointData[0], out x) && int.TryParse(pointData[1], out y))
                    {
                        listBox1.Items.Add($"X: {x} Y: {y}");
                    }
                }
            }

            MessageBox.Show("Точки загружены из файла", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
