---
kind: method
id: M:Autodesk.Revit.DB.Element.IsPhaseCreatedValid(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/ae48b10d-4a66-ee2c-85bf-f426435d0dbe.htm
---
# Autodesk.Revit.DB.Element.IsPhaseCreatedValid Method

**中文**: 构件、图元、元素

Returns true if createdPhaseId is an allowed value for the property CreatedPhaseId in this Element.

## Syntax (C#)
```csharp
public bool IsPhaseCreatedValid(
	ElementId createdPhaseId
)
```

## Parameters
- **createdPhaseId** (`Autodesk.Revit.DB.ElementId`) - The id of a Phase.

## Returns
True if createdPhaseId is an allowed value for the property CreatedPhaseId in this Element, false otherwise.

## Remarks
Acts as a validator for setting the property CreatedPhaseId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

