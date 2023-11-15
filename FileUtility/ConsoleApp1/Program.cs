

﻿using System;
using fu.lib;

namespace fu.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = args[0];
            var count = int.Parse(args[1]);

            var threads = new List<Thread>();

            for (var i = 0; i < count; i++)
            {
                var fileName = Path.Combine(directory, $"test{i}.txt");
                var content = $"content{i}";

                var thread = new Thread(() => {
                    var util = new CreateAndAccessUtility();
                    util.Run(fileName, content);
                });
                threads.Add(thread);
            }

            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());

        }
    }
}