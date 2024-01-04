using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace OnThi2.Models
{
    [MetadataTypeAttribute(typeof(tDanhMucSPMetadata))]
    public partial class tDanhMucSP
    {
        internal sealed class tDanhMucSPMetadata
        {
            [DisplayName("Mã Sản Phẩm ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này")]

            public string MaSP { get; set; }
            [DisplayName("Tên Sản Phẩm ")]
            public string TenSP { get; set; }
            [DisplayName("Mã Chất Liệu ")]
            public string MaChatLieu { get; set; }
            [DisplayName("Ngăn laptop ")]
            public string NganLapTop { get; set; }
            [DisplayName("Model ")]
            public string Model { get; set; }
            [DisplayName("Màu Sắc ")]
            public string MauSac { get; set; }
            [DisplayName("Mã Kích thước ")]
            public string MaKichThuoc { get; set; }
            [DisplayName("Cân nặng ")]
            public Nullable<double> CanNang { get; set; }
            [DisplayName("Độ Mới ")]
            public Nullable<double> DoNoi { get; set; }
            [Display(Name = "Mã Hãng Sản Xuất ")]
            public string MaHangSX { get; set; }
            [Display(Name = "Mã Nước Sản Xuất ")]
            public string MaNuocSX { get; set; }
            [Display(Name = "Mã Đặc tính ")]
            public string MaDacTinh { get; set; }
            [Display(Name = "Website ")]
            public string Website { get; set; }
            [Display(Name = "Thời gian bảo hành ")]
            public Nullable<double> ThoiGianBaoHanh { get; set; }
            [Display(Name = "GT sản phẩm ")]
            public string GioiThieuSP { get; set; }
            [Display(Name = "Giá ")]
            public Nullable<double> Gia { get; set; }
            [Display(Name = "Chiết khấu ")]
            public Nullable<double> ChietKhau { get; set; }
            [Display(Name = "Mã Loại ")]
            public string MaLoai { get; set; }
            [Display(Name = "Mã DT ")]
            public string MaDT { get; set; }
            [DisplayName("Ảnh")]
            [FileExtensions(Extensions = ".jpg", ErrorMessage = "Nhập đúng file ảnh .jpg!!")]
            public string Anh { get; set; }
        }
    }
}