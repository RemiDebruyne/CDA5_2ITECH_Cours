using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Entity;

public class Book : Entity
{
    public string Title { get; set; }

    public string Author { get; set; }

    public Guid ISBN { get; set; }

    public DateTime Publication { get; set; }

    public bool IsAvailable { get; set; }
}
