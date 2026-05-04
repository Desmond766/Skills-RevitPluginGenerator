---
kind: method
id: M:Autodesk.Revit.DB.BooleanOperationsUtils.ExecuteBooleanOperationModifyingOriginalSolid(Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.Solid,Autodesk.Revit.DB.BooleanOperationsType)
source: html/17966565-84c8-9dc3-dc0d-62cb6c896624.htm
---
# Autodesk.Revit.DB.BooleanOperationsUtils.ExecuteBooleanOperationModifyingOriginalSolid Method

Perform a boolean geometric operation between two solids, and modify the original solid to represent the result.

## Syntax (C#)
```csharp
public static void ExecuteBooleanOperationModifyingOriginalSolid(
	Solid solid0,
	Solid solid1,
	BooleanOperationsType booleanType
)
```

## Parameters
- **solid0** (`Autodesk.Revit.DB.Solid`) - The original solid object. This object cannot be obtained directly from a Revit element.
 This means that IsElementGeometry cannot be true.
- **solid1** (`Autodesk.Revit.DB.Solid`) - The second solid object. A copy will be taken of the input object, so any solid whether obtained from a Revit element or not would be accepted.
- **booleanType** (`Autodesk.Revit.DB.BooleanOperationsType`) - boolean operation type.

## Remarks
This operation modifies the original input Geometry objects.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the original solid object is the geometry of the Revit model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to perform the Boolean operation for the two solids. This may be due to geometric inaccuracies in the solids, such as slightly misaligned faces or edges. 
 If so, eliminating the inaccuracies by making sure the solids are accurately aligned may solve the problem. This also may be due to one or both solids having 
 complexities such as more than two faces geometrically meeting along a single edge, or two coincident edges, etc. Eliminating such conditions, or performing a 
 sequence of Boolean operations in an order that avoids such conditions, may solve the problem."

