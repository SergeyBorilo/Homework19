var directoryPath = args.Length > 0 ? args[0] : GetDirectoryPath();

if (Directory.Exists(directoryPath))
{
    List<string> directories = [];
    TraverseDirectory(directoryPath, directories);
    PrintDirectoriesAndFiles(directories);
}
else
    Console.WriteLine("Invalid directory path.");

return;

static string GetDirectoryPath()
{
    Console.Write("Enter the directory path: ");
    return Console.ReadLine();
}

static void TraverseDirectory(string path, List<string> directories)
{
    directories.Add(path);
    foreach (var dir in Directory.GetDirectories(path)) TraverseDirectory(dir, directories);
}

static void PrintDirectoriesAndFiles(List<string> directories)
{
    foreach (var dir in directories)
    {
        Console.WriteLine("[DIR] " + dir);
        foreach (var file in Directory.GetFiles(dir)) Console.WriteLine("  - " + Path.GetFileName(file));
    }
}

