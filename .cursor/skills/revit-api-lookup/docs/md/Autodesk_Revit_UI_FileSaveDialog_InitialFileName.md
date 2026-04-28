---
kind: property
id: P:Autodesk.Revit.UI.FileSaveDialog.InitialFileName
source: html/1d50085a-d8f2-00d4-d067-828c4c17be54.htm
---
# Autodesk.Revit.UI.FileSaveDialog.InitialFileName Property

The initial file name to be shown for this save operation.

## Syntax (C#)
```csharp
public string InitialFileName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: initialFileName cannot include prohibited unprintable characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

