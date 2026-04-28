---
kind: property
id: P:Autodesk.Revit.DB.ImageType.Path
source: html/11e87696-9900-94f4-48f9-2e307dd9aae1.htm
---
# Autodesk.Revit.DB.ImageType.Path Property

The path to the file from which the ImageType was loaded.

## Syntax (C#)
```csharp
public string Path { get; }
```

## Remarks
The path string can be in one of several formats:
 absolute local, relative local, or server (indicating that the file was provided by an external
 server). The format is determined by PathType The path can be an empty string, for example for (but not limited to) ImageTypes created using
 "Save to Project as Image".

