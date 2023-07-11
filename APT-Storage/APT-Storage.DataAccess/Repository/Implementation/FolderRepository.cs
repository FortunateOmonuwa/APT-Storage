using APT_Storage.DataAccess.Data_Context;
using APT_Storage.DataAccess.Repository.Contracts;
using APT_Storage.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Implementation
{
    
    public class FolderRepository : IFolder
    {
        private readonly DataContext _context;

        public FolderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Folder>> GetAllFoldersAsync() => await _context.Folders.Include(s => s.Subfolders).ToListAsync();

        //public Task<IEnumerable<Subfolder>> GetAllSubFoldersAsync(int folderId)
        //{
        //    try
        //    {
        //        var subfolder = 
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public async Task<Folder> GetFolderByIdAsync(int folderId)
        {
            try
            {
                var folder = await _context.Folders.FirstOrDefaultAsync(s => s.Id == folderId);
                if (folder == null)
                {
                    return null;
                }
                else
                {
                    var folderPath = folder.FolderPath;
                    var files = Directory.GetFiles(folderPath);
                    var subfolders = Directory.GetDirectories(folderPath);

                    var fileModels = files.Select(filePath => new FileModel
                    {
                        FileName = Path.GetFileName(filePath),
                        FileSize = new FileInfo(filePath).Length,
                       
                    }).ToList();

                    var subfolderModels = subfolders.Select(subfolderPath => new Subfolder
                    {
                        Name = Path.GetFileName(subfolderPath),
                        Files = fileModels
                    }).ToList();

                    folder.Files = fileModels;
                    folder.Subfolders = subfolderModels;

                    return folder;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Folder> GetSubFolderByIdAsync(int subFolderId)
        {
            throw new NotImplementedException();
        }
    }
}
