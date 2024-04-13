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
    public partial class PPaciente : Form
    {
        private NPaciente nPaciente;
        private NCita nCita;

        public PPaciente()
        {
            InitializeComponent();
            nPaciente = new NPaciente();
            nCita = new NCita();
            CargarDatos();
        }

        private void PPaciente_Load(object sender, EventArgs e)
        {

        }

        void CargarDatos()
        {
            dgPacientes.DataSource = nPaciente.MostrarPacientes();
        }

        void LimpiarDatos()
        {
            txtPacienteId.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            dtpFechaIngreso.Value = DateTime.Now;
            cbEstado.Checked = false;
            errorProvider1.Clear();
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgPacientes.DataSource = nPaciente.PacientesActivos();
            if (cbActivos.Checked == false)
            {
                CargarDatos();
            }
        }

        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(txtNombres.Text.ToString()) || string.IsNullOrWhiteSpace(txtNombres.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtNombres, "Debe ingresar un Nombre");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(txtApellidos.Text.ToString()) || string.IsNullOrWhiteSpace(txtApellidos.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(txtApellidos, "Debe ingresar un Apellido");
                return FormularioValido;
            }
            return FormularioValido;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var fecha = dtpFechaIngreso.Value.ToString();
            DateTime fechaeditarPaciente = DateTime.Parse(fecha);

            if (ValidarDatos())
            {
                Paciente paciente = new Paciente()

                {
                    Nombres = txtNombres.Text.ToString(),
                    Apellidos = txtApellidos.Text.ToString(),
                    FechaIngreso = fechaeditarPaciente,
                    Estado = cbEstado.Checked,
                };
                if (!string.IsNullOrEmpty(txtPacienteId.Text) && int.TryParse(txtPacienteId.Text.ToString(), out int pacienteId) && pacienteId != 0)
                {
                    paciente.PacienteId = pacienteId;
                    nPaciente.EditarPacientes(paciente);
                }
                else
                {
                    nPaciente.AgregarPacientes(paciente);
                }
                LimpiarDatos();
                CargarDatos();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var pacienteId = txtPacienteId.Text.ToString();
            if (string.IsNullOrEmpty(pacienteId) || string.IsNullOrWhiteSpace(pacienteId))
            {
                return;
            }
            var CitasAsociadas = nCita.MostrarCitas().Where(c => c.PacienteId == int.Parse(pacienteId)).ToList();
            if (CitasAsociadas.Count > 0)
            {
                MessageBox.Show("El paciente esta asociado a 'Cita', desvinculelo para poder eliminar ");
            }
            else
            {
                nPaciente.EliminarPacientes(int.Parse(pacienteId));
                CargarDatos();
                LimpiarDatos();
            }
        }

        private void dgPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgPacientes.Rows.Count)
            {
                DataGridViewRow row = dgPacientes.Rows[e.RowIndex];
                txtPacienteId.Text = row.Cells["PacienteId"].Value.ToString();
                txtNombres.Text = row.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                if (DateTime.TryParse(dgPacientes.CurrentRow.Cells["FechaIngreso"].Value.ToString(), out DateTime fechaFactura))
                {
                    dtpFechaIngreso.Value = fechaFactura;
                }
                cbEstado.Checked = bool.Parse(dgPacientes.CurrentRow.Cells["Estado"].Value.ToString());
            }
        }
    }
}
