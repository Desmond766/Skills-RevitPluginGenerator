---
kind: method
id: M:Autodesk.Revit.DB.Element.GetPhaseStatus(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/eedf5981-b5e2-dda7-cb5e-01a4d4fc7f6c.htm
---
# Autodesk.Revit.DB.Element.GetPhaseStatus Method

**中文**: 构件、图元、元素

Gets the status of a given element in the input phase

## Syntax (C#)
```csharp
public ElementOnPhaseStatus GetPhaseStatus(
	ElementId phaseId
)
```

## Parameters
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - Id of the phase.

## Returns
The status of the element in the phase.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id does not represent a valid phase.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

