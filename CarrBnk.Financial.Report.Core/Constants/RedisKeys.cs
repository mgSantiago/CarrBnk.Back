namespace CarrBnk.Financial.Report.Core.Constants
{
    internal static class RedisKeys
    {
        public static readonly string GetFinancialDailyReportCached = "GetFinancialDailyReport";
        public static string GetFinancialDailyReportCachedKey(string? startOfDay = null, string? endOfDay = null) => $"{SystemConstants.AppName}_{GetFinancialDailyReportCached}_{startOfDay ?? DateTime.Now.Date.ToString()}_{endOfDay ?? DateTime.Now.Date.AddDays(1).ToString()}";
    }
}
