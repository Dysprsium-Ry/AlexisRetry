using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Windows.Forms;

namespace alexisRetry.Forms
{
    public partial class AlexisConstructionServices : Form
    {
        public AlexisConstructionServices()
        {
            InitializeComponent();
            ClientClass.ClientsList();
            comboBoxClientUsername.DataSource = ClientObjects.ClientUsername;
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

            ServiceObjects.Clientusername = comboBoxClientUsername.Text;
            ServiceObjects.Service = comboBoxServiceBook.Text;
            ServiceObjects.BookedDate = dateTimePickerReservationDate.Value;
            ServiceObjects.HoursRented = int.Parse(textBoxServiceFee.Text);
            ServiceObjects.Fee = int.Parse(textBoxServiceFee.Text);

            ServicesClass.ServiceBooking();
            if (ServiceValidator.BookingSuccess)
            {
                MessageBox.Show("Booking Failed, unexpected error occurred.", "Error", MessageBoxButtons.RetryCancel);
            }
        }

        private void comboBoxServiceBook_TextChanged(object sender, EventArgs e)
        {
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
        }

        private void comboBoxClientUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceObjects.Clientusername = comboBoxClientUsername.Text;
            ClientClass.ClientIdList();
        }
    }
}
