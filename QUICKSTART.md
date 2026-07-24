# NBoard - Quick Start Guide

## 🚀 Get Started in 5 Minutes

### Step 1: Download & Install (2 minutes)

1. Go to: [NBoard Releases](https://github.com/naajmul/NBoard/releases)
2. Download: `NBoard-Setup.msi`
3. Double-click the installer
4. Follow the wizard
5. Click "Finish"

✅ **NBoard is now installed with desktop shortcut!**

---

### Step 2: Launch NBoard (30 seconds)

**Option A: Desktop Shortcut**
- Double-click "NBoard" icon on your desktop

**Option B: Start Menu**
- Press Windows key
- Type "NBoard"
- Press Enter

---

### Step 3: Create Your First Document (1 minute)

**Welcome Screen:**
```
┌─────────────────────────────────────────┐
│  NBoard - Professional Whiteboard       │
├─────────────────────────────────────────┤
│                                         │
│  [+ Create New Document]                │
│                                         │
│  Recent Documents:                      │
│  (None yet)                             │
│                                         │
│  [📁 Open File]  [⚙️ Settings]          │
└─────────────────────────────────────────┘
```

1. Click **"+ Create New Document"**
2. Canvas opens with blank page
3. Start drawing! 🎨

---

## 🎯 Essential Controls

### Drawing Tools (Toolbar)

| Tool | Icon | How to Use |
|------|------|----------|
| **Pen** | ✏️ | Click & draw on canvas |
| **Eraser** | 🗑️ | Click to erase |
| **Line** | 📏 | Click & drag |
| **Circle** | ⭕ | Click & drag for size |
| **Rectangle** | ▭ | Click & drag |
| **Square** | ■ | Click & drag (1:1 ratio) |
| **Triangle** | △ | Click & drag |
| **Hexagon** | ⬡ | Click & drag |
| **Pentagon** | ⬠ | Click & drag |
| **Text** | 📝 | Click to place text |

### Color & Size

```
[Color Button] ← Click to change pen color
[Size Slider: 1 ───────── 50] ← Adjust thickness
```

### Undo/Redo

```
[↶ Undo]  [↷ Redo]
```

- **Undo:** Ctrl+Z (revert last action)
- **Redo:** Ctrl+Y (redo undone action)

---

## 📋 Menu Options

### File Menu

```
📄 File
  ├─ New Document (Ctrl+N)
  ├─ Open Document (Ctrl+O)
  ├─ Save (Ctrl+S)
  ├─ Export
  │  ├─ PDF
  │  ├─ PNG
  │  ├─ SVG
  │  └─ JSON
  └─ Exit
```

### Edit Menu

```
✏️ Edit
  ├─ Undo (Ctrl+Z)
  ├─ Redo (Ctrl+Y)
  └─ Clear All (Delete)
```

### Tools Menu

```
🛠️ Tools
  ├─ Pen
  ├─ Eraser
  └─ Text
```

---

## ⌨️ Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| **Ctrl+N** | New Document |
| **Ctrl+O** | Open Document |
| **Ctrl+S** | Save Document |
| **Ctrl+Z** | Undo |
| **Ctrl+Y** | Redo |
| **Ctrl+E** | Export |
| **Delete** | Clear All |
| **Escape** | Deselect Tool |

---

## 💾 Auto-Save

✅ **NBoard automatically saves every 30 seconds**

- No manual save needed
- All documents saved in:
  ```
  C:\Users\[YourUsername]\Documents\NBoard\
  ```
- File format: `.wbd` (proprietary JSON-based)

---

## 📁 Manage Documents

### Open Recent Document

1. Launch NBoard
2. Welcome screen shows recent files
3. Click **"Open"** next to document name
4. Continue working!

### Delete Document

1. Welcome screen → Recent Documents
2. Click **"Delete"** button
3. Confirm deletion
4. Document removed

### Create New Document

1. Welcome screen → **"+ Create New Document"**
2. OR: While drawing → **File → New Document**
3. New blank canvas opens

---

## 🎨 Drawing Tips

### Basic Drawing

```
1. Select tool from toolbar
2. Adjust color (if needed)
3. Adjust size/thickness
4. Draw on canvas
5. Auto-saves every 30 seconds
```

### Change Colors

```
1. Click [Color Button] (black square in toolbar)
2. Windows color picker opens
3. Choose color
4. Click OK
5. Pen/shape now uses new color
```

### Adjust Size

```
1. Move [Size Slider] left/right
2. Size number updates in real-time
3. Draw with new size
```

### Undo Mistakes

```
1. Press Ctrl+Z (or click ↶ Undo button)
2. Last action removed
3. Can undo multiple times
4. Press Ctrl+Y to redo
```

---

## 📤 Export Your Work

### Save as PDF (for printing)

```
File → Export → Export as PDF
├─ Choose save location
├─ Enter filename
└─ Click Save
```

### Save as Image (PNG)

```
File → Export → Export as PNG
├─ Choose save location
├─ Enter filename
└─ Click Save
```

### Save as Vector (SVG)

```
File → Export → Export as SVG
├─ Choose save location
├─ Enter filename
└─ Click Save
```

### Save Project (JSON)

```
File → Export → Export as JSON
├─ Contains all layers and properties
├─ Import back into NBoard
└─ Full project backup
```

---

## ❓ Common Questions

### Q: Where are my documents saved?
**A:** `C:\Users\[YourUsername]\Documents\NBoard\`

### Q: Can I recover a deleted document?
**A:** If you deleted recently, check the Recycle Bin. Otherwise, no automatic recovery.

### Q: How do I create a shortcut on my desktop?
**A:** Already created during installation! If missing:
1. Right-click `NBoard.exe` from Program Files
2. Send to → Desktop (create shortcut)

### Q: Can I run NBoard on Mac/Linux?
**A:** Currently Windows only. Future versions may support other platforms.

### Q: How do I uninstall NBoard?
**A:** 
1. Settings → Apps → Apps & features
2. Find "NBoard" → Uninstall
3. Follow wizard

### Q: Does NBoard save automatically?
**A:** Yes! Every 30 seconds. No manual save needed.

### Q: What file format are documents saved in?
**A:** `.wbd` (JSON-based proprietary format). Can export to PDF, PNG, SVG, or JSON.

---

## 🆘 Troubleshooting

### NBoard won't start

✅ **Solution:** Install .NET 6.0 Runtime
- Go to: https://dotnet.microsoft.com/download/dotnet/6.0
- Download "Desktop Runtime"
- Install and restart PC

### Desktop shortcut missing

✅ **Solution:** Create manually
1. Open: `C:\Program Files\NBoard\`
2. Right-click `NBoard.exe`
3. Send to → Desktop (create shortcut)

### Can't save documents

✅ **Solution:** Check folder permissions
1. Right-click `C:\Users\[You]\Documents\NBoard`
2. Properties → Security → Edit
3. Give your user "Full Control"

### More issues?

📖 See: [TROUBLESHOOTING.md](TROUBLESHOOTING.md)

---

## 📚 Learn More

- 📖 **Full Features:** [README.md](README.md)
- 🔧 **Setup Guide:** [SETUP_GUIDE.md](SETUP_GUIDE.md)
- 📦 **Installer Guide:** [INSTALLER_GUIDE.md](INSTALLER_GUIDE.md)
- ❓ **Troubleshooting:** [TROUBLESHOOTING.md](TROUBLESHOOTING.md)
- 🐛 **Report Issues:** [GitHub Issues](https://github.com/naajmul/NBoard/issues)

---

## 🎉 Ready to Draw!

✅ Installation complete
✅ Desktop shortcut created
✅ Ready to create awesome drawings

**Double-click NBoard on your desktop and start creating! 🎨**

---

*Made with ❤️ by Naajmul Hassan*

**Version 1.0 | Updated July 24, 2024**