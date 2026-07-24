#!/bin/bash
# Build script for NBoard

echo "Building NBoard..."
echo "=================="

# Clean previous builds
echo "Cleaning previous builds..."
rm -rf bin/
rm -rf obj/

# Restore dependencies
echo "Restoring NuGet packages..."
dotnet restore

# Build Release
echo "Building Release version..."
dotnet build -c Release

if [ $? -eq 0 ]; then
    echo ""
    echo "=================="
    echo "Build completed successfully!"
    echo "=================="
    echo ""
    echo "Executable location:"
    echo "./bin/Release/net6.0-windows/NBoard.exe"
    echo ""
    echo "Run with: dotnet run -c Release"
else
    echo "Build failed! Please check the errors above."
    exit 1
fi