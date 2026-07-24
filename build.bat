@echo off
REM Build script for NBoard (Windows)

echo Building NBoard...
echo ==================
echo.

REM Clean previous builds
echo Cleaning previous builds...
rmdir /s /q bin 2>nul
rmdir /s /q obj 2>nul

REM Restore dependencies
echo Restoring NuGet packages...
dotnet restore
if errorlevel 1 (
    echo Restore failed!
    pause
    exit /b 1
)

REM Build Release
echo.
echo Building Release version...
dotnet build -c Release
if errorlevel 1 (
    echo Build failed!
    pause
    exit /b 1
)

echo.
echo ==================
echo Build completed successfully!
echo ==================
echo.
echo Executable location:
echo bin\Release\net6.0-windows\NBoard.exe
echo.
echo Run with: dotnet run -c Release
echo.
pause