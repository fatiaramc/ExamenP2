using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class ConcreteMemento : IMemento
    {
        private List<string> _state;
        private DateTime _date;

        public ConcreteMemento(List<string> state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }

        public List<string> GetState()
        {
            return _state;
        }
    }
}