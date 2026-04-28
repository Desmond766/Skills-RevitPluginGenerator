---
kind: method
id: M:Autodesk.Revit.DB.Subelement.IsParameterModifiable(Autodesk.Revit.DB.ElementId)
source: html/82d6f753-6e14-3bd1-1fb2-caa284bf4686.htm
---
# Autodesk.Revit.DB.Subelement.IsParameterModifiable Method

Checks if given parameter of this subelement is modifiable.

## Syntax (C#)
```csharp
public bool IsParameterModifiable(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Parameter id.

## Returns
True if given parameter of this subelement is modifiable, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

