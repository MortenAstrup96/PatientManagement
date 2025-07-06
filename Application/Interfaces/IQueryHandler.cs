namespace Application.Interfaces;
public interface IQueryHandler<in TQuery, TResult>
{
    Task<TResult> Handle(TQuery command, CancellationToken cancellationToken = default);
}
