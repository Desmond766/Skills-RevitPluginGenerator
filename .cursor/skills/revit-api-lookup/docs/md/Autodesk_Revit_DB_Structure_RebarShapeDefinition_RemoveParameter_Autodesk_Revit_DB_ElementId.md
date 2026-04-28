---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDefinition.RemoveParameter(Autodesk.Revit.DB.ElementId)
source: html/78f59d6a-8d6b-cdd9-f045-535e64c007bc.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDefinition.RemoveParameter Method

Remove the parameter from the definition.

## Syntax (C#)
```csharp
public void RemoveParameter(
	ElementId paramId
)
```

## Parameters
- **paramId** (`Autodesk.Revit.DB.ElementId`) - Id of a parameter in the definition.

## Remarks
If the definition does not have the parameter, the method does nothing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

