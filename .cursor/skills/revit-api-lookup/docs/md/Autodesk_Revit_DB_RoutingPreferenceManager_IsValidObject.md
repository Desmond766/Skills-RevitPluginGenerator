---
kind: property
id: P:Autodesk.Revit.DB.RoutingPreferenceManager.IsValidObject
source: html/7a555e3e-7c0f-bd48-e4ff-9102a321ba52.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.IsValidObject Property

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

