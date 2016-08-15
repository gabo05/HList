using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HList.Progression
{
    public abstract class MathProgression<R> : IMathProgression<R> where R : IMathProgression
    {
        #region Properties
        protected double first { get; set; }
        protected int? count { get; set; }
        public bool IsInfinite { get { return !this.count.HasValue; } }
        #endregion

        #region Constructors
        public MathProgression() {
            this.first = 0;
            this.count = null;
        }
        public MathProgression(double first, int count) {
            this.first = first;
            this.count = count;
        }
        #endregion

        #region Abstract Methods
        public abstract double First(Func<double, bool> predicate);
        public abstract T FoldLeft<T>(Func<T, double, T> fold);
        public abstract T FoldRight<T>(Func<T, double, T> fold);
        public abstract double GetElement(int index);
        public abstract int GetIndexOf(double element);
        public abstract double Last(Func<double, bool> predicate);
        public abstract IEnumerable<T> Map<T>(Func<double, T> map);
        public abstract double Sum();
        public abstract double Sum(Func<double, bool> predicate);
        public abstract R Take(int count);
        public abstract R Take(int start, int count);
        public abstract R TakeWhile(Func<double, bool> predicate);
        public abstract IEnumerable<double> Where(Func<double, int, bool> predicate);
        public abstract IEnumerable<double> Where(Func<double, bool> predicate);
        public abstract T FoldLeft<T>(Func<T, double, T> fold, int start);
        public abstract T FoldLeft<T>(Func<T, double, T> fold, int start, int end);
        public abstract T FoldRight<T>(Func<T, double, T> fold, int end);
        public abstract T FoldRight<T>(Func<T, double, T> fold, int end, int start);
        #endregion

        #region Implemented Methods
        public double First() {
            return this.first;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public double? Last()
        {
            if (this.IsInfinite)
                return null;
            return this.GetElement(this.count.Value -1);
        }
        public int? Count()
        {
            return count;
        }

        public bool Contains(double element)
        {
            return this.GetIndexOf(element) != -1;
        }
        public IEnumerator<double> GetEnumerator()
        {
            for (int i=0; this.IsInfinite || (!this.IsInfinite && i < this.count);i++) {
                yield return this.GetElement(i);
            }
        }
        #endregion
    }
}
