using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyStudentUpdate
{
    // =======================================================================
    // LỚP CƠ SỞ (BASE CLASS)
    // =======================================================================
    public class Person
    {
        private string Maso;
        private string Hoten;

        public Person()
        {
            Maso = " ";
            Hoten = " ";
        }

        public Person(string Maso, string Hoten)
        {
            this.Maso = Maso;
            this.Hoten = Hoten;
        }

        public string MASO { get =>  Maso; set => Maso = value; }
        public string HOTEN { get => Hoten; set => Hoten = value; }

        public virtual void InputPerson()
        {
            Console.Write("Nhập Mã Số : ");
            this.Maso = Console.ReadLine();
            Console.Write("Nhập Họ Tên : ");
            this.Hoten = Console.ReadLine();
        }

        public virtual void OutputPerson()
        {
            Console.Write("Mã Số : {0} \t| Họ Tên : {1} \t| ",this.Maso , this.Hoten);
        }
    }

    // =======================================================================
    // LỚP DẪN XUẤT 1: STUDENT
    // =======================================================================
    public class Student : Person
     {
        private string khoaSV;
        private double diemSV;

        public Student() : base() 
        {
            khoaSV = " ";
            diemSV = 0.0;
        }

        public Student(string  Maso, string Hoten , string khoaSV , double diemSV) : base(Maso , Hoten)
        {
            this.khoaSV = khoaSV;
            this.diemSV = diemSV;
        }

        public string KHOASV {  get => khoaSV; set => khoaSV = value; }
        public double DIEMSV { get => diemSV; set => diemSV = value; }

        public override void InputPerson()
        {
            base.InputPerson();

            Console.Write("Nhập Khoa Sinh Viên : ");
            khoaSV = Console.ReadLine();
            Console.Write("Nhập Điểm Trung Bình Sinh Viên : ");
            diemSV = double.Parse(Console.ReadLine());
        }

        public override void OutputPerson()
        {
            base.OutputPerson();
            Console.WriteLine("Khoa Sinh Viên : {0} \t| Điểm Trung Bình : {1} ", khoaSV, diemSV);
        }
     }

    // =======================================================================
    // LỚP DẪN XUẤT 2: TEACHER
    // =======================================================================
    public class Teacher : Person 
    {
        private string diachiGV;

        public Teacher() : base() 
        {
            diachiGV = " ";     
        }

        public Teacher(string Maso, string Hoten, string diachiGV) : base(Maso, Hoten)
        {
            this.diachiGV = diachiGV;
        }

        public String DIACHIGV { get => diachiGV; set => diachiGV = value; }

        public override void InputPerson()
        {
            base.InputPerson();

            Console.Write("Nhập Địa Chỉ Giảng Viên : ");
            diachiGV = Console.ReadLine();
        }

        public override void OutputPerson()
        {
            base.OutputPerson();

            Console.WriteLine("Địa Chỉ Giảng Viên : {0} ",diachiGV);
        }
    }

    public class Program
    {
        static void Main()
        {
            Console.InputEncoding  = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            bool exit = false;
            List<Student> QuanLyStudent = new List<Student>
            {
                new Student("SV001", "Lê An", "CNTT", 9.5),
                new Student("SV002", "Trần Bình", "Kinh Doanh", 8.0),
                new Student("SV003", "Nguyễn Cúc", "Ngoại Ngữ", 7.2),
                new Student("SV004", "Phạm Duy", "CNTT", 6.8),
                new Student("SV005", "Hoàng Giang", "Thiết Kế", 9.0),
                new Student("SV006", "Bùi Hà", "Kinh Doanh", 7.5),
                new Student("SV007", "Đỗ Khoa", "CNTT", 8.8),
                new Student("SV008", "Chu Mai", "Ngoại Ngữ", 6.5),
                new Student("SV009", "Lương Nam", "Thiết Kế", 9.2),
                new Student("SV010", "Võ Oanh", "Kinh Doanh", 7.9)
            };

            List<Teacher> QuanLyTeacher = new List<Teacher>
            {
                new Teacher("GV001" , "Kiều Oanh" ,"Quận 3"),                 
                new Teacher("GV002", "Nguyễn Hải", "Quận 9"),
                new Teacher("GV003", "Phạm Thi", "Bình Thạnh"),
                new Teacher("GV004", "Trần Dũng", "Quận 1"),
                new Teacher("GV005", "Võ Liên", "Quận 9")
            };

            while (!exit)
            {
                DisplayMenuUniVerSity();
                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        Console.WriteLine("✅ Bạn đã chọn chức năng: Thêm Sinh Viên.");
                        ADDStudent(QuanLyStudent);
                        break;
                    case 2:
                        Console.WriteLine("✅ Bạn đã chọn chức năng: Thêm Giảng Viên.");
                        ADDTeacher(QuanLyTeacher);
                        break;
                    case 3:
                        Console.WriteLine("📄 Bạn đã chọn chức năng: Xuất Danh Sách Sinh Viên.");
                        DisPlayStudent(QuanLyStudent);
                        break;
                    case 4:
                        Console.WriteLine("📄 Bạn đã chọn chức năng: Xuất Danh Sách Giảng Viên.");
                        DisPlayTeacher(QuanLyTeacher);
                        break;
                    case 5:
                        Console.WriteLine("🔢 Bạn đã chọn chức năng: Thống kê số lượng.");
                        CountTeacherAndStudent(QuanLyStudent, QuanLyTeacher);
                        break;
                    case 6:
                        Console.WriteLine("🔎 Bạn đã chọn chức năng: Xuất Danh Sách Sinh Viên Thuộc Khoa CNTT.");
                        DisPlayStudentFacutyCNTT(QuanLyStudent);
                        break;
                    case 7:
                        Console.WriteLine("🔎 Bạn đã chọn chức năng: Xuất Danh Sách Giảng Viên Ở Quận 9.");
                        DisPlayTeacherLocationQ9(QuanLyTeacher);
                        break;
                    case 8:
                        Console.WriteLine("🏆 Bạn đã chọn chức năng: Xuất Sinh Viên Có Điểm Trung Bình Cao Nhất và Thuộc Khoa CNTT.");
                        MaxScoreStudentAndFacutyCNTT(QuanLyStudent);
                        break;
                    case 9:
                        Console.WriteLine("📊 Bạn đã chọn chức năng: Xếp loại học lực của Sinh viên.");
                        RatingStudent(QuanLyStudent);
                        break;
                    case 0:
                            Console.WriteLine("👋 Bạn đã chọn chức năng: Thoát khỏi chương trình. Tạm biệt!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("⚠️ Lựa chọn không hợp lệ. Vui lòng nhập lại (0-9).");
                            break;
                        }

            }
        }

        static void DisplayMenuUniVerSity()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("               MENU CHƯƠNG TRÌNH QUẢN LÝ UniVerSity         ");
            Console.WriteLine("=============================================================");
            Console.WriteLine("1. Thêm Sinh Viên");
            Console.WriteLine("2. Thêm Giảng Viên");
            Console.WriteLine("3. Xuất Danh Sách Sinh Viên ");
            Console.WriteLine("4. Xuất Danh Sách Giảng Viên");
            Console.WriteLine("5. Số Lượng Từng Danh Sách ( Tổng Số Sinh Viên , Tổng Số Giảng Viên ) ");
            Console.WriteLine("6. Xuất Danh Sách Sinh Viên Thuộc Khoa CNTT");
            Console.WriteLine("7. Xuất Danh Sách Giảng Viên Ở Quận 9");
            Console.WriteLine("8. Xuất Ra Danh Sách Sinh Viên Có Điểm Trung Bình Cao Nhất Và Thuộc Khoa CNTT");
            Console.WriteLine("9. Số Lượng Của Từng Xếp Loại Trong Danh Sách , Theo Thang Điểm 10");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("=============================================================");
            Console.Write("Mời bạn chọn chức năng (0-9): ");
        }
        // Câu 1
        static void ADDStudent(List<Student> QLStudent)
        {
            Student NewStudent = new Student();
            NewStudent.InputPerson();
            QLStudent.Add(NewStudent);
            Console.WriteLine("Thêm 1 Sinh Viên Thành Công.");
        }

        // Câu 2
        static void ADDTeacher(List<Teacher> QLTeacher)
        {
            Teacher NewTeacher = new Teacher();
            NewTeacher.InputPerson();
            QLTeacher.Add(NewTeacher);
            Console.WriteLine("Thêm 1 Giảng Viên Thành Công.");
        }

        // Câu 3
        static void DisPlayStudent(List<Student> QLStudent)
        {
            foreach(Student NewStudent in  QLStudent)
            {
                NewStudent.OutputPerson();
            }  
        }

        // Câu 4
        static void DisPlayTeacher(List<Teacher> QLTeacher)
        {
            foreach(Teacher NewTeacher in QLTeacher)
            {
                NewTeacher.OutputPerson();
            }    
        }

        // Câu 5
        static void CountTeacherAndStudent(List<Student> QLStudent , List<Teacher> QLTeacher)
        {
            Console.WriteLine("Tổng Số Sinh Viên Có Trong Danh Sách Là  : {0} ",QLStudent.Count());
            Console.WriteLine("Tổng Số Giảng Viên Có Trong Danh Sách Là : {0} ",QLTeacher.Count());
        }

        // Câu 6
        static void DisPlayStudentFacutyCNTT(List<Student> QLStudent)
        {
            var ResultStudent = QLStudent.Where(sv => sv.KHOASV == "CNTT").ToList();
            DisPlayStudent(ResultStudent);          
        }

        // Câu 7
        static void DisPlayTeacherLocationQ9(List<Teacher> QLTeacher)
        {
            var ResultTeacher = QLTeacher.Where(tc => tc.DIACHIGV == "Quận 9").ToList();
            DisPlayTeacher(ResultTeacher);
        }

        // Câu 8
        static void MaxScoreStudentAndFacutyCNTT(List<Student> QLStudent)
        {
            double MaxScore = QLStudent.Max(sv => sv.DIEMSV);

            var ResultStudent = QLStudent.Where(sv => sv.KHOASV == "CNTT" && sv.DIEMSV == MaxScore).ToList();
            DisPlayStudent(ResultStudent);
        }

        // Câu 9
        static void RatingStudent(List<Student> QLStudent)
        {
            var StudentRating = QLStudent.Select(sv => new
            {
                SinhVien = sv,
                XepLoai = GetRating(sv.DIEMSV)
            });

            var CountRating = StudentRating.GroupBy(item => item.XepLoai).Select(group => new
            {
                XepLoai = group.Key,
                SoLuong = group.Count()
            }).OrderByDescending(item => item.SoLuong).ToList();

            foreach(var Student in CountRating)
            {
                Console.WriteLine("Xếp Loại      : {0}  \t| Số Lượng : {1} ", Student.XepLoai, Student.SoLuong);
            }

            
        }

        static string GetRating(double diem)
        {
            if (diem >= 9) return "Xuất Xắc";
            else if (diem >= 8) return "Giỏi";
            else if (diem >= 7) return "Khá";
            else if (diem >= 5) return "Trung Bình";
            else if (diem >= 4) return "Yếu";
            else return "Kém";
        }
    }

}
