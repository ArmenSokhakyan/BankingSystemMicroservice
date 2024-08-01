namespace NotificationServiceSystem.Core.Common
{
    public static class Delegates
    {
        public static async Task<int> CallbackMethod(string data)
        {
            // Дополнительные действия после основной операции
            return await Task.FromResult(("Post operation action executed." + data).Length);
        }
    }
}
