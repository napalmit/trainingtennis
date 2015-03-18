'''
Created on 18/mar/2015

@author: Luigi
'''
import serial
from it.napalm.core.progettihwsw.Comandi import Comandi
from it.napalm.core.progettihwsw.Risposte import Risposte
class ReleUSB(object):
    COM = ''
    SERIAL = 0
    TEST = '1'
    
    def __init__(self, comPort):
        print('ISt')
        self.COM = comPort
        
    def Connect(self):
        try:
            self.SERIAL = serial.Serial(
                port=self.COM,
                baudrate=115200,
                parity=serial.PARITY_NONE,
                stopbits=serial.STOPBITS_ONE,
                bytesize=serial.EIGHTBITS
            )
            if self.SERIAL.isOpen() :
                self.SERIAL.close()
            self.SERIAL.open()
            print(self.TEST)
            t = LetturaSeriale(self)
            t.start()
            time.sleep(1)
            self.InviaComando('0')
            
            while True:
                time.sleep(.5)
                print(self.TEST)
        except Exception as e :
            print("errore serial: " +  str(e))
            
    def Clean(self):
        try:
            self.SERIAL.flushInput()
            self.SERIAL.flushOutput()
        except Exception as e :
            print("errore Clean: " +  str(e))
            
    def InviaComando(self, command):
        try:
            print('invio:' + command)
            self.Clean()
            self.SERIAL.write(command.encode('utf-8'))
        except Exception as e :
            print("errore InviaComando: " +  str(e))
            
    def Close(self):
        try:
            if self.SERIAL.isOpen() :
                self.SERIAL.close()
        except Exception as e :
            print("errore Close: " +  str(e))
            
    def GetCmdAndResponse(self, sensorNumber):
        lista = []
        try:
            if sensorNumber == 1:
                lista[Comandi.AccendiRelay1];
                lista[Risposte.AccendiRelay1];
                lista[Comandi.SpegniRelay1];
                lista[Risposte.SpegniRelay1];
                lista[Comandi.Ingresso1];
                lista[Risposte.Ingresso1Alto];
                lista[Risposte.Ingresso1Basso];
            elif sensorNumber == 2:
                lista[Comandi.AccendiRelay2];
                lista[Risposte.AccendiRelay2];
                lista[Comandi.SpegniRelay2];
                lista[Risposte.SpegniRelay2];
                lista[Comandi.Ingresso2];
                lista[Risposte.Ingresso2Alto];
                lista[Risposte.Ingresso2Basso];
            elif sensorNumber == 3:
                lista[Comandi.AccendiRelay3];
                lista[Risposte.AccendiRelay3];
                lista[Comandi.SpegniRelay3];
                lista[Risposte.SpegniRelay3];
                lista[Comandi.Ingresso3];
                lista[Risposte.Ingresso3Alto];
                lista[Risposte.Ingresso3Basso];
            elif sensorNumber == 4:
                lista[Comandi.AccendiRelay4];
                lista[Risposte.AccendiRelay4];
                lista[Comandi.SpegniRelay4];
                lista[Risposte.SpegniRelay4];
                lista[Comandi.Ingresso4];
                lista[Risposte.Ingresso4Alto];
                lista[Risposte.Ingresso4Basso];
        except Exception as e :
            print("errore GetCmdAndResponse: " +  str(e))
            
        return lista
  
import threading 
import time
class LetturaSeriale(threading.Thread):
    RELE = 0;
    def __init__(self, releUSB):
        threading.Thread.__init__(self)
        self.RELE = releUSB
    
    def run(self):
        try:
            while True:
                last = ''
                for byte in self.RELE.SERIAL.read(self.RELE.SERIAL.inWaiting()): 
                    last += chr(byte)
                    test = bytes(last, "utf-8").decode("utf-8")
                    if test == 'A' :
                        self.RELE.TEST = '2'
                    if len(last) > 0:
                        last = ''
        except Exception as e :
            print("errore run LetturaSeriale:  " +  str(e))


if __name__ == "__main__":
    rele = ReleUSB('COM14')

    rele.Connect()
