using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();
        private CitiesAdded _originator = null;

        public Caretaker(CitiesAdded originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            this._mementos.Add(_originator.Save());
        }

        public void Undo()
        {
            if(_mementos.Count == 0)
            {
                return;
            }
            var memento = _mementos.Last();
            this._mementos.Remove(memento);
            try
            {
                _originator.Restore(memento);
            }
            catch(Exception e)
            {
                this.Undo();
            }
        }

        public List<IMemento> ShowHistory()
        {
            return _mementos;
        }

    }
}