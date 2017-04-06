Reg Add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /V ProxyServer /D myproxy:80 /F
Reg Add "HKCU\Software\Microsoft\Windows\CurrentVersion\Internet Settings" /V ProxyEnable /T REG_DWORD /D 1 /F
pause