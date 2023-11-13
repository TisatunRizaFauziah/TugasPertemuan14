using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasPertemuan14.Model;

namespace TugasPertemuan14.Controller
{
    internal class MahasisawaController : Model.Connection
    {
       
        public DataTable tampilMahasiswa()
        {
            DataTable dt = new DataTable();

            try
            {
                string tampil = " SELECT * FROM mahasiswa ";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        Connection koneksi = new Connection();
        public DataTable getlist(MySqlCommand cmd)
        {
            cmd.Connection = koneksi.GetConn();
            DataTable dt = new DataTable();

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public void tambahMahasiswa(string nim,string nama,DateTime tanggalLahir, byte[] photo)
        {
            string tambah = " INSERT INTO mahasiswa VALUES (" + "@NIM,@Nama,@tanggal_lahir,@Photo)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(tambah, GetConn());
                cmd.Parameters.Add("@NIM", MySqlConnector.MySqlDbType.VarChar).Value = nim;
                cmd.Parameters.Add("@Nama", MySqlConnector.MySqlDbType.VarChar).Value = nama;
                cmd.Parameters.Add("@tanggal_lahir", MySqlConnector.MySqlDbType.Date).Value = tanggalLahir;
                cmd.Parameters.Add("@Photo", MySqlConnector.MySqlDbType.Blob).Value = photo;
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Data Gagal " + ex.Message);

            }
        }
        public void hapusMahasiswa(string nim)
        {
            string hapus = "DELETE FROM mahasiswa WHERE NIM = " + nim;

            try
            {
                cmd = new MySqlConnector.MySqlCommand(hapus, GetConn());
                cmd.Parameters.Add("@NIM", MySqlConnector.MySqlDbType.VarChar).Value = nim;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("hapus gagal " + ex.Message);
            }
            
        }
    }
}
