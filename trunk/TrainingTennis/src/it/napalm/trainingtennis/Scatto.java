package it.napalm.trainingtennis;

import it.napalm.trainingtennis.algoritmo.FootworkThread;
import it.napalm.trainingtennis.utils.CountDownTimerWithPause;
import it.napalm.trainingtennis.utils.SoundManager;
import it.napalm.trainingtennis.utils.StatoSessione;
import it.napalm.trainingtennis.utils.TipoSuono;
import it.napalm.trainingtennis.utils.TipoSuonoNumero;
import it.napalm.trainingtennis.utils.Tools;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.Message;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.AbsoluteLayout;
import android.widget.ImageView;
import android.widget.TextView;

@SuppressWarnings("deprecation")
public class Scatto extends Fragment {

    private View view;
    private ImageView imgPause;
    private ImageView imgStop;
    private ImageView imgStart;
    public TextView txtTimer;
    public String ptext="..PAGE 1..";
    private SoundManager soundManager = new SoundManager();
    private SoundManager soundManagerNumeri = new SoundManager();
    private CountDownTimerWithPause countDownTimerSession;
    private CountDownTimerForStart countDownTimerForStart;
    private float minutiSession;
    private float secondiSession;
    public float durataSpostamentoSession;
    public int modalitaAllenamento;
    private int STATO_SESSIONE;
    private FootworkThread footworkThread;
    private Thread mainThread;

    // activity listener interface
    @SuppressWarnings("unused")
    private OnPageListener pageListener;
    public interface OnPageListener {
        public void onPage1(String s);
    }

    // onAttach : set activity listener
    @Override
    public void onAttach(Activity activity) {
        super.onAttach(activity);
        // if implemented by activity, set listener
        if(activity instanceof OnPageListener) {
            pageListener = (OnPageListener) activity;
        }
        // else create local listener (code never executed in this example)
        else pageListener = new OnPageListener() {
            @Override
            public void onPage1(String s) {
                Log.d("PAG1","Button event from page 1 : "+s);
            }
        };
    }

    public View onCreateView(LayoutInflater inflater,ViewGroup container,Bundle savedInstanceState) {
        if (container == null) {
            return null;
        }
        view = (AbsoluteLayout)inflater.inflate(R.layout.scatti_absolute,container,false);

        getPrefs();
        //initGUI();
        //initSound();

        STATO_SESSIONE = StatoSessione.NON_ATTIVA;




        //Handler handler = new MyHandler();
        //footworkThread = new FootworkThread(handler, this);
        //mainThread = new Thread(footworkThread);

        return view;
    }

    private void initGUI() {
        imgPause = (ImageView)view.findViewById(R.id.pause);
        imgPause.setVisibility(View.INVISIBLE);
        imgPause.setOnClickListener(new OnClickListener() {
            public void onClick(View v) {
                imgStart.setVisibility(View.VISIBLE);
                imgPause.setVisibility(View.INVISIBLE);
                imgStop.setVisibility(View.VISIBLE);
                STATO_SESSIONE = StatoSessione.IN_PAUSA;
                countDownTimerSession.pause();

                Activity mainActivity = getActivity();

                if(mainActivity instanceof MainActivity) {
                    ((MainActivity) mainActivity).setPagingEnabled(true);
                }

                footworkThread.onPause();
            }
        });
        imgStop = (ImageView)view.findViewById(R.id.stop);
        imgStop.setVisibility(View.INVISIBLE);
        imgStop.setOnClickListener(new OnClickListener() {
            public void onClick(View v) {
                imgStart.setVisibility(View.VISIBLE);
                imgPause.setVisibility(View.INVISIBLE);
                imgStop.setVisibility(View.INVISIBLE);
                STATO_SESSIONE = StatoSessione.NON_ATTIVA;
                countDownTimerSession.cancel();
                long durata = (long) (((minutiSession * 60) + secondiSession)) * 1000;
                txtTimer.setText(Tools.creaStringaCronometro(durata));

                soundManager.playSound(TipoSuono.SESSION_COMPLETED);

                Activity mainActivity = getActivity();

                if(mainActivity instanceof MainActivity) {
                    ((MainActivity) mainActivity).setPagingEnabled(true);
                }
                footworkThread.onPause();
            }
        });
        imgStart = (ImageView)view.findViewById(R.id.start);
        imgStart.setVisibility(View.VISIBLE);
        imgStart.setOnClickListener(new OnClickListener() {
            public void onClick(View v) {


                Activity mainActivity = getActivity();

                if(mainActivity instanceof MainActivity) {
                    ((MainActivity) mainActivity).setPagingEnabled(false);
                }

                if(STATO_SESSIONE != StatoSessione.IN_PAUSA){
                    //start
                    countDownTimerForStart = new CountDownTimerForStart(5000, 1000);
                    countDownTimerForStart.start();
                }else{
                    //resume
                    imgStart.setVisibility(View.INVISIBLE);
                    imgPause.setVisibility(View.VISIBLE);
                    imgStop.setVisibility(View.VISIBLE);
                    countDownTimerSession.resume();
                    STATO_SESSIONE = StatoSessione.ATTIVA;
                    footworkThread.onResume();
                }
            }
        });
        txtTimer = (TextView)view.findViewById(R.id.txtTimer);
        long durata = (long) (((minutiSession * 60) + secondiSession)) * 1000;
        txtTimer.setText(Tools.creaStringaCronometro(durata));

        countDownTimerSession = new CountDownTimerSession(durata, 1 * 1000, true);

    }

    private void initSound() {
        soundManager.initSound(view.getContext());
        soundManager.addSound(TipoSuono.SESSION_START, R.raw.sessionstarted);
        soundManager.addSound(TipoSuono.SESSION_PAUSED, R.raw.sessionpaused);
        soundManager.addSound(TipoSuono.SESSION_RESUMED, R.raw.sessionresumed);
        soundManager.addSound(TipoSuono.SESSION_COMPLETED, R.raw.sessioncompleted);
        soundManager.addSound(TipoSuono.STEP, R.raw.step);
        soundManager.addSound(TipoSuono.DESTRA, R.raw.destra);
        soundManager.addSound(TipoSuono.SINISTRA, R.raw.sinistra);
        soundManager.addSound(TipoSuono.AVANTI, R.raw.avanti);
        soundManager.addSound(TipoSuono.COLPISCI, R.raw.colpisci);

        soundManagerNumeri.initSound(view.getContext());
        soundManagerNumeri.addSound(TipoSuonoNumero.ZERO, R.raw.zero);
        soundManagerNumeri.addSound(TipoSuonoNumero.UNO, R.raw.uno);
        soundManagerNumeri.addSound(TipoSuonoNumero.DUE, R.raw.due);
        soundManagerNumeri.addSound(TipoSuonoNumero.TRE, R.raw.tre);
        soundManagerNumeri.addSound(TipoSuonoNumero.QUATTRO, R.raw.quattro);
        soundManagerNumeri.addSound(TipoSuonoNumero.CINQUE, R.raw.cinque);
        soundManagerNumeri.addSound(TipoSuonoNumero.SEI, R.raw.sei);
        soundManagerNumeri.addSound(TipoSuonoNumero.SETTE, R.raw.sette);
        soundManagerNumeri.addSound(TipoSuonoNumero.OTTO, R.raw.otto);
        soundManagerNumeri.addSound(TipoSuonoNumero.NOVE, R.raw.nove);
        soundManagerNumeri.addSound(TipoSuonoNumero.DIECI, R.raw.dieci);

    }

    public void playSound(int tipoSuono){
        soundManager.playSound(tipoSuono);
    }

    public long getDurationSound(int tipoSuono){
        return soundManager.getDuration(tipoSuono);
    }

    public void playSoundNumero(int numero){
        soundManagerNumeri.playSound(numero);
    }

    @SuppressLint("UseValueOf")
    private void getPrefs() {
        // Get the xml/preferences.xml preferences
        SharedPreferences prefs = PreferenceManager
                .getDefaultSharedPreferences(view.getContext());

        String minuti_txt  = prefs.getString("minuti", "Nothing has been entered");
        String secondi_txt  = prefs.getString("secondi", "Nothing has been entered");
        String durata_spostamento_txt = prefs.getString("durata_spostamento", "Nothing has been entered");
        minutiSession = new Float(minuti_txt);
        secondiSession = new Float(secondi_txt);

        if("-".indexOf(durata_spostamento_txt) > 0){
            //durataSpostamentoSession = new Float(durata_spostamento_txt);
        }else
            durataSpostamentoSession = new Float(durata_spostamento_txt);

        modalitaAllenamento = Integer.parseInt(prefs.getString("listPref", "5"));
        if(secondiSession > 60){
            float diff = (secondiSession / 60);
            int minutiAdd = (int)diff;
            minutiSession += minutiAdd;
            float resto = diff - minutiAdd;
            secondiSession = 60 * resto;
        }
    }

    public class CountDownTimerSession extends CountDownTimerWithPause {

        public CountDownTimerSession(long millisOnTimer, long countDownInterval,
                                     boolean runAtStart) {
            super(millisOnTimer, countDownInterval, runAtStart);
        }

        @Override
        public void onTick(long millisUntilFinished) {
            txtTimer.setText(Tools.creaStringaCronometro(millisUntilFinished));
        }

        @Override
        public void onFinish() {
            // TODO Auto-generated method stub
        }
    }

    public class CountDownTimerForStart extends CountDownTimer
    {

        public CountDownTimerForStart(long startTime, long interval)
        {
            super(startTime, interval);
        }

        @Override
        public void onFinish()
        {
            imgStart.setVisibility(View.INVISIBLE);
            imgPause.setVisibility(View.VISIBLE);
            imgStop.setVisibility(View.VISIBLE);
            long durata = (long) (((minutiSession * 60) + secondiSession)) * 1000;
            txtTimer.setText(Tools.creaStringaCronometro(durata));
            countDownTimerSession = new CountDownTimerSession(durata, 1 * 1000, true);
            countDownTimerSession.create();
            STATO_SESSIONE = StatoSessione.ATTIVA;
            if(mainThread.isAlive())
                footworkThread.onResume();
            else
                mainThread.start();
        }

        @Override
        public void onTick(long millisUntilFinished)
        {
            System.out.println("onTick:"+(int)millisUntilFinished / 1000);
            soundManagerNumeri.playSound((int)millisUntilFinished / 1000);
        }
    }

    private class MyHandler extends Handler {
        @Override
        public void handleMessage(Message msg) {
            Bundle bundle = msg.getData();
            if(bundle.containsKey("refresh")) {
                bundle.getString("refresh");
            }
        }
    }
}