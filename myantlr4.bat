@echo off

cd Grammers

call antlr4 SuperReadable.g4 -visitor -Dlanguage=CSharp

cd ../
