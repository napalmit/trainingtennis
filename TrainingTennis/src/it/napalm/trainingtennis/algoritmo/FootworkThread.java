package it.napalm.trainingtennis.algoritmo;

import it.napalm.trainingtennis.Footwork;
import it.napalm.trainingtennis.utils.TipoSuono;
import android.os.Handler;

public class FootworkThread implements Runnable {
    private Object mPauseLock;
    private boolean mPaused;
    private boolean mFinished;
    private Footwork footwork;
    private Algoritmo algoritmo;
    
    public FootworkThread(Handler handler, Footwork footwork) {
    	this.footwork = footwork;
    	mPauseLock = new Object();
        mPaused = false;
        mFinished = false;
        algoritmo = new Algoritmo(this.footwork.modalitaAllenamento);
    }

    public void run() {
    	while (!mFinished) {
            synchronized (mPauseLock) {
                while (mPaused) {
                    try {
                        mPauseLock.wait();
                    } catch (InterruptedException e) {
                    }
                }
            }
            try {
            	//eseguo il suono dello step
            	this.footwork.playSound(TipoSuono.STEP);
            	Thread.sleep(500);
            	//estrazione numero
            	int numeroUscito = algoritmo.Estrai();
            	//selezione il suono movimento
            	int playSound = 0;
            	if(numeroUscito == TipologiaSpostamento.DESTRA)
            		playSound = TipoSuono.DESTRA;
            	else if(numeroUscito == TipologiaSpostamento.SINISTRA)
            		playSound = TipoSuono.SINISTRA;
            	else if(numeroUscito == TipologiaSpostamento.AVANTI)
            		playSound = TipoSuono.AVANTI;
            	//eseguo il suono movimento
            	this.footwork.playSound(playSound);
            	//attendo che il suono movimento sia eseguito
            	Thread.sleep(this.footwork.getDurationSound(playSound));
            	//eseguo il suono della la durata dello spostamento
            	this.footwork.playSoundNumero((int)this.footwork.durataSpostamentoSession);
				Thread.sleep((long) (this.footwork.durataSpostamentoSession * 1000));
				//eseguo il suono per colpire
				this.footwork.playSound(TipoSuono.COLPISCI);
				//rientro (1 sec in più ripsetto allo sopstamento)
				Thread.sleep((long) (this.footwork.durataSpostamentoSession * 1000) + 1000);							
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
        }
    }

    /**
     * Call this on pause.
     */
    public void onPause() {
        synchronized (mPauseLock) {
            mPaused = true;
        }
    }

    /**
     * Call this on resume.
     */
    public void onResume() {
        synchronized (mPauseLock) {
            mPaused = false;
            mPauseLock.notifyAll();
        }
    }
    
    public void stop(){
    	mFinished = true;
    }

}
