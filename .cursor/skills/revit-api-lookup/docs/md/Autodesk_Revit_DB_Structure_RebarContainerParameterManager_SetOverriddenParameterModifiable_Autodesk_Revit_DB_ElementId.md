---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.SetOverriddenParameterModifiable(Autodesk.Revit.DB.ElementId)
source: html/0b91fcec-09b4-8e89-01cf-24272512395f.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.SetOverriddenParameterModifiable Method

Sets this overridden parameter to be modifiable.

## Syntax (C#)
```csharp
public void SetOverriddenParameterModifiable(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Overridden parameter id

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

