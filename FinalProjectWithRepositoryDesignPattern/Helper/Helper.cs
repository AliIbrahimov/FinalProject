namespace FinalProjectWithRepositoryDesignPattern.Helper;

public class Helper
{
    public static void DeleteHelper(string env, string path, string name)
    {
        string fullpath = Path.Combine(env, path, name);
        File.Delete(fullpath);
    }
}
