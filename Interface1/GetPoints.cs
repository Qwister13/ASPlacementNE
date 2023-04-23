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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Interface1
{
    public partial class GetPoints : Form
    {
        private PointStorage pointStorage = new PointStorage();
        MyPoints.DrawingPoint newPoint = new DrawingPoint();

        List<Point> selectedPoints = new List<Point>();
        public GetPoints()
        {
            InitializeComponent();
                       

            ToolStripMenuItem OpenNewFile = new ToolStripMenuItem("Открыть новый файл");
            OpenNewFile.Click += OpenFile;
            menuStrip2.Items.Add(OpenNewFile);

            ToolStripMenuItem SaveNewFile = new ToolStripMenuItem("Сохранить файл");
            SaveNewFile.Click += SavePointsToFile;
            menuStrip2.Items.Add(SaveNewFile);

            DoubleBuffered = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button1, "Удалить все точки");
            ToolTip1.SetToolTip(this.button2, "Удалить выбранную точку");

            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "План помещения (*.jpg)|*.jpg|План помещения (*.png)|*.png";
            openDlg.DefaultExt = "*.jpg |*.jpg ";
            openDlg.FilterIndex = 1;
            openDlg.Title = "Открытие файла плана помещения";

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(openDlg.FileName);
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                    DialogResult result = DialogResult = MessageBox.Show("Файл открыт",
                    "Открыт", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                catch
                {
                    DialogResult result = DialogResult = MessageBox.Show("Файл поврежден \nВыберите другой файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }

            }
            else
            {
                Close();
            }

        }

        List<Point> myPoints = new List<Point>();
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {

            MouseClick += PictureBox1_Click;
            //myPoints.Dispose();
        }
        Bitmap image;
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "Scheme Location (*.jpg)|*.jpg|План помещения (*.png)|*.png";
            openDlg.DefaultExt = "*.jpg |*.jpg ";
            openDlg.FilterIndex = 1;
            openDlg.Title = "Open file Scheme";

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(openDlg.FileName);
                    this.pictureBox1.Size = image.Size;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                    MessageBox.Show("Файл открыт");
                }
                catch
                {
                    DialogResult result = DialogResult = MessageBox.Show("Файл поврежден \nВыберите другой файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    Close();
                }

            }
            else
            {
                Close();
            }

        }

        private void SavePointsToFile(object sender, EventArgs e)
        {
            if (myPoints.Count == 0)
            {
                MessageBox.Show("Нет точек для сохранения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
            saveFileDialog.Title = "Сохранить точки в файл";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (var point in myPoints)
                    {
                        sw.WriteLine($"{point.X};{point.Y}");
                    }
                }

                MessageBox.Show("Точки сохранены в файл", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /*private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Формат схемы (*.jpg)|*.jpg|Формат схемы (*.png)|*.png";
            saveDlg.DefaultExt = "*.png";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";

            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;              

            RichTextBoxStreamType stream_type;
            if (saveDlg.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;

            MessageBox.Show("Файл сохранен");
        }*/

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            textBox1.Text = e.X.ToString();
            textBox1.Text = e.Y.ToString();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            double X, Y;
            String position = "";
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                textBox1.Text = "X= " + mouseEventArgs.X + " Y= " + mouseEventArgs.Y;
            }

            if(listBox1.Items.Contains("X:" + mouseEventArgs.X + " Y: " + mouseEventArgs.Y))
            {
                listBox1.Items.Remove("X:" + mouseEventArgs.X + " Y: " + mouseEventArgs.Y);
            }
            listBox1.Items.Add("X:" + mouseEventArgs.X + " Y: " + mouseEventArgs.Y);
            myPoints.Add(mouseEventArgs.Location);
            (sender as Control).Invalidate();

        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode= SmoothingMode.HighQuality;
            foreach (var point in myPoints)
            {
                if (selectedPoints.Contains(point)) continue; 
                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(point, new Size(5, 5)));
            }
            foreach (var selectedPoint in selectedPoints)
            {     
                g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(selectedPoint, new Size(6, 6)));
            }
            
        }

     
        private void DeleteAll_Click(object sender, EventArgs e)
        {
            MyPoints.DrawingPoint mypoint = new MyPoints.DrawingPoint();      
            myPoints.Clear();
            listBox1.Items.Clear();
            pictureBox1.Refresh();
            pictureBox1.Invalidate();
            

        }

        private void DeleteSelect_Click(object sender, EventArgs e)
        {
          
            if (listBox1.SelectedIndex != -1)
            {
                myPoints.RemoveAll(point => selectedPoints.Contains(point));
                listBox1.Items.Clear();
                foreach (var point in myPoints)
                    listBox1.Items.Add($"X: {point.X} Y: {point.Y}");;
                selectedPoints.Clear();
                pictureBox1.Invalidate();
                
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {    
            var listbox1 = (sender as ListBox);
            selectedPoints = listbox1.SelectedItems
                .Cast<string>()
                .Select(item => item
                .Split(new char[] { 'X', 'Y', ' ', '=', ':' }, StringSplitOptions.RemoveEmptyEntries))
                .Select(point => new Point(int.Parse(point[0]), int.Parse(point[1])))
                .ToList();
            pictureBox1.Invalidate();
        }
    }
}


