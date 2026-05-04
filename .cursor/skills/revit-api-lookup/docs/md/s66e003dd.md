---
kind: property
id: P:Autodesk.Revit.DB.MultiReferenceAnnotationOptions.IsValidObject
source: html/88ed10dc-950f-79a7-a59e-18a7c95b6cbe.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotationOptions.IsValidObject Property

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

