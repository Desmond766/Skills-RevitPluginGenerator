---
kind: property
id: P:Autodesk.Revit.DB.SubTransaction.IsValidObject
source: html/62b0bb2e-0c8e-9b81-3c72-1703237b6c5b.htm
---
# Autodesk.Revit.DB.SubTransaction.IsValidObject Property

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

