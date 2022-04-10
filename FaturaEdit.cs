using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fatura_Stok
{
    public partial class FaturaEdit : Form
    {
        private Fatura fatura = new Fatura();
        public long id;

        public FaturaEdit()
        {
            InitializeComponent();
        }

        private void FaturaEdit_Load(object sender, EventArgs e)
        {
            Guncelle();
            if (id != 0)
            {
                fatura = Kayit.stok.Fatura.First(t => t.Id == id);
                cbDonem.SelectedValue = fatura.DonemId;
                cbKisi.SelectedValue = fatura.KisiId;
                cbIkinciKisi.SelectedValue = fatura.IkinciKisiId;
                cbTur.SelectedValue = fatura.TurId;
                txtFiyat.Text = fatura.Fiyat.ToString();
                txtIkinciKisiFiyat.Text = fatura.IkinciFiyat.ToString();
                txtAciklama.Text = fatura.Aciklama;
                Text = "Fatura Düzenle";
                btnKaydet.Text = "Kaydet";
            }
        }

        private void Guncelle()
        {
            cbDonem.DataSource = Kayit.stok.Donemler.OrderByDescending(t => t.Id).ToList();
            cbKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
            cbIkinciKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
            cbTur.DataSource = Kayit.stok.Turler.OrderByDescending(t => t.Id).ToList();
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            if (id == 0 && !string.IsNullOrEmpty(txtDekont.Text))
                Process.Start(txtDekont.Text);
            else if (id != 0 && fatura.Dekont == null)
                MessageBox.Show("Dekont yüklenmemiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (id != 0 && fatura.Dekont != null)
            {
                string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"tempdekont{fatura.Id}_{new Random().Next()}.pdf");
                File.WriteAllBytes(yol, Convert.FromBase64String(fatura.Dekont));
                Process.Start(yol);
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Pdf Dosyası | *.pdf";
            file.Title = "Dekont dosyası seç..";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
                txtDekont.Text = file.FileName;
        }

        private void btnKisi_Click(object sender, EventArgs e)
        {
            KisiEdit frm = new KisiEdit();
            frm.ShowDialog();
            cbKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
            cbIkinciKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
        }

        private void btnTur_Click(object sender, EventArgs e)
        {
            TurEdit frm = new TurEdit();
            frm.ShowDialog();
            cbTur.DataSource = Kayit.stok.Turler.OrderByDescending(t => t.Id).ToList();
        }

        private void btnDonem_Click(object sender, EventArgs e)
        {
            DonemEdit frm = new DonemEdit();
            frm.ShowDialog();
            cbDonem.DataSource = Kayit.stok.Donemler.OrderByDescending(t => t.Id).ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbKisi.SelectedIndex == -1)
            {
                MessageBox.Show("Kişi seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbKisi.Focus();
            }
            else if (cbTur.SelectedIndex == -1)
            {
                MessageBox.Show("Tür seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbTur.Focus();
            }
            else if (cbDonem.SelectedIndex == -1)
            {
                MessageBox.Show("Dönem seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbDonem.Focus();
            }
            else if (string.IsNullOrEmpty(txtFiyat.Text))
            {
                MessageBox.Show("Fiyat boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFiyat.Focus();
            }
            else if (!decimal.TryParse(txtFiyat.Text, out decimal fiyat))
            {
                MessageBox.Show("Fiyat sadece sayısal değer olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFiyat.Focus();
            }
            else if (!decimal.TryParse(txtIkinciKisiFiyat.Text == "" ? "0" : txtIkinciKisiFiyat.Text, out decimal ikinciFiyat))
            {
                MessageBox.Show("İkinci kişi fiyat sadece sayısal değer olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIkinciKisiFiyat.Focus();
            }
            //else if (id == 0 && string.IsNullOrEmpty(txtDekont.Text))
            //{
            //    MessageBox.Show("Dekont seçmelisiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    txtDekont.Focus();
            //}
            else if (Kayit.stok.Fatura.Any(t => t.KisiId == (long)cbKisi.SelectedValue && t.TurId == (long)cbTur.SelectedValue && t.DonemId == (long)cbDonem.SelectedValue && t.Fiyat == fiyat && t.IkinciKisiId == (long)cbIkinciKisi.SelectedValue && t.IkinciFiyat == ikinciFiyat && t.Aciklama == txtAciklama.Text))
                MessageBox.Show("Aynı kayıt daha önce eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (id == 0)
                    fatura = new Fatura();
                fatura.KisiId = (long)cbKisi.SelectedValue;
                fatura.TurId = (long)cbTur.SelectedValue;
                fatura.DonemId = (long)cbDonem.SelectedValue;
                fatura.Fiyat = fiyat;
                fatura.IkinciKisiId = (long)cbIkinciKisi.SelectedValue;
                fatura.IkinciFiyat = ikinciFiyat;
                fatura.Aciklama = txtAciklama.Text;
                if (!string.IsNullOrEmpty(txtDekont.Text))
                    fatura.Dekont = Convert.ToBase64String(File.ReadAllBytes(txtDekont.Text));
                if (!string.IsNullOrEmpty(txtIkinciKisiDekont.Text))
                    fatura.IkinciDekont = Convert.ToBase64String(File.ReadAllBytes(txtIkinciKisiDekont.Text));
                if (id == 0)
                {
                    fatura.Id = Kayit.GetId(Kayit.stok.Fatura);
                    Kayit.stok.Fatura.Add(fatura);
                }
                Kayit.Kaydet();
                MessageBox.Show($"Fatura {(id == 0 ? "eklendi" : "kaydedildi")}.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIkinciKisi_Click(object sender, EventArgs e)
        {
            KisiEdit frm = new KisiEdit();
            frm.ShowDialog();
            cbKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
            cbIkinciKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList(); ;
        }

        private void btnSec2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Pdf Dosyası | *.pdf";
            file.Title = "Dekont dosyası seç..";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
                txtIkinciKisiDekont.Text = file.FileName;
        }

        private void btnAc2_Click(object sender, EventArgs e)
        {
            if (id == 0 && !string.IsNullOrEmpty(txtIkinciKisiDekont.Text))
                Process.Start(txtIkinciKisiDekont.Text);
            else if (id != 0 && fatura.IkinciDekont == null)
                MessageBox.Show("Dekont yüklenmemiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (id != 0 && fatura.IkinciDekont != null)
            {
                string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"tempikincidekont{fatura.Id}_{new Random().Next()}.pdf");
                File.WriteAllBytes(yol, Convert.FromBase64String(fatura.IkinciDekont));
                Process.Start(yol);
            }
        }

        private void btnYariAl_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtFiyat.Text, out decimal fiyat))
                txtIkinciKisiFiyat.Text = (fiyat / 2).ToString();
        }
    }
}