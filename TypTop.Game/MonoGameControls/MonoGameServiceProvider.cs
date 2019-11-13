***REMOVED***
***REMOVED***

namespace TypTop.Game.MonoGameControls
***REMOVED***
    public class MonoGameServiceProvider : IServiceProvider
    ***REMOVED***
        private readonly Dictionary<Type, object> _services;

        public MonoGameServiceProvider()
        ***REMOVED***
            _services = new Dictionary<Type, object>();
    ***REMOVED***

        public void AddService(Type type, object provider)
        ***REMOVED***
            _services.Add(type, provider);
    ***REMOVED***

        public object GetService(Type type)
        ***REMOVED***
            if (_services.TryGetValue(type, out var service))
                return service;

            return null;
    ***REMOVED***

        public void RemoveService(Type type)
        ***REMOVED***
            _services.Remove(type);
    ***REMOVED***

        public void AddService<T>(T service)
        ***REMOVED***
            AddService(typeof(T), service);
    ***REMOVED***

        public T GetService<T>() where T : class
        ***REMOVED***
            var service = GetService(typeof(T));
            return (T) service;
    ***REMOVED***
***REMOVED***
***REMOVED***
