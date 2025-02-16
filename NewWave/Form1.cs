using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewWave
{
    public partial class Acceso: Form
    {
        public Acceso()
        {
            InitializeComponent();
        }

        private void SalirAcceso_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void aceptarAcceso_Click(object sender, EventArgs e)
        {
            if (textUsuario.Text == "admin" && maskedTextCont.Text == "1234")
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
