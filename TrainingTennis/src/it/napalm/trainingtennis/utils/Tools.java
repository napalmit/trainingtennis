package it.napalm.trainingtennis.utils;

public class Tools {

	public static String creaStringaCronometro(long durateTime){
		String stringCronometro = "";		
		float durataTotaleSecondi = durateTime / 1000;
		int durataMinuti = (int)(durataTotaleSecondi / 60);
		int durataSecondi = (int) (durataTotaleSecondi - (durataMinuti * 60));
		String minutiString = durataMinuti+"";
		if(minutiString.length() == 1)
			minutiString = "0"+minutiString;
		String secondiString = durataSecondi+"";
		if(secondiString.length() == 1)
			secondiString = "0"+secondiString;
		stringCronometro = minutiString + ":" + secondiString;
		return stringCronometro;
	}
}
