---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.Split(System.Double)
zh: 拆分、打断、分割
source: html/cf3996cd-4987-b101-0806-bfa7b983a4c3.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.Split Method

**中文**: 拆分、打断、分割

Splits the analytical member at a point on its defining curve.

## Syntax (C#)
```csharp
public ElementId Split(
	double parameter
)
```

## Parameters
- **parameter** (`System.Double`) - The normalized parameter value along the element (should be greater than 0 and less than 1).

## Returns
The newly created analytical member id.

## Remarks
Analytical members that are not a line or an arc are not permitted.
 See CanSplit () () () to determine if the analytical member is allowed to be split by this method.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Analytical member cannot be split.

