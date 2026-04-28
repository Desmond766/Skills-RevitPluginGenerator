---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.IsValidObject
source: html/36baabe9-05a3-0c48-d020-b3b21f20d177.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsValidObject Property

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

