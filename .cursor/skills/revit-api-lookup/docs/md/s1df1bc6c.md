---
kind: property
id: P:Autodesk.Revit.DB.Transform1D.IsValidObject
source: html/39477cd6-6dd2-e06a-8d51-60b1cb59cce3.htm
---
# Autodesk.Revit.DB.Transform1D.IsValidObject Property

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

