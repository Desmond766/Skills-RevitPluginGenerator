---
kind: property
id: P:Autodesk.Revit.DB.SlabShapeEditor.IsValidObject
source: html/ef4c3c30-e968-c860-8d38-ecfc2513f35f.htm
---
# Autodesk.Revit.DB.SlabShapeEditor.IsValidObject Property

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

