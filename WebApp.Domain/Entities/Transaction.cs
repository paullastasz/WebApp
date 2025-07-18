using WebApp.Domain.Common;

namespace WebApp.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public int RN { get; set; }
        public int TOTAL { get; set; }

        public int TOTAL_SELLER { get; set; }

        public int TOTAL_BUYER { get; set; }

        public string GROUP_EN { get; set; }

        public string GROUP_AR { get; set; }

        public string USAGE_EN { get; set; }

        public string USAGE_AR { get; set; }

        public string IS_OFFPLAN_EN { get; set; }

        public string IS_OFFPLAN_AR { get; set; }

        public string IS_FREE_HOLD_EN { get; set; }

        public string IS_FREE_HOLD_AR { get; set; }

        public string DEFAULT_SORT { get; set; }

        public string TRANSACTION_NUMBER { get; set; }

        public string INSTANCE_DATE { get; set; }

        public int PROPERTY_ID { get; set; }

        public int GROUP_ID { get; set; }

        public int PROCEDURE_ID { get; set; }

        public string PROCEDURE_EN { get; set; }

        public string PROCEDURE_AR { get; set; }

        public int IS_OFFPLAN { get; set; }

        public int IS_FREE_HOLD { get; set; }

        public int AREA_ID { get; set; }

        public string AREA_EN { get; set; }

        public string AREA_AR { get; set; }

        public int TRANS_VALUE { get; set; }

        public decimal PROCEDURE_AREA { get; set; }

        public int USAGE_ID { get; set; }

        public decimal ACTUAL_AREA { get; set; }

        public int PROPERTY_TYPE_ID { get; set; }

        public string PROP_TYPE_EN { get; set; }

        public string PROP_TYPE_AR { get; set; }

        public int PROPERTY_SUB_TYPE_ID { get; set; }

        public string? PROP_SB_TYPE_EN { get; set; }

        public string? PROP_SB_TYPE_AR { get; set; }

        public string? ROOMS_EN { get; set; }

        public string? ROOMS_AR { get; set; }

        public string? PARKING { get; set; }

        public int BUILDING_AGE { get; set; }

        public int? PARCEL_ID { get; set; }

        public string? PROJECT_EN { get; set; }

        public string? PROJECT_AR { get; set; }

        public string? MASTER_PROJECT_EN { get; set; }

        public string? MASTER_PROJECT_AR { get; set; }

        public string? NEAREST_METRO_EN { get; set; }

        public string? NEAREST_METRO_AR { get; set; }

        public string? NEAREST_MALL_EN { get; set; }

        public string? NEAREST_MALL_AR { get; set; }

        public string? NEAREST_LANDMARK_EN { get; set; }

        public string? NEAREST_LANDMARK_AR { get; set; }

    }
}