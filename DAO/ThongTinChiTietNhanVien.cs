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
    
    public partial class ThongTinChiTietNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinChiTietNhanVien()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }
    
        public string MaTTCT { get; set; }
        public string MaNV { get; set; }
        public bool MaGT { get; set; }
        public string CMND { get; set; }
        public System.DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string DienThoai { get; set; }
        public string SoNha { get; set; }
        public string Duong { get; set; }
        public string Phuong_Xa { get; set; }
        public string Quan_Huyen { get; set; }
        public string Tinh_TP { get; set; }
        public string QuocGia { get; set; }
        public string MaDT { get; set; }
        public string MaTG { get; set; }
        public string SoTheATM { get; set; }
    
        public virtual DanToc DanToc { get; set; }
        public virtual GioiTinh GioiTinh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual Quan_Huyen Quan_Huyen1 { get; set; }
        public virtual QuocGia QuocGia1 { get; set; }
        public virtual Tinh_TP Tinh_TP1 { get; set; }
        public virtual TonGiao TonGiao { get; set; }
    }
}