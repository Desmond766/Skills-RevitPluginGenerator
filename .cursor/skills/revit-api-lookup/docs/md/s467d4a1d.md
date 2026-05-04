---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidObject
source: html/8d20fe9a-18e2-15d6-57be-a969d8b011f5.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailInfo.IsValidObject Property

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

