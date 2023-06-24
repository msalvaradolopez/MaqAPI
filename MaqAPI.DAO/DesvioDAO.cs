using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Interface;
using MaqAPI.DTO;
using MaqAPI.Datos.Models;
using MaqAPI.Utilerias;

namespace MaqAPI.DAO
{
    public class DesvioDAO : ICatalogoItem<DesvioDTO>, IConsultaItem<DesvioDTO>
    {
        public bool DeleteItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.desvio.Where(x => x.idDesvio == pItem.idDesvio).FirstOrDefault();


                    db.desvio.Remove(_ItemModel);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public DesvioDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.desvio
                        .Where(x => x.idDesvio == pFiltros.idDesvio)
                        .Select(x => new DesvioDTO
                        {
                            idDesvio = x.idDesvio,
                            numTabulador = x.numTabulador,
                            area = x.area,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            evento = x.evento,
                            estado_prisa = x.estado_prisa,
                            estado_frustacion = x.estado_frustacion,
                            estado_fatiga = x.estado_fatiga,
                            estado_complacencia = x.estado_complacencia,
                            error_ojos_no_tarea = x.error_ojos_no_tarea,
                            error_mente_no_tarea = x.error_mente_no_tarea,
                            error_mala_colocacion = x.error_mala_colocacion,
                            error_perdida_equilibrio = x.error_perdida_equilibrio,
                            observaciones = x.observaciones,
                            caidas = x.caidas,
                            golpes = x.golpes,
                            quemaduras = x.quemaduras,
                            asfixia = x.asfixia,
                            eletrocucion = x.eletrocucion,
                            objetos_que_golpean = x.objetos_que_golpean,
                            accidentes_vehiculares = x.accidentes_vehiculares,
                            actitud = x.actitud,
                            procedimiento_de_trabajo = x.procedimiento_de_trabajo,
                            permiso_de_trabajo = x.permiso_de_trabajo,
                            e_p_p = x.e_p_p,
                            herremientas_y_equipos = x.herremientas_y_equipos,
                            posicion_de_las_personas = x.posicion_de_las_personas,
                            orden_y_limpieza = x.orden_y_limpieza,
                            reaccion_de_la_persona = x.reaccion_de_la_persona,
                            compromiso_establecido = x.compromiso_establecido,
                            nomSupervisor = x.operadores.Nombre,
                            nomOperador = x.operadores1.Nombre,
                            nomObra = x.obras.Nombre
                        })
                        .FirstOrDefault();

                    return _item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<DesvioDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.desvio
                        .Where(x =>
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia || pFiltros.dia == 0))
                        )
                        .Select(x => new DesvioDTO
                        {
                            idDesvio = x.idDesvio,
                            numTabulador = x.numTabulador,
                            area = x.area,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            evento = x.evento,
                            estado_prisa = x.estado_prisa,
                            estado_frustacion = x.estado_frustacion,
                            estado_fatiga = x.estado_fatiga,
                            estado_complacencia = x.estado_complacencia,
                            error_ojos_no_tarea = x.error_ojos_no_tarea,
                            error_mente_no_tarea = x.error_mente_no_tarea,
                            error_mala_colocacion = x.error_mala_colocacion,
                            error_perdida_equilibrio = x.error_perdida_equilibrio,
                            observaciones = x.observaciones,
                            caidas = x.caidas,
                            golpes = x.golpes,
                            quemaduras = x.quemaduras,
                            asfixia = x.asfixia,
                            eletrocucion = x.eletrocucion,
                            objetos_que_golpean = x.objetos_que_golpean,
                            accidentes_vehiculares = x.accidentes_vehiculares,
                            actitud = x.actitud,
                            procedimiento_de_trabajo = x.procedimiento_de_trabajo,
                            permiso_de_trabajo = x.permiso_de_trabajo,
                            e_p_p = x.e_p_p,
                            herremientas_y_equipos = x.herremientas_y_equipos,
                            posicion_de_las_personas = x.posicion_de_las_personas,
                            orden_y_limpieza = x.orden_y_limpieza,
                            reaccion_de_la_persona = x.reaccion_de_la_persona,
                            compromiso_establecido = x.compromiso_establecido,
                            nomSupervisor = x.operadores.Nombre,
                            nomOperador = x.operadores1.Nombre,
                            nomObra = x.obras.Nombre
                        })
                        .ToList();

                    if (pFiltros.buscar != "")
                        _list = _list.Where(x => x.nomSupervisor.Contains(pFiltros.buscar)
                        || x.nomOperador.Contains(pFiltros.buscar)
                        || x.nomObra.Contains(pFiltros.buscar)
                        ).ToList();

                    return _list;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public DesvioDTO InsertItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _idDesvio = 0;

                    _idDesvio = pItem.idDesvio;
                    if (_idDesvio != 0)
                        throw new Exception("El registro ya existe.");

                    var _params = db.parametros.Where(x => x.nombre == "docDesvio").Select(x => x).FirstOrDefault();
                    if (!string.IsNullOrEmpty(_params.valor))
                        _idDesvio = Convert.ToInt32(_params.valor);

                    _idDesvio++;
                    pItem.idDesvio = _idDesvio;
                    _params.valor = _idDesvio.ToString();


                    var _ItemModel = new desvio();

                    _ItemModel.idDesvio = _idDesvio;
                    _ItemModel.numTabulador = pItem.numTabulador;
                    _ItemModel.area = pItem.area;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.evento = pItem.evento;
                    _ItemModel.estado_prisa = pItem.estado_prisa;
                    _ItemModel.estado_frustacion = pItem.estado_frustacion;
                    _ItemModel.estado_fatiga = pItem.estado_fatiga;
                    _ItemModel.estado_complacencia = pItem.estado_complacencia;
                    _ItemModel.error_ojos_no_tarea = pItem.error_ojos_no_tarea;
                    _ItemModel.error_mente_no_tarea = pItem.error_mente_no_tarea;
                    _ItemModel.error_mala_colocacion = pItem.error_mala_colocacion;
                    _ItemModel.error_perdida_equilibrio = pItem.error_perdida_equilibrio;
                    _ItemModel.observaciones = pItem.observaciones;
                    _ItemModel.caidas = pItem.caidas;
                    _ItemModel.golpes = pItem.golpes;
                    _ItemModel.quemaduras = pItem.quemaduras;
                    _ItemModel.asfixia = pItem.asfixia;
                    _ItemModel.eletrocucion = pItem.eletrocucion;
                    _ItemModel.objetos_que_golpean = pItem.objetos_que_golpean;
                    _ItemModel.accidentes_vehiculares = pItem.accidentes_vehiculares;
                    _ItemModel.actitud = pItem.actitud;
                    _ItemModel.procedimiento_de_trabajo = pItem.procedimiento_de_trabajo;
                    _ItemModel.permiso_de_trabajo = pItem.permiso_de_trabajo;
                    _ItemModel.e_p_p = pItem.e_p_p;
                    _ItemModel.herremientas_y_equipos = pItem.herremientas_y_equipos;
                    _ItemModel.posicion_de_las_personas = pItem.posicion_de_las_personas;
                    _ItemModel.orden_y_limpieza = pItem.orden_y_limpieza;
                    _ItemModel.reaccion_de_la_persona = pItem.reaccion_de_la_persona;
                    _ItemModel.compromiso_establecido = pItem.compromiso_establecido;


                    db.desvio.Add(_ItemModel);
                    db.SaveChanges();

                    return pItem;
                }
                catch (Exception ex)
                {
                    var _error = ex.Message.ToString();
                    throw;
                }
            }
        }

        public bool UpdateItem(DesvioDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.desvio.Where(x => x.idDesvio == pItem.idDesvio).FirstOrDefault();

                    _ItemModel.numTabulador = pItem.numTabulador;
                    _ItemModel.area = pItem.area;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.evento = pItem.evento;
                    _ItemModel.estado_prisa = pItem.estado_prisa;
                    _ItemModel.estado_frustacion = pItem.estado_frustacion;
                    _ItemModel.estado_fatiga = pItem.estado_fatiga;
                    _ItemModel.estado_complacencia = pItem.estado_complacencia;
                    _ItemModel.error_ojos_no_tarea = pItem.error_ojos_no_tarea;
                    _ItemModel.error_mente_no_tarea = pItem.error_mente_no_tarea;
                    _ItemModel.error_mala_colocacion = pItem.error_mala_colocacion;
                    _ItemModel.error_perdida_equilibrio = pItem.error_perdida_equilibrio;
                    _ItemModel.observaciones = pItem.observaciones;
                    _ItemModel.caidas = pItem.caidas;
                    _ItemModel.golpes = pItem.golpes;
                    _ItemModel.quemaduras = pItem.quemaduras;
                    _ItemModel.asfixia = pItem.asfixia;
                    _ItemModel.eletrocucion = pItem.eletrocucion;
                    _ItemModel.objetos_que_golpean = pItem.objetos_que_golpean;
                    _ItemModel.accidentes_vehiculares = pItem.accidentes_vehiculares;
                    _ItemModel.actitud = pItem.actitud;
                    _ItemModel.procedimiento_de_trabajo = pItem.procedimiento_de_trabajo;
                    _ItemModel.permiso_de_trabajo = pItem.permiso_de_trabajo;
                    _ItemModel.e_p_p = pItem.e_p_p;
                    _ItemModel.herremientas_y_equipos = pItem.herremientas_y_equipos;
                    _ItemModel.posicion_de_las_personas = pItem.posicion_de_las_personas;
                    _ItemModel.orden_y_limpieza = pItem.orden_y_limpieza;
                    _ItemModel.reaccion_de_la_persona = pItem.reaccion_de_la_persona;
                    _ItemModel.compromiso_establecido = pItem.compromiso_establecido;

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
