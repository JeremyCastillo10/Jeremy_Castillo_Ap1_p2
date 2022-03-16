using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jeremy_Castillo_Ap1_p2.DAL;
using Jeremy_Castillo_Ap1_p2.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Jeremy_Castillo_Ap1_p2.BLL
{
    public class ProductosBLL
    {
        private Contexto _contexto;

        Productos Productos = new Productos();

        public ProductosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int productoid)
        {
            bool paso = false;

            try
            {
                paso = _contexto.Productos.Any(p => p.ProductoId == productoid);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Insertar(Productos productos)
        {
            bool paso = false;
            try
            {
                _contexto.Productos.Add(productos);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificar(Productos productos)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM ProductosDetalles where ProductoId={productos.ProductoId}");

                foreach (var anterior in productos.productosDetalle)
                {
                    _contexto.Entry(anterior).State = EntityState.Added;
                }

                _contexto.Entry(productos).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;
        }

        public bool Guardar(Productos productos)
        {
            if(Existe(productos.ProductoId))
                return Modificar(productos);
            else
                return Insertar(productos);
        }

       public Productos? Buscar(int ProductoId)
        {

            Productos? productos;
            try
            {
                productos = _contexto.Productos.Find(ProductoId);
            }
            catch (Exception)
            {
                throw;
            }

            return productos;
        }

        public bool Eliminar(int productoid)
        {
            bool paso = false;

            try
            {
                var producto = _contexto.Productos.Find(productoid);
                if(producto != null)
                {
                    _contexto.Productos.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

      public List<Productos> GetList(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();
            try
            {
                lista = _contexto.Productos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
            return lista;
        }

        public List<ProductosDetalle> GetListD(Expression<Func<ProductosDetalle, bool>> criterio)
        {
            List<ProductosDetalle> lista = new List<ProductosDetalle>();
            try
            {
                lista = _contexto.ProductosDetalles.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
            return lista;
        }

        public bool ExisteEmp(int EmpacadoId)
        {
            bool paso = false;

            try
            {
                paso = _contexto.EntradaEmpacado.Any(p => p.Id == EmpacadoId);
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

         private bool Insertaremp(EntradaEmpacado entrada)
        {
            bool paso = false;
            try
            {
                _contexto.EntradaEmpacado.Add(entrada);
                Productos pro = new Productos();
                EntradaEmpacado en = new EntradaEmpacado();
                pro.Existencia -= en.CantidadUtilizado;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        private bool Modificaremp(EntradaEmpacado entrada)
        {
            bool paso = false;

            try
            {
                _contexto.Database.ExecuteSqlRaw($"Delete FROM EntradaEmpacado where Id={entrada.Id}");

                foreach (var anterior in Productos.EntradaEmpacados)
                {
                    _contexto.Entry(anterior).State = EntityState.Added;
                }

                _contexto.Entry(entrada).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return paso;

        

        }

        public bool GuardarEmp(EntradaEmpacado entrada)
        {
            if (!ExisteEmp(entrada.Id))//si no existe insertamos
                return Insertaremp(entrada);
            else
                return Modificaremp(entrada);
        }

        public bool EliminarEmp(int entradaId)
        {
            bool paso = false;

            try
            {
                var entrada = _contexto.EntradaEmpacado.Find(entradaId);
                if(entrada != null)
                {
                    _contexto.EntradaEmpacado.Remove(entrada);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public EntradaEmpacado BuscarEmp(int entradaId)
        {
            EntradaEmpacado? entrada;
            try
            {
                entrada = _contexto.EntradaEmpacado.Find(entradaId);
            }
            catch (Exception)
            {
                throw;
            }

            return entrada;
        }

        public List<EntradaEmpacado> GetListEntrada(Expression<Func<EntradaEmpacado, bool>> criterio)
        {
            List<EntradaEmpacado> lista = new List<EntradaEmpacado>();
            try
            {
                lista = _contexto.EntradaEmpacado.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            
            return lista;
        }

       
    }
}