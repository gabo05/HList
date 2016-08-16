using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HList.Progression
{
    public class ArithmeticProgression : MathProgression<ArithmeticProgression>
    {
        #region Constructors
        public ArithmeticProgression(double difference = 1) : base()
        {
            this.Difference = difference;
        }
        public ArithmeticProgression(double first, double difference = 1, int? count = null) : base(first, count)
        {
            this.Difference = difference;
        }
        public ArithmeticProgression(double first, double nelement, int eleinter, int? count = null)
        {
            this.first = first;

            int n = eleinter + 1;

            this.count = count;
            this.Difference = (nelement - first) / n;
        }
        public ArithmeticProgression(double nelement, int n, double difference, int? count = null)
        {
            this.Difference = difference;
            this.first = nelement - (n * difference);
            this.count = count;
        }
        public ArithmeticProgression(double[] sample, int? count = null)
        {
            if (sample == null || sample.Length == 0)
            {
                this.first = 0;
            }
            else if (sample.Length == 1)
            {
                this.first = sample[0];
                this.Difference = 1;
            }
            else {
                this.Difference = sample[1] - sample[0];
                this.first = sample[0];
            }
            this.count = count;
        }
        #endregion

        #region Properties
        public double Difference { get; protected set; }
        #endregion

        #region Override Methods
        public override double GetElement(int index)
        {
            if (!IsInfinite && index >= count.Value)
                throw new IndexOutOfRangeException("The progression does not contains this element");

            return this.first + (this.Difference * index);
        }

        public override int GetIndexOf(double element)
        {
            double _n = (element - this.first) / this.Difference;

            if (Math.Floor(_n) == _n)
                return (int)_n;

            return -1;
        }
        public override double Sum()
        {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            return (this.count.Value * (this.first + this.Last().Value)) / 2;
        }
        public override ArithmeticProgression Take(int _count)
        {
            return new ArithmeticProgression(first: this.first, difference: this.Difference, count: _count);
        }

        public override ArithmeticProgression Take(int start, int _count)
        {
            return new ArithmeticProgression(first: this.GetElement(start), difference: this.Difference, count: _count);
        }

        public override ArithmeticProgression TakeWhile(Func<double, bool> predicate)
        {
            bool finish = false;
            int i;

            for (i = 0; (this.IsInfinite || (!this.IsInfinite && i < this.count)) && !finish; i++)
            {
                finish = !predicate(this.GetElement(i));
            }
            return new ArithmeticProgression(first: this.first, difference: this.Difference, count: i-1);
        }
        
        #endregion
    }
}
