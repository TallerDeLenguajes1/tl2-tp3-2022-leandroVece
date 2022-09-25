namespace Cadeteria
{
    internal class cadeteria 
    {
        //relacion de compossicion con la clase cadete
        private string nombre;
        private string telefono;

        public string Nombre { get => nombre; set => nombre = value; }

        public string Telefono { get => telefono; set => telefono = value; }
        List<cadete> lista = new List<cadete>(); 

        internal List<cadete> Lista { get => lista; set => lista = value; }

        public cadeteria(string name, string phone){
            this.Nombre = name;
            this.Telefono = phone;
            
        }
    }
}