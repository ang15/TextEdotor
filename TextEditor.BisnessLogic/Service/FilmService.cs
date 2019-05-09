using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.EF;
using TextEditor.EF.Repositorie;

namespace TextEditor.BisnessLogic.Service
{
    public interface IFileService
    {
        void FileAdd(File file);
        void FileImageData();
    }
    public class FileService : IFileService
    {
        private readonly FileRepositorie _fileRepositorie;

        public FileService()
        {
            _fileRepositorie = new FileRepositorie();
        }

        public void FileAdd(File file)
        {
            _fileRepositorie.FileAdd(file);
        }
        public void FileImageData()
        {
            _fileRepositorie.FileImageData();
        }
    }
}
