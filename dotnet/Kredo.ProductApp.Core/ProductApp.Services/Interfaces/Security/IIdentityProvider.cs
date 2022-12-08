namespace ProductApp.Services
{
    public interface IIdentityProvider<T>
    {
        T GetCurrentUserId();
    }
}