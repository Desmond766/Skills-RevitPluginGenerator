---
kind: property
id: P:Autodesk.Revit.DB.Structure.AnalyticalModelSelector.IsValidObject
source: html/03e3b3d9-40bc-dda4-4d48-bf5fdc4b324d.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalModelSelector.IsValidObject Property

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

