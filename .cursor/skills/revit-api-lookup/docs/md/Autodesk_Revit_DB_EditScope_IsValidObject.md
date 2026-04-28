---
kind: property
id: P:Autodesk.Revit.DB.EditScope.IsValidObject
source: html/2ae83145-b34a-1830-68a0-e488e216fdb0.htm
---
# Autodesk.Revit.DB.EditScope.IsValidObject Property

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

