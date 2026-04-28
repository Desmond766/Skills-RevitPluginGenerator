---
kind: property
id: P:Autodesk.Revit.DB.InCanvasControlData.IsValidObject
source: html/c0d5263e-0680-9f7a-e084-79cbd6fbc6cb.htm
---
# Autodesk.Revit.DB.InCanvasControlData.IsValidObject Property

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

