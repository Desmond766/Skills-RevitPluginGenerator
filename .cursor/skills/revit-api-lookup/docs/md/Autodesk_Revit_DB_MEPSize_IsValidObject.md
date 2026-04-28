---
kind: property
id: P:Autodesk.Revit.DB.MEPSize.IsValidObject
source: html/edb2b8b8-c54a-2a81-f12d-509a4a7998ee.htm
---
# Autodesk.Revit.DB.MEPSize.IsValidObject Property

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

