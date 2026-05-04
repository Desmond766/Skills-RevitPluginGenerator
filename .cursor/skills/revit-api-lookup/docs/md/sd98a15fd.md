---
kind: property
id: P:Autodesk.Revit.DB.LinkOperations.IsValidObject
source: html/5ae89d17-e1ff-2a14-9929-562a5555d78b.htm
---
# Autodesk.Revit.DB.LinkOperations.IsValidObject Property

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

