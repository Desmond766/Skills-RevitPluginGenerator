---
kind: property
id: P:Autodesk.Revit.DB.ProjectPosition.IsValidObject
source: html/bf695610-3ceb-da3c-5ab9-df4ebd57b194.htm
---
# Autodesk.Revit.DB.ProjectPosition.IsValidObject Property

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

