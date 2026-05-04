---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.DoDragDrop(System.Collections.Generic.ICollection{System.String})
source: html/d106ea67-b15a-9cca-d8c4-172f144108b5.htm
---
# Autodesk.Revit.UI.UIApplication.DoDragDrop Method

Initiates a drag and drop operation of a collection of file names on the Revit user interface.

## Syntax (C#)
```csharp
public static void DoDragDrop(
	ICollection<string> dropData
)
```

## Parameters
- **dropData** (`System.Collections.Generic.ICollection < String >`) - The list of file paths and names.

## Remarks
The behavior after the 'dragData' dragged onto Revit is listed bellow:
 Only one AutoCAD format or image file dragged onto Revit: a new import placement editor will be started for import the file; More than one AutoCAD format or image files dragged onto Revit: a new import placement editor will be started only for the first AutoCAD format or image file; Only one family file dragged onto Revit: the family will be loaded, and an editor will be started to place the family; More than one family files dragged onto Revit: all the families will be loaded; More than one family files including other format files dragged onto Revit: Revit will try to open all the files; If a valid file or list of files is passed, Revit will do its best to use them appropriately. If any files are not usable, failure will be signalled to the interactive Revit user (and will not be signalled to the application with an exception).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when dropData is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - Thrown when dropData contains a file that doens't exist.

