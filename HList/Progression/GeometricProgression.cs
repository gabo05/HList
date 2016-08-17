using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HList.Progression
{
    public class GeometricProgression : MathProgression<GeometricProgression>
    {
        #region Constructor
        public GeometricProgression() : base()
        {
            this.first = 1;
            this.Ratio = 1;
        }
        public GeometricProgression(double first, int? count) : base(first, count) {
            this.Ratio = 1;
        }

        public GeometricProgression(double ratio) : base()
        {
            this.Ratio = ratio;
            this.first = 1;
        }
        public GeometricProgression(double first, double ratio) : base(first, null)
        {
            this.Ratio = ratio;
        }
        public GeometricProgression(double first, double ratio, int? count) : base(first, count)
        {
            this.Ratio = ratio;
        }
        public GeometricProgression(double first, double nelement, int eleinter, int? count) : base(first, count)
        {
            double n = eleinter + 1;
            this.Ratio = Math.Pow((nelement / first) ,1/ n);
        }
        public GeometricProgression(double nelement, int n, double ratio, int? count)
        {
            this.Ratio = ratio;
            this.first = nelement / (Math.Pow(Ratio, n));
            this.count = count;
        }
        public GeometricProgression(double?[] sample, int? count = null)
        {
            this.count = count;
            if (sample == null || sample.Length == 0)
            {
                this.first = 0;
            }
            else if (sample.Length == 1 && sample[0].HasValue)
            {
                this.first = sample[0].Value;
                this.Ratio = 1;
            }
            else if (sample.Length >= 2 && sample[1].HasValue && sample[0].HasValue)
            {
                this.Ratio = sample[1].Value / sample[0].Value;
                this.first = sample[0].Value;
            }
            else if (sample.Length > 2 && !sample[1].HasValue)
            {

                if (sample.Last().HasValue && sample.First().HasValue)
                {
                    this.count = sample.Length;
                    this.first = sample.First().Value;
                    this.Ratio = Math.Pow((sample.Last().Value / sample.First().Value), 1 / ((double)sample.Length - 1));
                }
                else if (!sample.Last().HasValue && sample.First().HasValue)
                {
                    this.count = null;
                    this.first = sample.First().Value;
                    double ci = sample.TakeWhile((x, i) => i == 0 || !x.HasValue).Count();
                    if (ci == sample.Length)
                        throw new ArgumentException("The progression can not be determinate by the arguments");
                    else
                    {
                        double nelement = sample[(int)ci].Value;

                        this.Ratio = Math.Pow((nelement / sample.First().Value) , 1/ci);
                    }
                }
            }
        }
        #endregion
        #region Properties
        public double Ratio { get; protected set; }
        #endregion
        public override double GetElement(int index)
        {
            if (!IsInfinite && index >= count.Value)
                throw new IndexOutOfRangeException("The progression does not contains this element");

            return this.first * Math.Pow(this.Ratio, index);
        }

        public override int GetIndexOf(double element)
        {
            double index  = Math.Log((element / this.first), this.Ratio);

            if (index == Math.Floor(index))
                return (int)index;

            return -1;
        }
        public override double Sum()
        {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");
            return (this.Last().Value * this.Ratio - this.first) / (this.Ratio - 1);
        }
        public override GeometricProgression Take(int _count)
        {
            if (!this.IsInfinite && this.count.Value < _count)
                _count = this.count.Value;

            return new GeometricProgression(this.first, this.Ratio, _count);
        }

        public override GeometricProgression Take(int start, int _count)
        {
            if (!this.IsInfinite)
            {
                var rest = (this.count.Value - start);

                _count = rest < _count ? rest : _count;
            }

            return new GeometricProgression(this.GetElement(start), this.Ratio, _count);
        }

        public override GeometricProgression TakeWhile(Func<double, bool> predicate)
        {
            bool finish = false;
            int i;

            for (i = 0; (this.IsInfinite || (!this.IsInfinite && i < this.count)) && !finish; i++)
            {
                finish = !predicate(this.GetElement(i));
            }
            return new GeometricProgression(first: this.first, ratio: this.Ratio, count: i - 1);
        }
    }
}
