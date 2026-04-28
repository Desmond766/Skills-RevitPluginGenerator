---
kind: method
id: M:Autodesk.Revit.DB.BasicFileInfo.Extract(System.String)
source: html/05800394-0e43-45f2-6c89-0db484d6a98c.htm
---
# Autodesk.Revit.DB.BasicFileInfo.Extract Method

Returns an instance of BasicFileInfo filled with basic information about a Revit file located at the given file-path

## Syntax (C#)
```csharp
public static BasicFileInfo Extract(
	string file
)
```

## Parameters
- **file** (`System.String`) - The full path to the file to be queried, including project (.rvt) and family (.rfa) files.

## Returns
If successful, basic file data.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file doesn't exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The file is a newer format file where the structure of the BasicFileInfo storage has changed, or the file is saved in very old version of Revit without basic file data.

