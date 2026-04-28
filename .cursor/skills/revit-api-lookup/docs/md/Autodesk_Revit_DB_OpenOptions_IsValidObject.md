---
kind: property
id: P:Autodesk.Revit.DB.OpenOptions.IsValidObject
source: html/c6876c22-4ac6-c92e-a6c1-3627a7fa6d16.htm
---
# Autodesk.Revit.DB.OpenOptions.IsValidObject Property

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

