---
kind: property
id: P:Autodesk.Revit.DB.SynchronizeWithCentralOptions.IsValidObject
source: html/03ced8e5-beb5-1582-b43c-5a97b937578c.htm
---
# Autodesk.Revit.DB.SynchronizeWithCentralOptions.IsValidObject Property

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

