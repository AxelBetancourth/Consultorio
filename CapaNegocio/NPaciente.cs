using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPaciente
    {
        private DPaciente dPaciente;

        public NPaciente()
        {
            dPaciente = new DPaciente();
        }

        public List<Paciente> MostrarPacientes()
        {
            return dPaciente.TodosLosPacientes();
        }
        public List<Paciente> PacientesActivos()
        {
            return dPaciente.TodosLosPacientes().Where(c => c.Estado == true).ToList();
        }
        public int AgregarPacientes(Paciente paciente)
        {
            return dPaciente.GuardarPacientes(paciente);
        }
        public int EditarPacientes(Paciente paciente)
        {
            return dPaciente.GuardarPacientes(paciente);
        }
        public int EliminarPacientes(int pacienteId)
        {
            return dPaciente.EliminarPacientes(pacienteId);
        }
    }
}
