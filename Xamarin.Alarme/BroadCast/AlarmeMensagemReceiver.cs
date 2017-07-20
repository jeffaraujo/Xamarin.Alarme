using Android.Content;
using Android.Widget;

namespace Xamarin.Alarme
{
    [BroadcastReceiver(Enabled = true)]
    public class AlarmeMensagemReceiver: BroadcastReceiver
    {
        
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Alarme do Jefão", ToastLength.Long).Show();
        }
    }
}