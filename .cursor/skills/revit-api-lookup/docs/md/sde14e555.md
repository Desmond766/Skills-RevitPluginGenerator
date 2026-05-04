---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerParameterManager.RemoveOverride(Autodesk.Revit.DB.ElementId)
source: html/936573d9-88a4-ed15-233b-6508a9c88a64.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerParameterManager.RemoveOverride Method

Removes an overridden value from the given parameter.

## Syntax (C#)
```csharp
public void RemoveOverride(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - The id of the parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - paramId has no override
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

