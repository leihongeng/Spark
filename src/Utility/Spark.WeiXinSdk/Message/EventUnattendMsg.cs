
namespace Spark.WeiXinSdk.Message
{
    /// <summary>
    /// 取消关注事件
    /// </summary>
    public class EventUnattendMsg : EventBaseMsg
    {
        public override string Event
        {
            get { return "unsubscribe"; }
        }
    }
}
