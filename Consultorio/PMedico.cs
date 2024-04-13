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
    public partial class PMedico : Form
    {
        private NMedico nMedico;
        private NCita nCita;

        public PMedico()
        {
            InitializeComponent();
            nMedico = new NMedico();
            nCita = new NCita();
            CargarDatos();
        }

        private void PMedico_Load(object sender, EventArgs e)
        {

        }
        void CargarDatos()
        {
            dgMedicos.DataSource = nMedico.MostrarMedicos();
        }

        void LimpiarDatos()
        {
            txtMedicoId.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            dtpFechaIngreso.Value = DateTime.Now;
            cbEstado.Checked = false;
            errorProvider1.Clear();
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {
            dgMedicos.DataSource = nMedico.MedicosActivos();
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
            DateTime fechaeditarMedico = DateTime.Parse(fecha);

            if (ValidarDatos())
            {
                Medico medico = new Medico()

                {
                    Nombres = txtNombres.Text.ToString(),
                    Apellidos = txtApellidos.Text.ToString(),
                    FechaIngreso = fechaeditarMedico,
                    Estado = cbEstado.Checked,
                };
                if (!string.IsNullOrEmpty(txtMedicoId.Text) && int.TryParse(txtMedicoId.Text.ToString(), out int medicoId) && medicoId != 0)
                {
                    medico.MedicoId = medicoId;
                    nMedico.EditarMedicos(medico);
                }
                else
                {
                    nMedico.AgregarMedicos(medico);
                }
                LimpiarDatos();
                CargarDatos();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var medicoId = txtMedicoId.Text.ToString();
            if (string.IsNullOrEmpty(medicoId) || string.IsNullOrWhiteSpace(medicoId))
            {
                return;
            }
            var CitasAsociadas = nCita.MostrarCitas().Where(c => c.MedicoId == int.Parse(medicoId)).ToList();
            if (CitasAsociadas.Count > 0)
            {
                MessageBox.Show("El medico esta asociado a 'Cita', desvinculelo para poder eliminar ");
            }
            else
            {
                nMedico.EliminarMedicos(int.Parse(medicoId));
                CargarDatos();
                LimpiarDatos();
            }
        }

        private void dgMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgMedicos.Rows.Count)
            {
                DataGridViewRow row = dgMedicos.Rows[e.RowIndex];
                txtMedicoId.Text = row.Cells["MedicoId"].Value.ToString();
                txtNombres.Text = row.Cells["Nombres"].Value.ToString();
                txtApellidos.Text = row.Cells["Apellidos"].Value.ToString();
                if (DateTime.TryParse(dgMedicos.CurrentRow.Cells["FechaIngreso"].Value.ToString(), out DateTime fechaFactura))
                {
                    dtpFechaIngreso.Value = fechaFactura;
                }
                cbEstado.Checked = bool.Parse(dgMedicos.CurrentRow.Cells["Estado"].Value.ToString());
            }
        }
    }
}
