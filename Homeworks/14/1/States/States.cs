using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using _1.Machines;

namespace _1.States
{
     public interface IState
    {
        void Handle();
        void setContext(Machine machine);
    }

    public abstract class AbstractState: IState
    {
        public Machine context = null;
        public abstract void Handle();
        public void setContext(Machine machine)
        {
            this.context = machine;
        }
    }

    public class Work : AbstractState
    {
        public WashingProgram program;
        public float workingTime = 0;
        public Work(WashingProgram program) : base()
        {
            this.program = program;
        }

        public Work() { }

        public override async void Handle()
        {
            if(this.context.prevState is Stop)
            {
                workingTime = ((Stop)(this.context.prevState)).duration;
                program = ((Stop)(this.context.prevState)).program;
            }
            Console.WriteLine("Work started...");
            while (workingTime < context.programDuration[program])
            {
                await Task.Delay(1000);
                if (this.context.state is Stop) 
                {
                    Console.WriteLine("State changed, stopping Work.Handle");
                    break;
                }


                workingTime += 1000;
                Console.WriteLine($"Working... Time elapsed: {workingTime}");
            }

            if(workingTime == context.programDuration[program])
            {
                this.context.ChangeState(new Idle());
            }
        }
    }

    public class Idle : AbstractState
    {
        public override async void Handle() {
            await Task.Delay(10000);
            if (this.context.state is Idle)
            {
                this.context.ChangeState(new Off());
            }
        }
 
    }

    public class Off : AbstractState
    {
        public override void Handle()
        {

        }
    }

    public class Stop : AbstractState
    {
        public Work prevWorkState;
        public float duration;
        public WashingProgram program;

        public override void Handle()
        {
            if(prevWorkState is Work || prevWorkState is null)
            {
                this.prevWorkState = (Work)(this.context.prevState);
                this.duration = prevWorkState.workingTime;
                this.program = prevWorkState.program;
            }
            else
            {
                Console.WriteLine("Error: machine state can be changed to Stop only if it was previously working!");
                this.context.ChangeState(new Idle());
            }
        }
    }
}
