﻿namespace KDT.Tests.RepositoryTests;

public class SmallItemTests
{
    #region Ctor

    private readonly Repository<SmallItem> _repository;
    
    public SmallItemTests()
    {
        var dbContext = new KdtDbContext();
        _repository = new Repository<SmallItem>(dbContext);
    }

    #endregion

    [Fact]
    public async void CrudFlow()
    {
        await _repository.Add(new SmallItem());
        
        var items = await _repository.GetListAsync();
        
        foreach (var item in items)
        {
            item.Name = "chain";
        }
        await _repository.Update(items.First());
        
        await _repository.Delete( items.First());

    }
}