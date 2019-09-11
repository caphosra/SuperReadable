@echo off

cd Grammers

call antlr4 SuperReadable.g4 -Dlanguage=Java
javac *.java
call grun SuperReadable file -gui

cd ../
