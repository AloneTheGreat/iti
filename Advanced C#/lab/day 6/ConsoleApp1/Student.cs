﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }

        public Student(int id, string name, string grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Grade: {Grade}.";
        }
    }
}
