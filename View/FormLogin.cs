using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasPertemuan14.Controller;
using TugasPertemuan14.View;

namespace TugasPertemuan14
{
    
    public partial class FormLogin : Form
    {
        MahasisawaController mhs = new MahasisawaController();
        public FormLogin()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if ((txtAdmin.Text == "") || (txtPass.Text == ""))
            {
                MessageBox.Show("Need login data ", "wrong login ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string name = txtAdmin.Text;
                string pass = txtPass.Text;
                DataTable table = mhs.getlist(new MySqlConnector.MySqlCommand
                    ("SELECT * FROM admin WHERE admin = '" + name + "' AND passwoard = '" + pass + "'"));
                if (table.Rows.Count > 0)
                {
                    FormUtama fr = new FormUtama();
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("your admin and passwoard are not exist", "wrong login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp signUp = new FormSignUp();
            signUp.Show();
            this.Hide();
        }


        private void PictureBoxBuka_Click(object sender, EventArgs e)
        {
            if (PictureBoxBuka.Visible == true)
            {
                PictureBoxBuka.Visible = false;
                //txtPass.UseSystemPasswordChar = true;
            }
        }

        private void PictureBoxTutup_Click_1(object sender, EventArgs e)
        {
            if (PictureBoxBuka.Visible == false)
            {
                PictureBoxBuka.Visible = true;
               // txtPass.UseSystemPasswordChar = false;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
