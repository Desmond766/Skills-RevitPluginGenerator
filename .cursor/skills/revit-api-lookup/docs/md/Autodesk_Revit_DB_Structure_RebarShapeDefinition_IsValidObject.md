---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDefinition.IsValidObject
source: html/47e5ab9c-5b4a-fc69-6745-89b296cc0900.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.IsValidObject Property

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

