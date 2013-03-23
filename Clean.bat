cd "%1" 
del *.ncb *.suo *.scc *.user *.aps *.obj *.ilk *.pdb *.idb *.pch *.dep /s /f /a /q 
del *.exe.embed.* *.exe.inter* *.dll.embed.* *.dll.inter* /s /f /a /q 
del BuildLog.htm UpgradeReport*.* UpgradeLog.xml *.sln.old /s /f /a /q 
del *.svn-base all-wcprops entries dir-prop-base /s /f /a /q 
for /f "delims=" %%i in ('dir /ad /b /s') do call :rd_dir_empty "%%i" 
goto :eof 
rem ======= 删除空目录 ========= 
:rd_dir_empty 
rd %1 2>nul||goto :eof 
set dir_route=%1 
for /f "delims=" %%i in (%dir_route%) do ( 
set dir_route="%%~dpi" 
for /f "delims=" %%j in ('dir /ad /b "%%~dpi"')do rd "%%~dpi%%j" 2>nul||goto :eof 
) 
:: 把路径最后的\去掉，以便set route_deepest="%%~dpi"能取到上一层路径 
if "%dir_route:~-2,1%"=="\" set dir_route="%dir_route:~1,-2%" 
if /i not "%cd%"==%dir_route% call :rd_dir_empty %dir_route% 
goto :eof 