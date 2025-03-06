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
            OverallTotalFeeUpdate();
            dateTimePickerReservationDate.MinDate = DateTime.Now;
        }
        private void AlexisConstructionServices_Load(object sender, EventArgs e)
        {

            this.reportViewerReports.RefreshReport();
        }

        #region UniversalUsed Method | EventHandlers
        private void refresh()
        {
            #region serviceTab
            ServicesClass.GetServices();
            ServicesClass.ViewServicesinService(dataGridViewServicesSrvc);
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
            comboBoxServiceBook.DataSource = ServiceObjects.Service;
            ServicesClass.PriceFetcher();
            TextBox_HourlyRate.Text = ServiceBooking.HourlyRate.ToString();
            #endregion

            #region clientTab
            ClientClass.ClientsList();
            comboBoxClientUsername.DataSource = ClientObjects.ClientUsername;
            ClientClass.ClientsDtGrid(dataGridViewClients);
            #endregion

            #region serviceLibTab
            ServiceLibraryClass.ServiceLib(dataGridViewServiceLibrary);
            #endregion

            #region transactionLogsTab
            transactionlogsClass.transactionlogsdGV(dataGridViewTransactionLogs);
            #endregion

            #region inventoryTab
            comboBoxInventoryService.DataSource = ServiceObjects.Service;
            InventoryClass.InventoryDataGridProvider(dataGridViewInventory);
            #endregion

            #region Billing
            BillingClass.BillingStatementDataGridProvider(dataGridViewPendingBilling);
            BillingClass.RegisteredApprovedPayment(dataGridViewPayedBilling);
            #endregion

            #region WeeklySchedule
            WeeklyScheduleClass.WeeklyScheduleDataGridProvider(dataGridViewWeeklySchedule);
            #endregion
        }
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            refresh();
        }
        #endregion


        #region ServiceTab
        #region method
        private void UpdateTotalFee()
        {
            if (int.TryParse(TextBox_ServiceDuration.Text.Trim(), out int duration))
            {
                TextBox_TotalFee.Text = (ServiceBooking.HourlyRate * duration).ToString();
            }
            else
            {
                TextBox_TotalFee.Text = "0";
            }
        }

        private void OverallTotalFeeUpdate()
        {
            ServiceBooking.TotalFee = int.Parse(TextBox_TotalFee.Text);
            ServicesClass.OverallTotalFee();
            TextBox_OverallTotalFee.Text = ServiceBooking.OverallTotalFee.ToString();
        }
        #endregion

        #region eventHandlers
        private void buttonBookService_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabPageServicesBooking.Controls)
            {
                if (control is TextBox textbox && string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBox.Show($"{textbox.Name} cannot be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textbox.Focus();
                    return;
                }
                if (control is TextBox textBox && textBox.Text == "0")
                {
                    MessageBox.Show($"{textBox.Name} cannot have a value of Zero", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox.Focus();
                    return;
                }
            }

            ServiceBooking.clientUsername = comboBoxClientUsername.Text;
            ServiceBooking.Service = comboBoxServiceBook.Text;
            ServiceBooking.BookedDate = dateTimePickerReservationDate.Value.Date;
            ServiceBooking.RentedDuration = int.Parse(TextBox_ServiceDuration.Text);
            ServiceBooking.TotalFee = int.Parse(TextBox_TotalFee.Text);

            bool isDateBooked = ServicesClass.checkDate();

            if (isDateBooked) { MessageBox.Show("This type of service is already booked in this date selected", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            else { ServicesClass.ServiceBooking(); MessageBox.Show("Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); refresh(); }
        }
        private void comboBoxServiceBook_TextChanged(object sender, EventArgs e)
        {
            ServiceBooking.Service = comboBoxServiceBook.Text;
            ServicesClass.ViewToolsinService(dataGridViewToolsInServices);
            ServicesClass.PriceFetcher();
            TextBox_HourlyRate.Text = ServiceBooking.HourlyRate.ToString();
            TextBox_TotalFee.Text = (ServiceBooking.HourlyRate * ServiceBooking.RentedDuration).ToString();
        }
        private void comboBoxClientUsername_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceObjects.Clientusername = comboBoxClientUsername.Text;
            //ClientClass.ClientIdList();
            ServicesClass.clientIdFetcher();
        }
        private void textBoxNumericalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            HandleInputDisplay(e);
        }
        private void textBoxTotalFee_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_ServiceDuration.Text)) { TextBox_ServiceDuration.Text = "0"; }
            UpdateTotalFee();
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
            multipleBookings.Fee1 = 0;
            multipleBookings.Fee2 = 0;
            multipleBookings.time1 = 0;
            multipleBookings.time2 = 0;
            multipleBookings.totalFee1 = 0;
            multipleBookings.totalFee2 = 0;
        }
        private void HandleInputDisplay(KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_ServiceDuration.Text))
            {
                TextBox_ServiceDuration.Text = "0";
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                TextBox_ServiceDuration.Text = "0";
                e.Handled = true;
                return;
            }

            if (TextBox_ServiceDuration.Text == "0")
            {
                if (e.KeyChar != '0')
                {
                    TextBox_ServiceDuration.Text = e.KeyChar.ToString();
                }
                e.Handled = true;
            }
            TextBox_ServiceDuration.SelectionStart = TextBox_ServiceDuration.Text.Length;
        }
        private void tabPageServicesBooking_MouseMove(object sender, MouseEventArgs e)
        {
            OverallTotalFeeUpdate();
        }
        #endregion

        #endregion

        #region TransactionLogs
        private void buttonTransactionAdd_Click(object sender, EventArgs e)
        {
            tabControlMain.SelectedIndex = 0;
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
            foreach (Control control in tabPageClients.Controls)
            {
                if (control is TextBox textbox)
                {
                    textbox.Clear();
                }
            }
        }
        private void textBoxClientPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
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
        #endregion

        #region Service Library
        private void buttonAddLibItem_Click(object sender, EventArgs e)
        {
            ServiceLibraryObject.service = textBoxServiceLib.Text;

            if (!ServiceLibraryClass.IsDoesNotExist())
            {
                ServiceLibraryObject.HourlyRate = Convert.ToInt32(textBoxServiceHourlyRate.Text);

                ServiceLibraryClass.AddService();
                refresh();
                foreach (Control control in tabPageInventory.Controls)
                {
                    if (control is TextBox textbox)
                    {
                        textbox.Clear();
                    }
                }
            }
            else { MessageBox.Show("Service already exists", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ServiceLibraryObject.service = null; }
        }
        private void buttonEditLibItem_Click(object sender, EventArgs e)
        {
            if (ServiceLibraryObject.service != textBoxServiceLib.Text && ServiceLibraryObject.HourlyRate != Convert.ToInt32(textBoxServiceHourlyRate.Text))
            {
                ServiceLibraryObject.service = textBoxServiceLib.Text;
                ServiceLibraryObject.HourlyRate = Convert.ToInt32(textBoxServiceHourlyRate.Text);

                ServiceLibraryClass.UpdateService();
            }
            else { MessageBox.Show("No changes Applied", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        private void dataGridViewServiceLibrary_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ServiceLibraryClass.SelectValueUpdateService(dataGridViewServiceLibrary);

            textBoxServiceLib.Text = ServiceLibraryObject.service;
            textBoxServiceHourlyRate.Text = ServiceLibraryObject.HourlyRate.ToString();
        }
        private void buttonDeleteLibItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to procced?\nYou cannot undo this action", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ServiceLibraryClass.DeleteService();
                MessageBox.Show("Deleted Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
        }
        #endregion

        #region Inventory
        private void buttonAddToolInventory_Click(object sender, EventArgs e)
        {
            InventoryObject.service = comboBoxInventoryService.Text;
            InventoryObject.tool = textBoxInventoryTool.Text;
            InventoryObject.quantity = Convert.ToInt32(textBoxInventoryQuantity.Text);

            if (!InventoryClass.IsToolExist())
            {
                InventoryClass.AddInventory();
                MessageBox.Show("Tool added successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
                foreach (Control control in tabPageInventory.Controls)
                {
                    if (control is TextBox textbox)
                    {
                        textbox.Clear();
                    }
                }
            }
            else MessageBox.Show("Tool already Exist in the Inventory", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void buttonEditToolInventory_Click(object sender, EventArgs e)
        {
            if (InventoryObject.tool != textBoxInventoryTool.Text && InventoryObject.quantity != Convert.ToInt32(textBoxInventoryQuantity.Text))
            {
                InventoryObject.service = textBoxInventoryTool.Text;
                InventoryObject.quantity = Convert.ToInt32(textBoxInventoryQuantity.Text);

                InventoryClass.UpdateInventory();
                refresh();
            }
            MessageBox.Show("Updated Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridViewInventory_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            InventoryObject.service = comboBoxInventoryService.Text;
            InventoryClass.SelectValueInventory(dataGridViewInventory);

            textBoxInventoryTool.Text = InventoryObject.tool;
            textBoxInventoryQuantity.Text = InventoryObject.quantity.ToString();
        }
        private void buttonDeleteToolInventory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you wish to procced?\nYou cannot undo this action", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                InventoryClass.DeleteToolFromInventory();
                MessageBox.Show("Deleted Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refresh();
            }
        }
        private void comboBoxInventoryService_SelectedValueChanged(object sender, EventArgs e)
        {
            InventoryObject.service = comboBoxInventoryService.Text;
            textBoxServiceTypeInventory.Text = InventoryObject.service;
            InventoryClass.InventoryDataGridProvider(dataGridViewInventory);
            foreach (Control control in tabPageInventory.Controls)
            {
                if (control is TextBox textbox)
                {
                    textbox.Clear();
                }
            }
        }
        #endregion

        #region Billing
        private void dataGridViewBillingStatement_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BillingClass.selectDataGridRow(dataGridViewPendingBilling);
        }
        private void buttonPaid_Click(object sender, EventArgs e)
        {
            BillingClass.ApprovePayment();
            refresh();
        }


        #endregion
    }
}
