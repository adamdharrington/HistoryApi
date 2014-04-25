using HistoryApp.Models;
using System.Linq;

namespace HistoryApp.Data
{
    interface IEvents
    {
        IQueryable<APIEvent> APIEvents { get; }
    }
}
