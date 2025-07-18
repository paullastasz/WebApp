namespace WebApp.Application.DTOs
{
    public class GetTransactionsRequestDTO
    {
        public string P_FROM_DATE {  get; set; } = null!;

        public string P_TO_DATE { get; set; } = null!;

        public string P_GROUP_ID { get; set; } = string.Empty;

        public string P_IS_OFFPLAN { get; set; } = string.Empty;

        public string P_IS_FREE_HOLD { get; set; } = string.Empty;

        public string P_AREA_ID { get; set; } = string.Empty;

        public string P_USAGE_ID { get; set; } = string.Empty;

        public string P_PROP_TYPE_ID { get; set; } = string.Empty;

        public string P_TAKE { get; set; } = null!;

        public string P_SKIP { get; set; } = null!;

        public string P_SORT { get; set; } = "INSTANCE_DATE_ASC";

    }
}