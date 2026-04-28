---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.IsValidThickness(System.Double)
source: html/0cff920e-0586-8030-5096-465a28ea1012.htm
---
# Autodesk.Revit.ApplicationServices.Application.IsValidThickness Method

Checks if the input value is valid to be supplied as a thickness (for an extrusion, or blend, or wall layer, or similar geometric construct).

## Syntax (C#)
```csharp
public static bool IsValidThickness(
	double thickness
)
```

## Parameters
- **thickness** (`System.Double`) - The input value.

## Returns
True if the input value is valid for thickness; false otherwise.

## Remarks
This checks two conditions:
 The value is greater than or equal to the minimum thickness allowed in Revit for these types of geometric constructs. The value is less than or equal to the maximum length/distance allowed by Revit for elements.

