using Core;
using Domain.User;
using System.Collections.Generic;

namespace Application.Services.User.Contracts
{
    public class GetResponse
    {
        public GetResponse()
        {
            ValidationResults = new List<BaseValidationResult>();            
        }

        public IUser User { get; set; }

        public IList<BaseValidationResult> ValidationResults { get; set; }
    }
}
