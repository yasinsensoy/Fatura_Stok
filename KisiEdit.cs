using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fatura_Stok
{
    public partial class KisiEdit : Form
    {
        Kisiler kisi;

        public KisiEdit()
        {
            InitializeComponent();
        }

        private void KisiEdit_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            dataKisi.DataSource = Kayit.stok.Kisiler.OrderByDescending(t => t.Id).ToList();
        }

        private bool Kontrol()
        {
            if (string.IsNullOrEmpty(txtAd.Text))
            {
                MessageBox.Show("Ad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAd.Focus();
            }
            else if (string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSoyad.Focus();
            }
            else if (Kayit.stok.Kisiler.Any(t => t.Ad == txtAd.Text && t.Soyad == txtSoyad.Text))
                MessageBox.Show("Aynı kayıt daha önce eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                return true;
            return false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Kontrol())
            {
                Kayit.stok.Kisiler.Add(new Kisiler(Kayit.GetId(Kayit.stok.Kisiler), txtAd.Text, txtSoyad.Text));
                Kayit.Kaydet();
                Guncelle();
                kisi = null;
                MessageBox.Show("Kişi eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAd.Focus();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Kontrol() && kisi != null)
            {
                kisi.Ad = txtAd.Text;
                kisi.Soyad = txtSoyad.Text;
                Kayit.Kaydet();
                Guncelle();
                MessageBox.Show("Kişi kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçilen kayıtları silmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dataKisi.SelectedRows)
                    Kayit.stok.Kisiler.Remove(Kayit.stok.Kisiler.First(t => t.Id == (long)item.Cells["Id"].Value));
                Kayit.Kaydet();
                Guncelle();
                kisi = null;
            }
        }

        private void dataKisi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                kisi = Kayit.stok.Kisiler.First(t => t.Id == (long)dataKisi.Rows[e.RowIndex].Cells["Id"].Value);
        }
    }
}
