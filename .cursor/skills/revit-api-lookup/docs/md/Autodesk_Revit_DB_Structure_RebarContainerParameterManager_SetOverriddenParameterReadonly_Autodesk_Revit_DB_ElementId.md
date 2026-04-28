---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.SetOverriddenParameterReadonly(Autodesk.Revit.DB.ElementId)
source: html/13dfe73c-aa3c-767d-c939-45feab28cd21.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.SetOverriddenParameterReadonly Method

Sets this overridden parameter to be readonly.

## Syntax (C#)
```csharp
public void SetOverriddenParameterReadonly(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Overridden parameter id

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

