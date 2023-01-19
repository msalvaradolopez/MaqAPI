using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Interface;
using MaqAPI.DTO;
using MaqAPI.Datos.Models;

namespace MaqAPI.DAO
{
    public class InsPecDAO : ICatalogoItem<InsPecDTO>, IConsultaItem<InsPecDTO>
    {
        public bool DeleteItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.inspec.Where(x => x.idInspeccion == pItem.idInspeccion).FirstOrDefault();


                    db.inspec.Remove(_ItemModel);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public InsPecDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.inspec
                        .Where(x => x.docInspeccion == pFiltros.docInspeccion)
                        .Select(x => new InsPecDTO {
                            idInspeccion = x.idInspeccion,
                            docInspeccion = x.docInspeccion,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idEconomico = x.idEconomico,
                            idOperador = x.idOperador,
                            turno = x.turno,
                            horometro = x.horometro,
                            idResponsableMtto = x.idResponsableMtto,
                            frenos = x.frenos,
                            frenos_obs = x.frenos_obs,
                            alarma_rev = x.alarma_rev,
                            alarma_rev_obs = x.alarma_rev_obs,
                            nivel_aceite = x.nivel_aceite,
                            nivel_aceite_obs = x.nivel_aceite_obs,
                            motor = x.motor,
                            motor_obs = x.motor,
                            transmision = x.transmision,
                            transmision_obs = x.transmision_obs,
                            fugas_aceite = x.fugas_aceite,
                            fugas_aceite_obs = x.fugas_aceite_obs,
                            nivel_agua = x.nivel_agua,
                            nivel_agua_obs = x.nivel_agua_obs,
                            extinguidor = x.extinguidor,
                            extinguidor_obs = x.extinguidor_obs,
                            luces = x.luces,
                            luces_obs = x.luces_obs,
                            torreta = x.torreta,
                            torreta_obs = x.torreta_obs,
                            neumaticos = x.neumaticos,
                            neumaticos_obs = x.neumaticos_obs,
                            pernos_bujes = x.pernos_bujes,
                            pernos_bujes_obs = x.pernos_bujes_obs,
                            direccion = x.direccion,
                            direccion_obs = x.direccion_obs,
                            espejos_retrovisores = x.espejos_retrovisores,
                            espejos_retrovisores_obs = x.espejos_retrovisores_obs,
                            claxon = x.claxon,
                            claxon_obs = x.claxon_obs,
                            cinturon_seguridad = x.cinturon_seguridad,
                            cinturon_seguridad_obs = x.cinturon_seguridad_obs,
                            nomSupervisor = x.operadores2.Nombre,
                            nomOperador = x.operadores.Nombre,
                            nomResponsableMtto = x.operadores1.Nombre,
                            nomEquipo = x.maquinaria.Tipo

                        })
                        .FirstOrDefault();

                    /*
                     (x.idObra.Contains(_filtros.buscar)
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                    */
                    return _item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<InsPecDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.inspec
                        .Where(x => 
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.idEconomico == pFiltros.idEconomico || pFiltros.idEconomico == "0")
                        && (x.idResponsableMtto == pFiltros.idResponsableMtto || pFiltros.idResponsableMtto == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia ||  pFiltros.dia == 0))
                        )
                        .Select(x => new InsPecDTO
                        {
                            idInspeccion = x.idInspeccion,
                            docInspeccion = x.docInspeccion,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idEconomico = x.idEconomico,
                            idOperador = x.idOperador,
                            turno = x.turno,
                            horometro = x.horometro,
                            idResponsableMtto = x.idResponsableMtto,
                            frenos = x.frenos,
                            frenos_obs = x.frenos_obs,
                            alarma_rev = x.alarma_rev,
                            alarma_rev_obs = x.alarma_rev_obs,
                            nivel_aceite = x.nivel_aceite,
                            nivel_aceite_obs = x.nivel_aceite_obs,
                            motor = x.motor,
                            motor_obs = x.motor,
                            transmision = x.transmision,
                            transmision_obs = x.transmision_obs,
                            fugas_aceite = x.fugas_aceite,
                            fugas_aceite_obs = x.fugas_aceite_obs,
                            nivel_agua = x.nivel_agua,
                            nivel_agua_obs = x.nivel_agua_obs,
                            extinguidor = x.extinguidor,
                            extinguidor_obs = x.extinguidor_obs,
                            luces = x.luces,
                            luces_obs = x.luces_obs,
                            torreta = x.torreta,
                            torreta_obs = x.torreta_obs,
                            neumaticos = x.neumaticos,
                            neumaticos_obs = x.neumaticos_obs,
                            pernos_bujes = x.pernos_bujes,
                            pernos_bujes_obs = x.pernos_bujes_obs,
                            direccion = x.direccion,
                            direccion_obs = x.direccion_obs,
                            espejos_retrovisores = x.espejos_retrovisores,
                            espejos_retrovisores_obs = x.espejos_retrovisores_obs,
                            claxon = x.claxon,
                            claxon_obs = x.claxon_obs,
                            cinturon_seguridad = x.cinturon_seguridad,
                            cinturon_seguridad_obs = x.cinturon_seguridad_obs,
                            nomSupervisor = x.operadores2.Nombre,
                            nomOperador = x.operadores.Nombre,
                            nomResponsableMtto = x.operadores1.Nombre,
                            nomEquipo = x.maquinaria.Tipo
                        })
                        .ToList();

                    /*
                     (x.idObra.Contains(_filtros.buscar)
                                        || x.Nombre.Contains(_filtros.buscar))
                                    && (x.estatus == _filtros.estatus || _filtros.estatus == "0"))
                    */

                    if(pFiltros.buscar != "")
                        _list = _list.Where(x => x.nomSupervisor.Contains(pFiltros.buscar)
                        || x.nomOperador.Contains(pFiltros.buscar)
                        || x.nomResponsableMtto.Contains(pFiltros.buscar)
                        || x.nomEquipo.Contains(pFiltros.buscar)
                        ).ToList();

                    return _list;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public InsPecDTO InsertItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _docInspreccion = 0;
                    int _idInspreccion = 0;

                    _idInspreccion = pItem.idInspeccion;
                    if (_idInspreccion != 0)
                        throw new Exception("El registro ya existe.");

                    _docInspreccion = pItem.docInspeccion;
                    if (_docInspreccion == 0)
                    {
                        var _params = db.parametros.Where(x => x.nombre == "docInspeccion").Select(x => x).FirstOrDefault();
                        if (!string.IsNullOrEmpty(_params.valor))
                            _docInspreccion = Convert.ToInt32(_params.valor);

                        _docInspreccion++;
                        pItem.docInspeccion = _docInspreccion;
                        _params.valor = _docInspreccion.ToString();
                    }


                    var _ItemModel = new inspec();

                    _ItemModel.docInspeccion = pItem.docInspeccion;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idEconomico = pItem.idEconomico;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.turno = pItem.turno;
                    _ItemModel.horometro = pItem.horometro;
                    _ItemModel.idResponsableMtto = pItem.idResponsableMtto;
                    _ItemModel.frenos = pItem.frenos;
                    _ItemModel.frenos_obs = pItem.frenos_obs;
                    _ItemModel.alarma_rev = pItem.alarma_rev;
                    _ItemModel.alarma_rev_obs = pItem.alarma_rev_obs;
                    _ItemModel.nivel_aceite = pItem.nivel_aceite;
                    _ItemModel.nivel_aceite_obs = pItem.nivel_aceite_obs;
                    _ItemModel.motor = pItem.motor;
                    _ItemModel.motor_obs = pItem.motor;
                    _ItemModel.transmision = pItem.transmision;
                    _ItemModel.transmision_obs = pItem.transmision_obs;
                    _ItemModel.fugas_aceite = pItem.fugas_aceite;
                    _ItemModel.fugas_aceite_obs = pItem.fugas_aceite_obs;
                    _ItemModel.nivel_agua = pItem.nivel_agua;
                    _ItemModel.nivel_agua_obs = pItem.nivel_agua_obs;
                    _ItemModel.extinguidor = pItem.extinguidor;
                    _ItemModel.extinguidor_obs = pItem.extinguidor_obs;
                    _ItemModel.luces = pItem.luces;
                    _ItemModel.luces_obs = pItem.luces_obs;
                    _ItemModel.torreta = pItem.torreta;
                    _ItemModel.torreta_obs = pItem.torreta_obs;
                    _ItemModel.neumaticos = pItem.neumaticos;
                    _ItemModel.neumaticos_obs = pItem.neumaticos_obs;
                    _ItemModel.pernos_bujes = pItem.pernos_bujes;
                    _ItemModel.pernos_bujes_obs = pItem.pernos_bujes_obs;
                    _ItemModel.direccion = pItem.direccion;
                    _ItemModel.direccion_obs = pItem.direccion_obs;
                    _ItemModel.espejos_retrovisores = pItem.espejos_retrovisores;
                    _ItemModel.espejos_retrovisores_obs = pItem.espejos_retrovisores_obs;
                    _ItemModel.claxon = pItem.claxon;
                    _ItemModel.claxon_obs = pItem.claxon_obs;
                    _ItemModel.cinturon_seguridad = pItem.cinturon_seguridad;
                    _ItemModel.cinturon_seguridad_obs = pItem.cinturon_seguridad_obs;


                    db.inspec.Add(_ItemModel);
                    db.SaveChanges();

                    pItem.idInspeccion = _ItemModel.idInspeccion;
                    return pItem;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public bool UpdateItem(InsPecDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                   
                    var _ItemModel = db.inspec.Where(x => x.idInspeccion == pItem.idInspeccion).FirstOrDefault();

                    _ItemModel.idInspeccion = pItem.idInspeccion;
                    _ItemModel.docInspeccion = pItem.docInspeccion;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idEconomico = pItem.idEconomico;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.turno = pItem.turno;
                    _ItemModel.horometro = pItem.horometro;
                    _ItemModel.idResponsableMtto = pItem.idResponsableMtto;
                    _ItemModel.frenos = pItem.frenos;
                    _ItemModel.frenos_obs = pItem.frenos_obs;
                    _ItemModel.alarma_rev = pItem.alarma_rev;
                    _ItemModel.alarma_rev_obs = pItem.alarma_rev_obs;
                    _ItemModel.nivel_aceite = pItem.nivel_aceite;
                    _ItemModel.nivel_aceite_obs = pItem.nivel_aceite_obs;
                    _ItemModel.motor = pItem.motor;
                    _ItemModel.motor_obs = pItem.motor;
                    _ItemModel.transmision = pItem.transmision;
                    _ItemModel.transmision_obs = pItem.transmision_obs;
                    _ItemModel.fugas_aceite = pItem.fugas_aceite;
                    _ItemModel.fugas_aceite_obs = pItem.fugas_aceite_obs;
                    _ItemModel.nivel_agua = pItem.nivel_agua;
                    _ItemModel.nivel_agua_obs = pItem.nivel_agua_obs;
                    _ItemModel.extinguidor = pItem.extinguidor;
                    _ItemModel.extinguidor_obs = pItem.extinguidor_obs;
                    _ItemModel.luces = pItem.luces;
                    _ItemModel.luces_obs = pItem.luces_obs;
                    _ItemModel.torreta = pItem.torreta;
                    _ItemModel.torreta_obs = pItem.torreta_obs;
                    _ItemModel.neumaticos = pItem.neumaticos;
                    _ItemModel.neumaticos_obs = pItem.neumaticos_obs;
                    _ItemModel.pernos_bujes = pItem.pernos_bujes;
                    _ItemModel.pernos_bujes_obs = pItem.pernos_bujes_obs;
                    _ItemModel.direccion = pItem.direccion;
                    _ItemModel.direccion_obs = pItem.direccion_obs;
                    _ItemModel.espejos_retrovisores = pItem.espejos_retrovisores;
                    _ItemModel.espejos_retrovisores_obs = pItem.espejos_retrovisores_obs;
                    _ItemModel.claxon = pItem.claxon;
                    _ItemModel.claxon_obs = pItem.claxon_obs;
                    _ItemModel.cinturon_seguridad = pItem.cinturon_seguridad;
                    _ItemModel.cinturon_seguridad_obs = pItem.cinturon_seguridad_obs;

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}

