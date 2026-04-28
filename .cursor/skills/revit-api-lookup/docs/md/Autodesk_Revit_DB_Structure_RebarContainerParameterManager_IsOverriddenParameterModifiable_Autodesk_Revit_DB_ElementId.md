---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.IsOverriddenParameterModifiable(Autodesk.Revit.DB.ElementId)
source: html/7d3b99fe-2028-3309-52cd-a3c8d4319d08.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.IsOverriddenParameterModifiable Method

Checks if overridden parameter is modifiable.

## Syntax (C#)
```csharp
public bool IsOverriddenParameterModifiable(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Overridden parameter id

## Returns
True if the parameter is modifiable, false if the parameter is readonly.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

