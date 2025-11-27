using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public void Print()
    {
        Console.WriteLine($"ID: {Id} | Ten: {Name} | Tuoi: {Age}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>()
        {
            new Student(1, "An", 14),
            new Student(2, "Binh", 15),
            new Student(3, "Anh Tu", 17),
            new Student(4, "Cuong", 18),
            new Student(5, "Tuan", 16),
            new Student(6, "Bao", 19),
        };

        Console.WriteLine("a. Danh sach toan bo hoc sinh:");
        foreach (var s in students)
            s.Print();
        Console.WriteLine();

        Console.WriteLine("b. Hoc sinh co tuoi tu 15 den 18:");
        var ageRange = students.Where(s => s.Age >= 15 && s.Age <= 18);
        foreach (var s in ageRange)
            s.Print();
        Console.WriteLine();

        Console.WriteLine("c. Hoc sinh co ten bat dau bang chu A:");
        var startWithA = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
        foreach (var s in startWithA)
            s.Print();
        Console.WriteLine();

        int totalAge = students.Sum(s => s.Age);
        Console.WriteLine($"d. Tong tuoi cua tat ca hoc sinh: {totalAge}");
        Console.WriteLine();

        Console.WriteLine("e. Hoc sinh co tuoi lon nhat:");
        int maxAge = students.Max(s => s.Age);
        var oldest = students.Where(s => s.Age == maxAge);
        foreach (var s in oldest)
            s.Print();
        Console.WriteLine();

        Console.WriteLine("f. Danh sach hoc sinh sap xep theo tuoi tang dan:");
        var sorted = students.OrderBy(s => s.Age);
        foreach (var s in sorted)
            s.Print();

        Console.WriteLine("\nNhan phim bat ky de ket thuc...");
        Console.ReadKey();
    }
}
