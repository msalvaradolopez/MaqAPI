﻿using MaqAPI.Datos;
using MaqAPI.Datos.Operaciones;
using MaqAPI.Entidades;
using MaqAPI.DTOMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public class srvUbicaciones : IServicios
    {
        public UbicacionEntidad ubicacionEntidad { get; set; }
        public bool Actualizar()
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
                _catalogosABC.Actualizar();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Agregar()
        {
            try
            {
                var _srvObras = new srvObras();
                var _svrOPeradores = new srvOperadores();
                var _svrMaquinaria = new srvMaquinaria();

                if (_svrMaquinaria.ListadoPorId(this.ubicacionEntidad.idEconomico) == null)
                    throw new Exception("Id Obra no existe.");

                if (_srvObras.ListadoPorId(this.ubicacionEntidad.idObra) == null)
                    throw new Exception("Id Equipo no existe.");

                if (_svrOPeradores.ListadoPorId(this.ubicacionEntidad.idOperador) == null)
                    throw new Exception("Id operador no existe.");

                this.ubicacionEntidad.fecha_ingreso = DateTime.Now;

                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
                _catalogosABC.Nuevo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar()
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC
                {
                    ubicacionEntidad = this.ubicacionEntidad
                };
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
                _catalogosABC.Eliminar();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<object> Listado()
        {
            throw new Exception("No implelentado.");
        }

        public IEnumerable<object> ListadoFiltro(object filtro)
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC();
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);

                var _ubicacionesDTOMap = new UbicacionesDTOMap();

                return _ubicacionesDTOMap.CreateUbicacionesList(_catalogosABC.ListadoFiltro(filtro), filtro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object ListadoPorId(object id)
        {
            try
            {
                var _UbicacionesABC = new UbicacionesABC();
                var _catalogosABC = new CatalogosABC(_UbicacionesABC);
                return _catalogosABC.ListadoPorId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<object> TableroList(int pagina)
        {
            try
            {
               
                var _tableroDTOMap = new TableroDTOMap();

                return _tableroDTOMap.createTableroList(pagina);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
