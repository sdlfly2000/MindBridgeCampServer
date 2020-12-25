using Core;
using System.Collections.Generic;

namespace Application.Services.LearningRoom.Contracts
{
    public class GetResponse
    {
        public GetResponse()
        {
            ValidationResults = new List<BaseValidationResult>();
        }

        IList<BaseValidationResult> ValidationResults { get; set; }
    }
}
