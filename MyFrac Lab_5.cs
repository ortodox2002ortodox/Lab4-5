using System.Numerics;
using System;
namespace Lab_5
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        private dynamic nom ;
        private dynamic denom;

        private dynamic gcf(dynamic nom, dynamic denom)
        {
            if(denom == 0 || nom == 0) 
                throw new DivideByZeroException("Denominator cannot be equal to 0");
            nom = Math.Abs(nom);
            denom = Math.Abs(denom);
            while (nom != denom)
            {
                if (nom > denom) nom = nom - denom;
                else denom = denom - nom;
            }
            return nom;
        }
        public MyFrac(BigInteger _nom, BigInteger _denom)
        {

            dynamic grcf = gcf(_nom, _denom);
            if ((_nom < 0) ^ (_denom < 0))
                nom = -Math.Abs(_nom / grcf);
            else nom = Math.Abs(_nom / grcf);
            denom = Math.Abs(_denom / grcf);
        }
        public MyFrac(MyFrac that)
        {
            nom = that.nom;
            denom = that.denom;
        }
        public MyFrac(int _nom, int _denom)
        {
            dynamic grcf = gcf(_nom, _denom);
            if ((_nom < 0) ^ (_denom < 0))
                nom = -Math.Abs(_nom / grcf);
            else nom = Math.Abs(_nom / grcf);
            denom = Math.Abs(_denom / grcf);
        }
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        }
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + denom * that.nom, denom * that.denom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
            
        }
        public MyFrac Divide(MyFrac that)
        {
            return new MyFrac(nom * that.denom, denom * that.nom);
        }
        public override string ToString()
        {
            return nom + "/" + denom;
        }
        public double DoubleValue()
        {
            return nom / Convert.ToDouble(denom);
        }
        public int CompareTo(MyFrac other)
        {
            return DoubleValue().CompareTo(other.DoubleValue());
        }
    }
}