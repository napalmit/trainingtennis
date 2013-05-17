package it.napalm.trainingtennis;

import android.os.Bundle;
import android.preference.PreferenceActivity;

public class Opzioni extends PreferenceActivity {
    @SuppressWarnings("deprecation")
	@Override
    protected void onCreate(Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            addPreferencesFromResource(R.layout.opzioni);
            // Get the custom preference
            /*Preference customPref = (Preference) findPreference("customPref");
            customPref
                            .setOnPreferenceClickListener(new OnPreferenceClickListener() {

                                    public boolean onPreferenceClick(Preference preference) {
                                            SharedPreferences customSharedPreference = getSharedPreferences(
                                                            "myCustomSharedPrefs", Activity.MODE_PRIVATE);
                                            SharedPreferences.Editor editor = customSharedPreference
                                                            .edit();
                                            editor.putString("myCustomPref",
                                                            "The preference has been clicked");
                                            editor.commit();
                                            return true;
                                    }

                            });*/
    }
}

