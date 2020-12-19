using Application.User;
using Core;
using System.Collections.Generic;

namespace Application.Services.User.Contracts
{
    public class GetResponse
    {
        public GetResponse()
        {
            ValidationResults = new List<BaseValidationResult>();            
        }

        public UserModel User { get; set; }

        public IList<BaseValidationResult> ValidationResults { get; set; }
    }
}
