O1500
IF [#1 NE 0] GOTO 1
M53
#500 = 0.013
G05.1Q0
IF [#524 EQ 0] GOTO 2 (Recorrido Prueba)
#1104 = 1 (ACTIVA ORDEN EN F54.4)
WHILE [#1004 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G54.4)
END 1
N2 #1104 = 0
#500 = 0.014
#529 = 529+1
IF [#537 EQ 0] GOTO 1000000
#536 = #536+1
G05.1Q1
GOTO 1000000
N1
IF [#1 NE 1] GOTO 51
M53
#500 = 0.013
G05.1Q0
IF [#524 EQ 0] GOTO 52 (Recorrido Prueba)
#1104 = 1 (ACTIVA ORDEN EN F54.4)
WHILE [#1004 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G54.4)
END 1
N52 #1104 = 0
#500 = 0.014
#529 = 529+1
IF [#537 EQ 0] GOTO 1000000
#536 = #536+1
G05.1Q1
GOTO 1000000
N51
N1000000 M99
M30
%

O1501
IF [#1 NE 0] GOTO 1
M53
#500 = 0.023
#1108 = 1 (ACTIVA ORDEN EN F55.0)
WHILE [#1008 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G55.0)
END 1
#1108 = 0
M53
#500=0.024
GOTO 1000000
N1
IF [#1 NE 1] GOTO 51
M53
#500 = 0.023
#1108 = 1 (ACTIVA ORDEN EN F55.0)
WHILE [#1008 EQ 0] DO 1 (ESPERA A CONFIRMACION EN G55.0)
END 1
#1108 = 0
M53
#500=0.024
GOTO 1000000
N51
N1000000 M99
M30
%

O1502
M53
#500=0.011
M53

IF [#1 NE 0] GOTO 800 (Maquina indice = 0)
G92.1Z1=0
M14
IF [#3 EQ -1] GOTO 999999
IF [#505 NE 0.002] GOTO 1 (2 Cebado Contacto)
N2 IF [[#501 AND 1] NE 1] GOTO 3
M53
IF [[#501 AND 1] NE 1] GOTO 21
M53
G31 F[#506*60] Z1=-280
GOTO 999999
N21
N3
N1
IF [#505 NE 0.003] GOTO 101 (3 Altura fija)
N102 IF [[#501 AND 1] NE 1] GOTO 103
IF [[#501 AND 1] NE 1] GOTO 121
G01 F[#506*60] Z1=#509
GOTO 999999
N121
N103
N101
N800

IF [#1 NE 1] GOTO 1000 (Maquina indice = 1)
M14
IF [#3 EQ -1] GOTO 999999
IF [#505 NE 0.003] GOTO 201 (3 Altura fija)
N202 IF [[#501 AND 1] NE 1] GOTO 203
IF [[#501 AND 1] NE 1] GOTO 221
G01 F[#506*60] Z2=#509
GOTO 999999
N221
N203
N201
N1000

IF [#1 NE 2] GOTO 1100 (Maquina indice = 2)
G92.1Z1=0
G92.1Z3=0
M14
IF [#3 EQ -1] GOTO 999999
IF [#505 NE 0.002] GOTO 301 (2 Cebado Contacto)
N302 IF [[#501 AND 1] NE 1] GOTO 303
M53
IF [[#501 AND 4] NE 4] GOTO 322
M53
IF [[#501 AND 2] NE 2] GOTO 323
M53
IF [[#501 AND 1] NE 1] GOTO 321
M53
G31 F[#506*60] Z1=-280
GOTO 999999
N322 G31 F[#506*60] Z1=-280 Z2=-999989 Z3=-280 
GOTO 999999
N323 G31 F[#506*60] Z1=-280 Z2=-999989 
GOTO 999999
N321
N303 IF [[#501 AND 2] NE 2] GOTO 304
M53
IF [[#501 AND 4] NE 4] GOTO 342
M53
IF [[#501 AND 2] NE 2] GOTO 341
M53
G31 F[#506*60] Z2=-999989
GOTO 999999
N342 G31 F[#506*60] Z2=-999989 Z3=-280 
GOTO 999999
N341
N304 IF [[#501 AND 4] NE 4] GOTO 305
M53
IF [[#501 AND 4] NE 4] GOTO 361
M53
G31 F[#506*60] Z3=-280
GOTO 999999
N361
N305
N301
IF [#505 NE 0.003] GOTO 401 (3 Altura fija)
N402 IF [[#501 AND 1] NE 1] GOTO 403
IF [[#501 AND 4] NE 4] GOTO 422
IF [[#501 AND 2] NE 2] GOTO 423
IF [[#501 AND 1] NE 1] GOTO 421
G01 F[#506*60] Z1=#509
GOTO 999999
N422 G01 F[#506*60] Z1=#509 Z2=#509 Z3=#509 
GOTO 999999
N423 G01 F[#506*60] Z1=#509 Z2=#509 
GOTO 999999
N421
N403 IF [[#501 AND 2] NE 2] GOTO 404
IF [[#501 AND 4] NE 4] GOTO 442
IF [[#501 AND 2] NE 2] GOTO 441
G01 F[#506*60] Z2=#509
GOTO 999999
N442 G01 F[#506*60] Z2=#509 Z3=#509 
GOTO 999999
N441
N404 IF [[#501 AND 4] NE 4] GOTO 405
IF [[#501 AND 4] NE 4] GOTO 461
G01 F[#506*60] Z3=#509
GOTO 999999
N461
N405
N401
N1100
N999999 
M53
#500=0.012
M53
N1000000 M99
M30
%

O1503
N1000000 M99
M30
%

O1504
N1000000 M99
M30
%

O1505
IF [#1 NE 0] GOTO 1 (Máquina 0)
M53
#500=0.008
M53
IF [#519 EQ 1] GOTO 2
M11
M53
G92.1Y1=0.0(Reset Eje YY1=)
G00 Z1=0.0)
M10
M53
GOTO 51
N3 G91
M10
M53
G01 F12000Z1=#520
GOTO 51
N51 G90
M53
#500=0.009
M53
GOTO 1000000
N1
IF [#1 NE 1] GOTO 51 (Máquina 1)
M53
#500=0.008
M53
IF [#519 EQ 1] GOTO 52
M11
M53
G92.1Y2=0.0(Reset Eje YY2=)
G00 Z2=0.0)
M10
M53
GOTO 101
N53 G91
M10
M53
G01 F12000Z2=#520
GOTO 101
N101 G90
M53
#500=0.009
M53
GOTO 1000000
N51
IF [#1 NE 2] GOTO 101 (Máquina 2)
M53
#500=0.008
M53
IF [#519 EQ 1] GOTO 102
M11
M53
G92.1Y1=0.0(Reset Eje YY1=)
G92.1Y2=0.0(Reset Eje YY2=)
G92.1Y3=0.0(Reset Eje YY3=)
G00 Z1=0.0)
Z2=0.0)
Z3=0.0)
M10
M53
GOTO 151
N103 G91
M10
M53
G01 F12000Z1=#520
GOTO 151
N151 G90
M53
#500=0.009
M53
GOTO 1000000
N101
N1000000 M99
M30
%

