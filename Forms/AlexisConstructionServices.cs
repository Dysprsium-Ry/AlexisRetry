using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Linq;
using System.Windows.Forms;

namespace alexisRetry.Forms
{
    public partial class AlexisConstructionServices : Form
    {
        public AlexisConstructionServices()
        {
            InitializeComponent();
            refresh();
        }

        private void AlexisConstructionServices_Load(object sender, EventArgs e)
        {

        }

        #region ServiceTab
        #region Method
        //public void registerService()
        //{
        //    if (!(comboBoxServiceBook.Items.Contains(comboBoxServiceBook.Text)))
        //    {
        //        ServicesClass.AddServicetoLib();
        //    }
        //}
        #endregion

        #region eventHandlers

        private void buttonBookService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHoursRendered.Text))
            {
                MessageBox.Show("Input a Hours Rendered", "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxServiceFee.Text))
            {
                MessageBox.Show("Input a Fee", "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(ClientObjects.ClientId == 0)
            {
                ClientObjects.ClientId = 1;
            }

            if (string.IsNullOrWhiteSpace(comboBoxClientUsername.Text))
            {
                MessageBox.Show("Input a Username", "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            serviceBooking.clientUsername = comboBoxClientUsername.Text;
            serviceBooking.Service = comboBoxServiceBook.Text;
            serviceBooking.BookedDate = dateTimePickerReservationDate.Value;
            serviceBooking.HoursRented = int.Parse(textBoxHoursRendered.Text);
            serviceBooking.Fee = int.Parse(textBoxServiceFee.Text);

            ServicesClass.ServiceBooking();
            if (ServiceValidator.BookingSuccess)
            {
                MessageBox.Show("Booking Failed, unexpected error occurred.", "Error", MessageBoxButtons.RetryCancel);
            }

            //registerService();
        }

        private void comboBoxServiceBook_TextChanged(object sender, EventArgs e)
        {
            serviceBooking.Service = comboBoxServiceBook.Text;
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
        }

        private void comboBoxClientUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceObjects.Clientusername = comboBoxClientUsername.Text;
            ClientClass.ClientIdList();
        }

        private void textBoxNumericalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        #endregion

        #endregion

        #region Client
        private void buttonClientAdd_Click(object sender, EventArgs e)
        {
            ClientRegister.username = textBoxClientUsername.Text;
            ClientRegister.email = textBoxClientEmail.Text;
            ClientRegister.PhoneNumber = Convert.ToInt64(textBoxClientPhoneNumber.Text);
            ClientRegister.name = textBoxClientName.Text;

            foreach (Control control in tabPageClients.Controls)
            {
                if (control is TextBox textbox && textbox == null)
                {
                    MessageBox.Show($"{textbox.Name} cannot be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            ClientClass.AddClient();
            refresh();
        }

        private void refresh()
        {
            ServicesClass.ServicesLoad();
            ClientClass.ClientsList();
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
            ServiceLibraryClass.ServiceLib(dataGridViewServiceLibrary);
            comboBoxClientUsername.DataSource = ClientObjects.ClientUsername;
        }
        #endregion

        #region Service Library
        private void buttonAddLibItem_Click(object sender, EventArgs e)
        {
            ServiceLibraryObject.service = comboBoxServiceslib.Text;
            ServiceLibraryObject.tool = textBoxToolLib.Text;
            ServiceLibraryObject.fee = Convert.ToInt32(textBoxFeepHourLib.Text);

            ServiceLibraryClass.LibLoader();
            refresh();
        }
        #endregion
    }
}
