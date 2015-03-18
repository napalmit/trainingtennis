'''
Created on 18/mar/2015

@author: Luigi
'''
from datetime import datetime
class DatiAcquisiti(object):
    SENSORE = ''
    DATA_ATTIVAZIONE = 0
    DATA_DISATTIVAZIONE = 0

    def __init__(self, aSensore):
        self.SENSORE = aSensore;
        self.DATA_ATTIVAZIONE = datetime.now()
    
    def DifferenceSeconds(self):
        return (self.DATA_ATTIVAZIONE - self.DATA_ATTIVAZIONE).microseconds
        