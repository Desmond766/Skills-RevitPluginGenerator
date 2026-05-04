---
kind: property
id: P:Autodesk.Revit.DB.TriangulationInterface.IsValidObject
source: html/fa702810-f261-78ad-2a92-0a8adb259e0f.htm
---
# Autodesk.Revit.DB.TriangulationInterface.IsValidObject Property

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

