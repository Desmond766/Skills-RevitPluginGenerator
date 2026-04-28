---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeParameters.IsValidExternalDefinition(Autodesk.Revit.DB.ExternalDefinition)
source: html/756b82f4-450c-9c43-34d3-818b9c648df4.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeParameters.IsValidExternalDefinition Method

Checks that an ExternalDefinition (shared parameter) may be used as a Rebar Shape parameter.

## Syntax (C#)
```csharp
public static bool IsValidExternalDefinition(
	ExternalDefinition param
)
```

## Parameters
- **param** (`Autodesk.Revit.DB.ExternalDefinition`) - Definition of a shared parameter.

## Returns
True if the definition is of type Length, false otherwise.

## Remarks
A Rebar Shape parameter must be an ExternalDefinition with a ParameterType of Length.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was Nothing nullptr a null reference ( Nothing in Visual Basic)

