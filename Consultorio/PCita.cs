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
    public partial class PCita : Form
    {
        private NCita nCita;

        public PCita()
        {
            InitializeComponent();
            nCita = new NCita();
            CargarDatos();
        }

        private void PCita_Load(object sender, EventArgs e)
        {
        }

        void CargarDatos()
        {
            dgCitas.DataSource = nCita.MostrarCitasGrid();
        }

        void LimpiarDatos()
        {
            txtCitaId.Text = "";
            txtMedicoId.Text = "";
            txtPacienteId.Text = "";
            txtNombreMedico.Text = "";
            txtNombrePaciente.Text = "";
            dtpFechaCita.Value = DateTime.Now;
            cbEstado.Checked = false;
            errorProvider1.Clear();
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgCitas.DataSource = nCita.MostrarCitasActivasGrid();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(txtNombreMedico.Text.ToString()) || string.IsNullOrWhiteSpace(txtNombreMedico.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtNombreMedico, "Debe ingresar un Medico");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(txtNombrePaciente.Text.ToString()) || string.IsNullOrWhiteSpace(txtNombrePaciente.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtNombrePaciente, "Debe ingresar un Paciente");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var fecha = dtpFechaCita.Value.ToString();
            DateTime fechaeditarCita = DateTime.Parse(fecha);

            if (ValidarDatos())
            {
                Cita cita = new Cita()
                {
                    MedicoId = int.Parse(txtMedicoId.Text.ToString()),
                    PacienteId = int.Parse(txtPacienteId.Text.ToString()),
                    FechaCita = fechaeditarCita,
                    Estado = cbEstado.Checked,
                };
                if (!string.IsNullOrEmpty(txtCitaId.Text) && int.TryParse(txtCitaId.Text.ToString(), out int citaId) && citaId != 0)
                {
                    cita.CitaId = citaId;
                    nCita.EditarCitas(cita);
                }
                else
                {
                    nCita.AgregarCitas(cita);
                }
                LimpiarDatos();
                CargarDatos();
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var citaId = txtCitaId.Text.ToString();
            if (string.IsNullOrEmpty(citaId) || string.IsNullOrWhiteSpace(citaId))
            {
                return;
            }
            nCita.EliminarCitas(int.Parse(citaId));
            CargarDatos();
            LimpiarDatos();
        }

        private void dgCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgCitas.Rows.Count)
            {
                txtMedicoId.Text = dgCitas.CurrentRow.Cells["MedicoId"].Value.ToString();
                txtNombreMedico.Text = dgCitas.CurrentRow.Cells["NombresMedicos"].Value.ToString();
                txtPacienteId.Text = dgCitas.CurrentRow.Cells["PacienteId"].Value.ToString();
                txtNombrePaciente.Text = dgCitas.CurrentRow.Cells["NombresPacientes"].Value.ToString();

                txtCitaId.Text = dgCitas.CurrentRow.Cells["CitaId"].Value.ToString();
                if (DateTime.TryParse(dgCitas.CurrentRow.Cells["FechaCita"].Value.ToString(), out DateTime fechaFactura))
                {
                    dtpFechaCita.Value = fechaFactura;
                }
                cbEstado.Checked = bool.Parse(dgCitas.CurrentRow.Cells["Estado"].Value.ToString());
            }
        }

        private void bMedico_Click(object sender, EventArgs e)
        {
            PBuscarMedicos BuscarMedicos = new PBuscarMedicos();
            BuscarMedicos.ShowDialog();
            txtMedicoId.Text = BuscarMedicos.MedicoId.ToString(); ;
            txtNombreMedico.Text = $"{BuscarMedicos.Nombres} {BuscarMedicos.Apellidos}";
        }

        private void bPaciente_Click(object sender, EventArgs e)
        {
            PBuscarPacientes BuscarPacientes = new PBuscarPacientes();
            BuscarPacientes.ShowDialog();
            txtPacienteId.Text = BuscarPacientes.PacienteId.ToString(); ;
            txtNombrePaciente.Text = $"{BuscarPacientes.Nombres} {BuscarPacientes.Apellidos}";
        }
    }
}
