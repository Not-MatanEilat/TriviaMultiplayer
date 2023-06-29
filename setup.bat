@echo off
goto :main

REM Function to install vcpkg if it is not already installed
:install_vcpkg
  echo Installing vcpkg
  cd C:\
  git clone https://github.com/Microsoft/vcpkg.git
  cd vcpkg
  cmd /c bootstrap-vcpkg.bat
  vcpkg integrate install
goto :install_cryptopp

REM Function to install cryptopp
:install_cryptopp
  echo Installing cryptopp
  vcpkg install cryptopp
goto :eof

:main
REM Check if vcpkg is already installed
if exist "C:\vcpkg" (
  echo Already installed vcpkg
  cd C:\vcpkg
  call :install_cryptopp
) else (
  call :install_vcpkg
)