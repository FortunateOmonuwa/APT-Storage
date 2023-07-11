using APT_Storage.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.Service.Subfolder_Service.Contract
{
    public interface ISubFolderService
    {
        Task<Subfolder> CreateSubfolder(int parentFolderId);
        Task <Subfolder>DeleteSubfolder(int subFolderId);
        Task<Subfolder> GetSubfolderbyId(int subFolderId);
        Task<IEnumerable<Subfolder>> GetAllSubfolders(int parentFolderId);
        Task<Folder> GetParentFolderById(int subFolderId);
        Task<Folder> GetSubFolderByName(string parentFolderName);
        Task<bool> DeleteSubFolderById(int folderId);
    }
}
