---
kind: property
id: P:Autodesk.Revit.DB.ExternalFileReference.IsValidObject
source: html/c64f3bd5-ab3e-092f-c4e3-634f085a62d6.htm
---
# Autodesk.Revit.DB.ExternalFileReference.IsValidObject Property

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

