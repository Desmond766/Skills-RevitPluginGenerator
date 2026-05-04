---
kind: type
id: T:Autodesk.Revit.UI.FileSaveDialog
source: html/afc7f52e-49ef-2c31-4414-9984b5fe456f.htm
---
# Autodesk.Revit.UI.FileSaveDialog

This class allows an add-in to prompt the user with the Revit dialog used to navigate to and select an existing
 or new file path. This dialog is typically used to enter a file name for saving or exporting.

## Syntax (C#)
```csharp
public class FileSaveDialog : FileDialog
```

## Remarks
The behavior and appearance of this dialog matches the Revit "Save as" dialog. This is a general-purpose dialog
 for saving any given file type, and the Options shown in the dialog for Revit projects and families will not be
 shown. To prompt the user to save the active Revit document specifically, use UIDocument.SaveAs(UISaveAsOptions) instead. The user will be requested to select or enter a file name matching the corresponding filter.
 If an existing file is selected, there will be
 a default prompt about overwriting the file shown, where the user can confirm or cancel this file selection. The folder location shown when the dialog is displayed defaults to the most recently used file location
 for saving or exporting. Use of this dialog does not actually save an existing file, but it will provide the selected file path
 back to the caller to take any action necessary.

