using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment.Core.Entities;

namespace TechnicalAssessment.Contract
{
    public interface IAuthService
    {

        Task<IdentityResult> RegisterAsync(User model);
        Task<string> LoginAsync(User model);

    }
}
