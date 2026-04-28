---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCAggregate.IsValidObject
source: html/ef4b2c85-dcaa-e66c-cec0-7c1b7b215403.htm
---
# Autodesk.Revit.DB.IFC.IFCAggregate.IsValidObject Property

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

