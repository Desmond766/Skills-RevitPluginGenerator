---
kind: property
id: P:Autodesk.Revit.DB.FailureMessageAccessor.IsValidObject
source: html/22d4b01e-2758-3a77-cafd-73448282f2d9.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.IsValidObject Property

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

