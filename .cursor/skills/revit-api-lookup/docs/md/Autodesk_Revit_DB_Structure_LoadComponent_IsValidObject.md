---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadComponent.IsValidObject
source: html/8e2babbc-52b7-1f83-a8c1-49532e14a98b.htm
---
# Autodesk.Revit.DB.Structure.LoadComponent.IsValidObject Property

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

