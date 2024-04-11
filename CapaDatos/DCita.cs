using CapaDatos.BaseDatos.Modelos;
using CapaDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCita
    {
        UnitOfWork _unitOfWork;

        public DCita()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CitaId { get; set; }
        public int MedicoId { get; set; }
        public int PacienteId { get; set; }
        public DateTime FechaCita { get; set; }
        public bool Estado { get; set; }

        public List<Cita> TodasLasCitas()
        {
            return _unitOfWork.Repository<Cita>().Consulta().ToList();
        }
        public int GuardarCitas(Cita cita)
        {
            if (cita.CitaId== 0)
            {
                _unitOfWork.Repository<Cita>().Agregar(cita);
                return _unitOfWork.Guardar();
            }
            else
            {
                var CitaInDb = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == cita.CitaId);
                if (CitaInDb != null)
                {
                    CitaInDb.MedicoId = cita.MedicoId;
                    CitaInDb.PacienteId = cita.PacienteId;
                    CitaInDb.FechaCita = cita.FechaCita;
                    CitaInDb.Estado = cita.Estado;
                    _unitOfWork.Repository<Cita>().Editar(CitaInDb);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public int EliminarCitas(int citaId)
        {
            var CitaInDb = _unitOfWork.Repository<Cita>().Consulta().FirstOrDefault(c => c.CitaId == citaId);
            if (CitaInDb != null)
            {
                _unitOfWork.Repository<Cita>().Eliminar(CitaInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
