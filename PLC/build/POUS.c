void LOGGER_init__(LOGGER *data__, BOOL retain) {
  __INIT_VAR(data__->EN,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->ENO,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->TRIG,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->MSG,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->LEVEL,LOGLEVEL__INFO,retain)
  __INIT_VAR(data__->TRIG0,__BOOL_LITERAL(FALSE),retain)
}

// Code part
void LOGGER_body__(LOGGER *data__) {
  // Control execution
  if (!__GET_VAR(data__->EN)) {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(FALSE));
    return;
  }
  else {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(TRUE));
  }
  // Initialise TEMP variables

  if ((__GET_VAR(data__->TRIG,) && !(__GET_VAR(data__->TRIG0,)))) {
    #define GetFbVar(var,...) __GET_VAR(data__->var,__VA_ARGS__)
    #define SetFbVar(var,val,...) __SET_VAR(data__->,var,__VA_ARGS__,val)

   LogMessage(GetFbVar(LEVEL),(char*)GetFbVar(MSG, .body),GetFbVar(MSG, .len));
  
    #undef GetFbVar
    #undef SetFbVar
;
  };
  __SET_VAR(data__->,TRIG0,,__GET_VAR(data__->TRIG,));

  goto __end;

__end:
  return;
} // LOGGER_body__() 





void PYTHON_EVAL_init__(PYTHON_EVAL *data__, BOOL retain) {
  __INIT_VAR(data__->EN,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->ENO,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->TRIG,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->CODE,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->ACK,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->RESULT,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->STATE,0,retain)
  __INIT_VAR(data__->BUFFER,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->PREBUFFER,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->TRIGM1,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->TRIGGED,__BOOL_LITERAL(FALSE),retain)
}

// Code part
void PYTHON_EVAL_body__(PYTHON_EVAL *data__) {
  // Control execution
  if (!__GET_VAR(data__->EN)) {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(FALSE));
    return;
  }
  else {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(TRUE));
  }
  // Initialise TEMP variables

  __IL_DEFVAR_T __IL_DEFVAR;
  __IL_DEFVAR_T __IL_DEFVAR_BACK;
  #define GetFbVar(var,...) __GET_VAR(data__->var,__VA_ARGS__)
  #define SetFbVar(var,val,...) __SET_VAR(data__->,var,__VA_ARGS__,val)
extern void __PythonEvalFB(int, PYTHON_EVAL*);__PythonEvalFB(0, data__);
  #undef GetFbVar
  #undef SetFbVar
;

  goto __end;

__end:
  return;
} // PYTHON_EVAL_body__() 





void PYTHON_POLL_init__(PYTHON_POLL *data__, BOOL retain) {
  __INIT_VAR(data__->EN,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->ENO,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->TRIG,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->CODE,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->ACK,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->RESULT,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->STATE,0,retain)
  __INIT_VAR(data__->BUFFER,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->PREBUFFER,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->TRIGM1,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->TRIGGED,__BOOL_LITERAL(FALSE),retain)
}

// Code part
void PYTHON_POLL_body__(PYTHON_POLL *data__) {
  // Control execution
  if (!__GET_VAR(data__->EN)) {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(FALSE));
    return;
  }
  else {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(TRUE));
  }
  // Initialise TEMP variables

  __IL_DEFVAR_T __IL_DEFVAR;
  __IL_DEFVAR_T __IL_DEFVAR_BACK;
  #define GetFbVar(var,...) __GET_VAR(data__->var,__VA_ARGS__)
  #define SetFbVar(var,val,...) __SET_VAR(data__->,var,__VA_ARGS__,val)
extern void __PythonEvalFB(int, PYTHON_EVAL*);__PythonEvalFB(1,(PYTHON_EVAL*)(void*)data__);
  #undef GetFbVar
  #undef SetFbVar
;

  goto __end;

__end:
  return;
} // PYTHON_POLL_body__() 





void PYTHON_GEAR_init__(PYTHON_GEAR *data__, BOOL retain) {
  __INIT_VAR(data__->EN,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->ENO,__BOOL_LITERAL(TRUE),retain)
  __INIT_VAR(data__->N,0,retain)
  __INIT_VAR(data__->TRIG,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->CODE,__STRING_LITERAL(0,""),retain)
  __INIT_VAR(data__->ACK,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->RESULT,__STRING_LITERAL(0,""),retain)
  PYTHON_EVAL_init__(&data__->PY_EVAL,retain);
  __INIT_VAR(data__->COUNTER,0,retain)
  __INIT_VAR(data__->ADD10_OUT,0,retain)
  __INIT_VAR(data__->EQ13_OUT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->SEL15_OUT,0,retain)
  __INIT_VAR(data__->AND7_OUT,__BOOL_LITERAL(FALSE),retain)
}

// Code part
void PYTHON_GEAR_body__(PYTHON_GEAR *data__) {
  // Control execution
  if (!__GET_VAR(data__->EN)) {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(FALSE));
    return;
  }
  else {
    __SET_VAR(data__->,ENO,,__BOOL_LITERAL(TRUE));
  }
  // Initialise TEMP variables

  __SET_VAR(data__->,ADD10_OUT,,ADD__UINT__UINT(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (UINT)__GET_VAR(data__->COUNTER,),
    (UINT)1));
  __SET_VAR(data__->,EQ13_OUT,,EQ__BOOL__UINT(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (UINT)__GET_VAR(data__->N,),
    (UINT)__GET_VAR(data__->ADD10_OUT,)));
  __SET_VAR(data__->,SEL15_OUT,,SEL__UINT__BOOL__UINT__UINT(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (BOOL)__GET_VAR(data__->EQ13_OUT,),
    (UINT)__GET_VAR(data__->ADD10_OUT,),
    (UINT)0));
  __SET_VAR(data__->,COUNTER,,__GET_VAR(data__->SEL15_OUT,));
  __SET_VAR(data__->,AND7_OUT,,AND__BOOL__BOOL(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (BOOL)__GET_VAR(data__->EQ13_OUT,),
    (BOOL)__GET_VAR(data__->TRIG,)));
  __SET_VAR(data__->PY_EVAL.,TRIG,,__GET_VAR(data__->AND7_OUT,));
  __SET_VAR(data__->PY_EVAL.,CODE,,__GET_VAR(data__->CODE,));
  PYTHON_EVAL_body__(&data__->PY_EVAL);
  __SET_VAR(data__->,ACK,,__GET_VAR(data__->PY_EVAL.ACK,));
  __SET_VAR(data__->,RESULT,,__GET_VAR(data__->PY_EVAL.RESULT,));

  goto __end;

__end:
  return;
} // PYTHON_GEAR_body__() 





void PROGRAM0_init__(PROGRAM0 *data__, BOOL retain) {
  __INIT_VAR(data__->B3,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->B5,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M4_HINTEN,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M4_VORNE,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->NOTAUS_FREI,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->NOTAUS_QUIT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->S7,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->S6,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->S5,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->AUTOM_STOP,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->S4,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->S2,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->QUIT_SCHUTZ0,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->K0,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M1_RECHTS,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M1_LINKS,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M1_RECHTS_SCHNELL,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M1_LINKS_SCHNELL,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->SM7,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->SM6,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->LM_HAND_EIN,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->LM_AUTOM_EIN,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M4_VOR,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->M4_ZURUECK,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->QUIT_SCHUTZ,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_EINER0,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_EINER1,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_EINER2,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_EINER3,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_ZEHNER1,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_ZEHNER2,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_ZEHNER3,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->A_ZEHNER4,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->TASTERA,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->TASTERB,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->LED_GREEN,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->LED_RED,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->LED_BLUE,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->NOT14_OUT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->AND2_OUT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->AND12_OUT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->AND3_OUT,__BOOL_LITERAL(FALSE),retain)
  __INIT_VAR(data__->AND1_OUT,__BOOL_LITERAL(FALSE),retain)
}

// Code part
void PROGRAM0_body__(PROGRAM0 *data__) {
  // Initialise TEMP variables

  __SET_VAR(data__->,LED_GREEN,,__GET_VAR(data__->S2,));
  __SET_VAR(data__->,NOT14_OUT,,!(__GET_VAR(data__->S2,)));
  __SET_VAR(data__->,LED_RED,,__GET_VAR(data__->NOT14_OUT,));
  __SET_VAR(data__->,AND2_OUT,,AND__BOOL__BOOL(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (BOOL)!(__GET_VAR(data__->TASTERA,)),
    (BOOL)!(__GET_VAR(data__->S2,))));
  __SET_VAR(data__->,M1_RECHTS,,__GET_VAR(data__->AND2_OUT,));
  __SET_VAR(data__->,AND12_OUT,,AND__BOOL__BOOL(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (BOOL)__GET_VAR(data__->S7,),
    (BOOL)!(__GET_VAR(data__->S2,))));
  __SET_VAR(data__->,M4_ZURUECK,,__GET_VAR(data__->AND12_OUT,));
  __SET_VAR(data__->,AND3_OUT,,AND__BOOL__BOOL(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (BOOL)!(__GET_VAR(data__->TASTERB,)),
    (BOOL)!(__GET_VAR(data__->S2,))));
  __SET_VAR(data__->,M1_LINKS,,__GET_VAR(data__->AND3_OUT,));
  __SET_VAR(data__->,AND1_OUT,,AND__BOOL__BOOL(
    (BOOL)__BOOL_LITERAL(TRUE),
    NULL,
    (UINT)2,
    (BOOL)__GET_VAR(data__->S6,),
    (BOOL)!(__GET_VAR(data__->S2,))));
  __SET_VAR(data__->,M4_VOR,,__GET_VAR(data__->AND1_OUT,));

  goto __end;

__end:
  return;
} // PROGRAM0_body__() 





