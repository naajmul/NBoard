# Troubleshooting Guide

## Common Issues & Solutions

### 1. Application Won't Start

#### Error: "NBoard.exe has stopped working"

**Solution 1: Install .NET 6.0 Runtime**
```
https://dotnet.microsoft.com/download/dotnet/6.0
```
- Download "Desktop Runtime"
- Install and restart PC
- Try launching NBoard again

**Solution 2: Run as Administrator**
1. Right-click NBoard shortcut
2. Select "Run as administrator"
3. Click "Yes" on UAC prompt

**Solution 3: Reinstall Application**
```bash
# Uninstall
msiexec /x NBoard-Setup.msi /quiet

# Restart PC

# Reinstall
NBoard-Setup.msi (double-click)
```

---

### 2. Desktop Shortcut Issues

#### Shortcut not appearing after installation

**Solution:**
1. Navigate to: `C:\Program Files\NBoard\`
2. Right-click `NBoard.exe`
3. Click "Send to" → "Desktop (create shortcut)"
4. Rename to "NBoard"

#### Shortcut shows broken icon

**Solution:**
1. Right-click shortcut → Properties
2. Click "Change Icon"
3. Browse to: `C:\Program Files\NBoard\NBoard.exe`
4. Select icon and click OK

---

### 3. Document Saving Issues

#### "Cannot save document" error

**Solution 1: Check Folder Permissions**
```
C:\Users\[Username]\Documents\NBoard\
```
- Right-click folder → Properties
- Go to "Security" tab
- Click "Edit" and ensure your user has "Full Control"
- Click Apply → OK

**Solution 2: Run as Administrator**
1. Right-click NBoard shortcut
2. Select "Run as administrator"

**Solution 3: Check Disk Space**
- Ensure you have at least 1 GB free space on C: drive

---

### 4. Performance Issues

#### Application running slow / Freezing

**Solution 1: Reduce Undo History**
- Currently stores unlimited undo/redo
- Close and reopen NBoard to clear memory

**Solution 2: Clear Old Documents**
```
C:\Users\[Username]\Documents\NBoard\
```
- Delete old `.wbd` files
- This frees up disk space and memory

**Solution 3: Disable Auto-Save (if needed)**
- Edit `App.config`
- Change: `<add key="EnableAutoSave" value="false" />`

---

### 5. Export Issues

#### "Export failed" error

**PDF Export:**
- Ensure at least 50 MB free disk space
- Check if output folder is writable
- Try exporting to Desktop instead

**SVG/JSON Export:**
- Same as PDF - check permissions and disk space

**Solution:**
```bash
# Run with admin privileges
# Right-click NBoard → Run as administrator
```

---

### 6. Installation Issues

#### "Windows Installer not available" error

**Solution:**
```bash
# Re-register Windows Installer
msiexec /regserver

# Then try installing again
NBoard-Setup.msi
```

#### "Cannot install in Program Files" error

**Solution 1: Run as Administrator**
1. Right-click `NBoard-Setup.msi`
2. Select "Run as administrator"
3. Click Yes on UAC prompt

**Solution 2: Use Custom Installation Folder**
1. Run installer
2. Choose: `C:\Users\[Username]\AppData\Local\NBoard`
3. Continue with installation

---

### 7. Uninstallation Issues

#### Cannot uninstall NBoard

**Solution 1: Control Panel**
1. Go to Settings → Apps → Apps & features
2. Find "NBoard"
3. Click "Uninstall"
4. Follow wizard

**Solution 2: Manual Uninstall**
```bash
# Command line
msiexec /x NBoard-Setup.msi /quiet

# Then delete folders manually
rmdir "C:\Program Files\NBoard" /s /q
```

**Solution 3: Windows Troubleshooter**
1. Settings → System → Troubleshoot
2. Advanced options → Program Compatibility Troubleshooter
3. Select NBoard → Try recommended settings

---

### 8. File Format Issues

#### Cannot open `.wbd` file

**Solution:**
1. Update NBoard to latest version
2. File may be corrupted - try backup
3. Export to PDF/SVG before updating

#### File shows incorrect data

**Solution:**
1. Delete corrupted file
2. Create new document
3. Recreate content

---

### 9. Keyboard Shortcuts Not Working

#### Ctrl+Z (Undo) doesn't work

**Solution 1: Check Focus**
- Click inside canvas area first
- Then try keyboard shortcut

**Solution 2: Verify Shortcut**
- Menu → Edit → Undo (should show Ctrl+Z)
- If not listed, shortcut may be overridden

**Solution 3: Restart Application**
1. Close NBoard
2. Reopen NBoard
3. Try shortcut again

---

## Getting Help

### Check These First
1. ✅ .NET 6.0 Runtime installed
2. ✅ Administrator permissions
3. ✅ Disk space available (1+ GB)
4. ✅ Windows 10 or newer
5. ✅ Latest NBoard version

### Report Bug
📝 GitHub Issues: https://github.com/naajmul/NBoard/issues

**Include:**
- Windows version (Win10/Win11)
- .NET version: `dotnet --version`
- Error message (screenshot if possible)
- Steps to reproduce

### Log File Location
```
C:\Users\[Username]\AppData\Local\NBoard\logs\
```

---

## System Information

To check your system:

**Windows Version:**
```bash
winver
```

**.NET Version:**
```bash
dotnet --version
```

**Disk Space:**
```bash
df -h  (Mac/Linux)
dir C: (Windows)
```

**Administrator Status:**
```
Settings → System → About → Admin check
```

---

## Still Having Issues?

1. Check GitHub Issues: https://github.com/naajmul/NBoard/issues
2. Create new issue with details
3. Include screenshots and error messages
4. Be specific about steps to reproduce

**Happy Drawing! 🎨**