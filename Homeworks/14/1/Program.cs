using _1.Factories;
using _1.Machines;
using _1.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*



./Entities

enum WashingProgram{
    quickWash,
    dry,
    autoClean,
    longWash
} 



 abstract WashingMachine
    - WashingMachine(height,width,state, programs)
    - State state;
    - int id;
    - int height
    - int width
    - float workingTime = 0
    - dictionary programs
    - public void ChangeState(State state)
    -- Console.WriteLine(Machine {this.name} changed state from {this.state} to {state})
    - async MachineIdle
    -- await Task.Delay(10000)
    -- if _context.state is Idle 
    --- _context.ChangeState(Off)

class VerticalMachine: WashingMachine
class HorizontalMachine: WashingMachine

./States

Helpers


interface State
    -context
    -execute
    -- If else chain


class Work
    - execute(WashingProgram)
    -- while (context.workingTime<this.programs[WashingProgram]) // як додати функціонал зупинки?
    --- wait(1000, new Action()=>{context.workingTime++;})
    --- 
    --this._context.ChangeState(new Idle())

class Idle 
    -execute
    -- context.workingTime = 0;
    --context.machineIdle()


class Off
    -execute...


./Factories

abstract IMachineFactory 
    - create
    - IdCounter = 0;

HorizontalMachineFactory:IFactory
    - Dictionary WashingProgram/float Length;//Long,Dry,clean

    - Create
    -- return new HorizontalMachine(100,50,new Off,programs,id)

VerticallMachineFactory:IFactory
    - Dictionary WashingProgram/float Length; //Quick,Dry, clean

    - Create
    -- return new VerticallMachine(100,50,new Off,programs,id)

 */


/*-------------------------------------------------------------------
 Питання
1) Як в даному випадку оптимізувати можливість зупинки прання?

---------------------------------------------------------------------
 */

namespace _1
{
    
    internal class Program
    {
        static public async void StopDelay(Machine machine, int duration)
        {
            await Task.Delay(duration);
            machine.ChangeState(new Stop());
        }

        static public async void ResumeDelay(Machine machine, int duration)
        {
            await Task.Delay(duration);
            machine.ChangeState(new Work());
        }

        static void Main(string[] args)
        {
            HorizontalMachineFactory factory = new HorizontalMachineFactory();
            HorizontalMachine machine = (HorizontalMachine)factory.Create();

            machine.ChangeState(new Idle());

            machine.ChangeState(new Work(WashingProgram.quickWash));
            StopDelay(machine, 3000);
            ResumeDelay(machine, 6000);

            Console.ReadLine();
        }
    }
}
