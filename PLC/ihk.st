PROGRAM program0
  VAR
    b5 AT %QX3.1 : BOOL;
    b3 AT %QX3.0 : BOOL;
    m1_links AT %QX8.1 : BOOL;
    m1_rechts AT %QX8.0 : BOOL;
    Notaus_Freigabe AT %QX3.3 : BOOL;
    Notaus_Quittierung AT %QX3.2 : BOOL;
    A_Zehner1 AT %QX10.4 : BOOL;
    A_Zehner2 AT %QX10.5 : BOOL;
    A_Zehner3 AT %QX10.6 : BOOL;
    A_Zehner4 AT %QX10.7 : BOOL;
    A_Einer0 AT %QX10.0 : BOOL;
    A_Einer1 AT %QX10.1 : BOOL;
    A_Einer2 AT %QX10.2 : BOOL;
    A_Einer3 AT %QX10.3 : BOOL;
  END_VAR

  m1_links := b5;
END_PROGRAM


CONFIGURATION Config0

  RESOURCE Res0 ON PLC
    TASK task0(INTERVAL := T#20ms,PRIORITY := 0);
    PROGRAM instance0 WITH task0 : program0;
  END_RESOURCE
END_CONFIGURATION
