using System;

namespace NLogging
{
	public class Logging
	{

             private static volatile Logging instance;
   private static object syncRoot = new Object();

   private Logging() {}

   public static Logging Instance
   {
      get 
      {
         if (instance == null) 
         {
            lock (syncRoot) 
            {
               if (instance == null) 
                  instance = new Logging();
            }
         }

         return instance;
      }
   }
		}
	
}

