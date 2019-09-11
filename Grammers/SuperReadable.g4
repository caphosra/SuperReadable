grammar SuperReadable;

// -------------------------------
//
//          Parser
//
// -------------------------------

file
    : statement* EOF
    ;

statement
    : SHOW_PHRASE NAME STATEMENT_FINISH                                             # PrintStatement
    | IF_PHRASE expr DO_FOLLOWINGS_PHRASE (statement)* THAT_ALL_PHRASE STATEMENT_FINISH      # IfStatement
    | REPEAT_PHRASE (statement)* THAT_ALL_PHRASE STATEMENT_FINISH                   # RepeatStatement
    | GO_OUT_PHRASE STATEMENT_FINISH                                                # GoOutStatement
    | CALCULATE_PHRASE expr STATEMENT_FINISH                                        # CalculateStatement
    | SET_RESULT_PHRASE NAME STATEMENT_FINISH                                       # SetResultStatement
    ;

expr
    : NUMBER                                                                        # NumberExpr
    | NAME                                                                          # ParameterExpr
    | NAME RIGHT_BRANCKET expr LEFT_BRANCKET                                        # FunctionExpr
    | RIGHT_BRANCKET expr LEFT_BRANCKET                                             # BrancketExpr // Not implemnted as a class
    | expr (MULTIPLE_OP | DIVSION_OP) expr                                          # MulExpr
    | expr (ADD_OP | MUINUS_OP) expr                                                # AddExpr
    ;

// -------------------------------
//
//          Lexer
//
// -------------------------------

STATEMENT_FINISH
    : '.'
    ;

//
// Phrases
//

SHOW_PHRASE
    : 'Show the value of'
    ;

IF_PHRASE
    : 'If there is non-negative that the answer of'
    ;

DO_FOLLOWINGS_PHRASE
    : ', then do the followings:'
    ;

REPEAT_PHRASE
    : 'Repeat the followings:'
    ;

GO_OUT_PHRASE
    : 'Go out of the loop'
    ;

THAT_ALL_PHRASE
    : 'That all'
    ;

CALCULATE_PHRASE
    : 'Calculate'
    ;

SET_RESULT_PHRASE
    : 'Set result to'
    ;

//
// Brackets
//

RIGHT_BRANCKET
    : '('
    ;

LEFT_BRANCKET
    : ')'
    ;

//
// Operators
//

ADD_OP
    : '+'
    ;

MUINUS_OP
    : '-'
    ;

MULTIPLE_OP
    : '*'
    ;

DIVSION_OP
    : '/'
    ;

EQUAL
    : '='
    ;

AND_OP
    : 'and'
    ;

OR_OP
    : 'or'
    ;

NOT_OP
    : 'not'
    ;

//
// Parameters
//

NAME
    : [a-zA-Z][a-zA-Z0-9]*
    ;

NUMBER
    : [0-9]+
    ;

WS
    : (' ' | '\r' | '\n' | '\t') -> skip
    ;

