namespace MultitabledDataSetApp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewInv = new System.Windows.Forms.DataGridView();
            this.dataGridViewCust = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrd = new System.Windows.Forms.DataGridView();
            this.btnUpdateDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetOrderInfo = new System.Windows.Forms.Button();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCust)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInv
            // 
            this.dataGridViewInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInv.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewInv.Name = "dataGridViewInv";
            this.dataGridViewInv.Size = new System.Drawing.Size(570, 126);
            this.dataGridViewInv.TabIndex = 0;
            // 
            // dataGridViewCust
            // 
            this.dataGridViewCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCust.Location = new System.Drawing.Point(12, 182);
            this.dataGridViewCust.Name = "dataGridViewCust";
            this.dataGridViewCust.Size = new System.Drawing.Size(570, 126);
            this.dataGridViewCust.TabIndex = 1;
            // 
            // dataGridViewOrd
            // 
            this.dataGridViewOrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrd.Location = new System.Drawing.Point(12, 341);
            this.dataGridViewOrd.Name = "dataGridViewOrd";
            this.dataGridViewOrd.Size = new System.Drawing.Size(570, 126);
            this.dataGridViewOrd.TabIndex = 2;
            // 
            // btnUpdateDatabase
            // 
            this.btnUpdateDatabase.Location = new System.Drawing.Point(469, 473);
            this.btnUpdateDatabase.Name = "btnUpdateDatabase";
            this.btnUpdateDatabase.Size = new System.Drawing.Size(113, 23);
            this.btnUpdateDatabase.TabIndex = 3;
            this.btnUpdateDatabase.Text = "Update Database";
            this.btnUpdateDatabase.UseVisualStyleBackColor = true;
            this.btnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Inventory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Customers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Orders";
            // 
            // btnGetOrderInfo
            // 
            this.btnGetOrderInfo.Location = new System.Drawing.Point(16, 473);
            this.btnGetOrderInfo.Name = "btnGetOrderInfo";
            this.btnGetOrderInfo.Size = new System.Drawing.Size(104, 23);
            this.btnGetOrderInfo.TabIndex = 7;
            this.btnGetOrderInfo.Text = "Get Order Details";
            this.btnGetOrderInfo.UseVisualStyleBackColor = true;
            this.btnGetOrderInfo.Click += new System.EventHandler(this.btnGetOrderInfo_Click);
            // 
            // txtCustId
            // 
            this.txtCustId.Location = new System.Drawing.Point(127, 473);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(100, 20);
            this.txtCustId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 479);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Customer ID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 507);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCustId);
            this.Controls.Add(this.btnGetOrderInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateDatabase);
            this.Controls.Add(this.dataGridViewOrd);
            this.Controls.Add(this.dataGridViewCust);
            this.Controls.Add(this.dataGridViewInv);
            this.Name = "MainForm";
            this.Text = "AutoLot Database Manipulator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCust)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInv;
        private System.Windows.Forms.DataGridView dataGridViewCust;
        private System.Windows.Forms.DataGridView dataGridViewOrd;
        private System.Windows.Forms.Button btnUpdateDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetOrderInfo;
        private System.Windows.Forms.TextBox txtCustId;
        private System.Windows.Forms.Label label4;
    }
}

