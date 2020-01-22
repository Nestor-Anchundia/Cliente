using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarea2.clases;

namespace tarea2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(){ Apellido= "Anchundia", Nombre="Alexy", Id=1},
                new Cliente(){ Apellido= "Anchundia", Nombre="Betty", Id=2},
                new Cliente(){ Apellido= "Anchundia", Nombre="Carlos", Id=3},
                new Cliente(){ Apellido= "Barcia", Nombre="Damaris", Id=4},
                new Cliente(){ Apellido= "Barcia", Nombre="Emmanuel", Id=5},
                new Cliente(){ Apellido= "Barcia", Nombre="Florencia", Id=6},
                new Cliente(){ Apellido= "Cedeño", Nombre="Gary", Id=7},
                new Cliente(){ Apellido= "Cedeño", Nombre="Hally", Id=8},
                new Cliente(){ Apellido= "Cedeño", Nombre="Iker", Id=9},
                new Cliente(){ Apellido= "Cedeño", Nombre="Jazmin", Id=10},

            };
            List<Factura> facturas = new List<Factura>()
             {
                 new Factura() { Observacion = "Platos", Año= 2020,  IdCliente = 1, Fecha = "12/04/2020", Total = 1000, },
                 new Factura() { Observacion = "carro",Año= 2000, IdCliente = 2, Fecha = "3/06/2020", Total = 700 },
                 new Factura() { Observacion = "veramicas", Año= 2000,IdCliente = 3, Fecha = "19/01/2020", Total = 300 },
                 new Factura() { Observacion = "nevera",Año= 2019, IdCliente = 4, Fecha = "29/09/2019", Total = 500 },
                 new Factura() { Observacion = "camas",Año= 2018, IdCliente = 5, Fecha = "13/06/2018", Total = 400 },
                 new Factura() { Observacion = "mesas",Año= 2019, IdCliente = 6, Fecha = "17/05/2019", Total = 800 },
                 new Factura() { Observacion = "flores",Año= 2020, IdCliente = 7, Fecha = "19/08/2020", Total = 200 },
                 new Factura() { Observacion = "cocina",Año= 2017, IdCliente = 8, Fecha = "14/02/2017", Total = 900 },
                 new Factura() { Observacion = "silla",Año= 2019, IdCliente = 9, Fecha = "11/12/2019", Total = 600 },
                 new Factura() { Observacion = "Platos",Año= 2017, IdCliente = 10, Fecha = "01/01/2017", Total = 100 },
             };
            int ban = 0, op;

            while (ban == 0)
            {
                //Menu
                Console.WriteLine("<<<<<<<<<<<<Menu>>>>>>>>");
                Console.WriteLine("1) Los 3 clientes con mayor monto de ventas \n" +
                                  "2) Los 3 clientes con menor monto en ventas \n" +
                                  "3) El cliente con más ventas realizadas..\n" +
                                  "4) Cada cliente y su cantidad de ventas realizadas.\n" +
                                  "5) Las ventas realizadas en el año 2019.\n" +
                                  "6) La venta más antigua.\n"+
                                  "7) Los clientes que tengan una venta cuya observación comience con Plato ");
                                  op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    //Incio
                    var consulta1 = from cliente in clientes
                                    join factura in facturas.Where(x => x.Total > 700)
                                    on cliente.Id equals factura.IdCliente
                                    select new {nombre= cliente.Nombre, apellido = cliente.Apellido, Total = factura.Total };

                    consulta1.ToList().ForEach(x =>
                    {
                        Console.WriteLine("{0} {1} = {2}", x.apellido, x.nombre, x.Total);
                    });
                    //Fin

                }
                else
                    if (op == 2)
                {
                    //incio

                    var consulta2 = from cliente in clientes
                                    join factura in facturas.Where(x => x.Total < 400)
                                    on cliente.Id equals factura.IdCliente
                                    select new { apellido = cliente.Apellido, nombre= cliente.Nombre, ToTal = factura.Total };

                    consulta2.ToList().ForEach(x =>
                    {
                        Console.WriteLine("{0} {1} = {2}", x.apellido, x.nombre, x.ToTal);
                    });
                    //fin
                }
                else
                    if (op == 3)
                {
                    //inicio
                    var consulta3 = from cliente in clientes
                                    where cliente.Nombre.ToUpper() == "Alexy".ToUpper()
                                    join factura in facturas on cliente.Id equals factura.IdCliente
                                    group cliente by factura.Total into resumen
                                    select new
                                    {
                                        ventas = resumen.Key,
                                        NombreDelCliente = (from res in resumen
                                                            select res.Nombre.ToString()).Min(),

                                    };
                    consulta3.ToList().ForEach(x =>
                    {
                        Console.WriteLine("{0} = {1}$", x.NombreDelCliente, x.ventas);
                    });
                    //fin
                }
                else
                    if (op == 4)
                {
                    //Inico

                    var consulta4 = from cliente in clientes
                                    join factura in facturas on cliente.Id equals factura.IdCliente
                                    select new
                                    {
                                        apellido = cliente.Apellido,
                                        nombre = cliente.Nombre,
                                        can = factura.Total,
                                        detalle = factura.Observacion
                                    };


                    consulta4.ToList().ForEach(x =>
                    {
                        Console.WriteLine("{0} {1} = valor {2} en {3}",x.apellido, x.nombre, x.can, x.detalle);
                    });
                    //Fin 
                }
                else
                    if (op == 5)
                {
                    //inicio

                    var consulta5 = from cliente in clientes
                                    join factura in facturas on cliente.Id equals factura.IdCliente
                                    where factura.Año == 2019
                                    select new
                                    {
                                        apellido= cliente.Apellido,
                                        fecha = factura.Fecha,
                                        nombre = cliente.Nombre,
                                        can = factura.Total,
                                        detalle = factura.Observacion
                                    };

                    consulta5.ToList().ForEach(x =>
                    {

                        Console.WriteLine("{0} {1} = valor {2}en {3} fecha={4}", x.apellido, x.nombre, x.can, x.detalle, DateTime.Now.ToString(x.fecha));
                      
                    });
                    //Fin
                }
                else
                    if (op == 6)
                {
                    //Incio

                    var consulta6 = from cliente in clientes
                                    join factura in facturas on cliente.Id equals factura.IdCliente
                                    where factura.Fecha == "19/10/2019"
                                    select new
                                    {
                                        apellido = cliente.Apellido,
                                        fecha = factura.Fecha,
                                        nombre = cliente.Nombre,
                                        can = factura.Total,
                                        detalle = factura.Observacion
                                    };
                    consulta6.ToList().ForEach(x =>
                    {

                        Console.WriteLine("{0{1} = Valor {2} en {3} fecha={4}", x.apellido, x.nombre, x.can, x.detalle, DateTime.Now.ToString(x.fecha));
                     
                    });
                    //Fin
                }
                else
                    if(op ==7)
                {
                    //Inicio

                    var consulta7 = from cliente in clientes
                                    join factura in facturas on cliente.Id equals factura.IdCliente
                                    where factura.Observacion.ToUpper() == "Plato".ToUpper() || factura.Observacion.ToUpper() == "Platos".ToUpper()
                                    select new
                                    {
                                        apellido = cliente.Apellido,
                                        fecha = factura.Fecha,
                                        nombre = cliente.Nombre,
                                        cant = factura.Total,
                                        detalle = factura.Observacion
                                    };
                    consulta7.ToList().ForEach(x =>
                    {

                        Console.WriteLine("{0} {1} =  valor {2} en {3} fecha={4}", x.apellido , x.nombre, x.cant, x.detalle);
                    });
                    //Fin


                }
                else 
                  
                    Console.WriteLine("No Valid0");

                Console.WriteLine("Desea Regresar al menu ");
                Console.WriteLine("Ingrese  0  o 1 para salir  ");
                int a = int.Parse(Console.ReadLine());
                ban = a;


            }
            Console.WriteLine("GRACIAS POR SU VISITA");
            Console.ReadLine();

        }
    }
}
