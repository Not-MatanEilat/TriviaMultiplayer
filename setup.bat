@echo off
if exist "C:\vcpkg" (
  echo Already installed vcpkg
  cd C:\vcpkg
  echo Installing cryptopp
  vcpkg install cryptopp
) else (
  echo Installing vcpkg
  cd C:\
  git clone https://github.com/Microsoft/vcpkg.git
  cd vcpkg
  bootstrap-vcpkg.bat
  vcpkg integrate install

  cd C:\vcpkg
  echo Installing cryptopp
  vcpkg install cryptopp

)
