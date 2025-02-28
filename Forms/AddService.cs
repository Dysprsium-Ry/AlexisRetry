using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using alexisRetry.Classes;

namespace alexisRetry.Forms
{
    public partial class Form3B : Form // Renamed from *3*b to a valid identifier
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public Form3B()
        {
            InitializeComponent();
            this.KeyPreview = true;

            panelMain.KeyDown += Form3B_KeyPress;

            
            panelMain.MouseDown += PanelMain_MouseDown;
            panelMain.MouseMove += PanelMain_MouseMove;
            panelMain.MouseUp += PanelMain_MouseUp;
        }

        private void Form3B_KeyPress(object sender, KeyEventArgs e)
        {
            // Your key press handling code here
        }

        private void PanelMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void PanelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void PanelMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Form3B_Load(object sender, EventArgs e)
        {
            dataload();
        }

        private void dataUploader(object sender, KeyEventArgs e)
        {
            multipleBookings.Service1 = string.IsNullOrWhiteSpace(comboBoxAddService.Text) ? "" : comboBoxAddService.Text;

            multipleBookings.Service2 = string.IsNullOrWhiteSpace(comboBoxAddService2.Text) ? "" : comboBoxAddService2.Text;

            multipleBookings.Fee1 = string.IsNullOrWhiteSpace(textBox1Fee.Text) ? 0 : int.TryParse(textBox1Fee.Text, out int fee1) ? fee1 : 0;

            multipleBookings.Fee2 = string.IsNullOrWhiteSpace(textBox2Fee.Text) ? 0 : int.TryParse(textBox2Fee.Text, out int fee2) ? fee2 : 0;

            multipleBookings.time1 = string.IsNullOrWhiteSpace(textBoxTime1.Text) ? 0 : int.TryParse(textBoxTime1.Text, out int time1) ? time1 : 0;

            multipleBookings.time2 = string.IsNullOrWhiteSpace(textBoxTime2.Text) ? 0 : int.TryParse(textBoxTime2.Text, out int time2) ? time2 : 0;
        }

        private void dataload()
        {
            comboBoxAddService.DataSource = ServicesClass.GetServices();
            if (textBox1Fee != null)
            {
                comboBoxAddService2.DataSource = ServicesClass.GetServices();
            }
        }
    }
}