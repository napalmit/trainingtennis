'''
Created on 18/mar/2015

@author: Luigi
'''

class Configurator(object):
    COM_PORT = '';
    NUMBER_OF_SENSOR = 0;
    VALORE_MINORE_PAUSA = 0;
    VALORE_MAGGIORE_PAUSA = 0;
    DURATA = 0;

    def __init__(self, comPort, numberOfSensor, valoreMinorePausa, valoreMaggiorePausa, durata):
        self.COM_PORT = comPort
        self.NUMBER_OF_SENSOR = numberOfSensor
        self.VALORE_MINORE_PAUSA = valoreMinorePausa
        self.VALORE_MAGGIORE_PAUSA = valoreMaggiorePausa
        self.DURATA = durata
        