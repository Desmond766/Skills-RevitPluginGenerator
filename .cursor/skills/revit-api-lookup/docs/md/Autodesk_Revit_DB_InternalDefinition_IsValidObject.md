---
kind: property
id: P:Autodesk.Revit.DB.InternalDefinition.IsValidObject
source: html/42e7b9ae-9f6b-95fb-b890-9cdc762c445c.htm
---
# Autodesk.Revit.DB.InternalDefinition.IsValidObject Property

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

