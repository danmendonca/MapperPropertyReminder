namespace MapperPropertyReminder.Tests.Helper
{
    using System;

    public class ComplexItem
    {
        public int MyInt { get; set; }

        public string MyString { get; set; }

        public double MyDouble { get; set; }

        public InnerComplexItem MyInnerComplex { get; set; }

        public DateTime MyDateTime { get; set; }

        public Object MyObject { get; set; }
    }
}