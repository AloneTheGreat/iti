﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqToObjects
{
    public class Course /*:IComparable<Course>*/
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public Subject Subject { get; set; }
        public Department Department { get; set; }

        //public int CompareTo(Course other)
        //{
            
        //}

        //public override string ToString()
        //{
        //    return Name;
        //}
    }
}
