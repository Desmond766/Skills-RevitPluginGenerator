---
kind: property
id: P:Autodesk.Revit.DB.ImportIFCOptions.IsValidObject
source: html/067c4795-caea-ea8b-cbd6-d5c2c55068fb.htm
---
# Autodesk.Revit.DB.ImportIFCOptions.IsValidObject Property

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

