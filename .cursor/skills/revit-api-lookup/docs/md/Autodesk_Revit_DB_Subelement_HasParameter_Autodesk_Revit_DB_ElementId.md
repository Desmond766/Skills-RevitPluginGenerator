---
kind: method
id: M:Autodesk.Revit.DB.Subelement.HasParameter(Autodesk.Revit.DB.ElementId)
source: html/5725cdbe-5482-b403-f72f-936443e50e83.htm
---
# Autodesk.Revit.DB.Subelement.HasParameter Method

Checks if this subelement have given parameter.

## Syntax (C#)
```csharp
public bool HasParameter(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Parameter id.

## Returns
True if %parameterId% identifies valid parameter of this subelement, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

