
' Note, this code will work with the PicBasic Compiler, or the Basic Stamp
' for use with the PicBasic standard version
INCLUDE "bs2defs.bas"
symbol pos = b3
symbol servo = b4
trisa 	=	%11111111
trisb 	=	%00000000

serpin  VAR	porta.0 'serial input pin

start:
   serin serpin,N2400,pos 'get serial input from PC

move:
  
   pulsout portb.0,pos	' send data to position servos
   pause 10

  goto start		' do it again
