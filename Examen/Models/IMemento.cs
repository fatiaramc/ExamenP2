using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public interface IMemento
    {
        List<string> GetState();
    }
}