---
kind: property
id: P:Autodesk.Revit.DB.PolymeshTopology.IsValidObject
source: html/208bce7c-7b17-32d2-f54a-4f4691aaefd7.htm
---
# Autodesk.Revit.DB.PolymeshTopology.IsValidObject Property

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

