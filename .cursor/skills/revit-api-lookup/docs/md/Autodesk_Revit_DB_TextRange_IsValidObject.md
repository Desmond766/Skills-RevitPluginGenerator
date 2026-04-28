---
kind: property
id: P:Autodesk.Revit.DB.TextRange.IsValidObject
source: html/aea7c716-bcd2-ae9f-7587-adcf2fc756c4.htm
---
# Autodesk.Revit.DB.TextRange.IsValidObject Property

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

