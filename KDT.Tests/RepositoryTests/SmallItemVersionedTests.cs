namespace KDT.Tests.RepositoryTests;

public class SmallItemVersionedTests
{
    #region Ctor

    private readonly Repository<SmallItemVersioned> _repository;
    
    public SmallItemVersionedTests()
    {
        var dbContext = new KdtDbContext();
        _repository = new Repository<SmallItemVersioned>(dbContext);
    }

    #endregion
    
    [Fact]
    public async void CrudFlow()
    {
        await _repository.Add(new SmallItemVersioned());
        
        var items = await _repository.GetListAsync();
        
        foreach (var item in items)
        {
            item.Name = "chain";
        }
        await _repository.Update(items.First());
        
        await _repository.Delete( items.First());

    }
}