using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Windows.Forms;

namespace alexisRetry.Forms
{
    public partial class AlexisConstructionServices : Form
    {
        ToolTip toolTip = new ToolTip();
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

            if (ClientObjects.ClientId == 0)
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
            #region serviceTab
            ServicesClass.ServicesLoad();
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
            comboBoxServiceBook.DataSource = ServiceObjects.Service;
            //textBoxHoursRendered.Text =
            //textBoxServiceFee.Text = 
            #endregion

            #region clientTab
            ClientClass.ClientsList();
            comboBoxClientUsername.DataSource = ClientObjects.ClientUsername;
            ClientClass.ClientsDtGrid(dataGridViewClients);
            #endregion

            #region serviceLibTab
            comboBoxServiceslib.DataSource = ServiceObjects.Service;
            ServiceLibraryClass.ServiceLib(dataGridViewServiceLibrary);
            #endregion

            #region transactionLogsTab
            transactionlogs.transactionlogsdGV(dataGridViewTransactionLogs);
            #endregion
        }
        #endregion

        #region Service Library
        private void buttonAddLibItem_Click(object sender, EventArgs e)
        {
            ServiceLibraryObject.service = comboBoxServiceslib.Text;
            ServiceLibraryObject.tool = textBoxToolLib.Text;

            ServiceLibraryClass.LibLoader();
            refresh();
        }
        #endregion

        private void buttonTransactionAdd_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxClientUsername.Text != updateClientInfo.username || textBoxClientEmail.Text != updateClientInfo.email || textBoxClientPhoneNumber.Text != updateClientInfo.phoneNum.ToString() || textBoxClientName.Text != updateClientInfo.name)
            {
                updateClientInfo.username = textBoxClientUsername.Text;
                updateClientInfo.email = textBoxClientEmail.Text;
                updateClientInfo.phoneNum = Convert.ToInt64(textBoxClientPhoneNumber.Text);
                updateClientInfo.name = textBoxClientName.Text;

                ClientClass.UpdateClientAccount();
                refresh();
            }
            else { MessageBox.Show("No changes applied", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void dataGridViewClients_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (Control control in tabPageClients.Controls)
            {
                if (control is TextBox textbox)
                {
                    textbox.Clear();
                }
            }
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewClients.SelectedRows[0];

                updateClientInfo.id = Convert.ToInt32(selectedRow.Cells["ClientId"].Value);
                updateClientInfo.username = selectedRow.Cells["Username"].Value.ToString();
                updateClientInfo.email = selectedRow.Cells["Email"].Value.ToString();
                updateClientInfo.phoneNum = Convert.ToInt64(selectedRow.Cells["PhoneNumber"].Value);
                updateClientInfo.name = selectedRow.Cells["Name"].Value.ToString();

                textBoxClientUsername.Text = updateClientInfo.username;
                textBoxClientEmail.Text = updateClientInfo.email;
                textBoxClientPhoneNumber.Text = updateClientInfo.phoneNum.ToString();
                textBoxClientName.Text = updateClientInfo.name;
            }
            else
            {
                MessageBox.Show("No row selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void totalFee()
        {
            toolTip.InitialDelay = 0;

            int serviceFee = int.TryParse(textBoxServiceFee.Text, out int sf) ? sf : 0;
            int hoursRendered = int.TryParse(textBoxHoursRendered.Text, out int hr) ? hr : 0;

            int result = serviceFee * hoursRendered;
            toolTip.SetToolTip(buttonBookService, $"Total Fee: {result}");
        }

        private void textBoxTotalFee_TextChanged(object sender, EventArgs e)
        {
            totalFee();
        }

        private void comboBoxServiceslib_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceLibraryObject.service = comboBoxServiceslib.Text;
            ServiceLibraryClass.ServiceLib(dataGridViewServiceLibrary);
        }
    }
}
