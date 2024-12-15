using _1.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Factories
{
    public abstract class Factory 
    {
        public abstract Machine Create();
    }

    public class HorizontalMachineFactory : Factory
    {
        public Dictionary<WashingProgram, float> programLength = new Dictionary<WashingProgram, float>(){ { WashingProgram.quickWash,10000},{ WashingProgram.autoClean,15000},{ WashingProgram.dry,5000} };
        public override Machine Create()
        {
            return new HorizontalMachine(50, 100, programLength);
        }
    }

    public class VerticalMachineFactory : Factory
    {
        public Dictionary<WashingProgram, float> programLength = new Dictionary<WashingProgram, float>() { { WashingProgram.longWash, 20000 }, { WashingProgram.autoClean, 15000 }, { WashingProgram.dry, 5000 } };
        public override Machine Create()
        {
            return new VerticalMachine(100, 50, programLength);
        }
    }
}
