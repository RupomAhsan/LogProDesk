namespace LogProDesk.Fomrs.Attendances
{
    partial class frmShift
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.chkMustCheckOut = new System.Windows.Forms.CheckBox();
            this.chkMustCheckIn = new System.Windows.Forms.CheckBox();
            this.nmrTotalWorkTimes = new System.Windows.Forms.NumericUpDown();
            this.nmrTotalWorkDays = new System.Windows.Forms.NumericUpDown();
            this.mtbEarlyAllowence = new System.Windows.Forms.MaskedTextBox();
            this.mtbLateAllowence = new System.Windows.Forms.MaskedTextBox();
            this.mtbEndCheckOut = new System.Windows.Forms.MaskedTextBox();
            this.mtbBeginCheckOut = new System.Windows.Forms.MaskedTextBox();
            this.mtbEndCheckIn = new System.Windows.Forms.MaskedTextBox();
            this.mtbBeginCheckIn = new System.Windows.Forms.MaskedTextBox();
            this.mtbOffDuty = new System.Windows.Forms.MaskedTextBox();
            this.mtbOnDuty = new System.Windows.Forms.MaskedTextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetailData = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTotalWorkTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTotalWorkDays)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Green;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 20);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Shifts";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cboBranch);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.chkMustCheckOut);
            this.groupBox2.Controls.Add(this.chkMustCheckIn);
            this.groupBox2.Controls.Add(this.nmrTotalWorkTimes);
            this.groupBox2.Controls.Add(this.nmrTotalWorkDays);
            this.groupBox2.Controls.Add(this.mtbEarlyAllowence);
            this.groupBox2.Controls.Add(this.mtbLateAllowence);
            this.groupBox2.Controls.Add(this.mtbEndCheckOut);
            this.groupBox2.Controls.Add(this.mtbBeginCheckOut);
            this.groupBox2.Controls.Add(this.mtbEndCheckIn);
            this.groupBox2.Controls.Add(this.mtbBeginCheckIn);
            this.groupBox2.Controls.Add(this.mtbOffDuty);
            this.groupBox2.Controls.Add(this.mtbOnDuty);
            this.groupBox2.Controls.Add(this.lblID);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.lblErrorMessage);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(242, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 479);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(255, 349);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 20);
            this.label26.TabIndex = 61;
            this.label26.Text = "*";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(255, 323);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 20);
            this.label25.TabIndex = 61;
            this.label25.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(255, 247);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 20);
            this.label24.TabIndex = 61;
            this.label24.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(255, 299);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 20);
            this.label23.TabIndex = 61;
            this.label23.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(255, 273);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 20);
            this.label22.TabIndex = 61;
            this.label22.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(255, 221);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 20);
            this.label21.TabIndex = 61;
            this.label21.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(255, 195);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 20);
            this.label18.TabIndex = 61;
            this.label18.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(255, 169);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 20);
            this.label17.TabIndex = 61;
            this.label17.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(255, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(16, 20);
            this.label16.TabIndex = 61;
            this.label16.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(255, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 20);
            this.label15.TabIndex = 61;
            this.label15.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(255, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 20);
            this.label14.TabIndex = 61;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(346, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 20);
            this.label13.TabIndex = 61;
            this.label13.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(347, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(16, 20);
            this.label20.TabIndex = 61;
            this.label20.Text = "*";
            // 
            // cboBranch
            // 
            this.cboBranch.DisplayMember = "Id";
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(149, 64);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(198, 21);
            this.cboBranch.TabIndex = 60;
            this.cboBranch.ValueMember = "Id";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 64);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Branch : ";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(149, 349);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(100, 21);
            this.cboStatus.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 349);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Status : ";
            // 
            // chkMustCheckOut
            // 
            this.chkMustCheckOut.AutoSize = true;
            this.chkMustCheckOut.Location = new System.Drawing.Point(188, 393);
            this.chkMustCheckOut.Name = "chkMustCheckOut";
            this.chkMustCheckOut.Size = new System.Drawing.Size(109, 17);
            this.chkMustCheckOut.TabIndex = 45;
            this.chkMustCheckOut.Text = "Must Check Out?";
            this.chkMustCheckOut.UseVisualStyleBackColor = true;
            // 
            // chkMustCheckIn
            // 
            this.chkMustCheckIn.AutoSize = true;
            this.chkMustCheckIn.Location = new System.Drawing.Point(61, 393);
            this.chkMustCheckIn.Name = "chkMustCheckIn";
            this.chkMustCheckIn.Size = new System.Drawing.Size(101, 17);
            this.chkMustCheckIn.TabIndex = 45;
            this.chkMustCheckIn.Text = "Must Check In?";
            this.chkMustCheckIn.UseVisualStyleBackColor = true;
            // 
            // nmrTotalWorkTimes
            // 
            this.nmrTotalWorkTimes.DecimalPlaces = 2;
            this.nmrTotalWorkTimes.Location = new System.Drawing.Point(149, 323);
            this.nmrTotalWorkTimes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrTotalWorkTimes.Name = "nmrTotalWorkTimes";
            this.nmrTotalWorkTimes.Size = new System.Drawing.Size(100, 20);
            this.nmrTotalWorkTimes.TabIndex = 44;
            // 
            // nmrTotalWorkDays
            // 
            this.nmrTotalWorkDays.DecimalPlaces = 2;
            this.nmrTotalWorkDays.Location = new System.Drawing.Point(149, 299);
            this.nmrTotalWorkDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrTotalWorkDays.Name = "nmrTotalWorkDays";
            this.nmrTotalWorkDays.Size = new System.Drawing.Size(100, 20);
            this.nmrTotalWorkDays.TabIndex = 44;
            // 
            // mtbEarlyAllowence
            // 
            this.mtbEarlyAllowence.Location = new System.Drawing.Point(149, 273);
            this.mtbEarlyAllowence.Mask = "00:00";
            this.mtbEarlyAllowence.Name = "mtbEarlyAllowence";
            this.mtbEarlyAllowence.Size = new System.Drawing.Size(100, 20);
            this.mtbEarlyAllowence.TabIndex = 43;
            this.mtbEarlyAllowence.ValidatingType = typeof(System.DateTime);
            // 
            // mtbLateAllowence
            // 
            this.mtbLateAllowence.Location = new System.Drawing.Point(149, 247);
            this.mtbLateAllowence.Mask = "00:00";
            this.mtbLateAllowence.Name = "mtbLateAllowence";
            this.mtbLateAllowence.Size = new System.Drawing.Size(100, 20);
            this.mtbLateAllowence.TabIndex = 43;
            this.mtbLateAllowence.ValidatingType = typeof(System.DateTime);
            // 
            // mtbEndCheckOut
            // 
            this.mtbEndCheckOut.Location = new System.Drawing.Point(149, 221);
            this.mtbEndCheckOut.Mask = "00:00";
            this.mtbEndCheckOut.Name = "mtbEndCheckOut";
            this.mtbEndCheckOut.Size = new System.Drawing.Size(100, 20);
            this.mtbEndCheckOut.TabIndex = 43;
            this.mtbEndCheckOut.ValidatingType = typeof(System.DateTime);
            // 
            // mtbBeginCheckOut
            // 
            this.mtbBeginCheckOut.Location = new System.Drawing.Point(149, 195);
            this.mtbBeginCheckOut.Mask = "00:00";
            this.mtbBeginCheckOut.Name = "mtbBeginCheckOut";
            this.mtbBeginCheckOut.Size = new System.Drawing.Size(100, 20);
            this.mtbBeginCheckOut.TabIndex = 43;
            this.mtbBeginCheckOut.ValidatingType = typeof(System.DateTime);
            // 
            // mtbEndCheckIn
            // 
            this.mtbEndCheckIn.Location = new System.Drawing.Point(149, 169);
            this.mtbEndCheckIn.Mask = "00:00";
            this.mtbEndCheckIn.Name = "mtbEndCheckIn";
            this.mtbEndCheckIn.Size = new System.Drawing.Size(100, 20);
            this.mtbEndCheckIn.TabIndex = 43;
            this.mtbEndCheckIn.ValidatingType = typeof(System.DateTime);
            // 
            // mtbBeginCheckIn
            // 
            this.mtbBeginCheckIn.Location = new System.Drawing.Point(149, 143);
            this.mtbBeginCheckIn.Mask = "00:00";
            this.mtbBeginCheckIn.Name = "mtbBeginCheckIn";
            this.mtbBeginCheckIn.Size = new System.Drawing.Size(100, 20);
            this.mtbBeginCheckIn.TabIndex = 43;
            this.mtbBeginCheckIn.ValidatingType = typeof(System.DateTime);
            // 
            // mtbOffDuty
            // 
            this.mtbOffDuty.Location = new System.Drawing.Point(149, 117);
            this.mtbOffDuty.Mask = "00:00";
            this.mtbOffDuty.Name = "mtbOffDuty";
            this.mtbOffDuty.Size = new System.Drawing.Size(100, 20);
            this.mtbOffDuty.TabIndex = 43;
            this.mtbOffDuty.ValidatingType = typeof(System.DateTime);
            // 
            // mtbOnDuty
            // 
            this.mtbOnDuty.Location = new System.Drawing.Point(149, 91);
            this.mtbOnDuty.Mask = "00:00";
            this.mtbOnDuty.Name = "mtbOnDuty";
            this.mtbOnDuty.Size = new System.Drawing.Size(100, 20);
            this.mtbOnDuty.TabIndex = 43;
            this.mtbOnDuty.ValidatingType = typeof(System.DateTime);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(8, 51);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 13);
            this.lblID.TabIndex = 42;
            this.lblID.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Location = new System.Drawing.Point(8, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(90, 13);
            this.label29.TabIndex = 41;
            this.label29.Text = "Required Fields(*)";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(123, 20);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMessage.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnAddNew);
            this.groupBox3.Location = new System.Drawing.Point(11, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 54);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(169, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 36;
            this.btnUpdate.Text = "U&pdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(250, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "D&elete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(7, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(88, 19);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 37;
            this.btnAddNew.Text = "A&dd New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(149, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(198, 20);
            this.txtName.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 325);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Count As Work Time(s) :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 299);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Count As Work Day(s) :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 273);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Early Allowence  :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 247);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Late Allowence :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 221);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "End Check Out :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Begin Check Out :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "End Check In :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Begin Check In :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Off Duty :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "On Duty :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 42);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Name :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.dgvDetailData);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 479);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lists";
            // 
            // dgvDetailData
            // 
            this.dgvDetailData.AllowUserToAddRows = false;
            this.dgvDetailData.AllowUserToDeleteRows = false;
            this.dgvDetailData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailData.Location = new System.Drawing.Point(3, 16);
            this.dgvDetailData.Name = "dgvDetailData";
            this.dgvDetailData.ReadOnly = true;
            this.dgvDetailData.Size = new System.Drawing.Size(218, 460);
            this.dgvDetailData.TabIndex = 0;
            this.dgvDetailData.SelectionChanged += new System.EventHandler(this.dgvDetailData_SelectionChanged);
            // 
            // frmShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 523);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings: Shift";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTotalWorkTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrTotalWorkDays)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox mtbOnDuty;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDetailData;
        private System.Windows.Forms.MaskedTextBox mtbEndCheckOut;
        private System.Windows.Forms.MaskedTextBox mtbBeginCheckOut;
        private System.Windows.Forms.MaskedTextBox mtbEndCheckIn;
        private System.Windows.Forms.MaskedTextBox mtbBeginCheckIn;
        private System.Windows.Forms.MaskedTextBox mtbOffDuty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMustCheckOut;
        private System.Windows.Forms.CheckBox chkMustCheckIn;
        private System.Windows.Forms.NumericUpDown nmrTotalWorkTimes;
        private System.Windows.Forms.NumericUpDown nmrTotalWorkDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox mtbEarlyAllowence;
        private System.Windows.Forms.MaskedTextBox mtbLateAllowence;
    }
}