namespace BD_MarLen
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search_but = new System.Windows.Forms.Button();
            this.search_field = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.DataGridView();
            this.lucene_serach = new System.Windows.Forms.Button();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.results)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // search_but
            // 
            this.search_but.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(59)))), ((int)(((byte)(40)))));
            this.search_but.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_but.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_but.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.search_but.Location = new System.Drawing.Point(135, 75);
            this.search_but.Name = "search_but";
            this.search_but.Size = new System.Drawing.Size(96, 44);
            this.search_but.TabIndex = 0;
            this.search_but.Text = "Найти";
            this.search_but.UseVisualStyleBackColor = false;
            this.search_but.Click += new System.EventHandler(this.button1_Click);
            // 
            // search_field
            // 
            this.search_field.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.search_field.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.search_field.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.search_field.Location = new System.Drawing.Point(135, 34);
            this.search_field.Name = "search_field";
            this.search_field.Size = new System.Drawing.Size(700, 25);
            this.search_field.TabIndex = 1;
            this.search_field.TextChanged += new System.EventHandler(this.search_field_TextChanged);
            // 
            // results
            // 
            this.results.AllowUserToAddRows = false;
            this.results.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.results.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.results.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.results.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.results.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HelveticaNeueCyr", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.results.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.results.ColumnHeadersHeight = 35;
            this.results.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.year});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.results.DefaultCellStyle = dataGridViewCellStyle6;
            this.results.GridColor = System.Drawing.Color.DimGray;
            this.results.Location = new System.Drawing.Point(135, 154);
            this.results.Name = "results";
            this.results.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.results.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.results.RowHeadersVisible = false;
            this.results.Size = new System.Drawing.Size(700, 661);
            this.results.TabIndex = 3;
            // 
            // lucene_serach
            // 
            this.lucene_serach.BackColor = System.Drawing.Color.DarkSlateGray;
            this.lucene_serach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lucene_serach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lucene_serach.Font = new System.Drawing.Font("HelveticaNeueCyr", 12F, System.Drawing.FontStyle.Bold);
            this.lucene_serach.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lucene_serach.Location = new System.Drawing.Point(265, 75);
            this.lucene_serach.Name = "lucene_serach";
            this.lucene_serach.Size = new System.Drawing.Size(150, 44);
            this.lucene_serach.TabIndex = 4;
            this.lucene_serach.Text = "Поиск Lucene";
            this.lucene_serach.UseVisualStyleBackColor = false;
            this.lucene_serach.Click += new System.EventHandler(this.lucene_serach_Click);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(BD_MarLen.Form1);
            // 
            // id
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(225)))));
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(225)))));
            this.name.DefaultCellStyle = dataGridViewCellStyle4;
            this.name.HeaderText = "Название фильма";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 457;
            // 
            // year
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(225)))));
            this.year.DefaultCellStyle = dataGridViewCellStyle5;
            this.year.HeaderText = "Год";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 140;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.lucene_serach);
            this.Controls.Add(this.results);
            this.Controls.Add(this.search_field);
            this.Controls.Add(this.search_but);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильмы";
            ((System.ComponentModel.ISupportInitialize)(this.results)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_but;
        private System.Windows.Forms.TextBox search_field;
        private System.Windows.Forms.DataGridView results;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Button lucene_serach;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
    }
}

