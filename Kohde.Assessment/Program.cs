using Kohde.Assessment.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            Human human = new Human("John", 35, "M");
            Dog dog = new Dog("Walter", 7, "Epol");
            Cat cat = new Cat("Snowball", 35, "Whiskers");

            List<Mammal> mammals = new List<Mammal>
            {
                human,
                dog,
                cat
            };

            foreach (Mammal m in mammals)
            {
                Console.WriteLine(m.GetDetails());
            }

            #endregion

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            #region Assessment C

            // correct the following LINQ statement found in their respective methods
            var numbers = new List<int>()
            {
                1, 4, 5, 9, 11, 15, 20, 27, 34, 55 // you may not change the numbers
            };
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
            Dog bulldog = null;
            using (bulldog as IDisposable)
            {
                //do suff
                
                //even if there are exceptions,
                //the using statement block ensures that the object is still disposed
                //can also have try catch inside using statement to explicitely catch exceptions
            }           

            #endregion

            #region Assessment E

            DisposeSomeObject();

            #endregion

            #region Assessment F

            // # SECTION A #
            // by making use of generics improve the implementation of the following methods
            // output must still render as: Name: [name] Age: [age]
            // THE METHOD THAT YOU CREATE MUST BE STATIC AND DECLARED IN THE PROGRAM CLASS
            // NB!! PLEASE NAME THE METHOD: ShowSomeMammalInformation
            
            //This could have been done in a foreach, but I think the reason was only to
            //demonstrate the use of a generic method for different objecs
            ShowSomeMammalInformation(human);
            ShowSomeMammalInformation(dog);
            ShowSomeMammalInformation(cat);


            // # SECTION B #
            // BY MAKING USE OF REFLECTION (amongst other things):
            //      => create a method so that the below code snippet will work:
            //      => place a constraint on the new method, so that a new instance will be created when 'dog' is null
            //      => thus is dog = null, the method should create a new instance an not fail

            // UNCOMMENT THE FOLLOWING PIECE OF CODE - IT WILL CAUSE A COMPILER ERROR - BECAUSE YOU HAVE TO CREATE THE METHOD

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
            foreach (var vowel in abc.SelectOnlyVowels())
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

            var foo = dogs.CustomWhere(x => x.Age > 6 && x.Name.SelectOnlyVowels().Any());

            // < DOGS REQUIRED OUTPUT =>
            //      Name: Max Age: 8

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


            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        #region Assessment B Method

        public static void PerformanceTest()
        {
            //String builder is faster as it is not immutable like a string, i.e. it does not have to be recreated everytime it is changed.
            StringBuilder someLongDataString = new StringBuilder();
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);
            someLongDataString.Append(source);

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++)
            {
                someLongDataString.Append(source);
            }
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE
            //return FirstOrDefault, because the list might be empty
            var first = numbers.Where(x => x % 2 == 0).FirstOrDefault();
            return first;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT
            //return FirstOrDefault, because the list might be empty 
            //can return SingleOrDefault if an error should rather be thrown
            var first = stringList.Where(x => x.IndexOf("a") != -1).FirstOrDefault();
            return first;
        }

        #endregion

        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method

            //by wrapping in "using" statement it adds better exception handling
            //and will also call Dispose even if there was an exception.
            using (var disposableObject = new DisposableObject())
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
                return disposableObject;
            }

        }

        #endregion

        #region Assessment F Methods        

        /*
         * Generic method to call GetDetails from any mammal
         * Could be even more generic for any class, then restriction should be on 'class' and not 'Mammal' 
         * Then one would have to check if the object contains the getdetails method with reflection and call it
         * else it should log a default output
         */
        public static void ShowSomeMammalInformation<T>(T mammal) where T : Mammal
        {
            mammal.GetDetails();
        }

        /*
         * GenericTester function takes a generic Func delegate and object on which to call the delegate as input
         * TOutType => the generic return type specified in the delegate
         * TClassType => the type of the input to the delegate
         * Contraints on TClassType => any class and that it must contain a public parameterless constructor         * 
         */
        public static TOutType GenericTester<TClassType, TOutType>(Func<TClassType, TOutType> func, TClassType obj) where TClassType : class, new()
        {
            //If the input obj is null, then create a new instance of the output type given in the delegate function
            if (obj == null)
            {
                //Create a new instance of the TClassType by using reflection (i.e. get type at runtime) and set it to obj
                obj = Activator.CreateInstance<TClassType>(); ;

            }
            //return the result of the function that was evaluated with the input parameter
            return func(obj);
        }

        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException)
            {
                //If 'throw e' is used here it basically throws the exception from this point.
                //Just using 'throw' keeps the stack trace intact (passes the exception along) when rethrowing exceptions.
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

            //Get method by using method name
            var method = typeof(Program).GetMethod("DisplaySomeStuff");
            //Make generic method and Substitute type for type arguments
            var generic = method.MakeGenericMethod(typeof(string));
            //Create some random string argument
            var args = new[] { "some string" };
            //return the value after the generic method was invoked
            return (string)generic.Invoke(null, args);
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

            //Get a container instance 
            var container = Ioc.Container;
            //register the DeviceProcessor with service as IDeviceProcessor (will throw exception if service has already been registered)
            container.Register<IDeviceProcessor, DeviceProcessor>();
            //register the SamsungDevice with service as IDevice (will throw exception if service has already been registered)
            container.Register<IDevice, SamsungDevice>();

            //// 2. resolve the IDeviceProcessor service to get an instance of DeviceProcessor           
            var deviceProcessor = container.Resolve<IDeviceProcessor>();
            //// call the GetDevicePrice method
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Dungeon Methods

        //IEnumerable<char> is a generic collection
        //IEnumerable<char> is used here instead of string, since we know we will be iterating through each element of the input.
        //By using IEnumerable<char> it increases performance 
        public static string SelectOnlyVowels(this IEnumerable<char> str)
        {
            //List to store chars to match against                         
            List<char> vowels = new List<char>() { 'a', 'e', 'o', 'u', 'i' };
            //return chars that are found in the list above and join the result in a string
            return string.Join("", str.Where(x => vowels.Contains(x)));
        }

        /*
         * To pass the InvokeLvlB2ExtensionMethod test
         */
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            //Iterate through each element of source
            foreach (var item in source)
            {
                //check if the item should be returned, i.e. if it passes the lambda expression provided
                if (func(item))
                {
                    //Below is just to print the result, but is not required
                    Type type = typeof(T);
                    MethodInfo method = type.GetMethod("GetDetails");
                    var result = method.Invoke(item, null);
                    Console.WriteLine(result);

                    //yield return is used to return a collection/sequence of values
                    yield return item;
                }
            }
        }

        /*
         * To pass the InvokeLvlB1ExtensionMethod test
         */
        //public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, System.Linq.Expressions.Expression<Func<T, bool>> func)
        //{
        //    //compile the expression tree into callable code
        //    Func<T, bool> compiledDelegate = func.Compile();

        //    //iterate through each element of source
        //    foreach (var element in source)
        //    {
        //        //check if the item should be returned, i.e. if it passes the lambda expression provided
        //        if (compiledDelegate(element))
        //        {
        //            //Below is just to print the result, but is not required
        //            Type type = typeof(T);
        //            MethodInfo method = type.GetMethod("GetDetails");
        //            var result = method.Invoke(element, null);
        //            Console.WriteLine(result);

        //            //yield return is used to return a collection/sequence of values
        //            yield return element;
        //        }
        //    }
        //}

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
