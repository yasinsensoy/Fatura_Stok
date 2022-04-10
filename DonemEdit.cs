using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fatura_Stok
{
    public partial class DonemEdit : Form
    {
        Donemler donem;

        public DonemEdit()
        {
            InitializeComponent();
        }

        private void DonemEdit_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> aylar = new Dictionary<string, int>();
            foreach (var item in Kayit.aylar)
                aylar.Add($"{item.Key:D2}-{item.Value}", item.Key);
            cbAy.DataSource = aylar.OrderBy(t => t.Value).ToList();
            Dictionary<string, int> yillar = new Dictionary<string, int>();
            for (int i = DateTime.Now.Year; i >= 2000; i--)
                yillar.Add(i.ToString(), i);
            cbYil.DataSource = yillar.OrderByDescending(t => t.Value).ToList();
            Guncelle();
        }

        private void Guncelle()
        {
            dataKisi.DataSource = Kayit.stok.Donemler.OrderByDescending(t => t.Id).ToList();
        }

        private bool Kontrol()
        {
            if (Kayit.stok.Donemler.Any(t => t.Yil == (int)cbYil.SelectedValue && t.Ay == (int)cbAy.SelectedValue))
                MessageBox.Show("Aynı kayıt daha önce eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                return true;
            return false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (Kontrol())
            {
                Kayit.stok.Donemler.Add(new Donemler(Kayit.GetId(Kayit.stok.Donemler), (int)cbYil.SelectedValue, (int)cbAy.SelectedValue));
                Kayit.Kaydet();
                Guncelle();
                donem = null;
                MessageBox.Show("Dönem eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Kontrol() && donem != null)
            {
                donem.Ay = (int)cbAy.SelectedValue;
                donem.Yil = (int)cbYil.SelectedValue;
                Kayit.Kaydet();
                Guncelle();
                MessageBox.Show("Dönem kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçilen kayıtları silmek istiyor musunuz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow item in dataKisi.SelectedRows)
                    Kayit.stok.Donemler.Remove(Kayit.stok.Donemler.First(t => t.Id == (long)item.Cells["Id"].Value));
                Kayit.Kaydet();
                Guncelle();
                donem = null;
            }
        }

        private void dataKisi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                donem = Kayit.stok.Donemler.First(t => t.Id == (long)dataKisi.Rows[e.RowIndex].Cells["Id"].Value);
        }
    }
}
