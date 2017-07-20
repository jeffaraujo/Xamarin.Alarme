using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace Xamarin.Alarme
{
    [Activity(Label = "Xamarin.Alarme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var rdbNotificacao = FindViewById<RadioButton>(Resource.Id.rdbNotificacao);
            var rdbMensagem = FindViewById<RadioButton>(Resource.Id.rdbToast);

            var btnUmaVez = FindViewById<Button>(Resource.Id.btnUmaVez);
            var btnRepetir = FindViewById<Button>(Resource.Id.btnRepetir);


            btnUmaVez.Click += delegate
            {
                if (rdbNotificacao.Checked == true)
                    IniciarAlarme(true, false);
                else
                    IniciarAlarme(false, false);
            };
            btnRepetir.Click += delegate
            {
                if (rdbNotificacao.Checked == true)
                    IniciarAlarme(true, true);
                else
                    IniciarAlarme(false, true);
            };
        }
        private void IniciarAlarme(bool isNotificacao, bool isRepetirAlarme)
        {
            AlarmManager manager = (AlarmManager)GetSystemService(Context.AlarmService);
            Intent minhaIntent;
            PendingIntent pendingIntent;
            if (!isNotificacao)
            {
                minhaIntent = new Intent(this, typeof(AlarmeMensagemReceiver));
                pendingIntent = PendingIntent.GetBroadcast(this, 0, minhaIntent, 0);
            }
            else
            {
                minhaIntent = new Intent(this, typeof(AlarmeNotificacaoReceiver));
                pendingIntent = PendingIntent.GetBroadcast(this, 0, minhaIntent, 0);
            }
            if (!isRepetirAlarme)
            {
                manager.Set(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, pendingIntent);
            }
            else
            {
                manager.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, 60 * 1000, pendingIntent);
            }
        }



    }
}


