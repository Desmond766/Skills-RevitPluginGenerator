---
kind: property
id: P:Autodesk.Revit.DB.ElementRecord.IsValidObject
source: html/12818288-f05f-72bf-639b-74f368531f1e.htm
---
# Autodesk.Revit.DB.ElementRecord.IsValidObject Property

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

