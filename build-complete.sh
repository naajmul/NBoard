#!/bin/bash
# Complete build and package script for NBoard
# This script builds the application and creates all distribution files

echo "===================================="
echo "NBoard - Complete Build & Package"
echo "===================================="
echo ""

# Clean previous builds
echo "[1/5] Cleaning previous builds..."
rm -rf bin/
rm -rf obj/
echo "     ✓ Cleaned"

# Restore dependencies
echo "[2/5] Restoring NuGet packages..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "     ✗ Restore failed!"
    exit 1
fi
echo "     ✓ Restored"

# Build Release
echo "[3/5] Building Release version..."
dotnet build -c Release
if [ $? -ne 0 ]; then
    echo "     ✗ Build failed!"
    exit 1
fi
echo "     ✓ Built"

# Create distribution folder
echo "[4/5] Creating distribution package..."
mkdir -p dist/NBoard
cp -r bin/Release/net6.0-windows/* dist/NBoard/
echo "     ✓ Package created"

# Summary
echo ""
echo "===================================="
echo "Build Complete!"
echo "===================================="
echo ""
echo "Output locations:"
echo "  💾 Executable: ./bin/Release/net6.0-windows/NBoard.exe"
echo "  📦 Package:    ./dist/NBoard/"
echo ""
echo "Next steps:"
echo "  1. Run: ./dist/NBoard/NBoard.exe"
echo "  2. To create installer, use WiX Toolset"
echo "  3. For easy distribution, use NBoard-Setup.msi"
echo ""
echo "Requirements to run:"
echo "  - Windows 10 or later"
echo "  - .NET 6.0 Desktop Runtime installed"
echo ""
echo "Happy drawing! 🎨"
