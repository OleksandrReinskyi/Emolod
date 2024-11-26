using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2
{

    public enum ShieldTypes
    {
        WarDoor,
        Buckler,
        Round
    }

    public enum ArmourTypes
    {
        Light,
        Medium,
        Heavy
    }

    public enum WeaponTypes
    {
        Sword,
        Bow,
        Spear
    }

    public enum UnitTypes
    {
        Cavalry,
        Infantry,
        Archer
    }

    public enum HorseTypes
    {
        Basic,
        Enhanced
    }

    abstract public class Unit
    {
        public float health = 100;
        public float defence  = 0;
        public float attack = 0;
        public float moral = 50;

        public List<string> weapons = new List<string>();
        public string armour;
        public string shield;
        public string horse;

        public void showInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Health: {this.health}");
            stringBuilder.AppendLine($"Defence: {this.defence}");
            stringBuilder.AppendLine($"Attack: {this.attack}");
            stringBuilder.AppendLine($"Moral: {this.moral}");

            stringBuilder.AppendLine($"Armour: {this.armour}");
            stringBuilder.AppendLine($"Shield: {this.shield}");
            stringBuilder.AppendLine($"Horse: {this.horse}");
            stringBuilder.AppendLine($"Weapons: {String.Join(", ", this.weapons.ToArray())}");
            Console.WriteLine(stringBuilder.ToString());
        }
    }

    public class Archer : Unit
    {
        UnitTypes type = UnitTypes.Archer;
    }

    public class Cavalry : Unit
    {
        UnitTypes type = UnitTypes.Cavalry;
    }

    public class Infantry : Unit
    {
        UnitTypes type = UnitTypes.Infantry;
    }

    public abstract class UnitBuilder {

        private Unit unit;
        public UnitTypes type;
        public UnitBuilder(UnitTypes type)
        {
            reset();
        }

        public void SetType(UnitTypes type)
        {
            this.type = type;
        }

        public void setHealth(float health) {
            this.unit.health = health;
        }
        public void setDefence(float defence) {
            this.unit.defence = defence;
        }
        public void setAttack(float attack) {
            this.unit.attack = attack;
        }
        public void setMoral(float moral) {
            this.unit.moral = moral;
        }

        abstract public bool checkShield<T>(T shield);
        public void setShield<T>(T shield) {
            if (!checkShield(shield))
            {
                this.unit.shield = null;
                Console.WriteLine("This unit type cannot have a shield!");
            }
            else
            {
                this.unit.shield = shield.ToString();
            }
        }

        abstract public bool checkArmour<T>(T armour);
        public void setArmour<T>(T armour)
        {
            if (!checkArmour(armour))
            {
                Console.WriteLine("This unit type cannot have an armour!");
            }
            else
            {
                this.unit.armour = armour.ToString();
            }
        }

        abstract public bool checkWeapon<T>(T weapon);
        public void addWeapon<T>(T weapon)
        {
            if (!checkWeapon(weapon))
            {
                Console.WriteLine("This unit type cannot have that type of weapon!");
            }
            else
            {
                this.unit.weapons.Add(weapon.ToString());
            }
        }

        abstract public bool checkHorse();
        public void setHorse<T>(T horse)
        {
            if (!checkHorse())
            {
                Console.WriteLine("This unit type cannot have a horse!");
            }
            else
            {
                this.unit.horse = horse.ToString();
            }
        }

        public Unit getUnit()
        {
            Unit unit = this.unit;
            reset();
            return unit;
        }
        public void reset()
        {
            if(type == UnitTypes.Archer)
            {
                this.unit = new Archer();
            }else if (type == UnitTypes.Cavalry)
            {
                this.unit = new Cavalry();
            }
            else
            {
                this.unit = new Infantry();
            }
        }
    }

    public class ArcherBuilder : UnitBuilder
    {
        public ArcherBuilder(UnitTypes type) :base(type)
        {
            
        }
        public override bool checkShield<T>(T shield) 
        {
            return false;
        }
        public override bool checkArmour<T>(T armour)
        {
            if(!armour.Equals(ArmourTypes.Light))
            {
                return false;
            }
            return true;
        }
        public override bool checkWeapon<T>(T weapon)
        {
            if(!weapon.Equals(WeaponTypes.Bow))
            {
                return false;
            }
            return true;
        }
        public override bool checkHorse()
        {
            return false;
        }
    }
    public class CavalryBuilder: UnitBuilder // Як покращити цю схему із обмеженням вибору амуніції для певного юніта?
    {
        public CavalryBuilder(UnitTypes type) : base(type)
        {

        }
        public override bool checkShield<T>(T shield)
        {
            if (!shield.Equals(ShieldTypes.Buckler))
            {
                return false;
            }
            return true;
        }
        public override bool checkArmour<T>(T armour)
        {
            if (armour.Equals(ArmourTypes.Heavy))
            {
                return false;
            }
            return true;
        }
        public override bool checkWeapon<T>(T weapon)
        {
            if (weapon.Equals(WeaponTypes.Bow))
            {
                return false;
            }
            return true;
        }
        public override bool checkHorse()
        {
            return true;
        }
    }
    public class InfantryBuilder: UnitBuilder
    {
        public InfantryBuilder(UnitTypes type) : base(type)
        {

        }
        public override bool checkShield<T>(T shield)
        {
            return true;
        }
        public override bool checkArmour<T>(T armour)
        {
            return true;
        }
        public override bool checkWeapon<T>(T weapon)
        {
            if (weapon.Equals(WeaponTypes.Bow))
            {
                return false;
            }
            return true;
        }
        public override bool checkHorse()
        {
            return false;
        }
    }

    public class UnitDirector {
        
        public void buildArcher(ArcherBuilder builder)
        {
            builder.setHealth(75);
            builder.setDefence(25);
            builder.setAttack(125);
            builder.setMoral(100);

            builder.setShield(ShieldTypes.Round);
            builder.addWeapon(WeaponTypes.Bow);
            builder.setHorse(HorseTypes.Basic);
            builder.setArmour(ArmourTypes.Light);
        }
    
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Unit archer = new Archer();
            ArcherBuilder builder = new ArcherBuilder(UnitTypes.Archer);
            UnitDirector director = new UnitDirector();

            director.buildArcher(builder);
            archer = builder.getUnit();

            archer.showInfo();
        }
    }
}
