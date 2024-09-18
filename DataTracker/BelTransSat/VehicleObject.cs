
using System.Text.Json.Serialization;

namespace ExcelParser.BelTransSat
{
    public class VehicleObject
    { 
        [JsonPropertyName("object_id")]
        public string ObjectId { get; set; }
        /*[JsonPropertyName("object_name")]
        public string ObjectName { get; set; }
        [JsonPropertyName("object_uid")]
        public string ObjectUid { get; set; }
        [JsonPropertyName("state_number")]
        public string StateNumber { get; set; }
        [JsonPropertyName("garage_number")]
        public string GarageNumber { get; set; }
        [JsonPropertyName("distance_gps")]
        public double DistanceGps { get; set; }
        [JsonPropertyName("distance_can")] 
        public double DistanceCan { get; set; }
        [JsonPropertyName("run_time")]
        public double RunTime { get; set; }
        [JsonPropertyName("run_time_str")]
        public string RunTimeStr { get; set; }
        [JsonPropertyName("stop_time")]
        public double StopTime { get; set; }
        [JsonPropertyName("stop_time_str")]
        public string StopTimeStr { get; set; }
        [JsonPropertyName("max_speed")]
        public double MaxSpeed { get; set; }
        [JsonPropertyName("fuel_can")]
        public double FuelCan { get; set; }
        [JsonPropertyName("fuel_dut")]
        public double FuelDut { get; set; }
        [JsonPropertyName("fuel_flow")]
        public object FuelFlow { get; set; }
        [JsonPropertyName("fuel_diffs")]
        public List<object> FuelDiffs { get; set; }*/
        
        [JsonPropertyName("fuel_in_list")]
        public List<object> FuelInList { get; set; }
        
        /*[JsonPropertyName("fuel_card_in")]
        public List<object> FuelCardIn { get; set; }
        [JsonPropertyName("fuel_dut_start")]
        public double FuelDutStart { get; set; }
        [JsonPropertyName("fuel_dut_finish")]
        public double FuelDutFinish { get; set; }
        [JsonPropertyName("odom_start")]
        public double OdomStart { get; set; }
        [JsonPropertyName("s_odo_dt")]
        public object SOdoDt { get; set; }
        [JsonPropertyName("odom_finish")]
        public double OdomFinish { get; set; }
        [JsonPropertyName("e_odo_dt")]
        public object EOdoDt { get; set; }
        [JsonPropertyName("avg_speed_gps")]
        public double AvgSpeedGps { get; set; }
        [JsonPropertyName("avg_speed_can")]
        public double AvgSpeedCan { get; set; }
        [JsonPropertyName("avg_fuel_can")]
        public object AvgFuelCan { get; set; }
        [JsonPropertyName("avg_fuel_dut")]
        public double AvgFuelDut { get; set; }
        [JsonPropertyName("fuel_can_stop")]
        public double FuelCanStop { get; set; }
        [JsonPropertyName("engine_time_h")]
        public double EngineTimeH { get; set; }
        [JsonPropertyName("adblue")]
        public object Adblue { get; set; }*/
    }

    public class Root
    {
        [JsonPropertyName("root")]
        public ResultWrapper RootWrapper { get; set; }
    }

    public class ResultWrapper
    {
        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("object_id")]
        public string ObjectId { get; set; }

        [JsonPropertyName("object_name")]
        public string ObjectName { get; set; }

        [JsonPropertyName("object_uid")]
        public string ObjectUid { get; set; }

        /*[JsonPropertyName("state_number")]
        public string StateNumber { get; set; }*/

        [JsonPropertyName("garage_number")]
        public string GarageNumber { get; set; }

        [JsonPropertyName("datetime")]
        public string Datetime { get; set; }

        [JsonPropertyName("odom_can")]
        public double? OdomCan { get; set; }

        [JsonPropertyName("odom_virt")]
        public double OdomVirt { get; set; }
    }
}