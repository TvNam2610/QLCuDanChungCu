using DTO;
using Novacode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class WordHelper
    {
        public static void ExportToWord(List<object> data, string templatePath, string exportPath)
        {
            // Tạo tài liệu Word mới
            using (DocX document = DocX.Load(templatePath))
            {
                DateTime dateNow = DateTime.Now;

                // tìm đối tượng Paragraph chứa trường dữ liệu
                Paragraph p = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("<<QuanLy>>"));
                Paragraph day = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{day}"));
                Paragraph month = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{month}"));
                Paragraph year = document.Paragraphs.FirstOrDefault(paragraph => paragraph.Text.Contains("{year}"));

                // thay thế chuỗi trường dữ liệu bằng giá trị thật
                p.ReplaceText("<<QuanLy>>", "Nguyễn Văn A");
                day.ReplaceText("{day}", dateNow.Day.ToString());
                month.ReplaceText("{month}", dateNow.Month.ToString());
                year.ReplaceText("{year}", dateNow.Year.ToString());

                // Lấy đối tượng bảng từ tài liệu Word
                Table table = document.Tables[1];
                int i = 1;

                // Lặp qua các dữ liệu trong danh sách


                foreach (var item in data)
                {
                    // Thêm một dòng mới vào bảng
                    Row row = table.InsertRow();

                    // Sử dụng các thuộc tính của đối tượng để điền dữ liệu vào bảng
                    if (item is NguoiDan)
                    {
                        NguoiDan nd = (NguoiDan)item;
                        row.Cells[0].Paragraphs[0].InsertText(i.ToString());
                        row.Cells[0].Width = 80;


                        row.Cells[1].Paragraphs[0].InsertText(nd.HoTen);

                        row.Cells[2].Paragraphs[0].InsertText(nd.NgaySinh.ToShortDateString());

                        row.Cells[3].Paragraphs[0].InsertText(nd.GioiTinh);

                        row.Cells[4].Paragraphs[0].InsertText(nd.SoDienThoai);

                        row.Cells[5].Paragraphs[0].InsertText(nd.DiaChi);

                        i++;

                    }
                    else if (item is NhanVien)
                    {
                        NhanVien nv = (NhanVien)item;
                        row.Cells[0].Paragraphs[0].InsertText(i.ToString());
                        row.Cells[0].Width = 80;


                        row.Cells[1].Paragraphs[0].InsertText(nv.TenNV);

                        row.Cells[2].Paragraphs[0].InsertText(nv.DiaChi);

                        row.Cells[3].Paragraphs[0].InsertText(nv.SoDienThoai);

                        row.Cells[4].Paragraphs[0].InsertText(nv.Email);

                        row.Cells[5].Paragraphs[0].InsertText(nv.MachucVu);

                        row.Cells[6].Paragraphs[0].InsertText(nv.MaNQL);

                        i++;
                    }
                }
                document.SaveAndOpenFile(exportPath);
            }
        }

        public static void SaveAndOpenFile(this DocX doc, string filename = "BaoCao.docx")
        {
            /*string thuMuc = "temp";
            if (!Directory.Exists(thuMuc))
                Directory.CreateDirectory(thuMuc);*/

            while (true)
            {
                string tenTep = $"{filename}";
                try
                {
                    doc.SaveAs(tenTep);
                    Process.Start(tenTep);
                    break;
                }
                catch
                {

                }
            }
        }
    }
}
