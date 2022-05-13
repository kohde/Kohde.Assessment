using Kohde.Assessment.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            //Console.ReadKey();

            #region Assessment A

            // the below class declarations looks like a 1st year student developed it
            // NOTE: this includes the class declarations as well
            // IMPROVE THE ARCHITECTURE 


            //Create all Required Instances of Parties that are used in Assessment A and F
            Human human = new Human(Name: "John", Age: 35, Gender: "M");
            Dog dog = new Dog(Name: "Walter", Age: 7, Food: "Epol");
            Cat cat = new Cat(Name: "Snowball", Age: 35, Food: "Whiskers");

            //Combine All Different Parties.
            List<PartyDetailsBase> parties = new List<PartyDetailsBase>() { human , dog , cat };

            //Print All Combined Parties to the console
            foreach (PartyDetailsBase part in parties)
            {
                Console.WriteLine(part.GetDetails());
            }

            #endregion

            //Console.ReadKey();

            #region Assessment B

            // you'll notice the following piece of code takes an
            // age to execute - CORRECT THIS
            // IT MUST EXECUTE IN UNDER A SECOND
            PerformanceTest();

            #endregion

            //Console.ReadKey();

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

            //Console.ReadKey();

            #region Assessment D

            // there are multiple corrections required!!
            // correct the following statement(s)
            try
            {
                //Instantiate the Dog Class which inherits the IDisposable interface.
                Dog bulldog = new Dog();
                var disposeDog = (IDisposable) bulldog;
                disposeDog.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion

            //Console.ReadKey();

            #region Assessment E

            DisposeSomeObject();

            #endregion

            //Console.ReadKey();

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

            string a = Program.GenericTester(walter => walter.GetDetails(), dog);
            Console.WriteLine("Result A: {0}", a);
            int b = Program.GenericTester(snowball => snowball.Age, cat);
            Console.WriteLine("Result B: {0}", b);

            #endregion

            //Console.ReadKey();

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

            //Console.ReadKey();

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

            //Console.ReadKey();

            #region IoC / DI

            // everything can be viewed in this method....
            PerformIoCActions();

            #endregion

            //Console.ReadKey();

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
            var someLongDataString = "";
            const int sLen = 30, loops = 500000; // YOU MAY NOT CHANGE THE NUMBER OF LOOPS IN ANY WAY !!
            var source = new string('X', sLen);

            //Use the Stringbuilder to manage string manipulation :
            System.Text.StringBuilder bob = new System.Text.StringBuilder();

            // DO NOT CHANGE THE ACTUAL FOR LOOP IN ANY WAY !!
            // in other words, you may not change: for (INITIALIZATION; CONDITION; INCREMENT/DECREMENT)
            for (var i = 0; i < loops; i++) 
            {
                bob.Append(source);
            }

            //Store String value in variable used before.
            someLongDataString = bob.ToString();
        }

        #endregion

        #region Assessment C Method

        public static int GetFirstEvenValue(List<int> numbers)
        {
            // RETURN THE FIRST EVEN NUMBER IN THE SEQUENCE

            //First query where the even numbers exists, then take the first or default item.
            var first = numbers.Where(x => x % 2 == 0).FirstOrDefault();
            return first;
        }

        public static string GetSingleStringValue(List<string> stringList)
        {
            // THE OUTPUT MUST RENDER THE FIRST ITEM THAT CONTAINS AN 'a' INSIDE OF IT

            //Query collection to only return items containing the letter 'a'.
            //Then make sure to return the first or default item.
            var first = stringList.Where(x => x.ToLower().Contains("a")).FirstOrDefault();

            return first;
        }

        #endregion
        
        #region Assessment E Method

        public static DisposableObject DisposeSomeObject()
        {
            // IMPROVE THE FOLLOWING PIECE OF CODE
            // as well as the PerformSomeLongRunningOperation method
            var disposableObject = new DisposableObject();
            try
            {
                disposableObject.PerformSomeLongRunningOperation();
                disposableObject.RaiseEvent("raised event");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                disposableObject.Dispose();
            }

            return disposableObject;
        }

        #endregion

        #region Assessment F Methods

        public static void ShowSomeHumanInformation(Human human)
        {
            Console.WriteLine("Name:" + human.Name + " Age: " + human.Age);
        }

        public static void ShowSomeDogInformation(Dog dog)
        {
            Console.WriteLine("Name:" + dog.Name + " Age: " + dog.Age);
        }

        public static void ShowSomeCatInformation(Cat cat)
        {
            Console.WriteLine("Name:" + cat.Name + " Age: " + cat.Age);
        }

        public static void ShowSomeMammalInformation<TheType>(TheType value)
        {
            if (value == null)
                return;

            //Get the Type of the generic type
            Type OurObjectType = typeof(TheType);

            //Get the properties of the generic type
            List<System.Reflection.PropertyInfo> OurObjectPropertyInfos = OurObjectType.GetProperties().ToList();

            string NameValue = null;
            string AgeValue = null;

            //loop through the properties, then when we come accross property Name and Age we get those values to print to the console.
            foreach (System.Reflection.PropertyInfo propertyInfo in OurObjectPropertyInfos)
            {
                object Value = propertyInfo.GetValue(value);
                string StringValue = Value?.ToString();

                if (string.Equals(propertyInfo.Name, "Name", StringComparison.OrdinalIgnoreCase))
                    NameValue = StringValue;

                if (string.Equals(propertyInfo.Name, "Age", StringComparison.OrdinalIgnoreCase))
                    AgeValue = StringValue;

            }

            Console.WriteLine($"Name: {NameValue} Age: {AgeValue}");
        }


        public static dynamic GenericTester<YourType, ReturnType>(Func<YourType, ReturnType> query , YourType value) where YourType : class ,  new()
        {
            if (value == null)
                value = new YourType();

            object ReturnValue = query.Invoke(value);
            return ReturnValue;
        }


        #endregion

        #region Assessment G Methods

        public static void CatchAndRethrowExplicitly()
        {
            try
            {
                ThrowException();
            }
            catch (ArithmeticException e)
            {
                //Rethrow the existing exception. Keep the Original Exception in the stack trace.
                Console.WriteLine($"Error Log : {e.Message}");
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

            //Using reflection get a Method by the name "DisplaySomeStuff"
            var method = typeof(Program).GetMethod("DisplaySomeStuff");
            //This is the parameters we expect the method to take in
            Type[] MethodArguments = { typeof(string) };
            var GenericMethod = method.MakeGenericMethod(MethodArguments);

            //Call the method and get the resuls so we can return as string.
            var MethodResultValue = GenericMethod.Invoke(typeof(Program), new object[] { "" });

            return MethodResultValue?.ToString();
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

            //Dependancy Injection Configuration, here we configure which implementations to use for which interfaces when required using this IOC container.
            IContainer DI_Container = Ioc.Container;
            DI_Container.Register<IDevice, SamsungDevice>();
            DI_Container.Register<IDeviceProcessor, DeviceProcessor>();

            // 2. resolve the IDeviceProcessor

            // use the IOC container to resolve our implementation for interface IDeviceProcessor
            IDeviceProcessor deviceProcessor = DI_Container.Resolve<IDeviceProcessor>();

            // call the GetDevicePrice method from interface IDeviceProcessor
            Console.WriteLine(deviceProcessor.GetDevicePrice());
        }

        #endregion

        #region Dungeon 

        /// <summary>
        /// Extension method for type string to select only vowels.
        /// </summary>
        public static IEnumerable<char> SelectOnlyVowels(this string value)
        {
            //List the Vowels we are going to look for :
            List<string> vowels = new List<string>() 
            {
                "a", "e", "i", "o", "u"
            };

            //Only Return the Vowels by 
            List<char> charactersToReturn = new List<char>();
            
            foreach(char c in value)
            {
                //Check if the vowel exists, then add to collection.
                if(vowels.FirstOrDefault(s =>  string.Equals($"{c}", s, StringComparison.OrdinalIgnoreCase)) != null)
                    charactersToReturn.Add(c);
            }

            return charactersToReturn;
        }



        /// <summary>
        /// Generic method that should take in lamda query and return the results it resolves into.
        /// </summary>
        public static List<T> CustomWhere<T>(this IEnumerable<T> value, Expression<Func<T, bool>> lamdaQuery)
        {
            try
            {
                //Compile the Lambda Expression
                Func<T, bool> result = lamdaQuery.Compile();

                //our collection to return in the end.
                List<T> resultList = new List<T>();

                //Loop through each item of the generic collection type
                foreach(T item in value)
                {
                    //run the function declared in the lamda expression to see if its boolean value returns true. If True return value.
                    var valueResult = result(item);
                    if (valueResult)
                        resultList.Add(item);
                }

                return resultList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return default;
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
