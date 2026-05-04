---
kind: property
id: P:Autodesk.Revit.DB.CADLinkOptions.IsValidObject
source: html/14518fe8-0dd7-afc1-0d22-ef9d0dfb5264.htm
---
# Autodesk.Revit.DB.CADLinkOptions.IsValidObject Property

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

