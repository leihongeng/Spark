namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///SmsTemp
    ///</summary>
    public class SmsTemp : BaseEntity
    {
        ///<summary>
        ///短信模板code
        ///</summary>
        public string TempId { get; set; }

        ///<summary>
        ///短信主题
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///短信内容
        ///</summary>
        public string Content { get; set; }

        ///<summary>
        ///短信签名
        ///</summary>
        public string SignName { get; set; }

        ///<summary>
        ///短信模板id，某些厂商用到
        ///</summary>
        public string OutTempId { get; set; }
    }
}