using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Windows.Forms;

namespace alexisRetry.Forms
{
    public partial class AlexisConstructionServices : Form
    {
        ToolTip toolTip = new ToolTip();

        private Form3B addServiceForm = null;

        public AlexisConstructionServices()
        {
            InitializeComponent();
            refresh();
            dateTimePickerReservationDate.MinDate = DateTime.Now;
        }

        private void AlexisConstructionServices_Load(object sender, EventArgs e)
        {

        }

        #region ServiceTab
        #region Method
        #endregion

        #region eventHandlers

        private void buttonBookService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxServiceDuration.Text) || textBoxServiceDuration.Text == "0")
            {
                MessageBox.Show("Input a Hours Rendered", "Booking Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxServiceBookingTotalFee.Text) || textBoxServiceBookingTotalFee.Text == "0")
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

            ServiceBooking.clientUsername = comboBoxClientUsername.Text;
            ServiceBooking.Service = comboBoxServiceBook.Text;
            ServiceBooking.BookedDate = dateTimePickerReservationDate.Value;
            ServiceBooking.RentedDuration = int.Parse(textBoxServiceDuration.Text);
            ServiceBooking.HourlyRate = int.Parse(textBoxBookingHourlyRate.Text);
            ServiceBooking.TotalFee = int.Parse(textBoxServiceBookingTotalFee.Text);

            bool isDateBooked = ServicesClass.checkDate();

            if (isDateBooked) { MessageBox.Show("This type of service is already booked in this date selected", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else { ServicesClass.ServiceBooking(); MessageBox.Show("Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); refresh(); }
        }

        private void comboBoxServiceBook_TextChanged(object sender, EventArgs e)
        {
            ServiceBooking.Service = comboBoxServiceBook.Text;
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
            ServicesClass.ViewServicesinService(dataGridViewServicesSrvc);
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
            comboBoxServiceBook.DataSource = ServiceObjects.Service;
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
            transactionlogsClass.transactionlogsdGV(dataGridViewTransactionLogs);
            #endregion

            #region inventoryTab
            comboBoxInventoryService.DataSource = ServiceObjects.Service;
            #endregion
        }
        #endregion

        #region Service Library
        private void buttonAddLibItem_Click(object sender, EventArgs e)
        {
            ServiceLibraryObject.service = comboBoxServiceslib.Text;
            ServiceLibraryObject.HourlyRate = Convert.ToInt32(textBoxServiceHourlyRate.Text);

            ServiceLibraryClass.AddService();
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
                ClientClass.selectDataGridRow(dataGridViewClients);

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

            int serviceFee = int.TryParse(textBoxServiceBookingTotalFee.Text, out int sf) ? sf : 0;
            int hoursRendered = int.TryParse(textBoxServiceDuration.Text, out int hr) ? hr : 0;

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

        private void buttonClientDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count > 0)
            {
                ClientClass.selectDataGridRow(dataGridViewClients);

                if (MessageBox.Show("Delete Client? You cannot undo this action.", "Notice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    ClientClass.DeleteClientAccount();
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("No row selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonTransactionDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactionLogs.SelectedRows.Count > 0)
            {
                transactionlogsClass.selectDataGridRow(dataGridViewTransactionLogs);

                if (MessageBox.Show("Do you wish to Delete this Record? You cannot undo this action.", "Notice!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    transactionlogsClass.DeleteLog();
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("No row selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridViewServicesSrvc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewServicesSrvc.SelectedRows.Count > 0)
            {
                ServicesClass.selectDataGridRow(dataGridViewServicesSrvc);

                comboBoxServiceBook.Text = ServiceBooking.Service;
            }
            else
            {
                MessageBox.Show("No row selected", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonCancelBook_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabPageServicesBooking.Controls)
            {
                if (control is TextBox textbox)
                {
                    textbox.Clear();
                }
            }
            refresh();
        }

        private void buttonAddAdditionalServiceLib_Click(object sender, EventArgs e)
        {
            if (addServiceForm == null || addServiceForm.IsDisposed)
            {
                addServiceForm = new Form3B();
                addServiceForm.FormClosed += (s, args) => addServiceForm = null;
                addServiceForm.Show();
            }
            else
            {
                addServiceForm.BringToFront();
            }
        }

        private void buttonRemoveAdditionalService_Click(object sender, EventArgs e)
        {
            if (addServiceForm != null && !addServiceForm.IsDisposed)
            {
                addServiceForm.Close();
                addServiceForm = null;
            }

            multipleBookings.Service1 = null;
            multipleBookings.Service2 = null;
        }
    }
}
