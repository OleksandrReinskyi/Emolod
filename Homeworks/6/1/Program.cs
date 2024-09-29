using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _1
{
    class Computer
    {
        public MotherBoard MotherBoard = null;
        public PowerSupply PowerSupply = null;
        public Computer(MotherBoard motherBoard, PowerSupply powerSupply)
        {
            MotherBoard = motherBoard;
            PowerSupply = powerSupply;
        }
        public Computer() { }
    }

    abstract class ComputerComponent
    {
        public static int ComponentIdCount = 0;
        public int Id;

        public string Name = String.Empty;
        public float Cost = 0;


        public ComputerComponent(string name, float cost)
        {
            this.Name = name;
            this.Cost = cost;
            this.Id = ComponentIdCount++;
        }
    }

    class CPU : ComputerComponent
    {
        public float Frequency = 0;

        public CPU(string name, float cost, float frequency) : base(name, cost)
        {
            this.Frequency = frequency;
        }
    }
    class RAM : ComputerComponent
    {
        public float Amount = 0;

        public RAM(string name, float cost, float amount) : base(name, cost)
        {
            this.Amount = amount;
        }
    }
    class GPU : ComputerComponent
    {
        public float Amount = 0;

        public GPU(string name, float cost, float amount) : base(name, cost)
        {
            this.Amount = amount;
        }
    }
    class SSD : ComputerComponent
    {
        public float Amount = 0;

        public SSD(string name, float cost, float amount) : base(name, cost)
        {
            this.Amount = amount;
        }
    }
    class PowerSupply : ComputerComponent
    {
        public float Power = 0;

        public PowerSupply(string name, float cost, float power) : base(name, cost)
        {
            this.Power = power;
        }
    }


    class MotherBoard : ComputerComponent
    {
        public CPU CPU = null;
        public GPU GPU = null;
        private Dictionary<int, RAM> RAMs = new Dictionary<int, RAM>();
        private Dictionary<int, SSD> SSDs = new Dictionary<int, SSD>();

        public void AddSSD(SSD ssd)
        {
            if (SSDs.Count == 4)
            {
                throw new PortsExceededException("SSD");
            }
            SSDs.Add(ssd.Id, ssd);
        }
        public void RemoveSSD(int id)
        {
            if (!SSDs.ContainsKey(id))
            {
                throw new ComponentNullException("SSD");
            }
            SSDs.Remove(id);
        }

        public void RemoveRAM(int id)
        {
            if (!RAMs.ContainsKey(id))
            {
                throw new ComponentNullException("RAM");
            }
            RAMs.Remove(id);
        }

        public void AddRAM(RAM ram)
        {
            if (RAMs.Count == 2)
            {
                throw new PortsExceededException("RAM");
            }
            RAMs.Add(ram.Id, ram);
        }

        public MotherBoard(string name,float cost) : base(name, cost)
        {
        }
    }

    class ComponentNullException : Exception
    {
        public ComponentNullException(string message):base($"The specified {message} doesn't exist!") { }
    }
    class PortsExceededException:Exception
    {
        public PortsExceededException(string message) : base($"The available ports number for {message} was exceeded!") { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PowerSupply power = new PowerSupply("PowerSupply", 100, 1500);

                CPU cpu = new CPU("CPU", 200, 200);
                RAM ram1 = new RAM("RAM1", 200, 8);
                RAM ram2 = new RAM("RAM2", 200, 16);
                SSD ssd1 = new SSD("SDD1", 500, 512);
                SSD ssd2 = new SSD("SDD2", 500, 512);
                GPU gpu = new GPU("GPU", 1000, 2048);

                MotherBoard motherBoard = new MotherBoard("MotherBoard", 200);
                motherBoard.CPU = cpu;
                motherBoard.GPU = gpu;

                motherBoard.AddSSD(ssd1);
                motherBoard.AddSSD(ssd2);

                motherBoard.AddRAM(ram1);
                motherBoard.AddRAM(ram2);

                Computer computer = new Computer(motherBoard, power);
            }
            catch (Exception e) {
                Console.WriteLine("Error: "+e.Message);
            }


        }
    }
 }

