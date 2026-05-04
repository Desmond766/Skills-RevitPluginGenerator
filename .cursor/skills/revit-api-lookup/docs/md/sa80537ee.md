---
kind: property
id: P:Autodesk.Revit.DB.DimensionEqualityLabelFormatting.IsValidObject
source: html/b417e790-7051-0f89-026c-9f9e6ff8144a.htm
---
# Autodesk.Revit.DB.DimensionEqualityLabelFormatting.IsValidObject Property

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

