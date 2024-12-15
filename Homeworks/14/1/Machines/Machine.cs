using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.States;

namespace _1.Machines
{
    public enum WashingProgram
    {
        quickWash,
        dry,
        autoClean,
        longWash
    }
    public abstract class Machine
    {
        public IState state = new Idle();
        public IState prevState = null;
        public int id;
        static int idCounter = 0;
        public int height;
        public int width;
        public Dictionary<WashingProgram, float> programDuration;
        public void ChangeState(IState state)
        {
            Console.WriteLine($"Machine {this.id} changed state from {this.state} to {state}");
            this.prevState = this.state;
            this.state = state;
            state.setContext( this );
            state.Handle();
        }
       

        public Machine(int height, int width, Dictionary<WashingProgram,float> programDuration)
        {
            this.height = height;
            this.width = width;
            this.id = idCounter++;
            this.programDuration = programDuration;
        }
    }

    public class VerticalMachine: Machine
    {
        public VerticalMachine(int height, int width, Dictionary<WashingProgram, float> programDuration) : base(height, width, programDuration) { }
    }
    public class HorizontalMachine : Machine
    {
        public HorizontalMachine(int height, int width, Dictionary<WashingProgram, float> programDuration) : base(height, width, programDuration) { }
    }
}
