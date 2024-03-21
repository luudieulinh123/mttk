using System;
using ShopOnline.Models; 
using System.Data.Entity;

public sealed class DatabaseContext
{
    private static  Lazy<DatabaseContext> instance = new Lazy<DatabaseContext>(() => new DatabaseContext());

    private readonly menfashionEntities dbContext;

    private DatabaseContext()
    {
        
        dbContext = new menfashionEntities();
    }

    public static DatabaseContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Lazy<DatabaseContext>(() => new DatabaseContext());
            }
            return instance.Value;
        }
    }

    public menfashionEntities GetDbContext()
    {
        return dbContext;
    }

   
}