---
kind: method
id: M:Autodesk.Revit.DB.ParameterUtils.IsBuiltInParameter(Autodesk.Revit.DB.ElementId)
source: html/7df6bd75-52ac-3657-aef1-6d594809c6f9.htm
---
# Autodesk.Revit.DB.ParameterUtils.IsBuiltInParameter Method

Checks whether an ElementId identifies a built-in parameter.

## Syntax (C#)
```csharp
public static bool IsBuiltInParameter(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The identifier to check.

## Returns
True if the ElementId identifies a built-in parameter, false otherwise.

## Remarks
An ElementId identifies a built-in parameter if it corresponds to a valid BuiltInParameter value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

