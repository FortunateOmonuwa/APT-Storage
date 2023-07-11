using APT_Storage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Contracts
{
    public interface IFileRepository
    {
        Task<FileModel> UploadFileAsync(FileModel file);//Uploads the file using the file entity and the userId

        Task<FileModel> GetByIdAsync(int fileId); //Retrieves a file by it's Id

        Task<IQueryable<FileModel>> AllFIlesAsync(); //Get's all files associated with the user}

        Task<IQueryable<FileModel>> GetAllFIlesBySizeAsync(long fileSize); //Get's all files based on a size range

        Task<IQueryable<FileModel>> GetAllFIlesOrderedByDateAsync(DateOnly date); //Get's all files based on the date uploaded/ added


        Task<IQueryable<FileModel>> GetAllFIlesByFolderIdAsync(int folderId); //Retrieves all files in a specific folder associated with a user.

        Task<FileModel> UpdateFileAsync(FileModel file); //Updates the meta-data of a file

        Task DeleteFileAsync(int fileId); // Deletes file by Id
    }
}
