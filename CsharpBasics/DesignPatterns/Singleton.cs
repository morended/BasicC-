using System;

namespace CsharpBasics.DesignPatterns
{
    /*Only single instance of a Singleton class is created

         /*1. When to use the pattern? When not to?
         Singleton is used when we want single object with internal state that can be accessed gloablly
         Singleton can be created for shared resources like database, Cache ,Session, stateless FactoryClasses
         static classes can be created for global access, if it doesnot have to maintain state.
         If the object creation is heavy and consumes lot of memory, it is always good to create one object and keep it floating around, instead of creating multiple
         
         Donot use singleton when object is not unique and doesnot need a shared global state

    2. What are the tradeoffs of using the pattern?
    Strengths: 
        single global access that can be shared among classes.
        creating multiple heavy object for single class can be avoided
        lazy initialization
    Weakness:
         Testing Singleton classes are hard to unit test. Eg: public method() { ObjectFactory.GetInstance()} // this cannot be mocked
         A method in singleton class, cannot be stubbed as pure singleton class cannot be subclassed.
         Voilates Single Responsibility principle as it handles two responsibilities,making the class singleton, actual functionality of the class.

   3. Where have you seen this pattern used/abused in our systems?
      
       In oneExchange all the Singleton instances are created by the container and we use dependency injection to access the singleton instances.
       This way we are not voilating the single Responsiblity priniciple  as container takes care of object creation and the class is only responsible for its functionality

       some of Singletons used in our system - ITypeDescriptorCache, IFieldRulesRegistry, ISessionFactory, IEhDatabaseService, ITimeZoneService

   4.  What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?

    Singletons make the testing the code hard. Having the global state creates test -depndence. All tests share same global data, and hence the test results may pass or fail 
    depending on the order the tests are executed.
    Making Singletons thread safe might effect performance
    Have to be very careful in deciding to make class a singleton.
    Use static classes when appropriate for stateless classes
    


    Basic Method of creating a singleton class
      1) Make the class sealed so other classes cannot inherit this class
      2) create a private constructor, so that it prevents other classes from instantiating this class
      3) create a public static method (a it should be accessed with the class) to get the instance of class.
      4) create a private static variable that has reference to the Singleton Class.
      5)If the instance is null then only create the object of Singleton Class
      6) This method implements lazy initialization of the object. It is not thread safe.
         * */
  
   public sealed class Singleton
   {
       private static Singleton instance = null;
       
       private Singleton() { }

       public static Singleton getInstance()
       {
           if (instance == null)
           {
               return new Singleton();
           }

           return instance;
       }
   }

    //Early Initialization - Thread Safe 
    //This way the static field may be initialized before the instance creation
    public sealed class ThreadSafeEarlySingleTon
    {
        private static readonly ThreadSafeEarlySingleTon instance = new ThreadSafeEarlySingleTon();

        private ThreadSafeEarlySingleTon() { }

        public static ThreadSafeEarlySingleTon getInstance()
        {
            return instance;
        }
    }

    //Lazy Intitialization - thread safe- using locks
    // drawback: Over head with locks. every call for instance acquires a lock.
    public sealed class ThreadSafeUsingLocksLazySingleTon
    {
        private static ThreadSafeUsingLocksLazySingleTon instance = null;
        private static readonly object lazylock = new Object();

        private ThreadSafeUsingLocksLazySingleTon() { }

        public static ThreadSafeUsingLocksLazySingleTon getInstance()
        {
            lock (lazylock)
            {
                if (instance == null)
                {
                    return new ThreadSafeUsingLocksLazySingleTon();
                }
            }
            return instance;
        }
    }

    //Lazy Intialization - thread safe - using double check locks
    // prevents acquiring  lock each time we request instance
  
    public sealed class ThreadSafeUsingDoubleCheckLockLazySingleTon
    {
        private static ThreadSafeUsingDoubleCheckLockLazySingleTon instance = null;
        private static readonly object lazylock = new Object();

        private ThreadSafeUsingDoubleCheckLockLazySingleTon() { }

        public static ThreadSafeUsingDoubleCheckLockLazySingleTon getInstance()
        {
      
                if (instance == null)
                {
                    lock (lazylock)
                    {
                        if (instance == null) return new ThreadSafeUsingDoubleCheckLockLazySingleTon();
                    }
                }
            return instance;
        }
    }

    //Best method: Lazy Initialization  using  System.Lazy<T> and pass a delegate to constuctor which calls the instance- Thread Safe

    public sealed class ThreadSafeLazySingleTon
    {
        private static readonly Lazy<ThreadSafeLazySingleTon> lazy =
            new Lazy<ThreadSafeLazySingleTon>(() => new ThreadSafeLazySingleTon());

        private ThreadSafeLazySingleTon() { }

        public static ThreadSafeLazySingleTon getInstance()
        {
            return lazy.Value;
         }
   
    }

   




}

