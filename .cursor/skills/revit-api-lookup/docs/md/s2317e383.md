---
kind: property
id: P:Autodesk.Revit.DB.ViewDisplaySketchyLines.IsValidObject
source: html/4f5a90c1-ef66-cf40-c88e-51c531a01e52.htm
---
# Autodesk.Revit.DB.ViewDisplaySketchyLines.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

