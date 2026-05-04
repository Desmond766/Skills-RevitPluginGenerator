---
kind: property
id: P:Autodesk.Revit.DB.AlphanumericRevisionSettings.IsValidObject
source: html/6155bd49-ab00-7961-a33b-397d739df218.htm
---
# Autodesk.Revit.DB.AlphanumericRevisionSettings.IsValidObject Property

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

