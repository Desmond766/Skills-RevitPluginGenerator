---
kind: property
id: P:Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIData.IsValidObject
source: html/6bce2de1-fa2e-94f1-5003-72bdb68eb671.htm
---
# Autodesk.Revit.UI.Mechanical.DuctFittingAndAccessoryPressureDropUIData.IsValidObject Property

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

