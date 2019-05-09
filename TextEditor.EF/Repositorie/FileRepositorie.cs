using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.EF.Model;

namespace TextEditor.EF.Repositorie
{
    public class FileRepositorie
    {
        
        public void FileAdd(File file)
        {
            using (var ctx = new TextEditorEntities())
            {
                // путь к файлу для загрузки
                string filename =file.FileName;

                // заголовок файла
                string title = file.Tittle;

                // получаем короткое имя файла для сохранения в бд
                string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); 

                // массив для хранения бинарных данных файла
                 byte[] imageData;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }

                file.Tittle = title;
                file.ImageData = imageData;
                ctx.Files.Add(file);
            }
        }

        public void FileImageData()
        {
            List<Image> images = new List<Image>();
            using (var ctx = new TextEditorEntities())
            {
                string sql = "SELECT * FROM Images";
                SqlCommand command = new SqlCommand(sql);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string filename = reader.GetString(1);
                        string title = reader.GetString(2);
                        byte[] data = (byte[])reader.GetValue(3);

                      Image  image = new Image(id, filename, title, data);
                        images.Add(image);
                    }
            }
                // сохраним первый файл из списка
                if (images.Count > 0)
                {
                    using (FileStream fs = new FileStream(images[0].FileName, FileMode.OpenOrCreate))
                    {
                        fs.Write(images[0].Data, 0, images[0].Data.Length);
                        Console.WriteLine(" '{0}' сохранено", images[0].Title);
                    }
                }
           
        }
    }
}
