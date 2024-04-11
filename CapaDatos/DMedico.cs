using CapaDatos.BaseDatos.Modelos;
using CapaDatos.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMedico
    {
        UnitOfWork _unitOfWork;

        public DMedico()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int MedicoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Medico> TodosLosMedicos()
        {
            return _unitOfWork.Repository<Medico>().Consulta().ToList();
        }
        public int GuardarMedicos(Medico medico)
        {
            if (medico.MedicoId == 0)
            {
                _unitOfWork.Repository<Medico>().Agregar(medico);
                return _unitOfWork.Guardar();
            }
            else
            {
                var MedicoInDb = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c => c.MedicoId == medico.MedicoId);
                if (MedicoInDb != null)
                {
                    MedicoInDb.Nombres = medico.Nombres;
                    MedicoInDb.Apellidos = medico.Apellidos;
                    MedicoInDb.FechaIngreso = medico.FechaIngreso;
                    MedicoInDb.Estado = medico.Estado;
                    _unitOfWork.Repository<Medico>().Editar(MedicoInDb);
                    return _unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public int EliminarMedicos(int medicoId)
        {
            var MedicoInDb = _unitOfWork.Repository<Medico>().Consulta().FirstOrDefault(c => c.MedicoId == medicoId);
            if (MedicoInDb != null)
            {
                _unitOfWork.Repository<Medico>().Eliminar(MedicoInDb);
                return _unitOfWork.Guardar();
            }
            return 0;
        }
    }
}
