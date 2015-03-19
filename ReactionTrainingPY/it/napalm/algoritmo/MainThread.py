'''
Created on 19/mar/2015

@author: Luigi
'''
import time
import threading 
from threading import Lock
from it.napalm.core.object.Configurator import Configurator
from it.napalm.core.progettihwsw.ReleUSB import ReleUSB
from it.napalm.core.object.Sensore import Sensore
from it.napalm.core.object import StatoSensore

mutex = Lock()

class MainThread(object):
    CONFIGURATOR = 0
    RELE = 0
    LIST_SENSOR = []
    LIST_DATI_ACQUISITI = []
    SECONDS = 0
    CYCLE = True
    CYCLE_SECOND = True
    CYCLE_TIME = True

    def __init__(self, aConfigurator):
        self.CONFIGURATOR = aConfigurator
        self.InitProg()
        
    def InitProg(self):
        try :
            self.RELE = ReleUSB(self.CONFIGURATOR.COM_PORT)
            self.RELE.EventoDatoRicevuto += RicevoDato
            self.RELE.Connect()
            onetoten = range(1,self.CONFIGURATOR.NUMBER_OF_SENSOR+1)
            for count in onetoten:
                sensore = Sensore()
                sensore.ID = count
                sensore.NAME = "sensore numero " + str(count)
                sensore.STATO = StatoSensore.DISATTIVO
                sensore.CaricaComandi(self.RELE.GetCmdAndResponse(count))
                self.RELE.InviaComando(sensore.Spegni())
                self.LIST_SENSOR.append(sensore)
            time.sleep(1)   
        except Exception as e :
            print("MainThread InitProg: " +  str(e))
    
    def Start(self):
        try:
            #self.CountDownStart(300)
            
            self.SECONDS = self.CONFIGURATOR.DURATA / 1000
            
            '''istanziare thread del tempo'''
            
            '''istanziare thread per invio dei dati'''
            
            '''main'''
            t = ThreadPrimario(self)
            t.start()
                
        
        except Exception as e :
            print("errore CountDownStart:  " +  str(e))

    def CountDownStart(self, millisec):
        try:
            onetoten = range(1,4)
            for count in onetoten:
                for sensore in self.LIST_SENSOR:
                    self.RELE.InviaComando(sensore.Accendi())
                time.sleep(millisec / 1000)
                for sensore in self.LIST_SENSOR:
                    self.RELE.InviaComando(sensore.Spegni())
                time.sleep(1 - (millisec / 1000))
                
        except Exception as e :
            print("errore CountDownStart:  " +  str(e))
            


def RicevoDato(dato):
    if dato.isalpha() :
        print ("Ricevo: " + dato)
        
class ThreadPrimario(threading.Thread):
    MAIN_THREAD = 0
    def __init__(self, aMainThread):
        threading.Thread.__init__(self)
        self.MAIN_THREAD = aMainThread
    
    def run(self):
        try:
            while self.MAIN_THREAD.CYCLE:
                mutex.acquire()
                print ('A')
                time.sleep(1)
                #mutex.release()
                mutex.release()
                self.MAIN_THREAD.CYCLE_SECOND = True
                t = ThreadSecondo(self.MAIN_THREAD)
                t.start()
                
                
        except Exception as e :
            print("errore run ThreadPrimario:  " +  str(e))
            
class ThreadSecondo(threading.Thread):
    MAIN_THREAD = 0
    def __init__(self, aMainThread):
        threading.Thread.__init__(self)
        self.MAIN_THREAD = aMainThread
    
    def run(self):
        try:
            #print(self.MAIN_THREAD.CYCLE_SECOND)
            mutex.acquire()
            while self.MAIN_THREAD.CYCLE_SECOND:                
                print ('B')
                time.sleep(2)
                self.MAIN_THREAD.CYCLE_SECOND = False
            mutex.release() 
        except Exception as e :
            print("errore run ThreadSecondo:  " +  str(e))

class ThreadTempo(threading.Thread):
    def __init__(self):
        threading.Thread.__init__(self)
    
    def run(self):
        try:
            print('A')
        except Exception as e :
            print("errore run ThreadTempo:  " +  str(e))
        

if __name__ == "__main__":
    print('start')
    conf = Configurator('COM14', 1, 800, 2000, 60)
    
    main = MainThread(conf)
    main.Start()