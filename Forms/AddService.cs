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
    public partial class Form3B : Form
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
            // Key press handling code here
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

        private void dataload()
        {
            comboBoxAddService.DataSource = ServicesClass.GetServices();
            if (textBox1Fee != null)
            {
                comboBoxAddService2.DataSource = ServicesClass.GetServices();
            }
        }

        private void textboxandComboBox_TextChanged(object sender, EventArgs e)
        {
            multipleBookings.Service1 = string.IsNullOrWhiteSpace(comboBoxAddService.Text) ? "" : comboBoxAddService.Text;
            multipleBookings.Service2 = string.IsNullOrWhiteSpace(comboBoxAddService2.Text) ? "" : comboBoxAddService2.Text;
            multipleBookings.Fee1 = string.IsNullOrWhiteSpace(textBox1Fee.Text) ? 0 : int.TryParse(textBox1Fee.Text, out int fee1) ? fee1 : 0;
            multipleBookings.Fee2 = string.IsNullOrWhiteSpace(textBox2Fee.Text) ? 0 : int.TryParse(textBox2Fee.Text, out int fee2) ? fee2 : 0;
            multipleBookings.time1 = string.IsNullOrWhiteSpace(textBoxTime1.Text) ? 0 : int.TryParse(textBoxTime1.Text, out int time1) ? time1 : 0;
            multipleBookings.time2 = string.IsNullOrWhiteSpace(textBoxTime2.Text) ? 0 : int.TryParse(textBoxTime2.Text, out int time2) ? time2 : 0;
        }

        private void comboBoxAddService_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceBooking.Service = comboBoxAddService.Text;
            ServicesClass.PriceFetcher();
            textBox1Fee.Text = ServiceBooking.HourlyRate.ToString();
        }
        private void comboBoxAddService2_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceBooking.Service = comboBoxAddService2.Text;
            ServicesClass.PriceFetcher();

            textBox2Fee.Text = ServiceBooking.HourlyRate.ToString();
        }

        #region textboxEventHandlers
        private void textBoxTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            HandleInputDisplay(e);
            multipleBookings.totalFee1 = multipleBookings.Fee1 * multipleBookings.time1;
            textBoxTotalFee1.Text = multipleBookings.totalFee1.ToString();
        }
        private void textBoxTime2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            HandleInputDisplay2(e);
            multipleBookings.totalFee2 = multipleBookings.Fee2 * multipleBookings.time2;
            textBoxTotalFee2.Text = multipleBookings.totalFee2.ToString();
        }
        private void HandleInputDisplay(KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTime1.Text))
            {
                textBoxTime1.Text = "0";
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                textBoxTime1.Text = "0";
                e.Handled = true;
                return;
            }

            if (textBoxTime1.Text == "0")
            {
                if (e.KeyChar != '0')
                {
                    textBoxTime1.Text = e.KeyChar.ToString();
                }
                e.Handled = true;
            }
            textBoxTime1.SelectionStart = textBoxTime1.Text.Length;
        }
        private void HandleInputDisplay2(KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTime2.Text))
            {
                textBoxTime2.Text = "0";
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                textBoxTime2.Text = "0";
                e.Handled = true;
                return;
            }

            if (textBoxTime2.Text == "0")
            {
                if (e.KeyChar != '0')
                {
                    textBoxTime2.Text = e.KeyChar.ToString();
                }
                e.Handled = true;
            }
            textBoxTime2.SelectionStart = textBoxTime2.Text.Length;
        }
        #endregion

        private void panelMain_MouseHover(object sender, EventArgs e)
        {
            ServicesClass.OverallTotalFee();
        }
    }
}