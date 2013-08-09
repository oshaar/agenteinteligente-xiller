
; PicBasic Pro Compiler 2.42, (c) 1998, 2002 microEngineering Labs, Inc. All Rights Reserved. 
PM_USED			EQU	1

	INCLUDE	"16F628.INC"

RAM_START       		EQU	00020h
RAM_END         		EQU	0014Fh
RAM_BANKS       		EQU	00003h
BANK0_START     		EQU	00020h
BANK0_END       		EQU	0007Fh
BANK1_START     		EQU	000A0h
BANK1_END       		EQU	000EFh
BANK2_START     		EQU	00120h
BANK2_END       		EQU	0014Fh
EEPROM_START    		EQU	02100h
EEPROM_END      		EQU	0217Fh

R0              		EQU	RAM_START + 000h
R1              		EQU	RAM_START + 002h
R2              		EQU	RAM_START + 004h
R3              		EQU	RAM_START + 006h
R4              		EQU	RAM_START + 008h
R5              		EQU	RAM_START + 00Ah
R6              		EQU	RAM_START + 00Ch
R7              		EQU	RAM_START + 00Eh
R8              		EQU	RAM_START + 010h
FLAGS           		EQU	RAM_START + 012h
GOP             		EQU	RAM_START + 013h
RM1             		EQU	RAM_START + 014h
RM2             		EQU	RAM_START + 015h
RR1             		EQU	RAM_START + 016h
RR2             		EQU	RAM_START + 017h
_W0              		EQU	RAM_START + 018h
_W1              		EQU	RAM_START + 01Ah
_W10             		EQU	RAM_START + 01Ch
_W11             		EQU	RAM_START + 01Eh
_W12             		EQU	RAM_START + 020h
_W2              		EQU	RAM_START + 022h
_W3              		EQU	RAM_START + 024h
_W4              		EQU	RAM_START + 026h
_W5              		EQU	RAM_START + 028h
_W6              		EQU	RAM_START + 02Ah
_W7              		EQU	RAM_START + 02Ch
_W8              		EQU	RAM_START + 02Eh
_W9              		EQU	RAM_START + 030h
_PORTL           		EQU	 PORTB
_PORTH           		EQU	 PORTA
_TRISL           		EQU	 TRISB
_TRISH           		EQU	 TRISA
_INS             		EQU	_PORTL
_OUTS            		EQU	_PORTL
_INL             		EQU	_PORTL
_INH             		EQU	_PORTH
_OUTL            		EQU	_PORTL
_OUTH            		EQU	_PORTH
_B0              		EQU	_W0
_B1              		EQU	_W0 + 001h
_B2              		EQU	_W1
_B3              		EQU	_W1 + 001h
_B4              		EQU	_W2
_B5              		EQU	_W2 + 001h
_B6              		EQU	_W3
_B7              		EQU	_W3 + 001h
_B8              		EQU	_W4
_B9              		EQU	_W4 + 001h
_B10             		EQU	_W5
_B11             		EQU	_W5 + 001h
_B12             		EQU	_W6
_B13             		EQU	_W6 + 001h
_B14             		EQU	_W7
_B15             		EQU	_W7 + 001h
_B16             		EQU	_W8
_B17             		EQU	_W8 + 001h
_B18             		EQU	_W9
_B19             		EQU	_W9 + 001h
_B20             		EQU	_W10
_B21             		EQU	_W10 + 001h
_B22             		EQU	_W11
_B23             		EQU	_W11 + 001h
_B24             		EQU	_W12
_B25             		EQU	_W12 + 001h
_pos             		EQU	_B3
_servo           		EQU	_B4
_W0_LOWBYTE      		EQU	_W0
_W0_HIGHBYTE     		EQU	_W0 + 001h
_W1_LOWBYTE      		EQU	_W1
_W1_HIGHBYTE     		EQU	_W1 + 001h
_W2_LOWBYTE      		EQU	_W2
_W2_HIGHBYTE     		EQU	_W2 + 001h
_W3_LOWBYTE      		EQU	_W3
_W3_HIGHBYTE     		EQU	_W3 + 001h
_W4_LOWBYTE      		EQU	_W4
_W4_HIGHBYTE     		EQU	_W4 + 001h
_W5_LOWBYTE      		EQU	_W5
_W5_HIGHBYTE     		EQU	_W5 + 001h
_W6_LOWBYTE      		EQU	_W6
_W6_HIGHBYTE     		EQU	_W6 + 001h
_W7_LOWBYTE      		EQU	_W7
_W7_HIGHBYTE     		EQU	_W7 + 001h
_W8_LOWBYTE      		EQU	_W8
_W8_HIGHBYTE     		EQU	_W8 + 001h
_W9_LOWBYTE      		EQU	_W9
_W9_HIGHBYTE     		EQU	_W9 + 001h
_W10_LOWBYTE     		EQU	_W10
_W10_HIGHBYTE    		EQU	_W10 + 001h
_W11_LOWBYTE     		EQU	_W11
_W11_HIGHBYTE    		EQU	_W11 + 001h
_W12_LOWBYTE     		EQU	_W12
_W12_HIGHBYTE    		EQU	_W12 + 001h
#define _IN0             	_INL_0
#define _IN1             	_INL_1
#define _IN2             	_INL_2
#define _IN3             	_INL_3
#define _IN4             	_INL_4
#define _IN5             	_INL_5
#define _IN6             	_INL_6
#define _IN7             	_INL_7
#define _IN8             	_INH_0
#define _IN9             	_INH_1
#define _IN10            	_INH_2
#define _IN11            	_INH_3
#define _IN12            	_INH_4
#define _IN13            	_INH_5
#define _IN14            	_INH_6
#define _IN15            	_INH_7
#define _OUT0            	_OUTL_0
#define _OUT1            	_OUTL_1
#define _OUT2            	_OUTL_2
#define _OUT3            	_OUTL_3
#define _OUT4            	_OUTL_4
#define _OUT5            	_OUTL_5
#define _OUT6            	_OUTL_6
#define _OUT7            	_OUTL_7
#define _OUT8            	_OUTH_0
#define _OUT9            	_OUTH_1
#define _OUT10           	_OUTH_2
#define _OUT11           	_OUTH_3
#define _OUT12           	_OUTH_4
#define _OUT13           	_OUTH_5
#define _OUT14           	_OUTH_6
#define _OUT15           	_OUTH_7
#define _BIT0            	_B0_0
#define _BIT1            	_B0_1
#define _BIT2            	_B0_2
#define _BIT3            	_B0_3
#define _BIT4            	_B0_4
#define _BIT5            	_B0_5
#define _BIT6            	_B0_6
#define _BIT7            	_B0_7
#define _BIT8            	_B1_0
#define _BIT9            	_B1_1
#define _BIT10           	_B1_2
#define _BIT11           	_B1_3
#define _BIT12           	_B1_4
#define _BIT13           	_B1_5
#define _BIT14           	_B1_6
#define _BIT15           	_B1_7
#define _serpin          	_PORTA_0
#define _INL_0           	_INL, 000h
#define _INL_1           	_INL, 001h
#define _INL_2           	_INL, 002h
#define _INL_3           	_INL, 003h
#define _INL_4           	_INL, 004h
#define _INL_5           	_INL, 005h
#define _INL_6           	_INL, 006h
#define _INL_7           	_INL, 007h
#define _INH_0           	_INH, 000h
#define _INH_1           	_INH, 001h
#define _INH_2           	_INH, 002h
#define _INH_3           	_INH, 003h
#define _INH_4           	_INH, 004h
#define _INH_5           	_INH, 005h
#define _INH_6           	_INH, 006h
#define _INH_7           	_INH, 007h
#define _OUTL_0          	_OUTL, 000h
#define _OUTL_1          	_OUTL, 001h
#define _OUTL_2          	_OUTL, 002h
#define _OUTL_3          	_OUTL, 003h
#define _OUTL_4          	_OUTL, 004h
#define _OUTL_5          	_OUTL, 005h
#define _OUTL_6          	_OUTL, 006h
#define _OUTL_7          	_OUTL, 007h
#define _OUTH_0          	_OUTH, 000h
#define _OUTH_1          	_OUTH, 001h
#define _OUTH_2          	_OUTH, 002h
#define _OUTH_3          	_OUTH, 003h
#define _OUTH_4          	_OUTH, 004h
#define _OUTH_5          	_OUTH, 005h
#define _OUTH_6          	_OUTH, 006h
#define _OUTH_7          	_OUTH, 007h
#define _B0_0            	_B0, 000h
#define _B0_1            	_B0, 001h
#define _B0_2            	_B0, 002h
#define _B0_3            	_B0, 003h
#define _B0_4            	_B0, 004h
#define _B0_5            	_B0, 005h
#define _B0_6            	_B0, 006h
#define _B0_7            	_B0, 007h
#define _B1_0            	_B1, 000h
#define _B1_1            	_B1, 001h
#define _B1_2            	_B1, 002h
#define _B1_3            	_B1, 003h
#define _B1_4            	_B1, 004h
#define _B1_5            	_B1, 005h
#define _B1_6            	_B1, 006h
#define _B1_7            	_B1, 007h
#define _PORTA_0         	 PORTA, 000h
#define _PORTB_0         	 PORTB, 000h

; Constants.
_T2400           		EQU	00000h
_T1200           		EQU	00001h
_T9600           		EQU	00002h
_T300            		EQU	00003h
_N2400           		EQU	00004h
_N1200           		EQU	00005h
_N9600           		EQU	00006h
_N300            		EQU	00007h
_OT2400          		EQU	00008h
_OT1200          		EQU	00009h
_OT9600          		EQU	0000Ah
_OT300           		EQU	0000Bh
_ON2400          		EQU	0000Ch
_ON1200          		EQU	0000Dh
_ON9600          		EQU	0000Eh
_ON300           		EQU	0000Fh
_MSBPRE          		EQU	00000h
_LSBPRE          		EQU	00001h
_MSBPOST         		EQU	00002h
_LSBPOST         		EQU	00003h
_LSBFIRST        		EQU	00000h
_MSBFIRST        		EQU	00001h
_CLS             		EQU	00000h
_HOME            		EQU	00001h
_BELL            		EQU	00007h
_BKSP            		EQU	00008h
_TAB             		EQU	00009h
_CR              		EQU	0000Dh
_UnitOn          		EQU	00012h
_UnitOff         		EQU	0001Ah
_UnitsOff        		EQU	0001Ch
_LightsOn        		EQU	00014h
_LightsOff       		EQU	00010h
_Dim             		EQU	0001Eh
_Bright          		EQU	00016h
	INCLUDE	"SERVO5.MAC"
	INCLUDE	"PBPPIC14.LIB"

	MOVE?CB	0FFh, TRISA
	MOVE?CB	000h, TRISB

	LABEL?L	_start	
	SERPIN?T	_serpin
	SERMODE?C	_N2400
	SERIN?B	_pos

	LABEL?L	_move	
	PULSOUT?TB	_PORTB_0, _pos
	PAUSE?C	00Ah
	GOTO?L	_start

	END
