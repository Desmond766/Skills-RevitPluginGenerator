---
kind: property
id: P:Autodesk.Revit.DB.RenderNode.IsValidObject
source: html/5e642162-fd60-8697-24d2-b2c8574d4fb2.htm
---
# Autodesk.Revit.DB.RenderNode.IsValidObject Property

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

