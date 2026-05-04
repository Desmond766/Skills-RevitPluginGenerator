---
kind: property
id: P:Autodesk.Revit.DB.Electrical.ConduitSizeIterator.IsValidObject
source: html/37298f2f-df19-876f-8d93-4e2a197b3fa3.htm
---
# Autodesk.Revit.DB.Electrical.ConduitSizeIterator.IsValidObject Property

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

