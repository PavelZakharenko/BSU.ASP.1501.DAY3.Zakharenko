using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomLib
{
    public class Polynom
    {
        double[] polynom;
        public Polynom(params double[] args)
        {
            if (args == null) throw new ArgumentNullException();
            polynom = args;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0;i<polynom.Length;i++)
            {
                if (polynom[i] != 0)
                {
                    sb.Append(polynom[i]);
                    if (i >= 1)
                        sb.Append("X");
                    if (i >= 2)
                        sb.Append($"^{i}");
                    if (i != polynom.Length - 1)
                        if (polynom[i + 1] > 0)
                            sb.Append("+");
                }
            }

            return sb.ToString();
        }

        public static Polynom operator+(Polynom x,Polynom y)
        {
            double[] result;
            if (x.polynom.Length >= y.polynom.Length)
                result = new double[x.polynom.Length];
            else result = new double[y.polynom.Length];
            for(int i=0;i<result.Length;i++)
            {
                if (i < x.polynom.Length)
                    result[i] += x.polynom[i];
                if (i < y.polynom.Length)
                    result[i] += y.polynom[i];
            }

            return new Polynom(result);
        }
        public static Polynom operator-(Polynom x, Polynom y)
        {
            double[] result;
            if (x.polynom.Length >= y.polynom.Length)
                result = new double[x.polynom.Length];
            else result = new double[y.polynom.Length];
            for(int i=0;i<result.Length;i++)
            {
                if (i < x.polynom.Length)
                    result[i] += x.polynom[i];
                if (i < y.polynom.Length)
                    result[i] -= y.polynom[i];
            }

            return new Polynom(result);
        }
       /* public static Polynom operator *(Polynom x, Polynom y)
        {
            //TODO
        }*/
        public override int GetHashCode()
        {
            int result=0;
           for(int i=0;i<polynom.Length;i++)
            {
                result = (result * 31) + polynom[i].GetHashCode();
            }
            return result;

        }
        public override bool Equals(object obj)
        {
            Polynom p = obj as Polynom;
            if (p == null)
                return false;
            if (base.Equals(p))
                return true;
            if (polynom.Length != p.polynom.Length)
                return false;
            for(int i=0;i<polynom.Length;i++)
            {
                if (polynom[i] != p.polynom[i])
                    return false;
            }          
            return true;
        }

    }
}
