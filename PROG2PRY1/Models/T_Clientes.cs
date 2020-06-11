

namespace PROG2PRY1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Clientes()
        {
            this.T_Productos = new HashSet<T_Productos>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Productos> T_Productos { get; set; }
    }
}
