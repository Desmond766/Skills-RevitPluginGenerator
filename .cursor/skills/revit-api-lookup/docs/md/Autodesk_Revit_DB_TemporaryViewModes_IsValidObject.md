---
kind: property
id: P:Autodesk.Revit.DB.TemporaryViewModes.IsValidObject
source: html/734d88c5-b94f-7ee6-436f-e5d92d4afce8.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.IsValidObject Property

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

