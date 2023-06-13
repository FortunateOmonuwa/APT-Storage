using APT_Storage.DataAccess.Repository.Contracts;
using APT_Storage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Implementation
{
    public class FileRepository : IFileRepository
    {
        public Task<IQueryable<FileModel>> AllFIlesAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteFileAsync(int fileId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FileModel>> GetAllFIlesByFolderIdAsync(int folderId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FileModel>> GetAllFIlesBySizeAsync(long fileSize)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FileModel>> GetAllFIlesOrderedByDateAsync(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public Task<FileModel> GetByIdAsync(int fileId)
        {
            throw new NotImplementedException();
        }

        public Task<FileModel> UpdateFileAsync(FileModel file)
        {
            throw new NotImplementedException();
        }

        public Task<FileModel> UploadFileAsync(FileModel file)
        {
            throw new NotImplementedException();
        }
    }
}
