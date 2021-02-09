using System;

namespace Encapsulation
{
    //Access modifiers:
    //1) public: No restrictions
    //2) internal: Limited to current assembly
    //3) protected: Limited to the containing class and derived classes
    //4) protected internal: Limited to current assembly or derived types
    //5) private: limited to containing type

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to view Using Private method(Line 87 to 99)");
            Console.WriteLine("Press 2 to run Using Protected and Private method(Line 38 to 66)");
            Console.WriteLine("Press 3 to run Using Internal method(Line 74 to 82)");
            Console.WriteLine("Press 4 to run Using Properties method(Line 108 to 121)");
            Console.WriteLine("Go check out my Using Inheritance and Interfaces method(Line 125 to 146) in code");

            switch(Console.ReadLine()){
                case "1": {
                    Accessibility a = new Accessibility();
                    a.MyProperty = "Private value changed";
                    Console.WriteLine(a.MyProperty);
                    break;
                }
                case "2": {
                    Derived d = new Derived();
                    d.MyDerivedMethod();
                    break;
                }
                case "3": {
                    MyInternalClass i = new MyInternalClass();
                    i.MyMethod();
                    break;
                }
                case "4": {
                    Person p = new Person();
                    p.FirstName = "John";
                    Console.WriteLine("Propery value changed to {0}!", p.FirstName);
                    break;
                }
                default: {
                    Console.WriteLine("Entered value does not associate with any of the provided options!");
                    break;
                }
            }
        }

        //Protected
        public class Base {
            private int _privateField = 42;
            protected int _protectedField = 42;

            private void MyPrivateMethod() {
                Console.WriteLine("Private method accessed!");
             }
            protected void MyProtectedMethod() {
                Console.WriteLine("Protected method accessed!");
             }
        }

        public class Derived : Base {
            public void MyDerivedMethod(){
                //Not ok, this will generate compile error
                // _privateField = 41; 
                // Console.WriteLine("_privateField changed from 42 to {0}!", _protectedField);

                //ok, protected fields can be accessed
                _protectedField = 43;
                Console.WriteLine("_protectedField changed from 42 to {0}!", _protectedField);

                //Not ok, this will generate compile error
                // MyPrivateMethod(); 

                //ok, protected fields can be accessed
                MyProtectedMethod();
            }
        }

        //Internal
        //To make internal types visible to other assemblies:
        //[assembly:InternalsVisibleTo("OtherAssembly1")]
        //[assembly:InternalsVisibleTo("OtherAssembly2")]
        internal class MyInternalClass {
            public void MyMethod(){
                Console.WriteLine("Internal method accessed!");
            }
        }

        //Private
        //Changing private field without users knowing
        public class Accessibility {

            //Initialization code and error checking omitted
            private string[] _myField = new string[1];

            public string MyProperty {
                get { 
                    return _myField[0]; 
                }
                set { 
                    _myField[0] = value; 
                }
            }
        }

        //Properties
        //Get Set values
        class Person 
        {
            private string _firstName;

            public string FirstName { 
                get { return _firstName; } 
                set { 
                    if(string.IsNullOrWhiteSpace(value))
                        throw new ArgumentNullException();
                    _firstName = value; 
                    }
                }
        }

        //Interfaces and Inheritance
        public interface ILeft
        {
             void Move();
        }
        internal interface IRight
        {
             void Move();
        }
        
        class MoveableObject : ILeft, IRight
        {
            void ILeft.Move()
            {
                Console.WriteLine("Left moved!");
            }
            void IRight.Move()
            {
                Console.WriteLine("Right moved!");
            }
        }
    }
}
