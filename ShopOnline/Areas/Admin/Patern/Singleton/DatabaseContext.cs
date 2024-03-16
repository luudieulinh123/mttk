using System;
using ShopOnline.Models; 
using System.Data.Entity;

public sealed class DatabaseContext
{
    private static readonly Lazy<DatabaseContext> instance = new Lazy<DatabaseContext>(() => new DatabaseContext());

    private readonly menfashionEntities dbContext;

    private DatabaseContext()
    {
        
        dbContext = new menfashionEntities();
    }

    public static DatabaseContext Instance
    {
        get { return instance.Value; }
    }

    public menfashionEntities GetDbContext()
    {
        return dbContext;
    }

   
}