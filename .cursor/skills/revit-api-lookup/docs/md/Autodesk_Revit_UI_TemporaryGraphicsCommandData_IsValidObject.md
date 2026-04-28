---
kind: property
id: P:Autodesk.Revit.UI.TemporaryGraphicsCommandData.IsValidObject
source: html/b4b1d09f-761d-3c6c-de36-48d5b26330f6.htm
---
# Autodesk.Revit.UI.TemporaryGraphicsCommandData.IsValidObject Property

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

