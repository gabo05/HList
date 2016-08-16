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

        #endregion
        #region Properties
        public double Ratio { get; protected set; }
        #endregion
        public override double GetElement(int index)
        {
            throw new NotImplementedException();
        }

        public override int GetIndexOf(double element)
        {
            throw new NotImplementedException();
        }

        public override GeometricProgression Take(int count)
        {
            throw new NotImplementedException();
        }

        public override GeometricProgression Take(int start, int count)
        {
            throw new NotImplementedException();
        }

        public override GeometricProgression TakeWhile(Func<double, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
