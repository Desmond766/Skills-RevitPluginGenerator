---
kind: type
id: T:Autodesk.Revit.UI.FileOpenDialog
source: html/efe4f212-6400-eaec-9263-1665ba9c163f.htm
---
# Autodesk.Revit.UI.FileOpenDialog

This class allows an add-in to prompt the user with the Revit dialog used to navigate to and select an existing
 file path. This dialog is typically used to select a file for opening or importing.

## Syntax (C#)
```csharp
public class FileOpenDialog : FileDialog
```

## Remarks
The behavior and appearance of this dialog matches the Revit "Open" dialog. This is a general-purpose dialog
 for opening any given file type, and options to configure settings like worksharing options will not be included. The user will be prompted to select an existing file that matches one of the provided filters. The user may not
 enter a file name that does not exist. The folder location shown when the dialog is displayed defaults to the most recently used file location
 for opening or importing. Use of this dialog does not actually open an existing file, but it will provide the selected file path
 back to the caller to take any action necessary.

