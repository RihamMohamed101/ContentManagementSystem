namespace ContentManagementSystem.Helper
{
    
        public class DocumentSettings
        {

            public static string uploadFile(IFormFile file, string folderName)
            {

                // Get folder path

                string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);


            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // get file name and make unique 


            string fileName = $"{Guid.NewGuid()} {file.FileName}";

                // get file path ==? pathFolder+fileName


                string filePAth = Path.Combine(folderPath, fileName);


            // save file as stream ==? data per time

            using (var fileStream = new FileStream(filePAth, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }


            return fileName;

            }

            public static void DeleteFile(string fileName, string folderName)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

                if (File.Exists(folderPath))
                {
                    File.Delete(folderPath);
                }
            }
        
    }
}
