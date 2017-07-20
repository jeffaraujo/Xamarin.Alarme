using Android.App;
using Android.Content;
using Android.Support.V7.App;


namespace Xamarin.Alarme
{
    [BroadcastReceiver(Enabled = true)]
    public class AlarmeNotificacaoReceiver: BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);

            builder.SetAutoCancel(true)
                .SetDefaults((int) NotificationDefaults.All)
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetContentTitle("Alarme ativado")
                .SetContentTitle("Esta é uma notificação")
                .SetContentInfo("Info");

            NotificationManager manager = (NotificationManager) context.GetSystemService(Context.NotificationService);

            manager.Notify(1, builder.Build());
        }
    }
}