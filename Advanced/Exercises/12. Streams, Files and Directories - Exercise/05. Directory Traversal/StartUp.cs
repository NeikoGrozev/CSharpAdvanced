namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo("../../../");
            FileInfo[] files = di.GetFiles();

            var filesByExtension = new Dictionary<string, Dictionary<string, long>>();
            
            foreach (var file in files)
            {
                string fileExtension = file.Extension;

                if (!filesByExtension.ContainsKey(fileExtension))
                {
                    filesByExtension.Add(fileExtension, new Dictionary<string, long>());
                }

                filesByExtension[fileExtension].Add(file.Name, file.Length);
            }

            using (var streamWriter = new StreamWriter("../../../report.txt"))
            {
                foreach (var extension in filesByExtension
                .OrderByDescending(e => e.Value.Count)
                .ThenBy(e => e.Key)
                .ToDictionary(x => x.Key, x => x.Value))
                {
                    streamWriter.WriteLine(extension.Key);

                    var currentFiles = extension.Value
                        .OrderBy(f => f.Value)
                        .ToDictionary(x => x.Key, x => x.Value);

                    foreach (var file in currentFiles)
                    {
                        streamWriter.WriteLine($"--{file.Key} - {(file.Value / 1000.0):F3}kb");
                    }
                }
            }
        }
    }
}
