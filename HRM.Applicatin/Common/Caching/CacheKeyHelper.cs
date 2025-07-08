public static class CacheKeyHelper<T>
{
    private const string AppPrefix = "HRM_v1_";

    public static string GetByIdKey(int id)
    {
        return $"{AppPrefix}{typeof(T).Name}_Single_{id}";
    }

    public static string GetAllKey()
    {
        return $"{AppPrefix}{typeof(T).Name}_All";
    }

    // Optional: allow custom suffixes or keys
    public static string Custom(string suffix)
    {
        return $"{AppPrefix}{typeof(T).Name}_{suffix}";
    }
}
