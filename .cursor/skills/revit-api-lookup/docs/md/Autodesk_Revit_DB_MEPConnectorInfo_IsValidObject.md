---
kind: property
id: P:Autodesk.Revit.DB.MEPConnectorInfo.IsValidObject
source: html/4c4e13eb-20e5-ab5c-6211-71f7a8c8ae66.htm
---
# Autodesk.Revit.DB.MEPConnectorInfo.IsValidObject Property

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

