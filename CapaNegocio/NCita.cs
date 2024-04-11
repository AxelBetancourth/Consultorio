using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCita
    {
        private DCita dCita;

        public NCita()
        {
            dCita = new DCita();
        }

        public List<Cita> MostrarCitas()
        {
            return dCita.TodasLasCitas();
        }
        public int AgregarMedicos(Cita cita)
        {
            return dCita.GuardarCitas(cita);
        }
        public int EditarMedicos(Cita cita)
        {
            return dCita.GuardarCitas(cita);
        }
        public int EliminarCitas(int citaId)
        {
            return dCita.EliminarCitas(citaId);
        }

        public List<object> MostrarCitasGrid()
        {
            var citas = dCita.TodasLasCitas().Select(c => new
            {
                c.CitaId,
                c.MedicoId,
                NombresMedicos = $"{c.Medico.Nombres}' '{c.Paciente.Apellidos}",
                c.PacienteId,
                NombresPacientes = $"{c.Paciente.Nombres}' '{c.Paciente.Apellidos}",
                c.FechaCita,
                c.Estado
            });
            return citas.Cast<object>().ToList();
        }

        public List<object> MostrarCitasActivasGrid()
        {
            var citas = dCita.TodasLasCitas().Select(c => new
            {
                c.CitaId,
                c.MedicoId,
                NombresMedicos = $"{c.Medico.Nombres}' '{c.Paciente.Apellidos}",
                c.PacienteId,
                NombresPacientes = $"{c.Paciente.Nombres}' '{c.Paciente.Apellidos}",
                c.FechaCita,
                c.Estado
            });
            return citas.Where(c => c.Estado == true).Cast<object>().ToList();
        }
    }
}
