using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyStudent
{
    internal class QuanLyStudent
    {
        private string maSV;
        private string tenSV;
        private string khoaSV;
        private double diemSV;
        
       public QuanLyStudent()
        {
            maSV = " ";
            tenSV = " ";
            khoaSV = " ";
            diemSV = 0.0;
        }

        public QuanLyStudent(string maSV, string tenSV, string khoaSV, double diemSV)
        {
            this.maSV = maSV;
            this.tenSV = tenSV;
            this.khoaSV = khoaSV;
            this.diemSV = diemSV;
        }

        public string MASV { get =>  maSV; set => maSV = value;}
        public string TenSV { get => tenSV; set => tenSV = value;}
        public string KHOASV { get => khoaSV; set => khoaSV = value;}
        public double DIEMSV { get => diemSV; set => diemSV = value; }
        public void InputStudent()
        {
            Console.Write("Nhập Mã Số Sinh Viên : ");
            maSV = Console.ReadLine();
            Console.Write("Nhập Tên Sinh Viên : ");
            tenSV = Console.ReadLine();
            Console.Write("Nhập Khoa Sinh Viên : ");
            khoaSV = Console.ReadLine();
            Console.Write("Nhập Điểm Trung Bình Sinh Viên : ");
            diemSV = double.Parse(Console.ReadLine());
        }

        public void OutputStudent()
        {
            Console.WriteLine("Mã Sinh Viên : {0} , Tên Sinh Viên : {1} , Khoa Sinh Viên : {2} , Điểm Trung Bình  : {3}",
                                maSV, tenSV, khoaSV , diemSV);
        }
    }
    public class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;
            List<QuanLyStudent> QLStudent = new List<QuanLyStudent>
            {
                new QuanLyStudent("SV001", "Lê An", "CNTT", 9.5),
                new QuanLyStudent("SV002", "Trần Bình", "Kinh Doanh", 8.0),
                new QuanLyStudent("SV003", "Nguyễn Cúc", "Ngoại Ngữ", 7.2),
                new QuanLyStudent("SV004", "Phạm Duy", "CNTT", 6.8),
                new QuanLyStudent("SV005", "Hoàng Giang", "Thiết Kế", 9.0),
                new QuanLyStudent("SV006", "Bùi Hà", "Kinh Doanh", 7.5),
                new QuanLyStudent("SV007", "Đỗ Khoa", "CNTT", 8.8),
                new QuanLyStudent("SV008", "Chu Mai", "Ngoại Ngữ", 6.5),
                new QuanLyStudent("SV009", "Lương Nam", "Thiết Kế", 9.2),
                new QuanLyStudent("SV010", "Võ Oanh", "Kinh Doanh", 7.9)
            };
            while (!exit)
            {
                Console.WriteLine("=========================================================================================");
                Console.WriteLine("                                 MENU CHỨC NĂNG             ");
                Console.WriteLine("=========================================================================================");
                Console.WriteLine("1. Thêm Sinh Viên");
                Console.WriteLine("2. Xuất Danh Sách Sinh Viên");
                Console.WriteLine("3. Xuất Danh Sách Sinh Viên Thuộc Khoa CNTT");
                Console.WriteLine("4. Xuất Danh Sách Sinh Viên Có Điểm Trung Bình Lớn Hơn 5");
                Console.WriteLine("5. Xuất Danh Sách Sinh Viên Được Sắp Xếp Tăng Dần Theo ĐTB");
                Console.WriteLine("6. Xuất Danh Sách Sinh Viên Được Sắp Xếp Tăng Dần Theo ĐTB Và Thuộc Khoa CNTT");
                Console.WriteLine("7. Tìm Sinh Viên Có Điểm Trung Bình Lớn Nhất Và Thuộc Khoa CNTT");
                Console.WriteLine("8. Xuất Số Lượng Của Từng Xếp Loại Trong Danh Sách Sinh Viên.");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("=========================================================================================");
                Console.Write("Mời bạn chọn chức năng (0-5): ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("✅ Bạn đã chọn chức năng: Thêm Sinh Viên.");
                        ADDStudent(QLStudent);
                        break;
                    case 2:
                        Console.WriteLine("📄 Bạn đã chọn chức năng: Xuất Danh Sách Sinh Viên.");
                        DisPlayStudent(QLStudent);
                        break;
                    case 3:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xuất Danh Sách Sinh Viên Thuộc Khoa CNTT");
                        DisPlayStudenFacutyCNTT(QLStudent);
                        break;
                    case 4:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xuất Danh Sách Sinh Viên Có Điểm Trung Bình Lớn Hơn 5");
                        DisPlayStudentAVGSCore5(QLStudent);
                        break;
                    case 5:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xuất Danh Sách Sinh Viên Sắp Xếp Theo ĐTB Tăng Dần");
                        SortAVGScoreStudent(QLStudent);
                        break;
                    case 6:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xuất Danh Sách Sinh Viên Có ĐTB Lớn Hơn 5 và Thuộc Khoa Công Nghệ Thông Tin");
                        DisPlayStudentAVGScore5AndFacutyCNTT(QLStudent);
                        break;
                    case 7:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xuất Sinh Viên Có Điểm Trung Bình Cao Nhất Và Thuộc Khoa CNTT");
                        MaxAVGScoreAndFacutyCNTT(QLStudent);
                        break;
                    case 8:
                        Console.WriteLine("✅ Bạn đã chọn chức năng : Xếp Loại Sinh Viên Và Cho Biết Số Lượng Trong Danh Sách");
                        RatingStudent(QLStudent);
                        break;
                    case 0:
                        Console.WriteLine("👋 Bạn đã chọn chức năng: Thoát khỏi chương trình. Tạm biệt!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("⚠️ Lựa chọn không hợp lệ. Vui lòng nhập lại (0, 1, hoặc 2).");
                        break;
                }

            }
        }
        static void ADDStudent(List<QuanLyStudent> QLList)
        {
            QuanLyStudent Student = new QuanLyStudent();
            Student.InputStudent();
            QLList.Add(Student);
            Console.WriteLine("Thêm Sinh Viên Thành Công");
        }

        static void DisPlayStudent(List<QuanLyStudent> QLList)
        {
            foreach (QuanLyStudent student in QLList)
            {
                student.OutputStudent();
            }
        }

        // Câu 3
        static void DisPlayStudenFacutyCNTT(List<QuanLyStudent> QLList)
        {
            var ResultCau3 = QLList.Where(sv => sv.KHOASV == "CNTT").ToList();
            DisPlayStudent(ResultCau3);
        }

        // Câu 4
        static void DisPlayStudentAVGSCore5(List<QuanLyStudent> QLList)
        {
            var ResultCau4 = QLList.Where(sv => sv.DIEMSV >= 5).ToList();
            DisPlayStudent(ResultCau4);
        }

        // Câu 5
        static void SortAVGScoreStudent(List<QuanLyStudent> QLList)
        {
            var ResultCau5 = QLList.OrderBy(sv => sv.DIEMSV).ToList();
            DisPlayStudent(ResultCau5);
        }

        // Câu 6
        static void DisPlayStudentAVGScore5AndFacutyCNTT(List<QuanLyStudent> QLList)
        {
            var ResultCau6 = QLList.Where(sv => sv.DIEMSV > 5 && sv.KHOASV == "CNTT").ToList();
            DisPlayStudent(ResultCau6);
        }

        // Câu 7
        static void MaxAVGScoreAndFacutyCNTT(List<QuanLyStudent> QLList)
        {
            double MaxScore = QLList.Max(sv => sv.DIEMSV);
            var ResultCau7 = QLList.Where(sv => sv.KHOASV == "CNTT" && sv.DIEMSV == MaxScore).ToList();
            DisPlayStudent(ResultCau7);
        }
        // Câu 8
        
        static void RatingStudent(List <QuanLyStudent> QLList)
        {
            var StudentRating = QLList.Select(sv => new
            {
                SinhVien = sv,
                XepLoai = GetRatingStudent(sv.DIEMSV),
            });

            var RatingCount = StudentRating.GroupBy(item => item.XepLoai).Select(Group => new
            {
                XepLoai = Group.Key,
                SoLuong = Group.Count(),
            }).OrderByDescending(item => item.SoLuong).ToList();

            foreach(var Rating in RatingCount)
            {
                Console.WriteLine("Xếp Loại : {0}  , Số Lượng : {1} ", Rating.XepLoai, Rating.SoLuong);
            }
        }

        static string GetRatingStudent(double Score)
        {
            if (Score >= 9) return "Xuất Xắc";
            else if (Score >= 8) return "Giỏi";
            else if (Score >= 7) return "Khá";
            else if (Score >= 5) return "Trung Bình";
            else if (Score >= 4) return "Yếu";
            else return "Kém";
        }
    }
}
