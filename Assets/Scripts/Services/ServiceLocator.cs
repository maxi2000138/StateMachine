public class ServiceLocator
{
    private static ServiceLocator _instance;

    public static ServiceLocator Container => _instance ??= new ServiceLocator();

    public void RegisterService<TService>(TService service) where TService : IService => 
        Implementation<TService>.ServiceInstance = service;

    public TService GetService<TService>() where TService : IService => 
        Implementation<TService>.ServiceInstance;
    
    private class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}