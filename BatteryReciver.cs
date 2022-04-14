using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



using Android.App;

using Android.Content;

using Android.OS;

using Android.Runtime;

using Android.Views;

using Android.Widget;



namespace HangingMan

{
    [BroadcastReceiver(Enabled = true)]

    [IntentFilter(new[] { Intent.ActionBatteryLow, Intent.ActionBatteryOkay })]

    public class BatteryReciver : BroadcastReceiver
    {
        private ReciverHandler handler;
        public BatteryReciver()
        {

        }
        public BatteryReciver(ReciverHandler handler)
        {
            this.handler = handler;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            if (handler != null)
            {
                if (intent.Action == Intent.ActionBatteryOkay)
                {
                    handler.SendEmptyMessage(1);
                }
                if (intent.Action == Intent.ActionBatteryLow)
                {
                    handler.SendEmptyMessage(0);
                }
            }
        }
    }
}