---
kind: property
id: P:Autodesk.Revit.DB.RepeaterBounds.IsValidObject
source: html/f8937f4f-7010-a79c-f08f-4f76ff90b33c.htm
---
# Autodesk.Revit.DB.RepeaterBounds.IsValidObject Property

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

