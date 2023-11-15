namespace fu.lib
{
    public class CreateAndAccessUtility
    {
        public void Run(string fileName, string content)
        {

            var thread1 = new Thread(() => {
                var cf = new CreateFile();
                cf.Run(fileName, content);
            });

            var thread2 = new Thread(() => {
                var af = new AccessFile();
                af.Run(fileName);
            });

            thread1.Start();
            thread1.Join();

            thread2.Start();
            thread2.Join();
        }
    }
}

public class CreateFile
{
    public void Run ( string fileName, string content) 
    {
        Console.WriteLine($"create file: {fileName}");
        //File.Create(fileName);
        File.WriteAllText(fileName, content);
    }
}

public class AccessFile
{
    public void Run ( string fileName) 
    {
        Console.WriteLine($"Reading file: {fileName}");
        var content = File.ReadAllText(fileName);
        Console.WriteLine(content);
    }
}