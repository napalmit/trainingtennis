package it.napalm.trainingtennis.algoritmo;

import java.util.ArrayList;
import java.util.Random;

public class Algoritmo {

	private int modalitaAllenamento;
	ArrayList<Integer> listaDaEstrarre = new ArrayList<Integer>();
	ArrayList<Integer> listaNumeroUsciti = new ArrayList<Integer>();
	
	public Algoritmo(int modalitaAllenamento){
		this.modalitaAllenamento = modalitaAllenamento;
		initArray();
	}

	private void initArray() {
		if(modalitaAllenamento == ModalitaAllenamento.TRE_SPOSTAMENTI_80_20){
			listaDaEstrarre.add(TipologiaSpostamento.DESTRA);
			listaDaEstrarre.add(TipologiaSpostamento.SINISTRA);
			listaDaEstrarre.add(TipologiaSpostamento.DESTRA);
			listaDaEstrarre.add(TipologiaSpostamento.SINISTRA);
			listaDaEstrarre.add(TipologiaSpostamento.AVANTI);
			listaDaEstrarre.add(TipologiaSpostamento.DESTRA);
			listaDaEstrarre.add(TipologiaSpostamento.SINISTRA);
			listaDaEstrarre.add(TipologiaSpostamento.DESTRA);
			listaDaEstrarre.add(TipologiaSpostamento.SINISTRA);
		}		
	}
	
	public int Estrai()
    {
        int rnd = new Random().nextInt(listaDaEstrarre.size() - 1);
        int numeroUscito = listaDaEstrarre.get(rnd);
        listaNumeroUsciti.add(numeroUscito);
        return numeroUscito;
    }
}
