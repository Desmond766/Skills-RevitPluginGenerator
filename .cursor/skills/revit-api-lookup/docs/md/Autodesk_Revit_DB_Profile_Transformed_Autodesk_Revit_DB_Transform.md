---
kind: property
id: P:Autodesk.Revit.DB.Profile.Transformed(Autodesk.Revit.DB.Transform)
source: html/481d3bae-2853-b1ab-9827-d16d3eaae46c.htm
---
# Autodesk.Revit.DB.Profile.Transformed Property

Transforms this profile and returns the result.

## Syntax (C#)
```csharp
public Profile this[
	Transform transform
] { get; }
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation used to transform the profile.

## Returns
The transformed profile.

## Remarks
Transforms all the curves that define the boundary of this profile.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the handle of the specified transformation is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when failed to transform a curve in the profile.

