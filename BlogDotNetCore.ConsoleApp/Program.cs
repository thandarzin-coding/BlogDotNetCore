// See https://aka.ms/new-console-template for more information
using BlogDotNetCore.ConsoleApp.AdoDotNetExamples;
using BlogDotNetCore.ConsoleApp.EfCoreExamples;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Run();

EfCoreExample efCoreExample = new EfCoreExample();
efCoreExample.Run();

Console.ReadKey();