using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior palladin = new Palladin();
            palladin = new FireSwordSpell(palladin);
            Console.WriteLine(palladin.Name);
            Console.WriteLine(palladin.GetMaxDamage());

            Console.WriteLine(new string('-', 25));

            Warrior barbarian = new Barbarian();
            barbarian = new PrimalRoar(barbarian);
            Console.WriteLine(barbarian.Name);
            Console.WriteLine(barbarian.GetMaxDamage());

            Console.WriteLine(new string ('-', 25));

            Warrior wildPalladin = new Barbarian();
            wildPalladin = new FireSwordSpell(wildPalladin);
            wildPalladin = new PrimalRoar(wildPalladin);
            Console.WriteLine(wildPalladin.Name);
            Console.WriteLine(wildPalladin.GetMaxDamage());
        }
    }
    //component
    abstract class Warrior
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public Warrior(string name, int damage)
        {
            this.Name = name;
            this.Damage = damage;
        }
        
        public abstract float GetMaxDamage();
    }
    //concrete component
    class Barbarian : Warrior
    {
        public Barbarian() : base("Barbarian", 15)
        { }
        public override float GetMaxDamage()
        {
            return this.Damage;
        }
    }
    //concrete component
    class Palladin : Warrior
    {
        public Palladin() : base("Palladin", 10)
        { }
        public override float GetMaxDamage()
        {
            return this.Damage;
        }
    }
    //decorator
    abstract class WarriorDecorator : Warrior
    {
        protected Warrior warrior;
        public WarriorDecorator(string name,int damage, Warrior warrior) : base(name,damage)
        {
            this.warrior = warrior;
        }
    }
    //concrete decorator
    class FireSwordSpell : WarriorDecorator
    {
        private int  _fireDamage = 5;
        public FireSwordSpell(Warrior warrior)
            : base(warrior.Name + " with sword on fire", warrior.Damage, warrior)
        { }

        public override float GetMaxDamage()
        {
            return warrior.GetMaxDamage() + _fireDamage;
        }
    }
    //concrete decorator
    class PrimalRoar : WarriorDecorator
    {
        private float _primalDamageCoefficient = 0.5f;
        public PrimalRoar(Warrior warrior)
            : base(warrior.Name + " is roaring right now", warrior.Damage, warrior)
        { }

        public override float GetMaxDamage()
        {
            return warrior.GetMaxDamage() + (warrior.GetMaxDamage() * _primalDamageCoefficient);
        }
    }
}