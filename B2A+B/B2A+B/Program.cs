using System;
using System.Collections.Generic;
using System.Linq;

namespace B2A_B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi danh sach sinh vien");
                Console.WriteLine("3. Sinh vien thuoc khoa CNTT");
                Console.WriteLine("4. Sinh vien co DTB >= 5");
                Console.WriteLine("5. Sap xep sinh vien theo DTB tang dan");
                Console.WriteLine("6. Sinh vien khoa CNTT va DTB >= 5");
                Console.WriteLine("7. Sinh vien co DTB cao nhat va khoa CNTT");
                Console.WriteLine("8. Dem so luong tung xep loai");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;

                    case "2":
                        DisplayStudentList(studentList);
                        break;

                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;

                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;

                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;

                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;

                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;

                    case "8":
                        CountStudentClassification(studentList);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }


        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("\n=== Nhap thong tin sinh vien ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Them thanh cong!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("\n=== Danh sach sinh vien ===");
            foreach (var s in studentList)
                s.Show();
        }

        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"\n=== Sinh vien thuoc khoa {faculty} ===");
            var students = studentList.Where(s =>
                s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            foreach (var s in students)
                s.Show();
        }

        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine($"\n=== Sinh vien co DTB >= {minDTB} ===");
            var students = studentList.Where(s => s.AverageScore >= minDTB);

            foreach (var s in students)
                s.Show();
        }

        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("\n=== Sap xep sinh vien theo DTB tang dan ===");
            var sorted = studentList.OrderBy(s => s.AverageScore);

            foreach (var s in sorted)
                s.Show();
        }

        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("\n=== Sinh vien khoa CNTT va DTB >= 5 ===");

            var students = studentList.Where(s =>
                s.AverageScore >= minDTB &&
                s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            foreach (var s in students)
                s.Show();
        }

        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("\n=== Sinh vien DTB cao nhat va thuoc khoa CNTT ===");

            var cnttStudents = studentList.Where(s =>
                s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            if (!cnttStudents.Any())
            {
                Console.WriteLine("Khong co sinh vien thuoc khoa CNTT.");
                return;
            }

            float maxDTB = cnttStudents.Max(s => s.AverageScore);

            var result = cnttStudents.Where(s => s.AverageScore == maxDTB);

            foreach (var s in result)
                s.Show();
        }

        static void CountStudentClassification(List<Student> studentList)
        {
            Console.WriteLine("\n=== Thong ke xep loai ===");

            var xuatSac = studentList.Count(s => s.AverageScore >= 9);
            var gioi = studentList.Count(s => s.AverageScore >= 8 && s.AverageScore < 9);
            var kha = studentList.Count(s => s.AverageScore >= 7 && s.AverageScore < 8);
            var trungBinh = studentList.Count(s => s.AverageScore >= 5 && s.AverageScore < 7);
            var yeu = studentList.Count(s => s.AverageScore >= 4 && s.AverageScore < 5);
            var kem = studentList.Count(s => s.AverageScore < 4);

            Console.WriteLine($"Xuat sac: {xuatSac}");
            Console.WriteLine($"Gioi: {gioi}");
            Console.WriteLine($"Kha: {kha}");
            Console.WriteLine($"Trung binh: {trungBinh}");
            Console.WriteLine($"Yeu: {yeu}");
            Console.WriteLine($"Kem: {kem}");
        }
    }
}
