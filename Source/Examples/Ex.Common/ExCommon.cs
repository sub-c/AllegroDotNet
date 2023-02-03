using System;

namespace Ex.Common;
public static class ExCommon
{
  public static void abort_example(string message)
  {
    Console.WriteLine(message);
    Environment.Exit(1);
  }
}
