using APT_Storage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Contracts
{
    public interface IFolder
    {
        Task<IEnumerable<Folder>> GetAllFoldersAsync();
        //Task<IEnumerable<Subfolder>> GetAllSubFoldersAsync( int folderId);
        Task<Folder> GetFolderByIdAsync(int folderId);
        Task<Folder> GetSubFolderByIdAsync(int subFolderId);
    }
}
