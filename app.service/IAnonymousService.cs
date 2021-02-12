using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using app.service.Anonymous.Command;

namespace app.service
{
    public interface IAnonymousService
    {
        Task<SendFaqResult> SendFaq(SendFaqCommand command);
    }
}
