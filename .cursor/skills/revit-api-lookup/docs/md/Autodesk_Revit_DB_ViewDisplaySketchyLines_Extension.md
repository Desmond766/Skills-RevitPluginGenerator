---
kind: property
id: P:Autodesk.Revit.DB.ViewDisplaySketchyLines.Extension
source: html/5ac2ce35-d2a8-4074-ef33-5093b7e960aa.htm
---
# Autodesk.Revit.DB.ViewDisplaySketchyLines.Extension Property

The extension scale value. Controls the magnitude of line's extension.
 Values between 0 and 10.

## Syntax (C#)
```csharp
public int Extension { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The extension value is not valid. The valid range is 0 to 10.

