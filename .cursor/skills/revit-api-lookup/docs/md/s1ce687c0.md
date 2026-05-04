---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarTrimExtendData.IsValidObject
source: html/d6ff953d-24a5-5d33-cb47-0718a6edb20a.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData.IsValidObject Property

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

