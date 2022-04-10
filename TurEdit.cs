using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fatura_Stok
{
    public partial class TurEdit : Form
    {
        Turler tur;

        public TurEdit()
        {
            InitializeComponent();
        }

        private void TurEdit_Load(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void Guncelle()
        {
            dataTur.DataSource = Kayit.stok.Turler.OrderByDescending(t => t.Id).ToList();
        }

        private bool Kontrol()
        {
            if (string.IsNullOrEmpty(txtTur.Text))
            {
                MessageBox.Show("Tür boş olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTur.Focus();
            }
            else if (Kayit.stok.Turler.Any(t => t.Tur == txtTur.Text))
                MessageBox.Show("Aynı kayıt daha önce eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                return true;
            return false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Kontrol())
            {
                Kayit.stok.Turler.Add(new Turler(Kayit.GetId(Kayit.stok.Turler), txtTur.Text));
                Kayit.Kaydet();
                Guncelle();
                tur = null;
                MessageBox.Show("Tür eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTur.Focus();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Kontrol() && tur != null)
            {
                tur.Tur = txtTur.Text;
                Kayit.Kaydet();
                Guncelle();
                MessageBox.Show("Tür kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçilen kayıtları silmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dataTur.SelectedRows)
                    Kayit.stok.Turler.Remove(Kayit.stok.Turler.First(t => t.Id == (long)item.Cells["Id"].Value));
                Kayit.Kaydet();
                Guncelle();
                tur = null;
            }
        }

        private void dataKisi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                tur = Kayit.stok.Turler.First(t => t.Id == (long)dataTur.Rows[e.RowIndex].Cells["Id"].Value);
        }
    }
}
