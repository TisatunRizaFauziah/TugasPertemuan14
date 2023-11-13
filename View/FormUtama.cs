using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using TugasPertemuan14.Controller;

namespace TugasPertemuan14.View
{
    public partial class FormUtama : Form
    {
        private MahasisawaController mhs = new MahasisawaController();
        public FormUtama()
        {
            InitializeComponent();
            tampilMahasiswa();
        }
        public void tampilMahasiswa()
        {
            dataGridViewMhs.DataSource = mhs.tampilMahasiswa();
            //dataGridViewMhs.RowTemplate.Height = 40;
            dataGridViewMhs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            byte[] img = (byte[])dataGridViewMhs.CurrentRow.Cells[3].Value;
            MemoryStream gambar = new MemoryStream(img);
            PictureBoxMhs.Image = Image.FromStream(gambar);
            PictureBoxMhs.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void FormUtama_Load(object sender, EventArgs e)
        { 
            txtNIM.MaxLength = 10;
            txtNama.MaxLength = 25;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNIM.Clear();
            txtNama.Clear();
            dtTanggalLahir.Value = DateTime.Now;
            PictureBoxMhs.Image = null;

            
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtTanggalLahir.CustomFormat = "dd/MM/yyyy";
          
        }

        private void dataGridViewMhs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNIM.Text = dataGridViewMhs.CurrentRow.Cells[0].Value.ToString();
            txtNama.Text = dataGridViewMhs.CurrentRow.Cells[1].Value.ToString();
            dtTanggalLahir.Value = (DateTime)dataGridViewMhs.CurrentRow.Cells[2].Value;
            byte[] img = (byte[])dataGridViewMhs.CurrentRow.Cells[3].Value;
            MemoryStream gambar = new MemoryStream(img);
            PictureBoxMhs.Image = Image.FromStream(gambar);
            PictureBoxMhs.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        bool verify()
        {
            if (string.IsNullOrEmpty(txtNIM.Text) || string.IsNullOrEmpty(txtNama.Text) || 
                dtTanggalLahir.Value == null ||PictureBoxMhs.Image == null)
               
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try { 
                mhs.hapusMahasiswa(txtNIM.Text);
                tampilMahasiswa();
                btnClear.PerformClick();
                MessageBox.Show("Hapus data berhasil", "Hapus data", MessageBoxButtons.OK, MessageBoxIcon.Information); txtNIM.Focus();
                }
                catch (Exception ex) { 
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hapus data error", "Hapus data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       }
    

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select Photo(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if(opf.ShowDialog() == DialogResult.OK)
            {
                PictureBoxMhs.Image=Image.FromFile(opf.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
                int born_year = dtTanggalLahir.Value.Year;
                int this_year = DateTime.Now.Year;
            if ((this_year - born_year) <= 17 || (this_year - born_year) >= 25) {
                MessageBox.Show("Umur harus diantar 17 s/d 25", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (verify())
            {
                try
                {
                    MemoryStream memori = new MemoryStream();
                    PictureBoxMhs.Image.Save(memori, PictureBoxMhs.Image.RawFormat);
                    byte[] img =memori.ToArray();
                   mhs.tambahMahasiswa(txtNIM.Text, txtNama.Text,
                    dtTanggalLahir.Value,img);
                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tampilMahasiswa();
                    txtNIM.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Inputan kosong", "Tambah data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            }
    }
}
