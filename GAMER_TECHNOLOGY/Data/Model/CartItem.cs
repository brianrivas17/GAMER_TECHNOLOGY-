﻿namespace GAMER_TECHNOLOGY.Data.Model
{
    public class CartItem
    {
        public int Id_articulo { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
        public int Quantity { get; set; }
        public string Email_user { get; set; }
    }
}
