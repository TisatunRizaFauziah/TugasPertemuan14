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

namespace TugasPertemuan14.View
{
    public partial class FormSignUp : Form
    {
        private Admin admin = new Admin();
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            Admin admin = new Admin();
            
                try
                {
                    admin.tambahAdmin(txtId.Text,txtAdmin.Text, txtPass.Text);
               
                    MessageBox.Show("New Admin Added ", "Add Admin ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtId.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            
        }
    }
    
}