using System;
using System.Drawing;
using System.Windows.Forms;

namespace Interface1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            //getInit();


            this.StartPosition = FormStartPosition.CenterScreen;


            //Пункт меню Проект
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Проект");
            ToolStripMenuItem CreateProject = new ToolStripMenuItem("Создать проект");
            CreateProject.Click += OpenBD_Click;
            fileItem.DropDownItems.Add(CreateProject);

            //Подпункт меню Проект
            ToolStripMenuItem OpenBD = new ToolStripMenuItem("Открыть БД");
            OpenBD.Click += OpenBD_Click;
            OpenBD.ShortcutKeys = Keys.Control | Keys.T;
            fileItem.DropDownItems.Add(OpenBD);

            //Подпункт меню Проект
            ToolStripMenuItem OpenPlan = new ToolStripMenuItem("Открыть чертеж помещения");
            OpenPlan.Click += OpenPlan_Click;
            OpenPlan.ShortcutKeys = Keys.Control | Keys.Y;
            fileItem.DropDownItems.Add(OpenPlan);

            //Подпункт меню Проект
            ToolStripMenuItem OpenScheme = new ToolStripMenuItem("Открыть схему подключения");
            OpenScheme.Click += OpenScheme_Click;
            OpenScheme.ShortcutKeys = Keys.Control | Keys.E;
            fileItem.DropDownItems.Add(OpenScheme);

            //Подпункт меню Проект
            ToolStripMenuItem Save = new ToolStripMenuItem("Сохранить");
            Save.Click += Save_Click;
            Save.ShortcutKeys = Keys.Control | Keys.S;
            fileItem.DropDownItems.Add(Save);

            //Подпункт меню Проект
            ToolStripMenuItem Close = new ToolStripMenuItem("Закрыть");
            Close.Click += Close_Click;
            Close.ShortcutKeys = Keys.Control | Keys.Escape;
            fileItem.DropDownItems.Add(Close);
            menuStrip1.Items.Add(fileItem);


            //Пункт меню Проектные данные
            ToolStripMenuItem fileItemData = new ToolStripMenuItem("Проектные данные");
            ToolStripMenuItem DataItem = new ToolStripMenuItem("Данные об оборудовании");
            DataItem.Click += DataItem_Click;
            fileItemData.DropDownItems.Add(DataItem);

            //Подпункт меню Проектные данные
            ToolStripMenuItem DataOffice = new ToolStripMenuItem("Данные о помещении");
            DataOffice.Click += DataOffice_Click;
            fileItemData.DropDownItems.Add(DataOffice);

            //Подпункт меню Проектные данные
            ToolStripMenuItem DataPoint = new ToolStripMenuItem("Данные о контрольных точках");
            DataPoint.Click += DataPoint_Click;
            fileItemData.DropDownItems.Add(DataPoint);
            menuStrip1.Items.Add(fileItemData);

            //Пункт меню Выполнить
            ToolStripMenuItem MakeProjectItem = new ToolStripMenuItem("Выполнить");
            MakeProjectItem.DropDownItems.Add("Запуск алгоритма размещения сетевого оборудования");
            MakeProjectItem.DropDownItems.Add("Подготовка проектной документации");
            menuStrip1.Items.Add(MakeProjectItem);


            //Пункт меню Справка
            ToolStripMenuItem Referens = new ToolStripMenuItem("Справка");
            ToolStripMenuItem Support = new ToolStripMenuItem("Помощь");
            Support.Click += Support_Clickl;
            Referens.DropDownItems.Add(Support);

            ToolStripMenuItem aboutProgram = new ToolStripMenuItem("О программе");
            aboutProgram.Click += AboutProgram_Click;
            Referens.DropDownItems.Add(aboutProgram);
            menuStrip1.Items.Add(Referens);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.AutoSize = true;
        }


        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //Функция вывода помощи
        private void Support_Clickl(object sender, EventArgs e)
        {
            DialogResult result = DialogResult = MessageBox.Show("Для помощи обратитесь по почте: \nBasyrovNI@gmail.com ",
                "Помощь", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        //Функция вывода инф-ии о программе
        private void AboutProgram_Click(object sender, EventArgs e)
        {

            DialogResult result = DialogResult = MessageBox.Show("Автоматизированная система размещения сетевого оборудования " +
                "\n\nАвтор: Басыров Наиль Илдарович \nГруппа 4414 ",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Question);


        }

        //Функция вывода данных о точках
        private void DataPoint_Click(object sender, EventArgs e)
        {
            InfoPoints newForm = new InfoPoints();
            newForm.Show();
        }

        //Функция вывода данных о выбранном оборудовании
        private void DataItem_Click(object sender, EventArgs e)
        {
            InfoEquipment newForm = new InfoEquipment();
            newForm.Show();
        }

        //Функция вывода данных о помещении 
        private void DataOffice_Click(object sender, EventArgs e)
        {
            InfoLocation newForm = new InfoLocation();
            newForm.Show();
        }

        //Реализация кнопки открытия БД
        private void OpenBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "DataBase File (*.mdb)|*.mdb";
            openDlg.DefaultExt = "*.mdb";
            openDlg.FilterIndex = 1;
            openDlg.Title = "Open DataBase File";

            if (openDlg.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openDlg.FileName;
            string fileText = System.IO.File.ReadAllText(filename);

            MessageBox.Show("Файл открыт");

            return;

        }

        //Реализация кнопки открытия Плана Помещения
        private void OpenPlan_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();

            openDlg.Filter = "План помещения (*.jpg)|*.jpg|План помещения (*.png)|*.png";
            openDlg.DefaultExt = "*.jpg |*.jpg ";
            openDlg.FilterIndex = 1;
            openDlg.Title = "Открытие файла плана помещения";


            if (openDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openDlg.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            MessageBox.Show("Файл открыт");
            Form2 newForm = new Form2();
            newForm.Show();
            return;
        }

        //Реализация кнопки открытия Схемы установки
        private void OpenScheme_Click(object sender, EventArgs e)
        {
            GetPoints ControlPoints = new GetPoints();
            ControlPoints.Show();
            return;

        }

        //Реализация кнопки сохранения проекта
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";

            saveDlg.Filter = "Text File (*.txt)|*.txt|Text File (*.png)|*.png";
            saveDlg.DefaultExt = "*.png";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the Project";

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
        }

        //Реализация кнопки закрытия проекта
        private void Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {

            }
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            textBox1.Text = e.X.ToString();
            textBox1.Text = e.Y.ToString();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            double X, Y;
            String position = "";
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                textBox1.Text = "X = " + mouseEventArgs.X + " Y = " + mouseEventArgs.Y;
            }
        }

       /* private void getInit()
        {
            SettingsDark get = new SettingsDark();
            get.readIni();
            if (get.theme == "Темный режим")
            {
                ToggleSwitch1.Checked = true;               
                this.BackColor = Color.FromArgb(32, 33, 36);
                this.ForeColor = Color.White;

            }
            else
            {
                ToggleSwitch1.Checked = false;
                
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(32, 33, 36);

            }
        }*/
        /*private void ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            SettingsDark set = new SettingsDark();
            if (ToggleSwitch1.Checked == true)
            {

                set.writeIni("SECTION", "key", "Темный режим");
                this.BackColor = Color.FromArgb(32, 33, 36);
                this.ForeColor = Color.White;
               
            }
            else
            {

                set.writeIni("SECTION", "key", "Светлый режим");
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(32, 33, 36);
               
            }
        }*/

    }

}
