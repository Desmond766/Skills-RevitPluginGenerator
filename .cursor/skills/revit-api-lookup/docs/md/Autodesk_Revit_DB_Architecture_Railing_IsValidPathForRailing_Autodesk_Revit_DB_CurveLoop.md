---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.IsValidPathForRailing(Autodesk.Revit.DB.CurveLoop)
zh: 栏杆
source: html/3f368fef-e0ac-1430-d409-1fa5136d1b8f.htm
---
# Autodesk.Revit.DB.Architecture.Railing.IsValidPathForRailing Method

**中文**: 栏杆

Checks whether a railing can be created along a railing path.

## Syntax (C#)
```csharp
public static bool IsValidPathForRailing(
	CurveLoop curveLoop
)
```

## Parameters
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The railing path along which the new railing will be created.

## Returns
True if the new railing path can be used in a railing definition, False otherwise.

## Remarks
The railing path should be located on the same horizontal plane and it should contain lines or arcs only.
 It also has to be continuous and its three or more curves cannot meet in one end point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

