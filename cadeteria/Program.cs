
namespace Cadeteria
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            cliente aux = new cliente(01,"juan","entre rios 1200","45123542","cerca de copito");
            pedido pAux = new pedido("01","coca", aux,"Sin asignar");

            cadete caux = new cadete(01,"ticho","moreno 1200","5521254");

            cadeteria eternos = new cadeteria("eternos","6542112");
            List<pedido> listaPedido = new List<pedido>();
            listaPedido.Add(pAux);
            eternos.Lista.Add(caux);
            eternos.Lista[0].Listpedido.Add(pAux);

            string OptionPedido;
            int optionCadete,optionCadete2;
        
            Console.WriteLine("\n Elija una opcion \n 1) Dar de alta pedidos 2) Asignar pedidos 3) Cambiar estado 4) Cambiar cadete");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                     listaPedido.Add(Altapedido());
                    break;
                case 2:
                    OptionPedido = selectorPedido(listaPedido);
                    optionCadete =selectorcadete(eternos.Lista);
                    asignarPedido(listaPedido,eternos, OptionPedido, optionCadete);
                    break;

                case 3:
                    optionCadete =selectorcadete(eternos.Lista);
                    OptionPedido = selectorPedido(listaPedido);
                    cabiarEstado(OptionPedido,optionCadete,listaPedido,eternos);
                    break;
                case 4:
                    Console.WriteLine("Elige primero el cadete que deseas que sea remplazado y luego el remplazo");
                    optionCadete =selectorcadete(eternos.Lista);
                    optionCadete2 =selectorcadete(eternos.Lista);

                    Console.WriteLine("Elige el pedido que deseas cambiar");
                    OptionPedido = selectorPedido(listaPedido); 
                    cambiarCadete(eternos,listaPedido, optionCadete,optionCadete2,OptionPedido);
                    break;
                default:
                break;
            }

        }

        //remueve el pedido guardado de un cadete y lo agrega a otro cadete previamente seleccionado por ID
        public static void cambiarCadete(cadeteria eternos,List<pedido> lista, int cadete1,int cadete2, string numPedido){
            
            pedido aux = lista.First(x => x.Numero == numPedido);
            foreach (var item in eternos.Lista)
            {
                if (cadete1 == item.Id)
                    item.Listpedido.Remove(aux);
                if (cadete2 == item.Id)
                    item.Listpedido.Add(aux);
            }
        }

        //estas dos funciones cargan un pedido nuevo y un cliente nuevo
        public static pedido Altapedido(){ 
            string numero; 
            string obs;
            
            numero = Console.ReadLine();
            obs = Console.ReadLine();
            
            return new pedido(numero,obs,setCliente(),"Sin asignar");
        }

        public static cliente setCliente(){ 
            
            int id; 
            string name, adress, phone, datosReferencia;

            id = int.Parse(Console.ReadLine());
            name = Console.ReadLine();
            adress = Console.ReadLine();
            phone = Console.ReadLine();
            datosReferencia = Console.ReadLine();

            cliente aux = new cliente(id, name,adress, phone, datosReferencia);
            return aux;
        }

        //esta funcion asigna un pedido elegido previamente por el numero de pedido a un cadete seleccionado por el ID
        public static void asignarPedido(List<pedido> lista, cadeteria eternos, string numPedido, int idCadete){

            pedido aux = lista.First(x => x.Numero == numPedido);
            foreach (var item in eternos.Lista)
            {
                if (item.Id == idCadete){
                    aux.Estado = "Pendiente";
                    item.Listpedido.Add(aux);
                }
            }
        }

        //esta funcio cambia el estado del pedido que tiene el cadete y elimina de la lista de pedidos
        public static void cabiarEstado(string numPedido,int idCadete,List<pedido> lista,cadeteria eternos){
            //pedido entregado lo elimino de la lista
            pedido aux = lista.First(x => x.Numero == numPedido);

            //cambio el estado del del pedido del cadete de la clase caderetia
           foreach (var item in eternos.Lista)
            {
                if (item.Id == idCadete){
                    //sentencia linq;
                    //item.Listpedido = from elemt in item.Listpedido where aux == elemt => (elemt.estado = "entregado");
                    foreach (var el in item.Listpedido)
                    {
                        if (el.Numero == numPedido){
                            el.Estado = "entregado";                    
                            break;
                        }
                    }
                }
            }
            lista.Remove(aux);
        }

        //estas funciones muestran la lista de cadetes y pedidos 
        public static void getCadetes(List<cadete> lista){  

            foreach (var item in lista)
            {
                Console.WriteLine("-Id {0} nombre {1}",item.Id,item.Nombre);
            }
        }
        public static void getPedidos(List<pedido> lista){

            foreach (var item in lista)
            {
                Console.WriteLine("Numero del pedido es {0}: nombre {1}/estado {2}/ cliente {3}",item.Numero,item.Obs,item.Estado, item.Cliente.Nombre);
            }
        }

        //estas funciones devuelven el cadete o pedido seleccionado ya sea por numero o por ID
        public static string selectorPedido(List<pedido> lista){

            Console.WriteLine("seleccione el pedido a asignar por el Numero de pedido");
            getPedidos(lista);
            return Console.ReadLine();;
        }

        public static int selectorcadete(List<cadete> lista){

            Console.WriteLine("seleccione el cadete a asignar por el Id");
            getCadetes(lista);
            return int.Parse(Console.ReadLine());
        }
    }
}