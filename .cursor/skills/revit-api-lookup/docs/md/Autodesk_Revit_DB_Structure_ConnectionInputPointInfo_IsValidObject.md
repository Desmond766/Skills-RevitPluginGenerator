---
kind: property
id: P:Autodesk.Revit.DB.Structure.ConnectionInputPointInfo.IsValidObject
source: html/061f00e9-3ee5-48b0-c75c-9736877d3179.htm
---
# Autodesk.Revit.DB.Structure.ConnectionInputPointInfo.IsValidObject Property

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

