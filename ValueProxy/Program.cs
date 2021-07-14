﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ValueProxy
{
    [DebuggerDisplay("{value*100,0f}%")]
    public struct Percentage : IEquatable<Percentage>
    {
        private readonly float value;

        public Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }

        public bool Equals(Percentage other)
        {
            return value.Equals(other.value);
        }

        public override bool Equals(object obj)
        {
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !left.Equals(right);
        }

        public static Percentage operator +(Percentage a, Percentage b)
        {
            return new Percentage(a.value + b.value);
        }

        public override string ToString()
        {
            return $"{value * 100}%";
        }
    }

    public static class PercentageExtensions
    {
        internal static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
        internal static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(
                10f * 5.Percent());

            WriteLine(
                2.Percent() + 3.Percent()
            );

            ReadLine();
        }
    }
}
