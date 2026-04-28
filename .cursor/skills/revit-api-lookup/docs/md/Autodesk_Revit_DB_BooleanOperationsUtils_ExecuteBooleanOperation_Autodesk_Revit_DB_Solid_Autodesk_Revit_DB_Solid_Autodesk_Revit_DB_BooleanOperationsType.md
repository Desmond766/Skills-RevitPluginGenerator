---
kind: method
id: M:Autodesk.Revit.DB.BooleanOperationsUtils.ExecuteBooleanOperation(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.BooleanOperationsType)
source: html/89cb7975-cc76-65ba-b996-bcb78d12161a.htm
---
# Autodesk.Revit.DB.BooleanOperationsUtils.ExecuteBooleanOperation Method

Perform a boolean geometric operation between two solids, and return a new solid to represent the result.

## Syntax (C#)
```csharp
public static Solid ExecuteBooleanOperation(
	Solid solid0,
	Solid solid1,
	BooleanOperationsType booleanType
)
```

## Parameters
- **solid0** (`Autodesk.Revit.DB.Solid`) - The first solid object. A copy will be taken of the input object, so any solid whether obtained from a Revit element or not would be accepted.
- **solid1** (`Autodesk.Revit.DB.Solid`) - The second solid object. A copy will be taken of the input object, so any solid whether obtained from a Revit element or not would be accepted.
- **booleanType** (`Autodesk.Revit.DB.BooleanOperationsType`) - boolean operation type.

## Returns
The result geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to perform the Boolean operation for the two solids. This may be due to geometric inaccuracies in the solids, such as slightly misaligned faces or edges.
 If so, eliminating the inaccuracies by making sure the solids are accurately aligned may solve the problem. This also may be due to one or both solids having
 complexities such as more than two faces geometrically meeting along a single edge, or two coincident edges, etc. Eliminating such conditions, or performing a
 sequence of Boolean operations in an order that avoids such conditions, may solve the problem.

