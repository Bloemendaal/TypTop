namespace BasicGameEngine
***REMOVED***
    abstract class Component
    ***REMOVED***
        private Entity _entity;

        public Entity Entity
        ***REMOVED***
            get => _entity;
            set
            ***REMOVED***
                _entity = value;
                AddedToEntity();
        ***REMOVED***
    ***REMOVED***

        public virtual void AddedToEntity() ***REMOVED*** ***REMOVED***
***REMOVED***
***REMOVED***