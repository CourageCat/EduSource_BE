namespace EduSource.Contract.DTOs.OrderDTOs;

public static class DashboardDTO
{
    public class DataDTO
    {
        public List<string> Categories { get; set; }
        public List<SeriesDTO> Series { get; set; }
    }
    public class SeriesDTO
    {

        public string Name { get; set; }
        public List<int> Data { get; set; }
    }

    public class MonthlyTargetDTO
    {
        public double Progress { get; set; }
        public double Target { get; set; }
        public int Revenue { get; set; }
        public int TodayRevenue { get; set; }
        public double GrowthPercentage { get; set; }
        public string Currency { get; set; }
        public string Comparison { get; set; }
    }
}
