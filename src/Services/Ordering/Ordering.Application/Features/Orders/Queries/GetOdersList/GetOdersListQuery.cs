using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOdersList
{
    public class GetOdersListQuery : IRequest<List<OrderVM>>
    {
        public string UserName { get; set; }
        public GetOdersListQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));   
        }
    }
}
