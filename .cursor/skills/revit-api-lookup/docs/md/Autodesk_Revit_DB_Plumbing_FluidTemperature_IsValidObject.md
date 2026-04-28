---
kind: property
id: P:Autodesk.Revit.DB.Plumbing.FluidTemperature.IsValidObject
source: html/1909ea5a-de47-3b6f-4565-e24e07c48d20.htm
---
# Autodesk.Revit.DB.Plumbing.FluidTemperature.IsValidObject Property

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

