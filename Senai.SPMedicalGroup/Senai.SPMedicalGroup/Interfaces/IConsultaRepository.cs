using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.SPMedicalGroup.Domains;

namespace Senai.SPMedicalGroup.Interfaces
{
    interface IConsultaRepository
    {
        void Agendar(Consultas consulta);

        void Atualizar(Consultas consulta);

        List<Consultas> Listar();

        /// <summary>
        /// Busca um Médico pelo Id
        /// </summary>
        /// <param name="idmedico">Id</param>
        /// <returns>Retorna um Medico</returns>
        List<Consultas> BuscarPorIdMedico(int idmedico);

        /// <summary>
        /// Busca um Prontuario pelo Id
        /// </summary>
        /// <param name="idprontuario">Id</param>
        /// <returns>Retorna um Prontuario(paciente)</returns>
        List<Consultas> BuscarPorIdProntuario(int idprontuario);

        /// <summary>
        /// Busca consultas de um determinado medico
        /// </summary>
        /// <param name="idmedico">Id</param>
        /// <returns>Retorna Consultas</returns>
        List<Consultas> BuscarConsultasMedico(int idmedico);

        /// <summary>
        /// Busca consultas de um determinado prontuario
        /// </summary>
        /// <param name="idprontuario">Id</param>
        /// <returns>Retorna Consultas</returns>
        List<Consultas> BuscarConsultasProntuario(int idprontuario);
    }
}
