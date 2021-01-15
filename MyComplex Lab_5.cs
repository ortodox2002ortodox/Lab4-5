using System;

namespace Lab_5
{
    public class MyComplex : IMyNumber<MyComplex>
    {
        private double re;
        private double im;

        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public MyComplex(MyComplex that)
        {
            re = that.re;
            im = that.im;
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(re + that.re, im + that.im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(re - that.re, im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double _re = re * that.re - im * that.im;
            double _im = re * that.im + im * that.re;
            return new MyComplex(_re, _im);
        }

        public MyComplex Divide(MyComplex that)
        {
            double _re = (re * that.re + im * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2));
            double _im = (im * that.re - re * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2));
            return new MyComplex(_re, _im);
        }

        public override string ToString()
        {
            return (System.String.Format("{0} + {1}i", re, im));
        }
    }
}