namespace Cadeteria
{
    internal class pedido
    {
        private string numero ,obs;
        private string estado;
        
        //siguiendo la teoria de composicion si creo clientes desde la clase pedido este se eliminara cuando elimine el pedido
        cliente cliente;


        public pedido(string numero, string obs, cliente cliente, string estado){
            this.Cliente = cliente;
            this.Numero = numero;
            this.Obs = obs;
            this.Estado = estado;
        }

        public void cargarCliente(int id, string name, string adress, string phone, string datosReferencia){
            this.Cliente = new cliente(id,name,adress,phone,datosReferencia);
        }

        public string Numero { get => numero; set => numero = value; }
        public string Obs { get => obs; set => obs = value; }
        public cliente Cliente { get => cliente; set => cliente = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}