using Kohde.Assessment.Container;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kohde.Assessment
{
    // *** NOTE ***
    // ALL CHANGES MUST BE ACCOMPANIED BY COMMENTS 
    // PLEASE READ ALL COMMENTS / INSTRUCTIONS
    public static class Program
    {
        static void Main(string[] args)
        {
            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 

            /*
             * bcodendaal: 
             * 1) The class initialisation was changed to be simpler by allowing the attribute values to be passed through the constructor.
             * 2) Cat, Dog and Human share properties and method implementations. They are also all related and share a common concept as "mammals". 
             *    This makes the classes good candidates for inheritence with a base class of Mammal.
             */

            Human human = new Human("M", "John", 35);
            Console.WriteLine(human.GetDetails());

            Dog dog = new Dog("Epol", "Walter", 7);
            Console.WriteLine(dog.GetDetails());

            Cat cat = new Cat("Whiskers", "Snowball", 35);
            Console.WriteLine(cat.GetDetails());

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            /*
             * bcodendaal:
             * I was able to solve this problem without research, but I found a better solution to my first attempt after researching it a bit.
             * My initial thinking was that the += operation was the issue as it took too much memory, but I was not sure why.
             * So on my first iteration I created a List<string> collection and added the strings to it. At the end I did a String.Concat() for the list.
             * This worked, but I was not 100% sure why. What I learned after reasearching was that StringBuilder is an even better solution since it
             * creates a buffer of a specific length which allows memory to be allocated up front and does not need reallocation of memory for each loop.
             */
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };

            //bcodendaal: I left comments for this assessment in the methods.
            // the following method must return the first event number - as suggested by it's name
            var firstValue = GetFirstEvenValue(numbers);
            Console.WriteLine("First Number: " + firstValue);

            var strings = new List<string>()
            {
                "John", "Jane", "Sarah", "Pete", "Anna"
            };
            // the following method must return the first name which contains an 'a'
            var strValue = GetSingleStringValue(strings);
            Console.WriteLine("Single String: " + strValue);

            #endregion

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)
            try
            {
                /*
                 * bcodendaal:
                 * Instead of trying to cast the Dog to an IDisposable object I've let the Dog class inherit from IDisposable.            
                 * The Dog class now implements a Dispose method which will be invoked when the using statement ends.
                 * Dog was also never initialised. You would either require a null check or initialise the object like I did here.
                 */
                using (Dog bulldog = new Dog("Purina", "Woof", 1))
                {
                    //do something with your disposable class.
                    bulldog.GetDetails();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            #region Assessment E
            //bcodendaal: my comments are in the related class.
            DisposeSomeObject();

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            ShowSomeMammalInformation(human);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(cat);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

            //bcodendaal: I ended up having to research this problem extensively and still struggeled to get the return type to be either string or int.
            string a = Program.GenericTester(walter => walter.GetDetails(), dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);



            #endregion

            #region Assessment G

            // in the following statement, everything works fine
            // but, it has a huge flaw! 
            // correct the following piece of code
            try
            {
                CatchAndRethrowExplicitly();
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Implicitly specified:{0}{1}", Environment.NewLine, e.StackTrace);
            }

            #endregion            

            #region Assessment H

            try
            {
                // REFLECTION TEST .... NAVIGATE TO THE BELOW METHOD TO GET ALL THE INSTRUCTIONS
                CallMethodWithReflection();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion            

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            #region Bonus XP - Dungeon

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            const string abc = "asduqwezxc";
            foreach (var vowel in abc.selectonlyvowels())
            {
                Console.WriteLine("{0}", vowel);
            }

            // < REQUIRED OUTPUT => a u e

            // > UNCOMMENT THE CODE BELOW AND CREATE A METHOD SO THAT THE FOLLOWING CODE WILL WORK
            // > DECLARE ALL THE METHODS WITHIN THE PROGRAM CLASS !!
            // > DO NOT ALTER THE EXISTING CODE


            List<Dog> dogs = new List<Dog>
            {
                new Dog {Age = 8, Name = "Max"},
                new Dog {Age = 3, Name = "Rocky"},
                new Dog {Age = 9, Name = "XML"}
            };

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.selectonlyvowels().Any());

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8

            foreach (var result in foo)
            {
                Console.WriteLine(result.GetDetails());
            }
            List<Cat> cats = new List<Cat>
            {
                new Cat {Age = 1, Name = "Capri"},
                new Cat {Age = 8, Name = "Cara"},
                new Cat {Age = 3, Name = "Captain Hooks"}
            };

            var bar = cats.CustomWhere(x => x.Age <= 4);
            // < CATS REQUIRED OUTPUT =>
            //      Name: Capri Age: 1
            //      Name: Captain Hooks Age: 3

            foreach (var result in bar)
            {
                Console.WriteLine(result.GetDetails());
            }

            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method

        public static void PerformanceTest()
        {
            var someLongDataString = "";
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            //bcodendaal notes:
            //providing stringbuilder with a size helps improve performance because it does not have to dynamically grow the buffer.
            StringBuilder sb = new StringBuilder(sLen * loops);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++)
            {
                //bcodendaal notes:
                //sb.append is more performance than +=. Strings are immutable so each time you do += you create a new object which is inefficient. 
                // StringBuilder maintains a buffer for string concatenation which means you dont need to create/destoy objects all the time.
                sb.Append(source);
            }
            someLongDataString = sb.ToString();
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            // bcodendaal: Using FirstOrDefault is good practice because it will return a default value
            // if nothing is found which allows you to add conditions to check for nulls or empty values
            // instead of getting an error.
            var first = numbers.Where(x => x % 2 == 0).FirstOrDefault();
            return first;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            // bcodendaal:
            // Using FirstOrDefault is good practice because it will return a default value if nothing is
            // found which allows you to add conditions to check for nulls or empty values instead of getting an error.
            // I changes this to SingleOrDefault because the intention is to render the "First" item, not the "only" item.
            // Single() will give an error of a collection contains more than one value satisfying the condition.
            // If the intention of this method was to do that then I would have specified SingleOrDefault instead of FirstOrDefault.
            var first = stringList.Where(x => x.IndexOf("a") != -1).FirstOrDefault();
            return first;
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            /*
             * bcodendaal: 
             * 1) You can make use of the "using" statement and remove the try, finally since "using" already 
             *    includes the finally that will call "dispose" of the IDisposable object.
             * 2) Added code to the dispose functions to reset the values of the EventHandler object and counter variable.
             */

            using (DisposableObject disposableObject = new DisposableObject())
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                return disposableObject;
            }


        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeMammalInformation<T>(T mammal) where T : MammalBase
        {
            Console.WriteLine("Name:" + mammal.Name + " Age: " + mammal.Age);
        }

        public static T GenericTester<T, T2>(Func<T2, T> func, T2 mammal = default)
        {
            //bcodendaal: check if the dog was null (if you want to differenciate between dog and cat you need to do a typeoff(T2) == typeoff(Dog) check here.
            if (mammal == null)
                mammal = (T2)Activator.CreateInstance(typeof(T2), new object[] { "Purina", "Woof", 1 });

            var result = func.Invoke(mammal);
            return (T)Convert.ChangeType(result, typeof(T));
        }
        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            //bcodendaal: If you want to retain the stacktrace you need to use "throw" and not "throw ex".  "throw ex" is throwing a "new" exception from that point.
            catch (Exception)
            {
                throw;
            }
        }

        private static void ThrowException()
        {
            throw new ArithmeticException("illegal expression - was this picked up??");
        }

        #endregion

        #region Assessment H Methods

        public static string CallMethodWithReflection()
        {
            // BY MAKING USE OF ONLY REFLECTION
            // CALL THE FOLLOWING METHOD: DisplaySomeStuff [WHICH IN JUST BELOW THIS ONE]
            // AND RETURN THE STRING CONTENT

            // DO NOT CHANGE THE NAME, RETURN TYPE OR ANY IMPLEMENTATION OF THIS METHOD NOR THE BELOW METHOD
            /*
             * bcodendaal notes - 
             * I honestly had no idea how to sole this problem initially. I understand what reflection does, but had to research to find
             * a solution that worked.
             */
            MethodInfo result = Type.GetType("Kohde.Assessment.Program").GetMethod("DisplaySomeStuff");
            if (result != null)
                return result.MakeGenericMethod(typeof(string)).Invoke(null, new object[] { "test" }).ToString();
            return "";
        }

        public static string DisplaySomeStuff<T>(T toDisplay) where T : class
        {
            return string.Format("Here it is: {0}", toDisplay);
        }

        #endregion

        #region IoC / DI

        public static void PerformIoCActions()
        {
            /*  An very simple IoC / DI container has been created for you. All the code can be viewed in the Container folder.
             *  By making use of the classes provided, perform the following tasks:
             *  
             *  Two classes and two interfaces have been created for you, namely:
             *  
             *      - IDevice
             *      - SamsungDevice
             *      - IDeviceProcessor
             *      - DeviceProcessor
             * 
             *  The actual declarations can be view lower down in this file.
             *  
             *  The following needs to happen:
             *      
             *      1. register the interfaces with the respective classes
             *      2. resolve an instance of the IDeviceProcessor and call the GetDevicePrice method
             *      
             *  Some of the code below has been done, but you need to fill in the blanks
             */

            // 1. register the interfaces and classes
            // TODO: ???
            /*
             * bcodendaal Notes:
             * Here I want to register the an IDevice as type of SamsungDevice and IDeviceProcessor should be a DeviceProcessor.
             * This means that when the DeviceProcessor is resolved the container will automatically inject a new instance of SamsungDevice because it is a dependency 
             * of the DeviceProcessor.
             */
            Ioc.Container.Register<IDevice, SamsungDevice>();
            Ioc.Container.Register<IDeviceProcessor, DeviceProcessor>();
            // 2. resolve the IDeviceProcessor
            var deviceProcessor = Ioc.Container.Resolve<IDeviceProcessor>();
            // call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Bonus XP - Dungeon methods
        /*
         * bcodendaal notes:  
         * This is an extension method on "String".
         * It will loop through the string character by character and return a list of all the characters that are vowels.
         */
        static List<char> selectonlyvowels(this string str)
        {
            var vowels = new List<char>() { 'a', 'i', 'u', 'e', 'o' };
            var result = new List<char>();

            foreach (char character in str)
                if (vowels.Contains(character))
                    result.Add(character);

            return result;
        }

        /*
         * bcodendaal notes:  
         * This is an extension method on a generic List<T> which also allows to pass in a function with a boolean return value.
         */
        public static List<T> CustomWhere<T>(this List<T> list, Func<T, bool> function)
            where T : IPet
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                if (function.Invoke(item))
                    result.Add(item);
            }
            return result;
        }
        #endregion
    }

    public interface IDevice
    {
        string DeviceCode { get; }
    }

    public class SamsungDevice : IDevice
    {
        public string DeviceCode { get; private set; }

        public SamsungDevice()
        {
            this.DeviceCode = "Samsung";
        }
    }

    public interface IDeviceProcessor
    {
        double GetDevicePrice();
    }

    public class DeviceProcessor : IDeviceProcessor
    {
        protected IDevice Device { get; private set; }

        public DeviceProcessor(IDevice device)
        {
            this.Device = device;
        }

        public double GetDevicePrice()
        {
            // the actual implementation of this method does not matter....
            return this.Device.DeviceCode.Equals("Samsung") ? 12.95 : 19.95;
        }
    }
}
