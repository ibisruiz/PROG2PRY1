//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROG2PRY1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Productos
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int ID_Categoria { get; set; }
        public int ID_Cliente { get; set; }
    
        public virtual T_Categoria T_Categoria { get; set; }
        public virtual T_Clientes T_Clientes { get; set; }
    }
}
