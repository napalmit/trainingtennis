package it.napalm.trainingtennis.utils;

import java.util.HashMap;

import android.annotation.SuppressLint;
import android.content.Context;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.SoundPool;

public class SoundManager {
	private SoundPool soundPool;
	private HashMap<Integer, Integer> hMap;
	private HashMap<Integer, Integer> hDuration;
	private AudioManager audioManager;
	private Context context;
	
	@SuppressLint("UseSparseArrays")
	public void initSound(Context theContext) {
		context = theContext;
		soundPool = new SoundPool(4, AudioManager.STREAM_MUSIC, 0);
		hMap = new HashMap<Integer, Integer>();
		hDuration = new HashMap<Integer, Integer>();
		audioManager = (AudioManager)context.getSystemService(Context.AUDIO_SERVICE);
	}

	public void addSound(int index, int SoundID)
	{
		hMap.put(index, soundPool.load(context, SoundID, 1));
		hDuration.put(index, (int)getSoundDuration(SoundID));
	}
	
	public void playSound(int index)
	{
		float streamVolume = audioManager.getStreamVolume(AudioManager.STREAM_MUSIC);
		soundPool.play((Integer) hMap.get(index), streamVolume, streamVolume, 1, 0, 1f);
	}
	
	public long getDuration(int index){
		return hDuration.get(index);
	}
	
	private long getSoundDuration(int rawId){
		   MediaPlayer player = MediaPlayer.create(context, rawId);
		   int duration = player.getDuration();
		   player.release();
		   
		   return duration;
	}
}
