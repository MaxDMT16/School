namespace SchoolSystem.Abstractions.CQRS.Contracts
{
    public interface IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
    }
}