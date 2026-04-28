---
kind: property
id: P:Autodesk.Revit.DB.AssemblyDifference.IsValidObject
source: html/ca5ba53b-c9ca-0e17-63dc-35ff8b2874d1.htm
---
# Autodesk.Revit.DB.AssemblyDifference.IsValidObject Property

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

