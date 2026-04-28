---
kind: method
id: M:Autodesk.Revit.DB.Element.GetParameterFormatOptions(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/476c8179-f938-d047-db7c-776cf7e2929c.htm
---
# Autodesk.Revit.DB.Element.GetParameterFormatOptions Method

**中文**: 构件、图元、元素

Returns a FormatOptions override for the element Parameter, or a default FormatOptions if no override exists.

## Syntax (C#)
```csharp
public FormatOptions GetParameterFormatOptions(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Id of parameter for which FormatOptions will be returned.

## Returns
Format options of element parameter. If the UseDefault property is true, then no formatting overrides have been defined in the element for the specified parameter, and the FormatOptions for the parameter should be obtained from the Unit object, which can be obtained from the Document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

