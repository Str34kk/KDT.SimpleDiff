namespace KDT.Tests.RepositoryTests;

public class SmallItemTests
{
    #region Ctor

    private readonly KdtDbContext _dbContext;
    private readonly Repository<SmallItem> _repository;
    
    public SmallItemTests()
    {
        _dbContext = new KdtDbContext();
        _repository = new Repository<SmallItem>(_dbContext);
    }

    #endregion

    [Fact]
    public async void ShouldAddItem()
    {
        await _repository.Add(new SmallItem());
    }

    [Fact]
    public async void ShouldGetAllItems()
    {
        await _repository.GetListAsync();
    }
    
    [Fact]
    public async void ShouldUpdateItem()
    {
        var items = await _repository.GetListAsync();
        foreach (var item in items)
        {
            item.Name = "chain";
        }
        await _repository.Update(items.First());
    }
    
    [Fact]
    public async void ShouldRemoveItem()
    {
        var item = await _repository.GetListAsync();
        await _repository.Delete( item.First());
    }
}