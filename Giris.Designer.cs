
namespace Fatura_Stok
{
    partial class Giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSifirla = new System.Windows.Forms.Button();
            this.cbTur = new System.Windows.Forms.ComboBox();
            this.cbKisi = new System.Windows.Forms.ComboBox();
            this.cbDonem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnYeni = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataFatura = new System.Windows.Forms.DataGridView();
            this.bwYukle = new System.ComponentModel.BackgroundWorker();
            this.lblToplam = new System.Windows.Forms.Label();
            this.Kisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Donem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IkinciKisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IkinciFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aciklama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ac = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Kaydet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IkinciAc = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IkinciKaydet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Sil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KisiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IkinciKisiId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TurId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dekont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IkinciDekont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFatura)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSifirla
            // 
            this.btnSifirla.AutoSize = true;
            this.btnSifirla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSifirla.Location = new System.Drawing.Point(79, 3);
            this.btnSifirla.Name = "btnSifirla";
            this.btnSifirla.Size = new System.Drawing.Size(48, 25);
            this.btnSifirla.TabIndex = 0;
            this.btnSifirla.Text = "Sıfırla";
            this.btnSifirla.UseVisualStyleBackColor = true;
            this.btnSifirla.Click += new System.EventHandler(this.btnSifirla_Click);
            // 
            // cbTur
            // 
            this.cbTur.DisplayMember = "Ad";
            this.cbTur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTur.FormattingEnabled = true;
            this.cbTur.Location = new System.Drawing.Point(309, 3);
            this.cbTur.Name = "cbTur";
            this.cbTur.Size = new System.Drawing.Size(236, 23);
            this.cbTur.TabIndex = 0;
            this.cbTur.ValueMember = "Id";
            this.cbTur.SelectedIndexChanged += new System.EventHandler(this.Filtre_Guncelle);
            // 
            // cbKisi
            // 
            this.cbKisi.DisplayMember = "AdSoyad";
            this.cbKisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKisi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKisi.FormattingEnabled = true;
            this.cbKisi.Location = new System.Drawing.Point(36, 3);
            this.cbKisi.Name = "cbKisi";
            this.cbKisi.Size = new System.Drawing.Size(236, 23);
            this.cbKisi.TabIndex = 2;
            this.cbKisi.ValueMember = "Id";
            this.cbKisi.SelectedIndexChanged += new System.EventHandler(this.Filtre_Guncelle);
            // 
            // cbDonem
            // 
            this.cbDonem.DisplayMember = "Ad";
            this.cbDonem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDonem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDonem.FormattingEnabled = true;
            this.cbDonem.Location = new System.Drawing.Point(605, 3);
            this.cbDonem.Name = "cbDonem";
            this.cbDonem.Size = new System.Drawing.Size(237, 23);
            this.cbDonem.TabIndex = 3;
            this.cbDonem.ValueMember = "Id";
            this.cbDonem.SelectedIndexChanged += new System.EventHandler(this.Filtre_Guncelle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kişi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(278, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tür";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbTur, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbDonem, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbKisi, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 60);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 6);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnYeni, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSifirla, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(715, 29);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 31);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnYeni
            // 
            this.btnYeni.AutoSize = true;
            this.btnYeni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYeni.Location = new System.Drawing.Point(3, 3);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(70, 25);
            this.btnYeni.TabIndex = 2;
            this.btnYeni.Text = "Yeni Kayıt";
            this.btnYeni.UseVisualStyleBackColor = true;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dönem";
            // 
            // dataFatura
            // 
            this.dataFatura.AllowUserToAddRows = false;
            this.dataFatura.AllowUserToDeleteRows = false;
            this.dataFatura.AllowUserToResizeRows = false;
            this.dataFatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataFatura.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataFatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFatura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kisi,
            this.Tur,
            this.Donem,
            this.Fiyat,
            this.IkinciKisi,
            this.IkinciFiyat,
            this.Aciklama,
            this.Ac,
            this.Kaydet,
            this.IkinciAc,
            this.IkinciKaydet,
            this.Sil,
            this.Id,
            this.KisiId,
            this.IkinciKisiId,
            this.DonemId,
            this.TurId,
            this.Dekont,
            this.IkinciDekont});
            this.dataFatura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataFatura.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataFatura.Location = new System.Drawing.Point(0, 60);
            this.dataFatura.MultiSelect = false;
            this.dataFatura.Name = "dataFatura";
            this.dataFatura.ReadOnly = true;
            this.dataFatura.RowHeadersVisible = false;
            this.dataFatura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFatura.Size = new System.Drawing.Size(845, 378);
            this.dataFatura.TabIndex = 9;
            this.dataFatura.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFatura_CellContentClick);
            this.dataFatura.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFatura_CellContentDoubleClick);
            this.dataFatura.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataFatura_DataBindingComplete);
            // 
            // bwYukle
            // 
            this.bwYukle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwYukle_DoWork);
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblToplam.Location = new System.Drawing.Point(0, 438);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(0, 20);
            this.lblToplam.TabIndex = 10;
            // 
            // Kisi
            // 
            this.Kisi.DataPropertyName = "Kisi";
            this.Kisi.HeaderText = "Kişi";
            this.Kisi.Name = "Kisi";
            this.Kisi.ReadOnly = true;
            this.Kisi.Width = 52;
            // 
            // Tur
            // 
            this.Tur.DataPropertyName = "Tur";
            this.Tur.HeaderText = "Tür";
            this.Tur.Name = "Tur";
            this.Tur.ReadOnly = true;
            this.Tur.Width = 50;
            // 
            // Donem
            // 
            this.Donem.DataPropertyName = "Donem";
            this.Donem.HeaderText = "Dönem";
            this.Donem.Name = "Donem";
            this.Donem.ReadOnly = true;
            this.Donem.Width = 73;
            // 
            // Fiyat
            // 
            this.Fiyat.DataPropertyName = "Fiyat";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Fiyat.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fiyat.HeaderText = "Fiyat";
            this.Fiyat.Name = "Fiyat";
            this.Fiyat.ReadOnly = true;
            this.Fiyat.Width = 57;
            // 
            // IkinciKisi
            // 
            this.IkinciKisi.DataPropertyName = "IkinciKisi";
            this.IkinciKisi.HeaderText = "İkinci Kişi";
            this.IkinciKisi.Name = "IkinciKisi";
            this.IkinciKisi.ReadOnly = true;
            this.IkinciKisi.Width = 83;
            // 
            // IkinciFiyat
            // 
            this.IkinciFiyat.DataPropertyName = "IkinciFiyat";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.IkinciFiyat.DefaultCellStyle = dataGridViewCellStyle2;
            this.IkinciFiyat.HeaderText = "İkinci Fiyat";
            this.IkinciFiyat.Name = "IkinciFiyat";
            this.IkinciFiyat.ReadOnly = true;
            this.IkinciFiyat.Width = 88;
            // 
            // Aciklama
            // 
            this.Aciklama.DataPropertyName = "Aciklama";
            this.Aciklama.HeaderText = "Açıklama";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.ReadOnly = true;
            this.Aciklama.Width = 82;
            // 
            // Ac
            // 
            this.Ac.HeaderText = "Aç";
            this.Ac.Name = "Ac";
            this.Ac.ReadOnly = true;
            this.Ac.Text = "Aç";
            this.Ac.UseColumnTextForButtonValue = true;
            this.Ac.Width = 26;
            // 
            // Kaydet
            // 
            this.Kaydet.HeaderText = "Kaydet";
            this.Kaydet.Name = "Kaydet";
            this.Kaydet.ReadOnly = true;
            this.Kaydet.Text = "Kaydet";
            this.Kaydet.UseColumnTextForButtonValue = true;
            this.Kaydet.Width = 50;
            // 
            // IkinciAc
            // 
            this.IkinciAc.HeaderText = "İkinci Aç";
            this.IkinciAc.Name = "IkinciAc";
            this.IkinciAc.ReadOnly = true;
            this.IkinciAc.Text = "İkinci Aç";
            this.IkinciAc.UseColumnTextForButtonValue = true;
            this.IkinciAc.Width = 57;
            // 
            // IkinciKaydet
            // 
            this.IkinciKaydet.HeaderText = "İkinci Kaydet";
            this.IkinciKaydet.Name = "IkinciKaydet";
            this.IkinciKaydet.ReadOnly = true;
            this.IkinciKaydet.Text = "İkinci Kaydet";
            this.IkinciKaydet.UseColumnTextForButtonValue = true;
            this.IkinciKaydet.Width = 81;
            // 
            // Sil
            // 
            this.Sil.HeaderText = "Sil";
            this.Sil.Name = "Sil";
            this.Sil.ReadOnly = true;
            this.Sil.Text = "Sil";
            this.Sil.UseColumnTextForButtonValue = true;
            this.Sil.Width = 27;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 42;
            // 
            // KisiId
            // 
            this.KisiId.DataPropertyName = "KisiId";
            this.KisiId.HeaderText = "Kişi Id";
            this.KisiId.Name = "KisiId";
            this.KisiId.ReadOnly = true;
            this.KisiId.Visible = false;
            this.KisiId.Width = 65;
            // 
            // IkinciKisiId
            // 
            this.IkinciKisiId.DataPropertyName = "IkinciKisiId";
            this.IkinciKisiId.HeaderText = "İkinci Kişi Id";
            this.IkinciKisiId.Name = "IkinciKisiId";
            this.IkinciKisiId.ReadOnly = true;
            this.IkinciKisiId.Visible = false;
            this.IkinciKisiId.Width = 96;
            // 
            // DonemId
            // 
            this.DonemId.DataPropertyName = "DonemId";
            this.DonemId.HeaderText = "Dönem Id";
            this.DonemId.Name = "DonemId";
            this.DonemId.ReadOnly = true;
            this.DonemId.Visible = false;
            this.DonemId.Width = 86;
            // 
            // TurId
            // 
            this.TurId.DataPropertyName = "TurId";
            this.TurId.HeaderText = "Tür Id";
            this.TurId.Name = "TurId";
            this.TurId.ReadOnly = true;
            this.TurId.Visible = false;
            this.TurId.Width = 63;
            // 
            // Dekont
            // 
            this.Dekont.DataPropertyName = "Dekont";
            this.Dekont.HeaderText = "Dekont";
            this.Dekont.Name = "Dekont";
            this.Dekont.ReadOnly = true;
            this.Dekont.Visible = false;
            this.Dekont.Width = 71;
            // 
            // IkinciDekont
            // 
            this.IkinciDekont.DataPropertyName = "IkinciDekont";
            this.IkinciDekont.HeaderText = "İkinci Dekont";
            this.IkinciDekont.Name = "IkinciDekont";
            this.IkinciDekont.ReadOnly = true;
            this.IkinciDekont.Visible = false;
            this.IkinciDekont.Width = 102;
            // 
            // Giris
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(845, 458);
            this.Controls.Add(this.dataFatura);
            this.Controls.Add(this.lblToplam);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.Name = "Giris";
            this.Text = "Fatura Stok";
            this.Load += new System.EventHandler(this.Giris_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFatura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSifirla;
        private System.Windows.Forms.ComboBox cbTur;
        private System.Windows.Forms.ComboBox cbKisi;
        private System.Windows.Forms.ComboBox cbDonem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.DataGridView dataFatura;
        private System.ComponentModel.BackgroundWorker bwYukle;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Donem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn IkinciKisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn IkinciFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aciklama;
        private System.Windows.Forms.DataGridViewButtonColumn Ac;
        private System.Windows.Forms.DataGridViewButtonColumn Kaydet;
        private System.Windows.Forms.DataGridViewButtonColumn IkinciAc;
        private System.Windows.Forms.DataGridViewButtonColumn IkinciKaydet;
        private System.Windows.Forms.DataGridViewButtonColumn Sil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn KisiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn IkinciKisiId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TurId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dekont;
        private System.Windows.Forms.DataGridViewTextBoxColumn IkinciDekont;
    }
}

