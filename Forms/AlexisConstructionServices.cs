using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alexisRetry.Forms
{
    public partial class AlexisConstructionServices : Form
    {
        public AlexisConstructionServices()
        {
            InitializeComponent();
        }

        private void AlexisConstructionServices_Load(object sender, EventArgs e)
        {

        }

        private void buttonBookService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHoursRendered.Text))
            {
                textBoxHoursRendered.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(textBoxServiceFee.Text))
            {
                textBoxServiceFee.Text = "0";
            }

            ServiceObjects.Service = comboBoxServiceBook.Text;
            ServiceObjects.HoursRented = int.Parse(textBoxServiceFee.Text);
            ServiceObjects.Fee = int.Parse(textBoxServiceFee.Text);


        }

        private void comboBoxServiceBook_TextChanged(object sender, EventArgs e)
        {
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
        }
    }
}
