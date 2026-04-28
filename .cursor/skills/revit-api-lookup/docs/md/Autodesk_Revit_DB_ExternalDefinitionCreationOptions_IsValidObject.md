---
kind: property
id: P:Autodesk.Revit.DB.ExternalDefinitionCreationOptions.IsValidObject
source: html/6ae1426b-0034-4ad7-e380-b33493c5ca19.htm
---
# Autodesk.Revit.DB.ExternalDefinitionCreationOptions.IsValidObject Property

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

