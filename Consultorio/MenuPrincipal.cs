using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consultorio
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PMedico medico = new PMedico();
            medico.MdiParent = this;
            medico.Show();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PPaciente paciente = new PPaciente();
            paciente.MdiParent = this;
            paciente.Show();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PCita cita = new PCita();
            cita.MdiParent = this;
            cita.Show();
        }
    }
}
