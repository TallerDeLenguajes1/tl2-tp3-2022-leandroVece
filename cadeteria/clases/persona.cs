namespace Cadeteria
{
    internal class persona
    {
        //clase padre o superclase
        private int id;
        private string nombre,direccion,telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public persona(int id, string name, string adress, string phone){
            this.Id = id;
            this.Nombre = name;
            this.Direccion = adress;
            this.Telefono = phone;
        }
    }
}