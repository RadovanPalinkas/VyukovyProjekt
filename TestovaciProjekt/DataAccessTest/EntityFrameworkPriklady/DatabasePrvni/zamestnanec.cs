//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessTest.EntityFrameworkPriklady.DatabasePrvni
{
    using System;
    using System.Collections.Generic;
    
    public partial class zamestnanec
    {
        public int id_zamestnance { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public int id_oddeleni { get; set; }
    
        public virtual oddeleni oddeleni { get; set; }
    }
}
