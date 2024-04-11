using CapaDatos;
using CapaDatos.BaseDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NMedico
    {
        DMedico dMedico;

        public NMedico()
        {
            dMedico = new DMedico();
        }

        public List<Medico> MostrarMedicos()
        {
            return dMedico.TodosLosMedicos();
        }
        public List<Medico> MedicosActivos()
        {
            return dMedico.TodosLosMedicos().Where(c => c.Estado == true).ToList();
        }
        public int AgregarMedicos(Medico medico)
        {
            return dMedico.GuardarMedicos(medico);
        }
        public int EditarMedicos(Medico medico)
        {
            return dMedico.GuardarMedicos(medico);
        }
        public int EliminarMedicos(int medicoId)
        {
            return dMedico.EliminarMedicos(medicoId);
        }
    }
}
