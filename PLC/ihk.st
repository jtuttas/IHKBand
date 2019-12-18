PROGRAM program0
  VAR
    b3 AT %QX3.0 : BOOL;
    b5 AT %QX3.1 : BOOL;
    m4_hinten AT %QX3.2 : BOOL;
    m4_vorne AT %QX3.3 : BOOL;
    Notaus_Frei AT %QX3.4 : BOOL;
    Notaus_quit AT %QX3.5 : BOOL;
    s7 AT %QX3.6 : BOOL;
    s6 AT %QX3.7 : BOOL;
    s5 AT %QX4.0 : BOOL;
    autom_stop AT %QX4.1 : BOOL;
    s4 AT %QX4.2 : BOOL;
    s2 AT %QX4.3 : BOOL;
    quit_schutz0 AT %QX4.5 : BOOL;
    k0 AT %QX4.6 : BOOL;
    m1_rechts AT %QX8.0 : BOOL;
    m1_links AT %QX8.1 : BOOL;
    m1_rechts_schnell AT %QX8.2 : BOOL;
    m1_links_schnell AT %QX8.3 : BOOL;
    sm7 AT %QX8.4 : BOOL;
    sm6 AT %QX8.5 : BOOL;
    lm_hand_ein AT %QX8.6 : BOOL;
    lm_autom_ein AT %QX8.7 : BOOL;
    m4_vor AT %QX9.0 : BOOL;
    m4_zurueck AT %QX9.1 : BOOL;
    quit_schutz AT %QX9.2 : BOOL;
    A_Einer0 AT %QX10.0 : BOOL;
    A_Einer1 AT %QX10.1 : BOOL;
    A_Einer2 AT %QX10.2 : BOOL;
    A_Einer3 AT %QX10.3 : BOOL;
    A_Zehner1 AT %QX10.4 : BOOL;
    A_Zehner2 AT %QX10.5 : BOOL;
    A_Zehner3 AT %QX10.6 : BOOL;
    A_Zehner4 AT %QX10.7 : BOOL;
  END_VAR

  m1_links := b5;
  m4_zurueck := s7;
  m4_vor := s6;
END_PROGRAM


CONFIGURATION Config0

  RESOURCE Res0 ON PLC
    TASK task0(INTERVAL := T#20ms,PRIORITY := 0);
    PROGRAM instance0 WITH task0 : program0;
  END_RESOURCE
END_CONFIGURATION
