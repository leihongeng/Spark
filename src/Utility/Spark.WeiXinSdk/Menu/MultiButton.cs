using System;
using System.Collections.Generic;
using System.Text;

namespace Spark.WeiXinSdk.Menu
{
    public class MultiButton : BaseButton
    {
        public List<SingleButton> sub_button = new List<SingleButton>();

        public void AddClickButton(ClickButton clickBtn)
        {
            sub_button.Add(clickBtn);
        }

        public void AddViewButton(ViewButton viewBtn)
        {
            sub_button.Add(viewBtn);
        }

    }
}
