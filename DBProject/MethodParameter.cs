//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class MethodParameter
    {
        public int MethodParameterID { get; set; }
        public int MethodID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
    
        public virtual Method Method { get; set; }
        public virtual Type Type { get; set; }
    }
}
