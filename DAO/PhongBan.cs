//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhongBan
    {
        public string MaPB { get; set; }
        public string TenPB { get; set; }
        public string ViTri { get; set; }
        public string TruongPB { get; set; }
        public string MaBP { get; set; }
        public long LuongCB { get; set; }
    
        public virtual BoPhan BoPhan { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}