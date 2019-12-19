TYPE
  LOGLEVEL : (CRITICAL, WARNING, INFO, DEBUG) := INFO;
END_TYPE

FUNCTION_BLOCK LOGGER
  VAR_INPUT
    TRIG : BOOL;
    MSG : STRING;
    LEVEL : LOGLEVEL := INFO;
  END_VAR
  VAR
    TRIG0 : BOOL;
  END_VAR

  IF TRIG AND NOT TRIG0 THEN
  {{
   LogMessage(GetFbVar(LEVEL),(char*)GetFbVar(MSG, .body),GetFbVar(MSG, .len));
  }}
  END_IF;
  TRIG0:=TRIG;
END_FUNCTION_BLOCK



FUNCTION_BLOCK python_eval
  VAR_INPUT
    TRIG : BOOL;
    CODE : STRING;
  END_VAR
  VAR_OUTPUT
    ACK : BOOL;
    RESULT : STRING;
  END_VAR
  VAR
    STATE : DWORD;
    BUFFER : STRING;
    PREBUFFER : STRING;
    TRIGM1 : BOOL;
    TRIGGED : BOOL;
  END_VAR

  {extern void __PythonEvalFB(int, PYTHON_EVAL*);__PythonEvalFB(0, data__);}
END_FUNCTION_BLOCK

FUNCTION_BLOCK python_poll
  VAR_INPUT
    TRIG : BOOL;
    CODE : STRING;
  END_VAR
  VAR_OUTPUT
    ACK : BOOL;
    RESULT : STRING;
  END_VAR
  VAR
    STATE : DWORD;
    BUFFER : STRING;
    PREBUFFER : STRING;
    TRIGM1 : BOOL;
    TRIGGED : BOOL;
  END_VAR

  {extern void __PythonEvalFB(int, PYTHON_EVAL*);__PythonEvalFB(1,(PYTHON_EVAL*)(void*)data__);}
END_FUNCTION_BLOCK

FUNCTION_BLOCK python_gear
  VAR_INPUT
    N : UINT;
    TRIG : BOOL;
    CODE : STRING;
  END_VAR
  VAR_OUTPUT
    ACK : BOOL;
    RESULT : STRING;
  END_VAR
  VAR
    py_eval : python_eval;
    COUNTER : UINT;
    ADD10_OUT : UINT;
    EQ13_OUT : BOOL;
    SEL15_OUT : UINT;
    AND7_OUT : BOOL;
  END_VAR

  ADD10_OUT := ADD(COUNTER, 1);
  EQ13_OUT := EQ(N, ADD10_OUT);
  SEL15_OUT := SEL(EQ13_OUT, ADD10_OUT, 0);
  COUNTER := SEL15_OUT;
  AND7_OUT := AND(EQ13_OUT, TRIG);
  py_eval(TRIG := AND7_OUT, CODE := CODE);
  ACK := py_eval.ACK;
  RESULT := py_eval.RESULT;
END_FUNCTION_BLOCK


PROGRAM program0
  VAR
    b3 : BOOL;
    b5 : BOOL;
    m4_hinten : BOOL;
    m4_vorne : BOOL;
    Notaus_Frei : BOOL;
    Notaus_quit : BOOL;
    s7 : BOOL;
    s6 : BOOL;
    s5 : BOOL;
    autom_stop : BOOL;
    s4 : BOOL;
    s2 : BOOL;
    quit_schutz0 : BOOL;
    k0 : BOOL;
    m1_rechts : BOOL;
    m1_links : BOOL;
    m1_rechts_schnell : BOOL;
    m1_links_schnell : BOOL;
    sm7 : BOOL;
    sm6 : BOOL;
    lm_hand_ein : BOOL;
    lm_autom_ein : BOOL;
    m4_vor : BOOL;
    m4_zurueck : BOOL;
    quit_schutz : BOOL;
    A_Einer0 : BOOL;
    A_Einer1 : BOOL;
    A_Einer2 : BOOL;
    A_Einer3 : BOOL;
    A_Zehner1 : BOOL;
    A_Zehner2 : BOOL;
    A_Zehner3 : BOOL;
    A_Zehner4 : BOOL;
    TasterA : BOOL;
    TasterB : BOOL;
    LED_green : BOOL;
    LED_red : BOOL;
    LED_blue : BOOL;
  END_VAR
  VAR
    NOT14_OUT : BOOL;
    AND2_OUT : BOOL;
    AND12_OUT : BOOL;
    AND3_OUT : BOOL;
    AND1_OUT : BOOL;
  END_VAR

  LED_green := s2;
  NOT14_OUT := NOT(s2);
  LED_red := NOT14_OUT;
  AND2_OUT := AND(NOT(TasterA), NOT(s2));
  m1_rechts := AND2_OUT;
  AND12_OUT := AND(s7, NOT(s2));
  m4_zurueck := AND12_OUT;
  AND3_OUT := AND(NOT(TasterB), NOT(s2));
  m1_links := AND3_OUT;
  AND1_OUT := AND(s6, NOT(s2));
  m4_vor := AND1_OUT;
END_PROGRAM


CONFIGURATION Config0

  RESOURCE Res0 ON PLC
    TASK task0(INTERVAL := T#20ms,PRIORITY := 0);
    PROGRAM instance0 WITH task0 : program0;
  END_RESOURCE
END_CONFIGURATION
