package it.napalm.trainingtennis;

import java.util.List;
import java.util.Vector;

import it.napalm.trainingtennis.utils.CountDownTimerWithPause;
import it.napalm.trainingtennis.utils.PagerAdapter;
import it.napalm.trainingtennis.utils.SoundManager;
import it.napalm.trainingtennis.utils.TipoSuono;
import it.napalm.trainingtennis.utils.Tools;
import it.napalm.trainingtennis.utils.CustomViewPager;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.view.KeyEvent;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends FragmentActivity {

	
	
	
	
	
	
	List<Fragment> fragments = new Vector<Fragment>();
	private PagerAdapter mPagerAdapter;
	private CustomViewPager mPager;
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main_pager);
		
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
		
		fragments.add(Fragment.instantiate(this,Footwork.class.getName()));
	    fragments.add(Fragment.instantiate(this,Scatto.class.getName()));
	    fragments.add(Fragment.instantiate(this,PaginaTre.class.getName()));
	    
	    this.mPagerAdapter = new PagerAdapter(super.getSupportFragmentManager(),fragments);
	    mPager = (CustomViewPager) super.findViewById(R.id.pager);
	    mPager.setAdapter(this.mPagerAdapter);
	    
	    mPager.setPagingEnabled(true);
	}
	

	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.mainmenu, menu);
		
		return true;
	}
	
	public boolean onKeyDown(int keyCode, KeyEvent event) {
	    if (keyCode == KeyEvent.KEYCODE_BACK) {
	    	moveTaskToBack(true);
	        return true;
	    }else {
	        return super.onKeyDown(keyCode, event);
	    }
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
	    switch (item.getItemId()) {
	    case R.id.action_settings:
	      Toast.makeText(this, "Selezionato tasto settaggi", Toast.LENGTH_SHORT)
	          .show();
	      Intent settingsActivity = new Intent(getBaseContext(),
                  Opzioni.class);
	      startActivity(settingsActivity);
	      break;
	    case R.id.action_exit:
	    	
	        finish();
	        System.exit(0);
	        return true;
	    default:
	      break;
	    }

	    return true;
	  }

	public void setPagingEnabled(boolean swipe){
		mPager.setPagingEnabled(swipe);
		//TODO
		mPager.setPagingEnabled(false);
	}
	
	

}
