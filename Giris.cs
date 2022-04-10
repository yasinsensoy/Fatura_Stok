using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fatura_Stok
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            Rectangle alan = Screen.GetWorkingArea(this);
            Size = new Size((int)(alan.Width * 0.8), (int)(alan.Height * 0.7));
            CenterToScreen();
            if (!bwYukle.IsBusy)
                bwYukle.RunWorkerAsync();

        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            cbKisi.SelectedIndexChanged -= new EventHandler(Filtre_Guncelle);
            cbKisi.SelectedIndex = 0;
            cbKisi.SelectedIndexChanged += new EventHandler(Filtre_Guncelle);
            cbTur.SelectedIndexChanged -= new EventHandler(Filtre_Guncelle);
            cbTur.SelectedIndex = 0;
            cbTur.SelectedIndexChanged += new EventHandler(Filtre_Guncelle);
            cbDonem.SelectedIndex = 0;
        }

        private void Filtre_Guncelle(object sender, EventArgs e)
        {
            long donem = (long)cbDonem.SelectedValue;
            long kisi = (long)cbKisi.SelectedValue;
            long tur = (long)cbTur.SelectedValue;
            dataFatura.DataSource = Kayit.stok.Fatura.Where(t => (t.DonemId == donem || donem == -1) && (t.KisiId == kisi || kisi == -1) && (t.TurId == tur || tur == -1)).OrderBy(t => t.Kisi).ThenBy(t => t.Donem).ThenBy(t => t.Tur).ToList();
        }

        private void Guncelle()
        {
            cbDonem.SelectedIndexChanged -= new EventHandler(Filtre_Guncelle);
            List<Donemler> donemler = new List<Donemler>() { new Donemler(-1, 0, 0) };
            donemler.AddRange(Kayit.stok.Donemler.OrderByDescending(t => t.Id));
            long dsv = cbDonem.SelectedValue == null ? -1 : (long)cbDonem.SelectedValue;
            cbDonem.DataSource = donemler;
            if (dsv != -1)
                cbDonem.SelectedValue = dsv;
            cbDonem.SelectedIndexChanged += new EventHandler(Filtre_Guncelle);
            cbKisi.SelectedIndexChanged -= new EventHandler(Filtre_Guncelle);
            List<Kisiler> kisiler = new List<Kisiler>() { new Kisiler(-1, "", "") };
            kisiler.AddRange(Kayit.stok.Kisiler.OrderByDescending(t => t.Id));
            long ksv = cbKisi.SelectedValue == null ? -1 : (long)cbKisi.SelectedValue;
            cbKisi.DataSource = kisiler;
            if (ksv != -1)
                cbKisi.SelectedValue = ksv;
            cbKisi.SelectedIndexChanged += new EventHandler(Filtre_Guncelle);
            cbTur.SelectedIndexChanged -= new EventHandler(Filtre_Guncelle);
            List<Turler> turler = new List<Turler>() { new Turler(-1, "") };
            turler.AddRange(Kayit.stok.Turler.OrderByDescending(t => t.Id));
            long tsv = cbTur.SelectedValue == null ? -1 : (long)cbTur.SelectedValue;
            cbTur.DataSource = turler;
            if (tsv != -1)
                cbTur.SelectedValue = tsv;
            cbTur.SelectedIndexChanged += new EventHandler(Filtre_Guncelle);
            dataFatura.DataSource = Kayit.stok.Fatura.Where(t => (t.DonemId == dsv || dsv == -1) && (t.KisiId == ksv || ksv == -1) && (t.TurId == tsv || tsv == -1)).OrderBy(t => t.Kisi).ThenBy(t => t.Donem).ThenBy(t => t.Tur).ToList();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            FaturaEdit frm = new FaturaEdit();
            frm.ShowDialog();
            Guncelle();
        }

        private void bwYukle_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Kayit.Yukle();
            Invoke((MethodInvoker)delegate
            {
                Guncelle();
            });
        }

        private void dataFatura_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                FaturaEdit frm = new FaturaEdit();
                frm.id = (long)dataFatura.Rows[e.RowIndex].Cells["Id"].Value;
                frm.ShowDialog();
                Guncelle();
            }
        }

        private void dataFatura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Fatura fatura = (Fatura)dataFatura.Rows[e.RowIndex].DataBoundItem;
                if (e.ColumnIndex == Ac.Index && !string.IsNullOrEmpty(fatura.Dekont))
                {
                    string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"tempdekont{fatura.Id}_{new Random().Next()}.pdf");
                    File.WriteAllBytes(yol, Convert.FromBase64String(fatura.Dekont));
                    Process.Start(yol);
                }
                else if (e.ColumnIndex == Kaydet.Index && !string.IsNullOrEmpty(fatura.Dekont))
                {
                    string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{fatura.Tur} {fatura.Donem} {fatura.Fiyat} TL.pdf");
                    File.WriteAllBytes(yol, Convert.FromBase64String(fatura.Dekont));
                    MessageBox.Show(yol, "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.ColumnIndex == IkinciAc.Index && !string.IsNullOrEmpty(fatura.IkinciDekont))
                {
                    string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"tempikincidekont{fatura.Id}_{new Random().Next()}.pdf");
                    File.WriteAllBytes(yol, Convert.FromBase64String(fatura.IkinciDekont));
                    Process.Start(yol);
                }
                else if (e.ColumnIndex == IkinciKaydet.Index && !string.IsNullOrEmpty(fatura.IkinciDekont))
                {
                    string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"İkinci Kişi {fatura.Tur} {fatura.Donem} {fatura.IkinciFiyat} TL.pdf");
                    File.WriteAllBytes(yol, Convert.FromBase64String(fatura.IkinciDekont));
                    MessageBox.Show(yol, "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (e.ColumnIndex == Sil.Index)
                {
                    DialogResult mesaj = MessageBox.Show("Silmek istediğinize emin misiniz?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (mesaj == DialogResult.Yes)
                    {
                        Kayit.stok.Fatura.Remove(Kayit.stok.Fatura.First(t => t.Id == fatura.Id));
                        Kayit.Kaydet();
                        Guncelle();
                    }
                }
            }
        }

        private void dataFatura_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataFatura.Columns["Kisi"].DisplayIndex = 0;
            dataFatura.Columns["Tur"].DisplayIndex = 1;
            dataFatura.Columns["Donem"].DisplayIndex = 2;
            dataFatura.Columns["Fiyat"].DisplayIndex = 3;
            dataFatura.Columns["IkinciKisi"].DisplayIndex = 4;
            dataFatura.Columns["IkinciFiyat"].DisplayIndex = 5;
            dataFatura.Columns["Aciklama"].DisplayIndex = 6;
            dataFatura.Columns["Ac"].DisplayIndex = 7;
            dataFatura.Columns["Kaydet"].DisplayIndex = 8;
            dataFatura.Columns["IkinciAc"].DisplayIndex = 9;
            dataFatura.Columns["IkinciKaydet"].DisplayIndex = 10;
            dataFatura.Columns["Sil"].DisplayIndex = 11;
            dataFatura.Columns["Id"].Visible = false;
            dataFatura.Columns["KisiId"].Visible = false;
            dataFatura.Columns["IkinciKisiId"].Visible = false;
            dataFatura.Columns["TurId"].Visible = false;
            dataFatura.Columns["DonemId"].Visible = false;
            dataFatura.Columns["Dekont"].Visible = false;
            dataFatura.Columns["IkinciDekont"].Visible = false;
            decimal toplam = 0, ikinciToplam = 0;
            foreach (DataGridViewRow item in dataFatura.Rows)
            {
                Fatura fatura = (Fatura)item.DataBoundItem;
                toplam += fatura.Fiyat;
                ikinciToplam += fatura.IkinciFiyat;
            }
            lblToplam.Text = $"Toplam: {toplam:C2} İkinci Kişi Toplam: {ikinciToplam:C2} Kişi Toplam: {toplam - ikinciToplam:C2}";
        }
    }
}
