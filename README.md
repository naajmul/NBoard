# NBoard - Professional Whiteboard Application

A feature-rich digital whiteboard application for Windows PC with pen drawing, shapes, text, infinite scrolling, and document management.

## Features

### Core Features
- ✅ **Pen Drawing** - Draw with adjustable color and size
- ✅ **Eraser** - Erase parts of your drawing with adjustable size
- ✅ **Geometric Shapes** - Line, Circle, Oval, Square, Rectangle, Triangle, Hexagon, Pentagon
- ✅ **Text Tool** - Add text with customizable size and color
- ✅ **Undo/Redo** - Full history with Ctrl+Z / Ctrl+Y
- ✅ **Infinite Scrolling** - Unlimited vertical pages connected seamlessly
- ✅ **Auto-Save** - Automatically saves every 30 seconds
- ✅ **Document Management** - View and open recent documents on startup
- ✅ **Export Options** - PDF, PNG, SVG, and custom JSON format

### Professional Features
- Start screen with recent documents list
- Keyboard shortcuts for all tools
- Professional menu bar (File, Edit, Tools, View, Help)
- Quick access toolbar
- Document versioning and recovery
- Professional installer (Setup.msi)

## Getting Started

### Prerequisites
- Windows 10 or later
- .NET 6.0 or higher
- Visual Studio 2022 (Community Edition is free)

### Installation
1. Clone this repository:
   ```bash
   git clone https://github.com/naajmul/NBoard.git
   cd NBoard
   ```

2. Open `NBoard.sln` in Visual Studio

3. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

4. Build the solution:
   ```bash
   dotnet build
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## Project Structure

```
NBoard/
├── Models/
│   ├── Document.cs          # Document model
│   └── DrawingAction.cs     # Drawing actions and tool types
├── Services/
│   ├── DocumentManager.cs   # Save/Load documents
│   ├── ExportService.cs     # Export to PDF, PNG, SVG, JSON
│   └── AutoSaveService.cs   # Auto-save functionality
├── Views/
│   ├── StartScreen.xaml     # Welcome screen
│   ├── StartScreen.xaml.cs  # Start screen logic
│   ├── CanvasWindow.xaml    # Drawing canvas
│   └── CanvasWindow.xaml.cs # Canvas logic
├── NBoard.csproj            # Project file
├── App.xaml                 # Application styles
├── App.xaml.cs              # Application entry point
└── README.md                # Documentation
```

## Usage

### Keyboard Shortcuts
- **Ctrl+N** - New Document
- **Ctrl+O** - Open Document
- **Ctrl+S** - Save Document
- **Ctrl+Z** - Undo
- **Ctrl+Y** - Redo
- **Ctrl+E** - Export
- **Delete** - Clear All
- **Escape** - Deselect Tool

### Tools
1. **Pen** ✏️ - Draw with adjustable color and size
2. **Eraser** 🗑️ - Erase drawings with adjustable size
3. **Shapes** 📐 - Draw geometric shapes (line, circle, rectangle, square, triangle, etc.)
4. **Text** 📝 - Add text with customizable size and color
5. **Scroll** - Scroll down to create unlimited pages

### Exporting Documents
- **PDF** - For printing and sharing
- **PNG** - For screenshots and web sharing
- **SVG** - For vector editing
- **JSON** - For saving project with all layers

## File Format

Documents are saved as `.wbd` files (JSON-based format):
```json
{
  "Id": "uuid-string",
  "Name": "My Drawing",
  "Created": "2024-07-24",
  "Modified": "2024-07-24",
  "Pages": [
    {
      "Id": 1,
      "Actions": [
        {
          "Type": "pen",
          "Color": "#000000",
          "Size": 3,
          "Points": [[x1,y1], [x2,y2], ...]
        }
      ]
    }
  ]
}
```

## Development

### Building from Source
```bash
git clone https://github.com/naajmul/NBoard.git
cd NBoard
dotnet build -c Release
```

### Running in Debug Mode
```bash
dotnet run
```

### Creating Installer
To create the setup.msi installer, you'll need WiX Toolset:
1. Install [WiX Toolset](https://wixtoolset.org/)
2. Build the solution in Release mode
3. Build the installer project

## Dependencies
- **Newtonsoft.Json** - For document serialization
- **iText7** - For PDF export functionality
- **WPF** - Windows Presentation Foundation (built-in)

## Settings
Settings are stored in:
```
C:\Users\[YourUsername]\Documents\NBoard\
```

## License
MIT License - Feel free to use and modify for personal or commercial use.

## Contributing
Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Submit a pull request

## Support & Issues
For bugs, feature requests, or questions:
- Create an [Issue](https://github.com/naajmul/NBoard/issues)
- Check existing issues first

## Roadmap
- [ ] Layers support
- [ ] Color palette presets
- [ ] Cloud sync
- [ ] Collaboration features
- [ ] Animation support
- [ ] Plugin system

---

**Made with ❤️ by Naajmul**

*Last Updated: July 24, 2024*