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
        public MathProgression()
        {
            this.first = 0;
            this.count = null;
        }
        public MathProgression(double first, int? count)
        {
            this.first = first;
            this.count = count;
        }
        #endregion

        #region Abstract Methods
        
        public abstract double GetElement(int index);
        public abstract int GetIndexOf(double element);
        public abstract R Take(int count);
        public abstract R Take(int start, int count);
        public abstract R TakeWhile(Func<double, bool> predicate);
        #endregion

        #region Implemented Methods
        public virtual double First()
        {
            return this.first;
        }
        public virtual double? First(Func<double, bool> predicate)
        {
            bool found = false;
            double? _first = null;
            double pivote;
            for (int i = 0; (this.IsInfinite || (!this.IsInfinite && i < this.count)) && !found; i++)
            {
                pivote = this.GetElement(i);
                found = predicate(pivote);
                if (found)
                    _first = pivote;
            }
            return _first;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public virtual double? Last()
        {
            if (this.IsInfinite)
                return null;
            return this.GetElement(this.count.Value - 1);
        }
        public virtual double? Last(Func<double, bool> predicate)
        {
            if (this.IsInfinite)
                return null;

            bool found = false;
            double? _last = null;
            double pivote;
            for (int i = this.count.Value - 1; i >= 0 && !found; i--)
            {
                pivote = this.GetElement(i);
                found = predicate(pivote);
                if (found)
                    _last = pivote;
            }
            return _last;
        }
        public virtual int? Count()
        {
            return count;
        }

        public virtual bool Contains(double element)
        {
            return this.GetIndexOf(element) != -1;
        }
        public virtual IEnumerator<double> GetEnumerator()
        {
            for (int i = 0; this.IsInfinite || (!this.IsInfinite && i < this.count); i++)
            {
                yield return this.GetElement(i);
            }
        }
        public virtual IEnumerable<T> Map<T>(Func<double, T> map)
        {
            foreach (double element in this)
            {
                yield return map(element);
            }
        }
        public virtual IEnumerable<T> Map<T>(Func<double, T> map, int start)
        {
            for (int i = start; this.IsInfinite || (!this.IsInfinite && i < this.count); i++)
            {
                yield return map(this.GetElement(i));
            }
        }
        public virtual IEnumerable<T> Map<T>(Func<double, T> map, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return map(this.GetElement(i));
            }
        }
        public virtual double Sum()
        {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            double _sum = 0;

            foreach (double element in this)
                _sum += element;
            return _sum;
        }
        public virtual double Sum(Func<double, bool> predicate) {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            double _sum = 0;

            foreach (double element in this)
            {
                if(predicate(element))
                    _sum += element;
            }
                
            return _sum;
        }
        public virtual T FoldLeft<T>(Func<T, double, T> fold)
        {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            T acc = default(T);

            foreach (double element in this)
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual T FoldLeft<T>(Func<T, double, T> fold, int start)
        {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            T acc = default(T);
            double element = this.GetElement(start);

            for (int i = start; i < this.count; i++, element = this.GetElement(i))
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual T FoldLeft<T>(Func<T, double, T> fold, int start, int end)
        {
            T acc = default(T);
            double element = this.GetElement(start);

            for (int i = start; i <= end; i++, element = this.GetElement(i))
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual T FoldRight<T>(Func<T, double, T> fold) {
            if (this.IsInfinite)
                throw new InvalidOperationException("This is an infinite progression");

            T acc = default(T);
            double element = this.Last().Value;

            for (int i = this.count.Value -1; i >= 0; i--, element = this.GetElement(i))
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual T FoldRight<T>(Func<T, double, T> fold, int end)
        {
            T acc = default(T);
            double element = this.GetElement(end);

            for (int i = end; i >= 0; i--, element = this.GetElement(i))
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual T FoldRight<T>(Func<T, double, T> fold, int end, int start)
        {
            T acc = default(T);
            double element = this.GetElement(end);

            for (int i = end; i >= start; i--, element = this.GetElement(i))
            {
                acc = fold(acc, element);
            }
            return acc;
        }
        public virtual IEnumerable<double> Where(Func<double, bool> predicate)
        {
            double pivote = 0;

            for (int i = 0; (this.IsInfinite || (!this.IsInfinite && i < this.count)); i++)
            {
                pivote = this.GetElement(i);
                if (predicate(pivote))
                    yield return pivote;
            }
        }

        public virtual IEnumerable<double> Where(Func<double, int, bool> predicate)
        {
            double pivote = 0;

            for (int i = 0; (this.IsInfinite || (!this.IsInfinite && i < this.count)); i++)
            {
                pivote = this.GetElement(i);
                if (predicate(pivote, i))
                    yield return pivote;
            }
        }
        #endregion
    }
}
