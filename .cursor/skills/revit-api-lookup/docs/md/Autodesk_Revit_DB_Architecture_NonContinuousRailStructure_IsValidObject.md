---
kind: property
id: P:Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.IsValidObject
source: html/71cc965d-3af4-216e-bd6c-5d0b2ebdda0e.htm
---
# Autodesk.Revit.DB.Architecture.NonContinuousRailStructure.IsValidObject Property

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

