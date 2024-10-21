using DotnetActionsToolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_sample_action
{
    public class Program
    {
        static readonly Core _core = new Core();

        static List<int> GenerateFibo(int n)
        {
            int a = 0;
            int b = 1;
            var list = new List<int>();
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                list.Add(a);
            }
            return list;
        }

        static void Main(string[] args)
        {
            try
            {
                var fibNumber = Int32.Parse(_core.GetInput("fibNumber"));
                _core.Info($"Generating up to {fibNumber}..."); // debug is only output if you set teh secret ACTIONS_RUNNER_DEBUG to true

                _core.Debug(DateTime.Now.ToLongTimeString());
                var fibs = GenerateFibo(fibNumber);
                _core.Debug(DateTime.Now.ToLongTimeString());
                _core.Info(String.Join(',', fibs));

            }
            catch (Exception ex)
            {
                _core.SetFailed(ex.Message);
            }
        }
    }
}
