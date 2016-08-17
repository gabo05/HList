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
        public ArithmeticProgression() : base()
        {
            this.Difference = 1;
        }
        public ArithmeticProgression(double first, int? count) : base(first, count) {
            this.Difference = 1;
        }

        public ArithmeticProgression(double difference) : base()
        {
            this.Difference = difference;
        }
        public ArithmeticProgression(double first, double difference) : base(first, null)
        {
            this.Difference = difference;
        }
        public ArithmeticProgression(double first, double difference, int? count) : base(first, count)
        {
            this.Difference = difference;
        }
        public ArithmeticProgression(double first, double nelement, int eleinter, int? count) : base(first, count)
        {
            int n = eleinter + 1;
            this.Difference = (nelement - first) / n;
        }
        public ArithmeticProgression(double nelement, int n, double difference, int? count)
        {
            this.Difference = difference;
            this.first = nelement - (n * difference);
            this.count = count;
        }
        public ArithmeticProgression(double?[] sample, int? count = null)
        {
            this.count = count;
            if (sample == null || sample.Length == 0)
            {
                this.first = 0;
            }
            else if (sample.Length == 1 && sample[0].HasValue)
            {
                this.first = sample[0].Value;
                this.Difference = 1;
            }
            else if (sample.Length >= 2 && sample[1].HasValue && sample[0].HasValue)
            {
                this.Difference = sample[1].Value - sample[0].Value;
                this.first = sample[0].Value;
            }
            else if (sample.Length > 2 && !sample[1].HasValue) {

                if (sample.Last().HasValue && sample.First().HasValue)
                {
                    this.count = sample.Length;
                    this.first = sample.First().Value;
                    this.Difference = (sample.Last().Value - sample.First().Value) / (sample.Length - 1);
                }
                else if (!sample.Last().HasValue && sample.First().HasValue) {
                    this.count = null;
                    this.first = sample.First().Value;
                    int ci = sample.TakeWhile((x, i) => i == 0 || !x.HasValue).Count();
                    if (ci == sample.Length)
                        throw new ArgumentException("The progression can not be determinate by the arguments");
                    else {
                        double nelement = sample[ci].Value;

                        this.Difference = (nelement - sample.First().Value) / ci;
                    }
                }
            }
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
            if (!this.IsInfinite && this.count.Value < _count)
                _count = this.count.Value;

            return new ArithmeticProgression(first: this.first, difference: this.Difference, count: _count);
        }

        public override ArithmeticProgression Take(int start, int _count)
        {
            if (!this.IsInfinite)
            {
                var rest = (this.count.Value - start);

                _count = rest < _count ? rest : _count;
            }
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
