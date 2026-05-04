---
kind: property
id: P:Autodesk.Revit.DB.ExportPatternKey.IsValidObject
source: html/ca1dfea5-3e2d-6497-e803-8d898e0c88ec.htm
---
# Autodesk.Revit.DB.ExportPatternKey.IsValidObject Property

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

