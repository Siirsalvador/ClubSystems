namespace ClubSystemsAssessment.Repository.Interfaces;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> CreateUpdate(T T);
}