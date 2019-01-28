namespace Spark.Config.Api.Entity
{
    ///<summary>
    ///SmsRecord
    ///</summary>
    public class SmsRecord : BaseEntity
    {
        public SmsRecord()
        {
            Status = 0;
        }

        ///<summary>
        ///
        ///</summary>
        public string Mobile { get; set; }

        ///<summary>
        ///短信签名
        ///</summary>
        public string SignName { get; set; }

        ///<summary>
        ///适合发短信内容的厂商
        ///</summary>
        public string Content { get; set; }

        ///<summary>
        ///渠道
        ///</summary>
        public int? Type { get; set; }

        ///<summary>
        ///状态
        ///</summary>
        public int Status { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string TempId { get; set; }
    }
}