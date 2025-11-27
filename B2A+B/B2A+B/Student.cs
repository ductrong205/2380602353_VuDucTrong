using System;

namespace B2A_B
{
    public class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student()
        {
        }

        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void Input()
        {
            Console.Write("Nhap MSSV: ");
            StudentID = Console.ReadLine();

            Console.Write("Nhap Ho ten: ");
            FullName = Console.ReadLine();

            Console.Write("Nhap Diem TB: ");
            AverageScore = float.Parse(Console.ReadLine());

            Console.Write("Nhap Khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine($"MSSV:{StudentID} | Ho ten:{FullName} | Khoa:{Faculty} | DiemTB:{AverageScore}");
        }
    }
}
