//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bakiye_Kontrol.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bakiye_Banka
    {
        public int ID { get; set; }
        public Nullable<int> BankaID { get; set; }
        public string ParaBirimi { get; set; }
        public Nullable<int> Bakiye { get; set; }
    
        public virtual Banka Banka { get; set; }
    }
}
