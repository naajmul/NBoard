@echo off
REM Complete build and package script for NBoard
REM This script builds the application and creates all distribution files

setlocal enabledelayedexpansion

echo ====================================
echo NBoard - Complete Build ^& Package
echo ====================================
echo.

REM Clean previous builds
echo [1/5] Cleaning previous builds...
if exist bin rmdir /s /q bin >nul 2>&1
if exist obj rmdir /s /q obj >nul 2>&1
echo      ✓ Cleaned

REM Restore dependencies
echo [2/5] Restoring NuGet packages...
call dotnet restore
if errorlevel 1 (
    echo      ✗ Restore failed!
    pause
    exit /b 1
)
echo      ✓ Restored

REM Build Release
echo [3/5] Building Release version...
call dotnet build -c Release
if errorlevel 1 (
    echo      ✗ Build failed!
    pause
    exit /b 1
)
echo      ✓ Built

REM Create distribution folder
echo [4/5] Creating distribution package...
if not exist dist mkdir dist
if not exist dist\NBoard mkdir dist\NBoard
xcopy bin\Release\net6.0-windows\* dist\NBoard\ /E /I /Y >nul 2>&1
echo      ✓ Package created

REM Create README for distribution
echo [5/5] Creating distribution files...

(
echo NBoard v1.0.0
echo Professional Digital Whiteboard
echo.
echo INSTALLATION:
echo 1. Ensure .NET 6.0 Desktop Runtime is installed
echo    Download from: https://dotnet.microsoft.com/download/dotnet/6.0
echo.
echo 2. Double-click NBoard.exe to run
echo.
echo 3. To create desktop shortcut:
echo    - Right-click NBoard.exe
echo    - Send to ^> Desktop (create shortcut)
echo    - Rename to "NBoard"
echo.
echo FEATURES:
echo - Pen drawing with adjustable color and size
echo - Eraser tool
echo - Geometric shapes (line, circle, rectangle, square, triangle, etc.)
echo - Text tool
echo - Undo/Redo (Ctrl+Z / Ctrl+Y)
echo - Infinite scrolling
echo - Auto-save every 30 seconds
echo - Export to PDF, PNG, SVG, JSON
echo.
echo REQUIREMENTS:
echo - Windows 10 or later
echo - .NET 6.0 Desktop Runtime
echo - 200 MB disk space
echo.
echo DOCUMENTS SAVED IN:
echo C:\Users\[YourUsername]\Documents\NBoard\
echo.
echo Made with love by Naajmul
echo https://github.com/naajmul/NBoard
) > dist\NBoard\README.txt

echo      ✓ Distribution files created

echo.
echo ====================================
echo Build Complete!
echo ====================================
echo.
echo Output locations:
echo   ^!
echo   Executable: .\bin\Release\net6.0-windows\NBoard.exe
echo   ^!
echo   Package:    .\dist\NBoard\
echo.
echo Next steps:
echo   1. Run: .\dist\NBoard\NBoard.exe
echo   2. Or copy entire dist\NBoard folder to any location
echo   3. Double-click NBoard.exe to start
echo.
echo Requirements to run:
echo   - Windows 10 or later
echo   - .NET 6.0 Desktop Runtime installed
echo   - Download from: https://dotnet.microsoft.com/download/dotnet/6.0
echo.
echo Happy drawing! 🎨
echo.
pause
