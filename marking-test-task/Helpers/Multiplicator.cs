namespace marking_test_task.Helpers
{
    public static class Multiplicator
    {
        public static TResult[] UseMultiple<TResult>(
            Func<int, TResult> method,
            int min,
            int max
        )
        {
            return Enumerable.Range(min, max).Select(method).ToArray();
        }

        public static TResult[] UseMultiple<TResult>(
            Func<int, TResult> method,
            int count
        )
        {
            return Enumerable.Range(0, count).Select(method).ToArray();
        }
    }
}
