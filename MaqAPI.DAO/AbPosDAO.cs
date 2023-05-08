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
    public class AbPosDAO : ICatalogoItem<AbPosDTO>, IConsultaItem<AbPosDTO>
    {
        public bool DeleteItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.abpos.Where(x => x.idAbordaje == pItem.idAbordaje).FirstOrDefault();


                    db.abpos.Remove(_ItemModel);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public AbPosDTO GetItemById(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _item = db.abpos
                        .Where(x => x.idAbordaje == pFiltros.idAbordaje)
                        .Select(x => new AbPosDTO
                        {
                            idAbordaje = x.idAbordaje,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            riesgo = x.riesgo,
                            desvio = x.desvio,
                            casco = (bool)x.casco,
                            lentes= (bool)x.lentes,
                            guantes = (bool)x.guantes,
                            uniforme = (bool)x.uniforme,
                            zapatos = (bool)x.zapatos,
                            uni_fajado = (bool)x.zapatos,
                            tapones = (bool)x.tapones,
                            mascarilla = (bool)x.mascarilla,
                            careta = (bool)x.careta,
                            arnes = (bool)x.arnes,
                            polainas = (bool)x.polainas,
                            peto = (bool)x.peto,
                            gogles = (bool)x.gogles,
                            otros = (bool)x.otros,
                            otro_descrip = x.otro_descrip,
                            act_inseguros = x.act_inseguros,
                            acc_correctiva = x.acc_correctiva,
                            cond_inseguras = x.cond_inseguras,
                            compromisos = x.compromisos
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

        public List<AbPosDTO> GetItemList(FiltrosDTO pFiltros)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {
                    var _list = db.abpos
                        .Where(x =>
                        (x.idSupervisor == pFiltros.idSupervisor || pFiltros.idSupervisor == "0")
                        && (x.idOperador == pFiltros.idOperador || pFiltros.idOperador == "0")
                        && (x.fecha.Year == pFiltros.anno && x.fecha.Month == pFiltros.mes && (x.fecha.Day == pFiltros.dia || pFiltros.dia == 0))
                        )
                        .Select(x => new AbPosDTO
                        {
                            idAbordaje = x.idAbordaje,
                            fecha = x.fecha,
                            idSupervisor = x.idSupervisor,
                            idObra = x.idObra,
                            idOperador = x.idOperador,
                            riesgo = x.riesgo,
                            desvio = x.desvio,
                            casco = (bool)x.casco,
                            lentes = (bool)x.lentes,
                            guantes = (bool)x.guantes,
                            uniforme = (bool)x.uniforme,
                            zapatos = (bool)x.zapatos,
                            uni_fajado = (bool)x.zapatos,
                            tapones = (bool)x.tapones,
                            mascarilla = (bool)x.mascarilla,
                            careta = (bool)x.careta,
                            arnes = (bool)x.arnes,
                            polainas = (bool)x.polainas,
                            peto = (bool)x.peto,
                            gogles = (bool)x.gogles,
                            otros = (bool)x.otros,
                            otro_descrip = x.otro_descrip,
                            act_inseguros = x.act_inseguros,
                            acc_correctiva = x.acc_correctiva,
                            cond_inseguras = x.cond_inseguras,
                            compromisos = x.compromisos,
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

        public AbPosDTO InsertItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    int _idAbordaje = 0;

                    _idAbordaje = pItem.idAbordaje;
                    if (_idAbordaje != 0)
                        throw new Exception("El registro ya existe.");

                    var _params = db.parametros.Where(x => x.nombre == "docAbPos").Select(x => x).FirstOrDefault();
                    if (!string.IsNullOrEmpty(_params.valor))
                        _idAbordaje = Convert.ToInt32(_params.valor);

                    _idAbordaje++;
                    pItem.idAbordaje = _idAbordaje;
                    _params.valor = _idAbordaje.ToString();


                    var _ItemModel = new abpos();

                    _ItemModel.idAbordaje = _idAbordaje;
                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.riesgo = pItem.riesgo;
                    _ItemModel.desvio = pItem.desvio;
                    _ItemModel.casco = pItem.casco;
                    _ItemModel.lentes = pItem.lentes;
                    _ItemModel.guantes = pItem.guantes;
                    _ItemModel.uniforme = pItem.uniforme;
                    _ItemModel.zapatos = pItem.zapatos;
                    _ItemModel.uni_fajado = pItem.uni_fajado;
                    _ItemModel.tapones = pItem.tapones;
                    _ItemModel.mascarilla = pItem.mascarilla;
                    _ItemModel.careta = pItem.careta;
                    _ItemModel.arnes = pItem.arnes;
                    _ItemModel.polainas = pItem.polainas;
                    _ItemModel.peto = pItem.peto;
                    _ItemModel.gogles = pItem.gogles;
                    _ItemModel.otros = pItem.otros;
                    _ItemModel.otro_descrip = pItem.otro_descrip;
                    _ItemModel.act_inseguros = pItem.act_inseguros;
                    _ItemModel.acc_correctiva = pItem.acc_correctiva;
                    _ItemModel.cond_inseguras = pItem.cond_inseguras;
                    _ItemModel.compromisos = pItem.compromisos;


                    db.abpos.Add(_ItemModel);
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

        public bool UpdateItem(AbPosDTO pItem)
        {
            using (var db = new MaquinariaEntities())
            {
                try
                {

                    var _ItemModel = db.abpos.Where(x => x.idAbordaje == pItem.idAbordaje).FirstOrDefault();

                    _ItemModel.fecha = pItem.fecha;
                    _ItemModel.idSupervisor = pItem.idSupervisor;
                    _ItemModel.idObra = pItem.idObra;
                    _ItemModel.idOperador = pItem.idOperador;
                    _ItemModel.riesgo = pItem.riesgo;
                    _ItemModel.desvio = pItem.desvio;
                    _ItemModel.casco = pItem.casco;
                    _ItemModel.lentes = pItem.lentes;
                    _ItemModel.guantes = pItem.guantes;
                    _ItemModel.uniforme = pItem.uniforme;
                    _ItemModel.zapatos = pItem.zapatos;
                    _ItemModel.uni_fajado = pItem.uni_fajado;
                    _ItemModel.tapones = pItem.tapones;
                    _ItemModel.mascarilla = pItem.mascarilla;
                    _ItemModel.careta = pItem.careta;
                    _ItemModel.arnes = pItem.arnes;
                    _ItemModel.polainas = pItem.polainas;
                    _ItemModel.peto = pItem.peto;
                    _ItemModel.gogles = pItem.gogles;
                    _ItemModel.otros = pItem.otros;
                    _ItemModel.otro_descrip = pItem.otro_descrip;
                    _ItemModel.act_inseguros = pItem.act_inseguros;
                    _ItemModel.acc_correctiva = pItem.acc_correctiva;
                    _ItemModel.cond_inseguras = pItem.cond_inseguras;
                    _ItemModel.compromisos = pItem.compromisos;

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
