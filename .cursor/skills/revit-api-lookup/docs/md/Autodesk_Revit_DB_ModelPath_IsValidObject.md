---
kind: property
id: P:Autodesk.Revit.DB.ModelPath.IsValidObject
source: html/eddecc61-5a2b-d53c-1ec5-b9596cd05d07.htm
---
# Autodesk.Revit.DB.ModelPath.IsValidObject Property

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

