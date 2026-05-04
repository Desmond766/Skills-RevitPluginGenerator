---
kind: property
id: P:Autodesk.Revit.DB.RepeatingReferenceSource.IsValidObject
source: html/0ec943f5-0a4c-e751-4410-23a018eee60d.htm
---
# Autodesk.Revit.DB.RepeatingReferenceSource.IsValidObject Property

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

