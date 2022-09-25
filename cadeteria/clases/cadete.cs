namespace Cadeteria
{
    internal class cadete : persona
    {
        //clase hija que hereda de persona sus atributos que comparten
        //relacion de agregacion con los pedidos;
        private List<pedido> listpedido = new List<pedido>();


        internal List<pedido> Listpedido { get => listpedido; set => listpedido = value; }

        public cadete(int id, string name, string adress, string phone):base(id,name,adress,phone){
            this.Id = id;
            this.Nombre = name;
            this.Direccion = adress;
            this.Telefono = phone;
        }

        public string jornalACobrar(List<pedido> pedidos){
            //sacar el calculo de cada pedido realizado por 300 pesos

            return "la jornada laboral es de ";
        }

        public void get(List<pedido> pedidos){
            //sacar el calculo de cada pedido realizado por 300 pesos
            foreach (var item in pedidos)
            {
                Console.WriteLine("estado del pedido {0} es {1}",item.Numero,item.Estado);
            }
            
        }
        
    }
}