namespace alexisRetry.Forms
{
    partial class AlexisConstructionServices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageServices = new System.Windows.Forms.TabPage();
            this.textBoxServiceFee = new System.Windows.Forms.TextBox();
            this.textBoxHoursRendered = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelService1 = new System.Windows.Forms.Label();
            this.dataGridViewToolsInServices = new System.Windows.Forms.DataGridView();
            this.comboBoxServiceBook = new System.Windows.Forms.ComboBox();
            this.tabPageTransactionLogs = new System.Windows.Forms.TabPage();
            this.buttonTransactionDelete = new System.Windows.Forms.Button();
            this.buttonTransactionEdit = new System.Windows.Forms.Button();
            this.buttonTransactionAdd = new System.Windows.Forms.Button();
            this.dataGridViewTransactionLogs = new System.Windows.Forms.DataGridView();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonClientEdit = new System.Windows.Forms.Button();
            this.buttonClientAdd = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.tabPageOfferedServices = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxFeepHourLib = new System.Windows.Forms.TextBox();
            this.textBoxToolLib = new System.Windows.Forms.TextBox();
            this.buttonDeleteLibItem = new System.Windows.Forms.Button();
            this.buttonEditLibItem = new System.Windows.Forms.Button();
            this.buttonAddLibItem = new System.Windows.Forms.Button();
            this.dataGridViewServiceLibrary = new System.Windows.Forms.DataGridView();
            this.tabPageBillingStatements = new System.Windows.Forms.TabPage();
            this.tabPageThisWeek = new System.Windows.Forms.TabPage();
            this.comboBoxServiceslib = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRemoveAdditionalService = new System.Windows.Forms.Button();
            this.buttonAddAdditionalServiceLib = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.buttonPaid = new System.Windows.Forms.Button();
            this.buttonBookService = new System.Windows.Forms.Button();
            this.buttonCancelBook = new System.Windows.Forms.Button();
            this.labelReservationDate = new System.Windows.Forms.Label();
            this.dateTimePickerReservationDate = new System.Windows.Forms.DateTimePicker();
            this.labelClientUsername = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panelTop.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToolsInServices)).BeginInit();
            this.tabPageTransactionLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionLogs)).BeginInit();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.tabPageOfferedServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceLibrary)).BeginInit();
            this.tabPageBillingStatements.SuspendLayout();
            this.tabPageThisWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.GrayText;
            this.panelTop.Controls.Add(this.label9);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(930, 73);
            this.panelTop.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calisto MT", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(28, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(279, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Alexis Construction Services";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageServices);
            this.tabControlMain.Controls.Add(this.tabPageTransactionLogs);
            this.tabControlMain.Controls.Add(this.tabPageClients);
            this.tabControlMain.Controls.Add(this.tabPageOfferedServices);
            this.tabControlMain.Controls.Add(this.tabPageBillingStatements);
            this.tabControlMain.Controls.Add(this.tabPageThisWeek);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 73);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(930, 489);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabPageServices
            // 
            this.tabPageServices.Controls.Add(this.labelClientUsername);
            this.tabPageServices.Controls.Add(this.comboBox2);
            this.tabPageServices.Controls.Add(this.dateTimePickerReservationDate);
            this.tabPageServices.Controls.Add(this.labelReservationDate);
            this.tabPageServices.Controls.Add(this.buttonCancelBook);
            this.tabPageServices.Controls.Add(this.buttonBookService);
            this.tabPageServices.Controls.Add(this.buttonRemoveAdditionalService);
            this.tabPageServices.Controls.Add(this.buttonAddAdditionalServiceLib);
            this.tabPageServices.Controls.Add(this.textBoxServiceFee);
            this.tabPageServices.Controls.Add(this.textBoxHoursRendered);
            this.tabPageServices.Controls.Add(this.label13);
            this.tabPageServices.Controls.Add(this.label12);
            this.tabPageServices.Controls.Add(this.labelService1);
            this.tabPageServices.Controls.Add(this.dataGridViewToolsInServices);
            this.tabPageServices.Controls.Add(this.comboBoxServiceBook);
            this.tabPageServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageServices.Name = "tabPageServices";
            this.tabPageServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServices.Size = new System.Drawing.Size(922, 463);
            this.tabPageServices.TabIndex = 0;
            this.tabPageServices.Text = "Services";
            this.tabPageServices.UseVisualStyleBackColor = true;
            // 
            // textBoxServiceFee
            // 
            this.textBoxServiceFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceFee.Location = new System.Drawing.Point(57, 386);
            this.textBoxServiceFee.Name = "textBoxServiceFee";
            this.textBoxServiceFee.Size = new System.Drawing.Size(246, 30);
            this.textBoxServiceFee.TabIndex = 4;
            // 
            // textBoxHoursRendered
            // 
            this.textBoxHoursRendered.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHoursRendered.Location = new System.Drawing.Point(57, 304);
            this.textBoxHoursRendered.Name = "textBoxHoursRendered";
            this.textBoxHoursRendered.Size = new System.Drawing.Size(246, 30);
            this.textBoxHoursRendered.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(47, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Fee";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Hours Rendered";
            // 
            // labelService1
            // 
            this.labelService1.AutoSize = true;
            this.labelService1.Location = new System.Drawing.Point(47, 120);
            this.labelService1.Name = "labelService1";
            this.labelService1.Size = new System.Drawing.Size(43, 13);
            this.labelService1.TabIndex = 5;
            this.labelService1.Text = "Service";
            // 
            // dataGridViewToolsInServices
            // 
            this.dataGridViewToolsInServices.AllowUserToAddRows = false;
            this.dataGridViewToolsInServices.AllowUserToDeleteRows = false;
            this.dataGridViewToolsInServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewToolsInServices.Location = new System.Drawing.Point(480, 39);
            this.dataGridViewToolsInServices.Name = "dataGridViewToolsInServices";
            this.dataGridViewToolsInServices.ReadOnly = true;
            this.dataGridViewToolsInServices.Size = new System.Drawing.Size(404, 386);
            this.dataGridViewToolsInServices.TabIndex = 4;
            // 
            // comboBoxServiceBook
            // 
            this.comboBoxServiceBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxServiceBook.FormattingEnabled = true;
            this.comboBoxServiceBook.Location = new System.Drawing.Point(58, 139);
            this.comboBoxServiceBook.Name = "comboBoxServiceBook";
            this.comboBoxServiceBook.Size = new System.Drawing.Size(246, 33);
            this.comboBoxServiceBook.TabIndex = 1;
            this.comboBoxServiceBook.TextChanged += new System.EventHandler(this.comboBoxServiceBook_TextChanged);
            // 
            // tabPageTransactionLogs
            // 
            this.tabPageTransactionLogs.Controls.Add(this.buttonTransactionDelete);
            this.tabPageTransactionLogs.Controls.Add(this.buttonTransactionEdit);
            this.tabPageTransactionLogs.Controls.Add(this.buttonTransactionAdd);
            this.tabPageTransactionLogs.Controls.Add(this.dataGridViewTransactionLogs);
            this.tabPageTransactionLogs.Location = new System.Drawing.Point(4, 22);
            this.tabPageTransactionLogs.Name = "tabPageTransactionLogs";
            this.tabPageTransactionLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTransactionLogs.Size = new System.Drawing.Size(922, 463);
            this.tabPageTransactionLogs.TabIndex = 1;
            this.tabPageTransactionLogs.Text = "Transaction Logs";
            this.tabPageTransactionLogs.UseVisualStyleBackColor = true;
            // 
            // buttonTransactionDelete
            // 
            this.buttonTransactionDelete.Location = new System.Drawing.Point(778, 398);
            this.buttonTransactionDelete.Name = "buttonTransactionDelete";
            this.buttonTransactionDelete.Size = new System.Drawing.Size(124, 36);
            this.buttonTransactionDelete.TabIndex = 3;
            this.buttonTransactionDelete.Text = "Delete";
            this.buttonTransactionDelete.UseVisualStyleBackColor = true;
            // 
            // buttonTransactionEdit
            // 
            this.buttonTransactionEdit.Location = new System.Drawing.Point(778, 356);
            this.buttonTransactionEdit.Name = "buttonTransactionEdit";
            this.buttonTransactionEdit.Size = new System.Drawing.Size(124, 36);
            this.buttonTransactionEdit.TabIndex = 2;
            this.buttonTransactionEdit.Text = "Edit";
            this.buttonTransactionEdit.UseVisualStyleBackColor = true;
            // 
            // buttonTransactionAdd
            // 
            this.buttonTransactionAdd.Location = new System.Drawing.Point(778, 312);
            this.buttonTransactionAdd.Name = "buttonTransactionAdd";
            this.buttonTransactionAdd.Size = new System.Drawing.Size(124, 36);
            this.buttonTransactionAdd.TabIndex = 1;
            this.buttonTransactionAdd.Text = "Add";
            this.buttonTransactionAdd.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTransactionLogs
            // 
            this.dataGridViewTransactionLogs.AllowUserToAddRows = false;
            this.dataGridViewTransactionLogs.AllowUserToDeleteRows = false;
            this.dataGridViewTransactionLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactionLogs.Location = new System.Drawing.Point(35, 22);
            this.dataGridViewTransactionLogs.Name = "dataGridViewTransactionLogs";
            this.dataGridViewTransactionLogs.ReadOnly = true;
            this.dataGridViewTransactionLogs.Size = new System.Drawing.Size(721, 412);
            this.dataGridViewTransactionLogs.TabIndex = 0;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.button4);
            this.tabPageClients.Controls.Add(this.buttonClientEdit);
            this.tabPageClients.Controls.Add(this.buttonClientAdd);
            this.tabPageClients.Controls.Add(this.labelName);
            this.tabPageClients.Controls.Add(this.labelPhoneNumber);
            this.tabPageClients.Controls.Add(this.labelEmail);
            this.tabPageClients.Controls.Add(this.labelUsername);
            this.tabPageClients.Controls.Add(this.textBoxName);
            this.tabPageClients.Controls.Add(this.textBoxPhoneNumber);
            this.tabPageClients.Controls.Add(this.textBoxEmail);
            this.tabPageClients.Controls.Add(this.textBoxUsername);
            this.tabPageClients.Controls.Add(this.dataGridViewClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Size = new System.Drawing.Size(922, 463);
            this.tabPageClients.TabIndex = 2;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(672, 393);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(222, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "Delete";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonClientEdit
            // 
            this.buttonClientEdit.Location = new System.Drawing.Point(672, 359);
            this.buttonClientEdit.Name = "buttonClientEdit";
            this.buttonClientEdit.Size = new System.Drawing.Size(222, 28);
            this.buttonClientEdit.TabIndex = 10;
            this.buttonClientEdit.Text = "Edit";
            this.buttonClientEdit.UseVisualStyleBackColor = true;
            // 
            // buttonClientAdd
            // 
            this.buttonClientAdd.Location = new System.Drawing.Point(672, 325);
            this.buttonClientAdd.Name = "buttonClientAdd";
            this.buttonClientAdd.Size = new System.Drawing.Size(222, 28);
            this.buttonClientAdd.TabIndex = 9;
            this.buttonClientAdd.Text = "Add";
            this.buttonClientAdd.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(651, 217);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Name";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(651, 152);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.labelPhoneNumber.TabIndex = 7;
            this.labelPhoneNumber.Text = "Phone Number";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(651, 87);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(36, 13);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "E-Mail";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(651, 23);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 5;
            this.labelUsername.Text = "Username";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(672, 233);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(222, 27);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(672, 166);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(222, 27);
            this.textBoxPhoneNumber.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(672, 103);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(222, 27);
            this.textBoxEmail.TabIndex = 2;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.Location = new System.Drawing.Point(672, 39);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(222, 27);
            this.textBoxUsername.TabIndex = 1;
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.AllowUserToAddRows = false;
            this.dataGridViewClients.AllowUserToDeleteRows = false;
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(35, 22);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.ReadOnly = true;
            this.dataGridViewClients.Size = new System.Drawing.Size(608, 415);
            this.dataGridViewClients.TabIndex = 0;
            // 
            // tabPageOfferedServices
            // 
            this.tabPageOfferedServices.Controls.Add(this.comboBoxServiceslib);
            this.tabPageOfferedServices.Controls.Add(this.label7);
            this.tabPageOfferedServices.Controls.Add(this.label6);
            this.tabPageOfferedServices.Controls.Add(this.label5);
            this.tabPageOfferedServices.Controls.Add(this.textBoxFeepHourLib);
            this.tabPageOfferedServices.Controls.Add(this.textBoxToolLib);
            this.tabPageOfferedServices.Controls.Add(this.buttonDeleteLibItem);
            this.tabPageOfferedServices.Controls.Add(this.buttonEditLibItem);
            this.tabPageOfferedServices.Controls.Add(this.buttonAddLibItem);
            this.tabPageOfferedServices.Controls.Add(this.dataGridViewServiceLibrary);
            this.tabPageOfferedServices.Location = new System.Drawing.Point(4, 22);
            this.tabPageOfferedServices.Name = "tabPageOfferedServices";
            this.tabPageOfferedServices.Size = new System.Drawing.Size(922, 463);
            this.tabPageOfferedServices.TabIndex = 3;
            this.tabPageOfferedServices.Text = "Services Library";
            this.tabPageOfferedServices.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fee per Hour";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tool";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Service";
            // 
            // textBoxFeepHourLib
            // 
            this.textBoxFeepHourLib.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFeepHourLib.Location = new System.Drawing.Point(50, 260);
            this.textBoxFeepHourLib.Name = "textBoxFeepHourLib";
            this.textBoxFeepHourLib.Size = new System.Drawing.Size(306, 29);
            this.textBoxFeepHourLib.TabIndex = 17;
            // 
            // textBoxToolLib
            // 
            this.textBoxToolLib.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxToolLib.Location = new System.Drawing.Point(50, 156);
            this.textBoxToolLib.Name = "textBoxToolLib";
            this.textBoxToolLib.Size = new System.Drawing.Size(306, 29);
            this.textBoxToolLib.TabIndex = 16;
            // 
            // buttonDeleteLibItem
            // 
            this.buttonDeleteLibItem.Location = new System.Drawing.Point(769, 412);
            this.buttonDeleteLibItem.Name = "buttonDeleteLibItem";
            this.buttonDeleteLibItem.Size = new System.Drawing.Size(126, 28);
            this.buttonDeleteLibItem.TabIndex = 14;
            this.buttonDeleteLibItem.Text = "Delete";
            this.buttonDeleteLibItem.UseVisualStyleBackColor = true;
            // 
            // buttonEditLibItem
            // 
            this.buttonEditLibItem.Location = new System.Drawing.Point(622, 412);
            this.buttonEditLibItem.Name = "buttonEditLibItem";
            this.buttonEditLibItem.Size = new System.Drawing.Size(126, 28);
            this.buttonEditLibItem.TabIndex = 13;
            this.buttonEditLibItem.Text = "Edit";
            this.buttonEditLibItem.UseVisualStyleBackColor = true;
            // 
            // buttonAddLibItem
            // 
            this.buttonAddLibItem.Location = new System.Drawing.Point(473, 412);
            this.buttonAddLibItem.Name = "buttonAddLibItem";
            this.buttonAddLibItem.Size = new System.Drawing.Size(126, 28);
            this.buttonAddLibItem.TabIndex = 12;
            this.buttonAddLibItem.Text = "Add";
            this.buttonAddLibItem.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServiceLibrary
            // 
            this.dataGridViewServiceLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServiceLibrary.Location = new System.Drawing.Point(473, 29);
            this.dataGridViewServiceLibrary.Name = "dataGridViewServiceLibrary";
            this.dataGridViewServiceLibrary.Size = new System.Drawing.Size(422, 365);
            this.dataGridViewServiceLibrary.TabIndex = 0;
            // 
            // tabPageBillingStatements
            // 
            this.tabPageBillingStatements.Controls.Add(this.buttonPaid);
            this.tabPageBillingStatements.Controls.Add(this.dataGridView1);
            this.tabPageBillingStatements.Location = new System.Drawing.Point(4, 22);
            this.tabPageBillingStatements.Name = "tabPageBillingStatements";
            this.tabPageBillingStatements.Size = new System.Drawing.Size(922, 463);
            this.tabPageBillingStatements.TabIndex = 4;
            this.tabPageBillingStatements.Text = "Billing Statements";
            this.tabPageBillingStatements.UseVisualStyleBackColor = true;
            // 
            // tabPageThisWeek
            // 
            this.tabPageThisWeek.Controls.Add(this.dataGridView2);
            this.tabPageThisWeek.Location = new System.Drawing.Point(4, 22);
            this.tabPageThisWeek.Name = "tabPageThisWeek";
            this.tabPageThisWeek.Size = new System.Drawing.Size(922, 463);
            this.tabPageThisWeek.TabIndex = 5;
            this.tabPageThisWeek.Text = "Weekly Schedule";
            this.tabPageThisWeek.UseVisualStyleBackColor = true;
            // 
            // comboBoxServiceslib
            // 
            this.comboBoxServiceslib.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxServiceslib.FormattingEnabled = true;
            this.comboBoxServiceslib.Location = new System.Drawing.Point(53, 55);
            this.comboBoxServiceslib.Name = "comboBoxServiceslib";
            this.comboBoxServiceslib.Size = new System.Drawing.Size(303, 32);
            this.comboBoxServiceslib.TabIndex = 23;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(35, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(687, 402);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonRemoveAdditionalService
            // 
            this.buttonRemoveAdditionalService.Location = new System.Drawing.Point(353, 390);
            this.buttonRemoveAdditionalService.Name = "buttonRemoveAdditionalService";
            this.buttonRemoveAdditionalService.Size = new System.Drawing.Size(100, 35);
            this.buttonRemoveAdditionalService.TabIndex = 8;
            this.buttonRemoveAdditionalService.Text = "Remove Service";
            this.buttonRemoveAdditionalService.UseVisualStyleBackColor = true;
            // 
            // buttonAddAdditionalServiceLib
            // 
            this.buttonAddAdditionalServiceLib.Location = new System.Drawing.Point(353, 348);
            this.buttonAddAdditionalServiceLib.Name = "buttonAddAdditionalServiceLib";
            this.buttonAddAdditionalServiceLib.Size = new System.Drawing.Size(100, 35);
            this.buttonAddAdditionalServiceLib.TabIndex = 7;
            this.buttonAddAdditionalServiceLib.Text = "Add More Service";
            this.buttonAddAdditionalServiceLib.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(35, 22);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(858, 402);
            this.dataGridView2.TabIndex = 1;
            // 
            // buttonPaid
            // 
            this.buttonPaid.Location = new System.Drawing.Point(749, 388);
            this.buttonPaid.Name = "buttonPaid";
            this.buttonPaid.Size = new System.Drawing.Size(152, 36);
            this.buttonPaid.TabIndex = 1;
            this.buttonPaid.Text = "Paid";
            this.buttonPaid.UseVisualStyleBackColor = true;
            // 
            // buttonBookService
            // 
            this.buttonBookService.Location = new System.Drawing.Point(353, 266);
            this.buttonBookService.Name = "buttonBookService";
            this.buttonBookService.Size = new System.Drawing.Size(100, 35);
            this.buttonBookService.TabIndex = 5;
            this.buttonBookService.Text = "Book";
            this.buttonBookService.UseVisualStyleBackColor = true;
            this.buttonBookService.Click += new System.EventHandler(this.buttonBookService_Click);
            // 
            // buttonCancelBook
            // 
            this.buttonCancelBook.Location = new System.Drawing.Point(353, 307);
            this.buttonCancelBook.Name = "buttonCancelBook";
            this.buttonCancelBook.Size = new System.Drawing.Size(100, 35);
            this.buttonCancelBook.TabIndex = 6;
            this.buttonCancelBook.Text = "Cancel";
            this.buttonCancelBook.UseVisualStyleBackColor = true;
            // 
            // labelReservationDate
            // 
            this.labelReservationDate.AutoSize = true;
            this.labelReservationDate.Location = new System.Drawing.Point(47, 212);
            this.labelReservationDate.Name = "labelReservationDate";
            this.labelReservationDate.Size = new System.Drawing.Size(90, 13);
            this.labelReservationDate.TabIndex = 30;
            this.labelReservationDate.Text = "Reservation Date";
            // 
            // dateTimePickerReservationDate
            // 
            this.dateTimePickerReservationDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerReservationDate.CustomFormat = "MMMM dd,  yyyy";
            this.dateTimePickerReservationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReservationDate.Location = new System.Drawing.Point(58, 229);
            this.dateTimePickerReservationDate.MinDate = new System.DateTime(2025, 2, 25, 0, 0, 0, 0);
            this.dateTimePickerReservationDate.Name = "dateTimePickerReservationDate";
            this.dateTimePickerReservationDate.Size = new System.Drawing.Size(246, 26);
            this.dateTimePickerReservationDate.TabIndex = 2;
            this.dateTimePickerReservationDate.Value = new System.DateTime(2025, 2, 25, 9, 17, 9, 0);
            // 
            // labelClientUsername
            // 
            this.labelClientUsername.AutoSize = true;
            this.labelClientUsername.Location = new System.Drawing.Point(47, 39);
            this.labelClientUsername.Name = "labelClientUsername";
            this.labelClientUsername.Size = new System.Drawing.Size(84, 13);
            this.labelClientUsername.TabIndex = 34;
            this.labelClientUsername.Text = "Client Username";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(58, 58);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(246, 33);
            this.comboBox2.TabIndex = 33;
            // 
            // AlexisConstructionServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 562);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.panelTop);
            this.Name = "AlexisConstructionServices";
            this.Text = "AlexisConstructionServices";
            this.Load += new System.EventHandler(this.AlexisConstructionServices_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageServices.ResumeLayout(false);
            this.tabPageServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewToolsInServices)).EndInit();
            this.tabPageTransactionLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactionLogs)).EndInit();
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.tabPageOfferedServices.ResumeLayout(false);
            this.tabPageOfferedServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServiceLibrary)).EndInit();
            this.tabPageBillingStatements.ResumeLayout(false);
            this.tabPageThisWeek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageServices;
        private System.Windows.Forms.TabPage tabPageTransactionLogs;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.TabPage tabPageOfferedServices;
        private System.Windows.Forms.DataGridView dataGridViewToolsInServices;
        private System.Windows.Forms.ComboBox comboBoxServiceBook;
        private System.Windows.Forms.DataGridView dataGridViewTransactionLogs;
        private System.Windows.Forms.Button buttonTransactionDelete;
        private System.Windows.Forms.Button buttonTransactionEdit;
        private System.Windows.Forms.Button buttonTransactionAdd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonClientEdit;
        private System.Windows.Forms.Button buttonClientAdd;
        private System.Windows.Forms.Button buttonDeleteLibItem;
        private System.Windows.Forms.Button buttonEditLibItem;
        private System.Windows.Forms.Button buttonAddLibItem;
        private System.Windows.Forms.DataGridView dataGridViewServiceLibrary;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxFeepHourLib;
        private System.Windows.Forms.TextBox textBoxToolLib;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelService1;
        private System.Windows.Forms.TextBox textBoxServiceFee;
        private System.Windows.Forms.TextBox textBoxHoursRendered;
        private System.Windows.Forms.TabPage tabPageBillingStatements;
        private System.Windows.Forms.TabPage tabPageThisWeek;
        private System.Windows.Forms.ComboBox comboBoxServiceslib;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRemoveAdditionalService;
        private System.Windows.Forms.Button buttonAddAdditionalServiceLib;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button buttonPaid;
        private System.Windows.Forms.Button buttonCancelBook;
        private System.Windows.Forms.Button buttonBookService;
        private System.Windows.Forms.DateTimePicker dateTimePickerReservationDate;
        private System.Windows.Forms.Label labelReservationDate;
        private System.Windows.Forms.Label labelClientUsername;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}