using CapaNegocio;
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
    public partial class PBuscarPacientes : Form
    {
        private NPaciente nPaciente;

        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public PBuscarPacientes()
        {
            InitializeComponent();
            nPaciente = new NPaciente();
            CargarDatos();
        }

        private void PBuscarPacientes_Load(object sender, EventArgs e)
        {

        }

        private void CargarDatos()
        {
            var datos = nPaciente.MostrarPacientes();
            dgPacientes.DataSource = datos;
            dgPacientes.Columns["Nombres"].HeaderText = "Nombre Completo";
            dgPacientes.Columns["Apellidos"].Visible = false;
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgPacientes.DataSource = nPaciente.PacientesActivos();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }

        private void dgPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PacienteId = Convert.ToInt32(dgPacientes.CurrentRow.Cells["PacienteId"].Value);
            Nombres = dgPacientes.CurrentRow.Cells["Nombres"].Value.ToString();
            Apellidos = dgPacientes.CurrentRow.Cells["Apellidos"].Value.ToString();
            this.Visible = false;
        }
    }
}
