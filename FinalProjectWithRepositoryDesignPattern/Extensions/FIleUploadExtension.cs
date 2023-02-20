using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.Extensions
{
    public static class FIleUploadExtension
    {
        public static string UploadFile(this IFormFile file,string env,string path)
        {
            string imagename = Guid.NewGuid() + file.FileName;
            string fullPath = Path.Combine(env,path,imagename);
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return imagename;
        }
    }
}
