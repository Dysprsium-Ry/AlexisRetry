using alexisRetry.Classes;
using alexisRetry.Objects;
using System;
using System.Linq;
using System.Text.Json;
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
            OverallTotalFeeUpdate();
            dateTimePickerReservationDate.MinDate = DateTime.Now;
            //dateTimePickerReservationDate.MinDate = DateTime.Now.AddHours(0);
        }
        private void AlexisConstructionServices_Load(object sender, EventArgs e)
        {
            reportViewerReports.RefreshReport();
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
            TransactionManagementClass.WeeklyScheduleDataGridProvider(dataGridViewWeeklySchedule);
            #endregion

            #region BindingSource
            //bindingSource.DataSource = AdditionalBooking.TransactionsList;
            #endregion

            #region Report
            ReportClass.SetReportData(reportViewerReports);
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
            if (AdditionalBooking.TransactionsList.Count < 1)
            {
                TextBox_OverallTotalFee.Text = TextBox_TotalFee.Text;
                ServiceBooking.OverallTotalFee = int.Parse(TextBox_OverallTotalFee.Text);
            }
            //else
            //{
            //    foreach (var totals in AdditionalBooking.TransactionsList)
            //    {
            //        var overalltotal = int.Parse(TextBox_TotalFee.Text);
            //        overalltotal += totals.TotalFee;
            //        TextBox_OverallTotalFee.Text = overalltotal.ToString();
            //    }
            //    ServiceBooking.OverallTotalFee = int.Parse(TextBox_OverallTotalFee.Text);
            //}
        }
        private bool BookingValidator()
        {
            foreach (Control control in tabPageServicesBooking.Controls)
            {
                if (control is TextBox textbox && string.IsNullOrWhiteSpace(textbox.Text) && textbox != TextBox_OverallTotalFee)
                {
                    MessageBox.Show($"{textbox.Name} cannot be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textbox.Focus();
                    return true;
                }
                if (control is TextBox textBox && textBox.Text == "0" && textBox != TextBox_OverallTotalFee)
                {
                    MessageBox.Show($"{textBox.Name} cannot have a value of Zero", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox.Focus();
                    return true;
                }
            }
            return false;
        }
        private DateTime WorkingHours()
        {
            dateTimePickerReservationDate.Value = DateTime.Now;
            DateTime date = dateTimePickerReservationDate.Value.AddHours(int.Parse(TextBox_ServiceDuration.Text));

            while (date.Hour >= 17)
            {
                TimeSpan remainingHours = date - date.Date.AddHours(17);
                DateTime nextDayStart = dateTimePickerReservationDate.Value.Date.AddDays(1).AddHours(8);
                DateTime endTime = nextDayStart.Add(remainingHours);
                return endTime;
            }
            return date;
        }
        private void ExcessTimeBooking()
        {
            if (ServiceBooking.AdditionalTime > 0)
            {
                MessageBox.Show($"Service Duration exceeds the working hours. Additional {ServiceBooking.AdditionalTime} hours will be added to the next day", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ServiceBooking.CalculatedDate = WorkingHours();
                ServicesClass.ServiceBooking();
            }
        }
        #endregion

        #region eventHandlers
        private void buttonBookService_Click(object sender, EventArgs e)
        {
            //DateTime date = dateTimePickerReservationDate.Value.AddHours(int.Parse(TextBox_ServiceDuration.Text));
            //if (int.TryParse(TextBox_ServiceDuration.Text, out int AddedHours))
            //{
            //    ServiceBooking.CalculatedDate = dateTimePickerReservationDate.Value.AddHours(AddedHours);
            //}

            ServiceBooking.CalculatedDate = WorkingHours();

            ServicesClass.BookingToolsRegistration();
            ToJson.Tools = JsonSerializer.Serialize(ToolsList.ToolList);

            if (AdditionalBooking.TransactionsList.Count > 0)
            {
                foreach (var transaction in AdditionalBooking.TransactionsList)
                {
                    ServiceBooking.clientUsername = comboBoxClientUsername.Text;
                    ServiceBooking.Service = transaction.Service;
                    ServiceBooking.BookedDate = transaction.BookedDate;
                    ServiceBooking.RentedDuration = transaction.RentedDuration;
                    ServiceBooking.TotalFee = transaction.TotalFee;

                    bool isDateBooked = ServicesClass.checkDate();

                    if (isDateBooked) { MessageBox.Show($"Service {ServiceBooking.Service} is already booked in the selected Date", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                    else { ServicesClass.ServiceBooking(); ExcessTimeBooking(); }
                }
                MessageBox.Show($"Service {ServiceBooking.Service} is Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); AdditionalBooking.TransactionsList.Clear(); dataGridView.DataSource = null; refresh();
            }
            else
            {
                if (BookingValidator()) { return; }

                ServiceBooking.clientUsername = comboBoxClientUsername.Text;
                ServiceBooking.Service = comboBoxServiceBook.Text;
                ServiceBooking.BookedDate = dateTimePickerReservationDate.Value;
                ServiceBooking.RentedDuration = int.Parse(TextBox_ServiceDuration.Text);
                ServiceBooking.TotalFee = int.Parse(TextBox_TotalFee.Text);

                bool isDateBooked = ServicesClass.checkDate();

                if (isDateBooked) { MessageBox.Show("This type of service is already booked in this date selected", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else { ServicesClass.ServiceBooking(); ServicesClass.ToolDecrement(); MessageBox.Show("Booked Succesfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information); ExcessTimeBooking(); refresh(); }
            }
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
            ServicesClass.clientIdFetcher();
        }
        private void TextBox_ServiceDuration_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            WorkingHours();
            dateTimePickerReservationDate.Value = WorkingHours();
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
        private void TextBox_ServiceDuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (dateTimePickerReservationDate.Value.Hour >= 17)
            {
                WorkingHours();
                dateTimePickerReservationDate.Value = WorkingHours();
            }
        }
        private void textBoxTotalFee_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox_ServiceDuration.Text)) { TextBox_ServiceDuration.Text = "0"; }
            UpdateTotalFee();
            OverallTotalFeeUpdate();
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
            if (BookingValidator()) { return; }

            if (!int.TryParse(TextBox_ServiceDuration.Text, out int rentedDuration) || !int.TryParse(TextBox_HourlyRate.Text, out int hourlyRate) || !int.TryParse(TextBox_TotalFee.Text, out int totalFee))
            {
                MessageBox.Show("Invalid input. Please check the values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ServiceBooking.CalculatedDate = WorkingHours();
            ServicesClass.BookingToolsRegistration();
            ToJson.Tools = JsonSerializer.Serialize(ToolsList.ToolList);

            var newbooking = new Booking
            {
                Service = comboBoxServiceBook.Text,
                BookedDate = dateTimePickerReservationDate.Value.Date,
                RentedDuration = rentedDuration,
                HourlyRate = hourlyRate,
                TotalFee = totalFee
            };

            if (!AdditionalBooking.TransactionsList.Contains(newbooking))
            {
                AdditionalBooking.TransactionsList.Add(newbooking);

                var overalltotal = AdditionalBooking.TransactionsList.Sum(booking => booking.TotalFee);

                TextBox_OverallTotalFee.Text = overalltotal.ToString();
                ServiceBooking.OverallTotalFee = overalltotal;

                dataGridView.DataSource = null;
                dataGridView.DataSource = AdditionalBooking.TransactionsList;
            }
            else
            {
                MessageBox.Show("This booking already exists in the list.", "Duplicate Booking", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            TextBox_ServiceDuration.Text = "0";
        }
        private void buttonRemoveAdditionalService_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            AdditionalBooking.TransactionsList.Clear();
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
            foreach (Control control in tabPageClients.Controls)
            {
                if (control is TextBox textbox && string.IsNullOrWhiteSpace(textbox.Text))
                {
                    MessageBox.Show($"{textbox.Name} cannot be empty", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            ClientRegister.username = TextBox_ClientUsername.Text;
            ClientRegister.email = TextBox_ClientEmail.Text;
            ClientRegister.PhoneNumber = Convert.ToInt64(TextBox_ClientPhoneNumber.Text);
            ClientRegister.name = TextBox_ClientName.Text;

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
            if (TextBox_ClientUsername.Text != updateClientInfo.username || TextBox_ClientEmail.Text != updateClientInfo.email || TextBox_ClientPhoneNumber.Text != updateClientInfo.phoneNum.ToString() || TextBox_ClientName.Text != updateClientInfo.name)
            {
                updateClientInfo.username = TextBox_ClientUsername.Text;
                updateClientInfo.email = TextBox_ClientEmail.Text;
                updateClientInfo.phoneNum = Convert.ToInt64(TextBox_ClientPhoneNumber.Text);
                updateClientInfo.name = TextBox_ClientName.Text;

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

                TextBox_ClientUsername.Text = updateClientInfo.username;
                TextBox_ClientEmail.Text = updateClientInfo.email;
                TextBox_ClientPhoneNumber.Text = updateClientInfo.phoneNum.ToString();
                TextBox_ClientName.Text = updateClientInfo.name;
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
            if (ServiceLibraryObject.service != textBoxServiceLib.Text || ServiceLibraryObject.HourlyRate != Convert.ToInt32(textBoxServiceHourlyRate.Text))
            {
                ServiceLibraryObject.service = textBoxServiceLib.Text;
                ServiceLibraryObject.HourlyRate = Convert.ToInt32(textBoxServiceHourlyRate.Text);

                ServiceLibraryClass.UpdateService();
                refresh();
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
            if (InventoryObject.tool != textBoxInventoryTool.Text || InventoryObject.quantity != Convert.ToInt32(textBoxInventoryQuantity.Text))
            {
                InventoryObject.tool = textBoxInventoryTool.Text;
                InventoryObject.quantity = Convert.ToInt32(textBoxInventoryQuantity.Text);

                InventoryClass.UpdateInventory();
                refresh();
                MessageBox.Show("Updated Successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("No Changes Applied", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
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

        #region Report

        #endregion

        
    }
}
