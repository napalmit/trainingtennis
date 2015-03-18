'''
Created on 18/mar/2015

@author: Luigi
'''
from it.napalm.core.object.StatoSensore import StatoSensore
class Sensore(object):
    ID = 0
    NAME = ''
    STATO = 0

    def __init__(self):
        self.STATO = StatoSensore.DISATTIVO
        
    def CaricaComandi(self, aComandi):
        self.CmdAccendi = aComandi[0]
        self.RitornoAccendi = aComandi[1]
        self.CmdSpegni = aComandi[2]
        self.RitornoSpegni = aComandi[3]
        self.CmdIngresso = aComandi[4]
        self.IngressoAlto = aComandi[5]
        self.IngressoBasso = aComandi[6]
        
    CmdAccendi = ''
    RitornoAccendi = ''
    CmdSpegni = ''
    RitornoSpegni = ''
    CmdIngresso = ''
    IngressoAlto = ''
    IngressoBasso = ''
    
    def Accendi(self):
        return self.CmdAccendi
    
    def Spegni(self):
        return self.CmdSpegni
    
    def Ingresso(self):
        return self.CmdIngresso
        