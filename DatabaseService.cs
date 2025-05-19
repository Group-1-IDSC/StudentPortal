using SQLite;

public static class DatabaseService
{
    static SQLiteAsyncConnection db;

    public static async Task InitAsync()
    {
        if (db != null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "UserProfile.db3");
        db = new SQLiteAsyncConnection(dbPath);
        await db.CreateTableAsync<UserProfile>();
        Console.WriteLine("📦 Initialized SQLite at: " + dbPath);
    }

    public static async Task SaveOrUpdateProfileImageAsync(byte[] imageData)
    {
        await InitAsync();

        var existing = await db.Table<UserProfile>().FirstOrDefaultAsync();
        if (existing != null)
        {
            existing.ProfileImage = imageData;
            await db.UpdateAsync(existing);
        }
        else
        {
            var profile = new UserProfile { ProfileImage = imageData };
            await db.InsertAsync(profile);
        }
    }

    public static async Task<UserProfile> GetLatestProfileAsync()
    {
        await InitAsync();

        return await db.Table<UserProfile>()
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefaultAsync();
    }
}
