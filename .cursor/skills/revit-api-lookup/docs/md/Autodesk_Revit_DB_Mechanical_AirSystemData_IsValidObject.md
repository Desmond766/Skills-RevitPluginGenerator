---
kind: property
id: P:Autodesk.Revit.DB.Mechanical.AirSystemData.IsValidObject
source: html/0dbea7ba-2e36-06f6-bdf6-27da88b8b2dd.htm
---
# Autodesk.Revit.DB.Mechanical.AirSystemData.IsValidObject Property

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

