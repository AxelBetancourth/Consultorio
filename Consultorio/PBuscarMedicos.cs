using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
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
    public partial class PBuscarMedicos : Form
    {
        private NMedico nMedico;
        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public PBuscarMedicos()
        {
            InitializeComponent();
            nMedico = new NMedico();
            CargarDatos();
        }

        private void PBuscarMedicos_Load(object sender, EventArgs e)
        {
        }

        private void CargarDatos()
        {
            var datos = nMedico.MostrarMedicos();
            dgMedicos.DataSource = datos;
            dgMedicos.Columns["Nombres"].HeaderText = "Nombre Completo";
            dgMedicos.Columns["Apellidos"].Visible = false;
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgMedicos.DataSource = nMedico.MedicosActivos();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }

        private void dgMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MedicoId = Convert.ToInt32(dgMedicos.CurrentRow.Cells["MedicoId"].Value);
            Nombres = dgMedicos.CurrentRow.Cells["Nombres"].Value.ToString();
            Apellidos = dgMedicos.CurrentRow.Cells["Apellidos"].Value.ToString();
            this.Visible = false;
        }
    }
}
