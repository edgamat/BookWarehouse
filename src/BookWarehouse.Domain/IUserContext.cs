namespace BookWarehouse.Domain
{
    public interface IUserContext
    {
        string Username { get; }

        bool IsInRole(string role);
    }
}