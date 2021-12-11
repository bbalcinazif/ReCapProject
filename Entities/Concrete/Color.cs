using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concrete
{
    [Keyless]
    public class Color:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
