using SLMBugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLMBugTracker.Services.Interfaces
{
    public interface IBTRolesService
    {  
     public Task<bool> IsUserInRoleAsync(BTUser user, string roleName);
     public Task<IEnumerable<string>> GetUserRolesAsync(BTUser user);
     public Task<bool> AddUserToRoleAsync(BTUser user, string roleName);
     public Task<bool> RemoveUserFromRoleAsync(BTUser user, string roleName);
     public Task<bool> RemoveUserFromRolesAsync(BTUser user, IEnumerable<string> roles);


    

    } 
}
 