---
kind: property
id: P:Autodesk.Revit.DB.FabricationRodInfo.IsValidObject
source: html/3f44845c-9603-0c28-99d4-e247e6622361.htm
---
# Autodesk.Revit.DB.FabricationRodInfo.IsValidObject Property

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

