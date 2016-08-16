using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HList.Progression
{
    public interface IMathProgression: IEnumerable<double>
    {
        double GetElement(int index);
        int GetIndexOf(double element);
        int? Count();
        bool Contains(double element);
        double First();
        double? First(Func<double, bool> predicate);
        double? Last();
        double? Last(Func<double, bool> predicate);
        double Sum();
        double Sum(Func<double, bool> predicate);
        T FoldLeft<T>(Func<T, double, T> fold);
        T FoldLeft<T>(Func<T, double, T> fold, int start);
        T FoldLeft<T>(Func<T, double, T> fold, int start, int end);
        T FoldRight<T>(Func<T, double, T> fold);
        T FoldRight<T>(Func<T, double, T> fold, int end);
        T FoldRight<T>(Func<T, double, T> fold, int end, int start);
        IEnumerable<T> Map<T>(Func<double, T> map);
        IEnumerable<T> Map<T>(Func<double, T> map, int start);
        IEnumerable<T> Map<T>(Func<double, T> map, int start, int end);
        IEnumerable<double> Where(Func<double, bool> predicate);
        IEnumerable<double> Where(Func<double, int, bool> predicate);
    }
    public interface IMathProgression<T> : IMathProgression where T : IMathProgression
    {
        T Take(int count);
        T Take(int start, int count);
        T TakeWhile(Func<double, bool> predicate);
    }
}
